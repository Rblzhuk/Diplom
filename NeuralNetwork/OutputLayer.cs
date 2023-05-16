using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNetwork
{
    class OutputLayer : Layer
    {
        public OutputLayer(int curNeurons, int prevNeurons, Network.NeuronType neuronType, string type) : base(curNeurons, prevNeurons, neuronType, type) { }
        public override void StraightPass(Network net, Layer nextLayer)
        {
            for (int i = 0; i < Neurons.Length; i++)
            {
                Neurons[i].Output = Neurons[i].Output;
                net.RESULTS[i] = Neurons[i].Output;
            }
            net.RESULTS = GetAnswersToPercents(net.RESULTS);
        }
        //public override double[] MiniBatchBackwardPass(double[] errors)
        //{
        //    double[] error_sum = new double[prevNeurons];
        //    double gradient = 0;

        //    for (int j = 0; j < prevNeurons; j++)
        //    {
        //        error_sum[j] = 0;
        //    }

        //    for (int i = 0; i < curNeurons; i++)
        //    {
        //        for (int j = 0; j < prevNeurons; j++)
        //        {
        //            gradient = GetGradient(errors[i], GetDerivative(Neurons[i].Output));
        //            gradient += lambda * Neurons[i].Weights[j];
        //            error_sum[j] += Neurons[i].Weights[j] * errors[i];
        //            Neurons[i].Weights[j] -= gradient * learningRate * Neurons[i].Output;
        //        }
        //    }
        //    return error_sum;
        //}

        private double[] GetAnswersToPercents(double[] input)
        {
            //double sum = 0;
            //for (int i = 0; i < input.Length; i++)
            //{
            //    input[i] = Math.Log(input[i]);
            //    sum += input[i];
            //}
            //for (int i = 0; i < input.Length; i++)
            //{
            //    input[i] -= sum;
            //}
            //input = ScaleInput(input);

            //double[] result = new double[input.Length];
            //double max = input.Max();
            //double sum = 0;
            //for (int i = 0; i < input.Length; i++)
            //{
            //    double temp = input[i] - max;
            //    result[i] = temp;
            //    sum += temp;
            //}
            //for (int i = 0; i < input.Length; i++)
            //{
            //    result[i] /= sum;
            //}
            //return result;

            double sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] > 10)
                {
                    input[i] /= Math.Pow(10, Math.Floor(Math.Log10(input[i])));
                }
                else if (sum < -10)
                {
                    input[i] /= Math.Pow(10, Math.Floor(Math.Log10(-input[i])));
                }
                sum += Math.Exp(input[i]);
            }
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = Math.Exp(input[i]) / sum;
                if (double.IsNaN(input[i]) || double.IsInfinity(input[i]))
                {
                    input[i] = double.Epsilon;
                }
            }

            //double sum = 0;
            //for (int i = 0; i < input.Length; i++)
            //{
            //    sum += input[i];
            //}
            //for (int i = 0; i < input.Length; i++)
            //{
            //    input[i] /= sum;
            //}

            return input;
        }
    }
}
