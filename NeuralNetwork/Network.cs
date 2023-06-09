using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using DrawSymbols;
using NeuralNetworkConstructor;

namespace NeuralNetwork
{
    public class Network
    {
        InputLayer inputLayer;
        HiddenLayer[] _HIDDEN_LAYERS;
        OutputLayer outputLayer;
        Random random;
        DrawSymbolsClass drawSymbols = null;

        private string trainSymbolsPath = NetworkParameters.trainSymbolsPath;
        private string testSymbolsPath = NetworkParameters.testSymbolsPath;

        public enum MemoryMode { GET, SET }
        public enum NeuronType { Hidden, Output }

        private string[] _TRAIN_SET;
        private string[] _TEST_SET;

        private double[] _ACCURACY;

        public double[] RESULTS { get; private set; }

        private double[] _LOSS_TO_EPOCH;

        private int[] _answersCount;
        private int[] _rightAnswersCount;
        private double _lossToEpoch;

        public int trueIndex { get; private set; }
        public int predictIndex { get; private set; }

        public Network(int inpNeurons, int[] hidNeurons, int outNeurons, DrawSymbolsClass draw)
        {
            _ACCURACY = new double[outNeurons];
            _answersCount = new int[outNeurons];
            _rightAnswersCount = new int[outNeurons];

            trueIndex = -1;
            predictIndex = -1;

            RESULTS = new double[outNeurons];
            _TRAIN_SET = new string[NetworkParameters.trainFileSize];
            _TEST_SET = new string[NetworkParameters.testFileSize];

            drawSymbols = draw;

            DownLoadSymbolsFile(_TEST_SET, NetworkParameters.testSymbolsPath);
            DownloadAccurasy(MemoryMode.GET);
            DownloadAverageLoss(MemoryMode.GET);

            random = new Random();
            _HIDDEN_LAYERS = new HiddenLayer[hidNeurons.Length];

            if (_HIDDEN_LAYERS.Length > 0)
            {
                for (int i = 0; i < _HIDDEN_LAYERS.Length; i++)
                {
                    _HIDDEN_LAYERS[i] = new HiddenLayer(hidNeurons[i], (i > 0 ? hidNeurons[i - 1] : inpNeurons), Network.NeuronType.Hidden, $"HiddenLayer{i + 1}");
                }
                outputLayer = new OutputLayer(outNeurons, hidNeurons[hidNeurons.Length - 1], Network.NeuronType.Output, "OutputLayer");
            }
            else
            {
                outputLayer = new OutputLayer(outNeurons, inpNeurons, Network.NeuronType.Output, "OutputLayer");
            }
        }

        public void StraightForward(int[,] DATA_MATRIX)
        {
            //Данные для скрытого слоя загружаются тут, а не во входном слое, из-за несогласованности доступа классов этих слоёв
            inputLayer = new InputLayer(DATA_MATRIX, DATA_MATRIX.GetLength(0), DATA_MATRIX.GetLength(1));

            if (_HIDDEN_LAYERS.Length > 0)
            {
                _HIDDEN_LAYERS[0].Data = inputLayer.outputs;
                for (int i = 0; i < _HIDDEN_LAYERS.Length - 1; i++)
                {
                    _HIDDEN_LAYERS[i].StraightPass(null, _HIDDEN_LAYERS[i + 1]);
                }
                _HIDDEN_LAYERS[_HIDDEN_LAYERS.Length - 1].StraightPass(null, outputLayer);
            }
            else
            {
                outputLayer.Data = inputLayer.outputs;
            }

            outputLayer.StraightPass(this, null);

            predictIndex = Array.IndexOf(RESULTS, RESULTS.Max());
        }

