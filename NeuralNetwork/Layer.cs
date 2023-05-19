using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace NeuralNetwork
{
    abstract class Layer
    {
        Random random;

        private double[,] _weights;

        public double[,] Weights { get => _weights; set { _weights = value; } }

        protected double learningRate = 0.01d;//скорость обучения
        protected const double lambda = 0.1;//регуляризация (L2)
        protected const double beta = 0.9;//скорость обновления весов

        protected int curNeurons;
        protected int prevNeurons;
        protected Layer(int curNeurons, int prevNeurons, Network.NeuronType neuronType, string type)
        {
            random = new Random();
            this.curNeurons = curNeurons;
            this.prevNeurons = prevNeurons;

            _neurons = new Neuron[curNeurons];
            Neurons = Neurons;

            _weights = WeightInitialize(Network.MemoryMode.GET, type);
            //Инициировать нейроны с массивами весов
            for (int i = 0; i < curNeurons; i++)
            {
                //Массив весов для каждого нейрона
                double[] oneNeuronWeights = new double[prevNeurons];
                //Наполнение этого массива из массива всех весов слоя
                for (int j = 0; j < prevNeurons; j++)
                {
                    oneNeuronWeights[j] = _weights[i, j];
                }
                Neurons[i] = new Neuron(null, oneNeuronWeights, neuronType);
            }
        }


        Neuron[] _neurons;
        public Neuron[] Neurons { get => _neurons; set => _neurons = value; }
        public double[] Data
        {
            set
            {
                for (int i = 0; i < Neurons.Length; ++i)
                {
                    Neurons[i].Inputs = value;
                }
            }
        }

        public double[,] WeightInitialize(Network.MemoryMode mode, string layerType)
        {
            double[,] _weights = new double[curNeurons, prevNeurons];
            XmlDocument weights_doc = new XmlDocument();
            XmlElement weights_root;
            if (File.Exists($"{Path.Combine(Environment.CurrentDirectory, "Weights", layerType)}.xml"))
            {
                weights_doc.Load($"{Path.Combine(Environment.CurrentDirectory, "Weights", layerType)}.xml");
                weights_root = weights_doc.DocumentElement;
            }
            else
            {
                weights_root = weights_doc.CreateElement("Weights");
                weights_doc.AppendChild(weights_root);
            }
            Random random = new Random();
            int weightsElementCount = weights_root.ChildNodes.Count;

            if (weights_root.ChildNodes.Count < curNeurons * prevNeurons)
            {
                for (int i = 0; i < (curNeurons * prevNeurons) - weightsElementCount; i++)
                {
                    XmlElement weight = weights_doc.CreateElement("weight");

                    weight.InnerText = (random.Next(-99999, 99999) * 0.0001).ToString();
                    weights_root.AppendChild(weight);
                }
                MessageBox.Show($"Количество весов в файле и в параметрах {layerType} слоя не совпадают\n" +
                    $"Количество весов в файле: {weightsElementCount}, количество весов в параметрах слоя: {curNeurons * prevNeurons}\n" +
                    $"Текущих: {curNeurons}, предыдущих: {prevNeurons}");
                weights_doc.Save($"{Path.Combine(Environment.CurrentDirectory, "Weights", layerType)}.xml");
            }

            switch (mode)
            {
                case Network.MemoryMode.GET:

                    for (int i = 0; i < _weights.GetLength(0); i++)
                    {
                        for (int j = 0; j < _weights.GetLength(1); j++)
                        {
                            _weights[i, j] = double.Parse(weights_root.ChildNodes.Item(_weights.GetLength(1) * i + j).InnerText.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
                        }
                    }

                    break;
                case Network.MemoryMode.SET:
                    //Переписать значение веса для каждого нейрона в слое (layerType)
                    for (int i = 0; i < _neurons.Length; i++)
                    {
                        for (int j = 0; j < _weights.GetLength(1); j++)
                        {
                            weights_root.ChildNodes.Item(_weights.GetLength(1) * i + j).InnerText = _neurons[i].Weights[j].ToString();
                        }
                    }
                    weights_doc.Save($"{Path.Combine(Environment.CurrentDirectory, "Weights", layerType)}.xml");
                    break;
            }
            return _weights;
        }
        //для прямых проходов
        public abstract void StraightPass(Network net, Layer nextLayer);
        //для обучения - обратное прохождение
        public double[] MiniBatchBackwardPass(double[] errors)
        {
            double[] error_sum = new double[prevNeurons];
            double[] update_speed = new double[prevNeurons];
            double gradient = 0;
            double range = Math.Sqrt(1d / prevNeurons);

            for (int j = 0; j < prevNeurons; j++)
            {
                error_sum[j] = 0;
                update_speed[j] = beta;
            }

            for (int i = 0; i < curNeurons; i++)
            {
                for (int j = 0; j < prevNeurons; j++)
                {
                    gradient = GetGradient(errors[i], GetDerivative(Neurons[i].Output));
                    gradient += lambda * Neurons[i].Weights[j];

                    update_speed[j] = beta * update_speed[j] - learningRate * gradient; // вычисляем новую скорость
                    error_sum[j] += Neurons[i].Weights[j] * update_speed[j];
                    Neurons[i].Weights[j] -= update_speed[j] * Neurons[i].Inputs[j];

                    //error_sum[j] += Neurons[i].Weights[j] * gradient;
                    //Neurons[i].Weights[j] -= gradient * learningRate * Neurons[i].Inputs[j];

                    if (double.IsNaN(Neurons[i].Weights[j]) || double.IsInfinity(Neurons[i].Weights[j]))
                    {
                        Neurons[i].Weights[j] = random.NextDouble() * range * 2 - range;
                    }
                }
            }
            return error_sum;
        }

        //Производная от функции RELU
        public double GetDerivative(double output)
        {
            return /*(output > 0 ? 1 : output* 0.01);*/output * (1 - output);
        }
        public double GetGradient(double error, double derivative)
        {
            return error * derivative;
        }
    }
}
