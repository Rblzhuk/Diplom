using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class InputLayer
    {
        private const double _max_output = 255;
        public double[] outputs;
        public InputLayer(int[,] dataMatrix, int dataMatrixLength_0, int dataMatrixLength_1)
        {
            outputs = new double[dataMatrixLength_0 * dataMatrixLength_1];
            for (int i = 0; i < dataMatrixLength_0; i++)
            {
                for (int j = 0; j < dataMatrixLength_1; j++)
                {
                    outputs[i * dataMatrixLength_0 + j] = dataMatrix[i, j] / _max_output;
                }
            }
        }
    }
}