        public void Train(Network network)
        {
            ResetAccuracy();
            DownLoadSymbolsFile(_TRAIN_SET, trainSymbolsPath);

            int i = 0;
            int miniBatchSize = NetworkParameters.minibatchSize;
            int miniBatchCount = NetworkParameters.minibatchCount;
            int epochCount = NetworkParameters.epochCount;

            double[] mini_batch_errors = new double[RESULTS.Length];

            int[] mark_right_answers = new int[RESULTS.Length];

            double[] prev_layer_errors;
            do
            {
                _lossToEpoch = 0;
                //Прохождение мини-батчей
                for (int c = 0; c < miniBatchCount; c++)
                {
                    for (int e = 0; e < mini_batch_errors.Length; e++)
                    {
                        mini_batch_errors[e] = 0;
                    }
                    for (int m = 0; m < miniBatchSize; m++)
                    {
                        HandleRandomSymbolFromSet(_TRAIN_SET, RESULTS.Length);

                        for (int e = 0; e < RESULTS.Length; e++)
                        {
                            mark_right_answers[e] = (e == trueIndex ? 1 : 0);
                            mini_batch_errors[e] += -mark_right_answers[e] * Math.Log(RESULTS[e]) - (1 - mark_right_answers[e]) * Math.Log(1 - RESULTS[e]);
                            //mini_batch_errors[e] += Math.Pow(mark_right_answers[e] - RESULTS[e], 2);
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
                        _lossToEpoch += mini_batch_errors[e];
                    }
                    prev_layer_errors = outputLayer.MiniBatchBackwardPass(mini_batch_errors);
                    for (int h = _HIDDEN_LAYERS.Length - 1; h >= 0; h--)
                    {
                        prev_layer_errors = _HIDDEN_LAYERS[h].MiniBatchBackwardPass(prev_layer_errors);
                    }
                }
                _lossToEpoch /= mini_batch_errors.Length;
                _lossToEpoch /= miniBatchCount;
                DownloadAverageLoss(MemoryMode.SET);
                i++;
            } while (_lossToEpoch > NetworkParameters.lossThreshold && i < epochCount);
            for (int h = 0; h < _HIDDEN_LAYERS.Length; h++)
            {
                _HIDDEN_LAYERS[h].WeightInitialize(MemoryMode.SET, $"HiddenLayer{h + 1}");
            }
            outputLayer.WeightInitialize(MemoryMode.SET, "OutputLayer");
            DownloadAverageLoss(MemoryMode.GET);
            ResetAccuracy();
            //MessageBox.Show($"Пройдёно эпох {i}, погрешность {lossFunction}");
        }

        private void HandleRandomSymbolFromSet(string[] symbolsArray, int maxAnswerIndex)
        {
            int randomRow;
            int searchingIndex;
            string[] symbol = null;
            string buf;
            do
            {
                searchingIndex = random.Next(symbolsArray.Length);
                symbol = symbolsArray[searchingIndex].Split(',');
            } while (int.Parse(symbol[0]) >= maxAnswerIndex);

            drawSymbols.DownloadSymbolToMatrix(symbol);
            drawSymbols.MNISTNormalizeMatrix();
            StraightForward(drawSymbols.DATA_MATRIX);

            randomRow = random.Next(symbolsArray.Length);

            buf = symbolsArray[searchingIndex];
            symbolsArray[searchingIndex] = symbolsArray[randomRow];
            symbolsArray[randomRow] = buf;

            trueIndex = int.Parse(symbol[0]);

            UpdateAccuracy();
        }

        private void DownLoadSymbolsFile(string[] symbolsArray, string filePath)
        {
            int i = 0;
            string row;
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                while ((row = streamReader.ReadLine()) != null && i < symbolsArray.Length)
                {
                    symbolsArray[i] = row;
                    i++;
                }
                streamReader.Close();
            }
        }

        public void ResetWeights()
        {
            for (int i = 0; i < _HIDDEN_LAYERS.Length; i++)
            {
                ResetWeights($"HiddenLayer{i + 1}");
            }
            ResetWeights("OutputLayer");
            ResetAccuracy();
            DeleteLossStatistic();
        }

        private void ResetWeights(string layerType)
        {
            XmlDocument weights_doc = new XmlDocument();
            weights_doc.Load($"{Path.Combine(NetworkParameters.weightsPath, layerType)}.xml");
            XmlElement weights_root = weights_doc.DocumentElement;
            weights_root.RemoveAll();
            weights_doc.Save($"{Path.Combine(NetworkParameters.weightsPath, layerType)}.xml");
        }

        private void ResetAccuracy()
        {
            for (int i = 0; i < NetworkParameters.ANSWER_SET.Length; i++)
            {
                _ACCURACY[i] = 0;
                _answersCount[i] = 0;
                _rightAnswersCount[i] = 0;
            }
            XmlDocument accuracyDoc = new XmlDocument();
            XmlElement accuracyRoot;
            accuracyDoc.Load($"{Path.Combine(NetworkParameters.accuracyPath)}");
            accuracyRoot = accuracyDoc.DocumentElement;
            accuracyRoot.RemoveAll();
            accuracyDoc.Save($"{Path.Combine(NetworkParameters.accuracyPath)}");
        }
        private void DeleteLossStatistic()
        {
            XmlDocument lossDoc = new XmlDocument();
            XmlElement lossRoot;
            lossDoc.Load($"{Path.Combine(NetworkParameters.averageLossPath)}");
            lossRoot = lossDoc.DocumentElement;
            lossRoot.RemoveAll();
            lossDoc.Save($"{Path.Combine(NetworkParameters.averageLossPath)}");
        }
        private void UpdateAccuracy()
        {
            if (_answersCount[trueIndex] < 0)
            {
                _answersCount[trueIndex] = 0;
                _rightAnswersCount[trueIndex] = 0;
            }
            _answersCount[trueIndex]++;
            if (trueIndex == predictIndex)
            {
                _rightAnswersCount[trueIndex]++;
            }
            _ACCURACY[trueIndex] = _rightAnswersCount[trueIndex] / (double)_answersCount[trueIndex];
        }
        //оценка точности работы нейросети
        public void AccuracyAssessment()
        {

            for (int i = 0; i < NetworkParameters.accuracyTestsCount; i++)
            {
                PredictRandomTestSymbol();
            }
        }

