using System;
using static System.Math;

namespace NeuralNetwork
{
    public class Neuron
    {
        public Neuron(double[] inputs, double[] weights, Network.NeuronType type)
        {
            Weights = weights;
            Inputs = inputs;
            _type = type;
        }
        private Network.NeuronType _type;
        private double[] _weights;
        private double[] _inputs;

        private double _output;

        public double[] Weights { get => _weights; set => _weights = value; }

        public double Output
        {
            get { return _output; }
            set
            {
                _output = Activator(_inputs, _weights);
            }
        }
        public double[] Inputs { get => _inputs; set => _inputs = value; }

        //inputs - массив значений выходов нейронов предыдущего слоя; weights - массив значений весов, которые связывают текущий нейрон с предыдущим слоем
        private double Activator(double[] inputs, double[] weights)
        {
            double sum = 0;

            for (int i = 0; i < inputs.Length; ++i)
            {
                sum += inputs[i] * weights[i];
            }
            if (double.IsNaN(sum) || double.IsInfinity(sum))
            {
                sum = double.Epsilon;
            }

            sum = Max(sum, sum * 0.01);

            //sum++;

            //while (sum > 10 || sum < -10)
            //{
            //    sum *= 0.1;
            //}

            //if (sum > 5)
            //{
            //    sum /= Math.Pow(10, Math.Floor(Math.Log10(sum)));
            //}
            //else if (sum < -5)
            //{
            //    sum /= Math.Pow(10, Math.Floor(Math.Log10(-sum)));
            //}
            //sum = 1 / (1 + Math.Exp(-sum));

            return sum;
        }
    }
}
