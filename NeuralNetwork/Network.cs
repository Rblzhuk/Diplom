using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using DrawDigits;

namespace NeuralNetwork
{
    public class Network
    {
        InputLayer inputLayer;
        HiddenLayer[] _HIDDEN_LAYERS;
        OutputLayer outputLayer;
        Random random = new Random();
        DrawSymbolsClass drawSymbols = null;

        public string WeightsFolder = Path.Combine(Environment.CurrentDirectory, "Weights");
        //private string _train_letters_digits_Set_Path = Path.Combine(Environment.CurrentDirectory, "DataSets", "emnist-digits-train.csv");
        private string _train_letters_digits_Set_Path = Path.Combine(Environment.CurrentDirectory, "DataSets", "emnist-byclass-train.csv");

        private const int _greateTrainfileSize = 697933;

        public enum MemoryMode { GET, SET }
        public enum NeuronType { Hidden, Output }

        public double[] RESULTS;
        private string[] _TRAIN_SET = null;

        public Network(int inpNeurons, int hiddenLayersCount, int[] hidNeurons, int outNeurons)
        {
            RESULTS = new double[outNeurons];
            _TRAIN_SET = new string[_greateTrainfileSize];
            _HIDDEN_LAYERS = new HiddenLayer[hiddenLayersCount];
            for (int i = 0; i < _HIDDEN_LAYERS.Length; i++)
            {
                _HIDDEN_LAYERS[i] = new HiddenLayer(hidNeurons[i], (i > 0 ? hidNeurons[i - 1] : inpNeurons), Network.NeuronType.Hidden, $"HiddenLayer{i + 1}");
            }
            outputLayer = new OutputLayer(outNeurons, hidNeurons[hidNeurons.Length - 1], Network.NeuronType.Output, "OutputLayer");
        }

        public void HandleOneDigit(Network net, int[,] DATA_MATRIX)
        {
            inputLayer = new InputLayer(DATA_MATRIX, DATA_MATRIX.GetLength(0), DATA_MATRIX.GetLength(1));
            //Данные для скрытого слоя загружаются тут, а не во входном слое, из-за несогласованности доступа классов этих слоёв

            if (_HIDDEN_LAYERS.Length > 0)
            {
                _HIDDEN_LAYERS[0].Data = inputLayer.outputs;
                for (int i = 0; i < _HIDDEN_LAYERS.Length - 1; i++)
                {
                    _HIDDEN_LAYERS[i].StraightPass(null, _HIDDEN_LAYERS[i + 1]);
                }
                _HIDDEN_LAYERS[_HIDDEN_LAYERS.Length - 1].StraightPass(null, outputLayer);
            }

            outputLayer.StraightPass(net, null);
        }