        public void PredictRandomTestSymbol()
        {
            HandleRandomSymbolFromSet(_TEST_SET, RESULTS.Length);
            DownloadAccurasy(MemoryMode.SET);
        }

        private void DownloadAccurasy(MemoryMode mode)
        {
            XmlDocument accuracyDoc = new XmlDocument();
            XmlElement accuracyRoot;
            XmlElement accuracyElement;
            XmlElement answersCountElement;
            XmlElement rightAnswersCountElement;
            if (File.Exists($"{Path.Combine(NetworkParameters.accuracyPath)}"))
            {
                accuracyDoc.Load($"{Path.Combine(NetworkParameters.accuracyPath)}");
                accuracyRoot = accuracyDoc.DocumentElement;
            }
            else
            {
                accuracyRoot = accuracyDoc.CreateElement("Accuracy");
                accuracyDoc.AppendChild(accuracyRoot);
            }

            if (accuracyRoot.ChildNodes.Count < NetworkParameters.ANSWER_SET.Length)
            {
                int accuracyElementCount = accuracyRoot.ChildNodes.Count;
                for (int i = 0; i < NetworkParameters.ANSWER_SET.Length - accuracyElementCount; i++)
                {
                    accuracyElement = accuracyDoc.CreateElement($"class_{i}");
                    answersCountElement = accuracyDoc.CreateElement($"answersCount");
                    rightAnswersCountElement = accuracyDoc.CreateElement($"rightAnswersCount");

                    answersCountElement.InnerText = "-1";
                    rightAnswersCountElement.InnerText = "-1";

                    accuracyElement.AppendChild(answersCountElement);
                    accuracyElement.AppendChild(rightAnswersCountElement);
                    accuracyRoot.AppendChild(accuracyElement);
                }
                accuracyDoc.Save((NetworkParameters.accuracyPath));
            }

            switch (mode)
            {
                case MemoryMode.GET:
                    {
                        for (int i = 0; i < NetworkParameters.ANSWER_SET.Length; i++)
                        {
                            _answersCount[i] = int.Parse(accuracyRoot.ChildNodes.Item(i).SelectSingleNode("answersCount").InnerText, System.Globalization.CultureInfo.InvariantCulture);
                            _rightAnswersCount[i] = int.Parse(accuracyRoot.ChildNodes.Item(i).SelectSingleNode("rightAnswersCount").InnerText, System.Globalization.CultureInfo.InvariantCulture);
                            if (_answersCount[i] > 0)
                            {
                                _ACCURACY[i] = _rightAnswersCount[i] / (double)_answersCount[i];
                            }
                            else
                            {
                                _ACCURACY[i] = -0.1;
                            }
                        }
                        break;
                    }
                case MemoryMode.SET:
                    {
                        accuracyRoot.ChildNodes.Item(trueIndex).SelectSingleNode("answersCount").InnerText = _answersCount[trueIndex].ToString();
                        accuracyRoot.ChildNodes.Item(trueIndex).SelectSingleNode("rightAnswersCount").InnerText = _rightAnswersCount[trueIndex].ToString();
                        accuracyDoc.Save((NetworkParameters.accuracyPath));
                        break;
                    }
            }
        }
        private void DownloadAverageLoss(MemoryMode mode)
        {
            XmlDocument lossDoc = new XmlDocument();
            XmlElement lossRoot;
            XmlElement lossElement;
            if (File.Exists($"{Path.Combine(NetworkParameters.averageLossPath)}"))
            {
                lossDoc.Load($"{Path.Combine(NetworkParameters.averageLossPath)}");
                lossRoot = lossDoc.DocumentElement;
            }
            else
            {
                lossRoot = lossDoc.CreateElement("AverageLoss");

                lossDoc.AppendChild(lossRoot);
                lossDoc.Save(NetworkParameters.averageLossPath);
            }

            switch (mode)
            {
                case MemoryMode.GET:
                    {
                        _LOSS_TO_EPOCH = new double[lossRoot.ChildNodes.Count];
                        for (int i = 0; i < _LOSS_TO_EPOCH.Length; i++)
                        {
                            _LOSS_TO_EPOCH[i] = double.Parse(lossRoot.ChildNodes.Item(i).InnerText.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
                        }
                        break;
                    }
                case MemoryMode.SET:
                    {
                        lossElement = lossDoc.CreateElement($"loss");

                        lossElement.InnerText = _lossToEpoch.ToString();

                        lossRoot.AppendChild(lossElement);
                        lossDoc.Save(NetworkParameters.averageLossPath);
                        break;
                    }
            }
        }

        public double[] GetAccuracyArray()
        {
            DownloadAverageLoss(MemoryMode.GET);
            return _ACCURACY;
        }
        public double[] GetLossArray()
        {
            return _LOSS_TO_EPOCH;
        }

        public int GetPredictionCountToSession()
        {
            return _answersCount.Sum();
        }
    }
}
