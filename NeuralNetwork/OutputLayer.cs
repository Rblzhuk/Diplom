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
            //net.RESULTS = GetAnswersToPercents(net.RESULTS);
        }

        private double[] GetAnswersToPercents(double[] input)
        {
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

            return input;
        }
    }
}
