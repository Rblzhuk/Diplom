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
    }
}