        public void Train(Network network, DrawSymbolsClass draw, string[] ANSWER_SET)
        {
            DownLoadTrainFile();

            drawSymbols = draw;

            int i = 0;

            double lossFunction = 0;

            int batchSize = 512;
            int miniBatchSize = 32;
            int miniBatchCount = batchSize / miniBatchSize;
            double[] mini_batch_errors = new double[ANSWER_SET.Length];
            double[] epoch_errors = new double[ANSWER_SET.Length];
            int[] mark_right_answers = new int[ANSWER_SET.Length];

            double[] prev_layer_errors;

            int randomTrainSymbolIndex;

            int epochCount = 50;
            const double lossThreshold = 0.01d;
            do
            {
                for (int e = 0; e < epoch_errors.Length; e++)
                {
                    epoch_errors[e] = 0;
                }
                //Прохождение мини-батчей
                for (int c = 0; c < miniBatchCount; c++)
                {
                    for (int e = 0; e < mini_batch_errors.Length; e++)
                    {
                        mini_batch_errors[e] = 0;
                    }
                    for (int m = 0; m < miniBatchSize; m++)
                    {
                        randomTrainSymbolIndex = DownloadTrainSymbol(ANSWER_SET.Length);

                        HandleOneDigit(network, drawSymbols.DATA_MATRIX);
                        for (int e = 0; e < RESULTS.Length; e++)
                        {
                            mark_right_answers[e] = (e == randomTrainSymbolIndex ? 1 : 0);
                            mini_batch_errors[e] += -mark_right_answers[e] * Math.Log(RESULTS[e]) - (1 - mark_right_answers[e]) * Math.Log(1 - RESULTS[e]);
                            //mini_batch_errors[e] += Math.Pow(mark_right_answers[e]- RESULTS[e],2);
                            //mini_batch_errors[e] += RESULTS[e] - mark_right_answers[e];
                            if (double.IsNaN(mini_batch_errors[e]) || double.IsInfinity(mini_batch_errors[e]))
                            {
                                mini_batch_errors[e] = double.Epsilon;
                            }
                        }
                    }
                    for (int e = 0; e < mini_batch_errors.Length; e++)
                    {
                        mini_batch_errors[e] /= miniBatchSize;
                        //mini_batch_errors[e] *= 1 / miniBatchSize;
                        epoch_errors[e] += mini_batch_errors[e];
                    }
                    prev_layer_errors = outputLayer.MiniBatchBackwardPass(mini_batch_errors);
                    for (int h = _HIDDEN_LAYERS.Length - 1; h >= 0; h--)
                    {
                        prev_layer_errors = _HIDDEN_LAYERS[h].MiniBatchBackwardPass(prev_layer_errors);
                    }
                }
                lossFunction = 0;
                for (int e = 0; e < epoch_errors.Length; e++)
                {
                    epoch_errors[e] /= miniBatchCount;
                    lossFunction += epoch_errors[e];
                }
                lossFunction /= epoch_errors.Length;
                //prev_layer_errors = outputLayer.MiniBatchBackwardPass(epoch_errors);
                //for (int h = _HIDDEN_LAYERS.Length - 1; h >= 0; h--)
                //{
                //    prev_layer_errors = _HIDDEN_LAYERS[h].MiniBatchBackwardPass(prev_layer_errors);
                //}

                i++;
            } while (i < epochCount);
            for (int h = 0; h < _HIDDEN_LAYERS.Length; h++)
            {
                _HIDDEN_LAYERS[h].WeightInitialize(MemoryMode.SET, $"HiddenLayer{h + 1}");
            }
            outputLayer.WeightInitialize(MemoryMode.SET, "OutputLayer");
            //MessageBox.Show($"Пройдёно эпох {i}, погрешность {lossFunction}");
        }

        public int DownloadTrainSymbol(int answerSetLength)
        {
            random = new Random();
            int randomRow;
            int searchingIndex;
            string[] symbol = null;
            string buf;
            do
            {
                searchingIndex = random.Next(_TRAIN_SET.Length);
                symbol = _TRAIN_SET[searchingIndex].Split(',');
            } while (int.Parse(symbol[0]) >= answerSetLength);
            drawSymbols.DownloadSymbolToMatrix(symbol);

            randomRow = random.Next(_TRAIN_SET.Length);

            buf = _TRAIN_SET[searchingIndex];
            _TRAIN_SET[searchingIndex] = _TRAIN_SET[randomRow];
            _TRAIN_SET[randomRow] = buf;

            return int.Parse(symbol[0]);
        }

        private void DownLoadTrainFile()
        {
            int usingFileSize;
            int i = 0;
            string row;
            using (StreamReader streamReader = new StreamReader(_train_letters_digits_Set_Path))
            {
                while ((row = streamReader.ReadLine()) != null)
                {
                    _TRAIN_SET[i] = row;
                    i++;
                }
                streamReader.Close();
            }
        }

        public void ResetWeights()
        {
            DialogResult dialog = MessageBox.Show("Вы действительно хотите удалить все веса нейросети?", "Внимание!", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                for (int i = 0; i < _HIDDEN_LAYERS.Length; i++)
                {
                    ResetWeights($"HiddenLayer{i + 1}");
                }
                ResetWeights("OutputLayer");
                MessageBox.Show("Для всех весов заданы случайные значения");
            }
        }

        private void ResetWeights(string layerType)
        {
            XmlDocument weights_doc = new XmlDocument();
            weights_doc.Load($"{Path.Combine(WeightsFolder, layerType)}.xml");
            XmlElement weights_root = weights_doc.DocumentElement;
            weights_root.RemoveAll();
            weights_doc.Save($"{Path.Combine(WeightsFolder, layerType)}.xml");
        }
    }
}
