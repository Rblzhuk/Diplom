using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class HiddenLayer : Layer
    {
        public HiddenLayer(int curNeurons, int prevNeurons, Network.NeuronType neuronType, string type) : base(curNeurons, prevNeurons, neuronType, type) { }
        public override void StraightPass(Network net, Layer nextLayer)
        {
            double[] hiddenOut = new double[Neurons.Length];
            for (int i = 0; i < hiddenOut.Length; i++)
            {
                Neurons[i].Output = Neurons[i].Output;
                hiddenOut[i] = Neurons[i].Output;
            }
            nextLayer.Data = hiddenOut;
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
        //        gradient = GetGradient(errors[i], GetDerivative(Neurons[i].Output));
        //        for (int j = 0; j < prevNeurons; j++)
        //        {
        //            gradient += lambda * Neurons[i].Weights[j];
        //            error_sum[j] += Neurons[i].Weights[j] * Neurons[i].Inputs[j];
        //            Neurons[i].Weights[j] -= gradient * learningRate * Neurons[i].Output;
        //        }
        //    }
        //    return error_sum;
        //}
    }
}
