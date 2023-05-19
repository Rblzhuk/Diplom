using NeuralNetwork;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DiplomPrototype
{
    public partial class Form1 : Form
    {

        private string[] _DATA_SET = null;

        private string DataSetsFolder;
        private string _test_letters_digits_Set_Path;
        private Network network;
        private Random random;

        private int _inpNeurons;
        private int _outNeurons;
        private int _hidLayersCount;
        private double _answersCount;
        private double _rightAnswersCount;
        private double _accuracy;

        public Form1()
        {
            InitializeComponent();
            SetDefaultValues();
        }

        private string[] _ANSWER_SET = new string[]
        {
            "0","1","2","3","4","5","6","7","8","9",
            "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
            "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"
        };

        private int[] _NEURONS_COUNT = new int[]
        {
            128,64,62
        };
        private void SetDefaultValues()
        {
            _inpNeurons = drawSymbolsClass1.DATA_MATRIX.GetLength(0) * drawSymbolsClass1.DATA_MATRIX.GetLength(1);
            _outNeurons = _ANSWER_SET.Length;
            _hidLayersCount = _NEURONS_COUNT.Length;

            DataSetsFolder = Path.Combine(Environment.CurrentDirectory, "DataSets");
            random = new Random();

            _test_letters_digits_Set_Path = Path.Combine(DataSetsFolder, "emnist-byclass-test.csv");
            _DATA_SET = File.ReadAllLines(_test_letters_digits_Set_Path);

            network = new Network(_inpNeurons, _hidLayersCount, _NEURONS_COUNT, _outNeurons);

            ResetAccuracy();
        }

        private void Button_DownloadNextDigit_Click(object sender, EventArgs e)
        {
            if (File.Exists(_test_letters_digits_Set_Path))
            {
                HandleFile();
                network.HandleOneDigit(network, drawSymbolsClass1.DATA_MATRIX);
                Laber_NetworkAnswer.Text = (_ANSWER_SET[Array.IndexOf(network.RESULTS, network.RESULTS.Max())]).ToString();
                UpdateAccuracy();
                //TestForward();
            }
            else
            {
                MessageBox.Show($"Файл {_test_letters_digits_Set_Path} в корневой папке проекта: {Path.Combine(Environment.CurrentDirectory, "DataSets")} не найден");
            }
        }

        private void HandleFile()
        {
            int randomDigit;
            string[] symbol;
            do
            {
                randomDigit = random.Next(_DATA_SET.Length);
                symbol = _DATA_SET[randomDigit].Split(',');
            } while (int.Parse(symbol[0]) >= _ANSWER_SET.Length);
            drawSymbolsClass1.DownloadSymbolToMatrix(symbol);
            Label_RightAnswer.Text = _ANSWER_SET[int.Parse(symbol[0])];
        }

        private void Button_ResetWeights_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Прогресс обучения будет потерян. Задать весам случайное значение?", "Внимание!", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                network.ResetWeights();
                network = new Network(_inpNeurons, _hidLayersCount, _NEURONS_COUNT, _outNeurons);
                ResetAccuracy();
            }
        }


        private void drawDigitsClass1_DoubleClick(object sender, EventArgs e)
        {
            drawSymbolsClass1.IsDrawMode = !drawSymbolsClass1.IsDrawMode;
        }

        private void Button_MatrixClear_Click(object sender, EventArgs e)
        {
            drawSymbolsClass1.ErasePicture();
            Laber_NetworkAnswer.Text = "";
            Label_RightAnswer.Text = "";
        }

        private void drawDigitsClass1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawSymbolsClass1.IsDrawMode)
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        {
                            drawSymbolsClass1.DrawPixel(e.Y / drawSymbolsClass1.currentPixelSize, e.X / drawSymbolsClass1.currentPixelSize, 255);
                            network.HandleOneDigit(network, drawSymbolsClass1.DATA_MATRIX);
                            Laber_NetworkAnswer.Text = (_ANSWER_SET[Array.IndexOf(network.RESULTS, network.RESULTS.Max())]).ToString();
                            break;
                        }
                    case MouseButtons.Right:
                        {
                            drawSymbolsClass1.DrawPixel(e.Y / drawSymbolsClass1.currentPixelSize, e.X / drawSymbolsClass1.currentPixelSize, 0);
                            network.HandleOneDigit(network, drawSymbolsClass1.DATA_MATRIX);
                            Laber_NetworkAnswer.Text = (_ANSWER_SET[Array.IndexOf(network.RESULTS, network.RESULTS.Max())]).ToString();
                            break;
                        }
                }
            }
        }

        private void Button_DownloadPucture_Click(object sender, EventArgs e)
        {
            network.HandleOneDigit(network, drawSymbolsClass1.DATA_MATRIX);
            Laber_NetworkAnswer.Text = (_ANSWER_SET[Array.IndexOf(network.RESULTS, network.RESULTS.Max())]).ToString();
        }

        private void Button_StartLearningSet_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Обучение займёт некоторое время. Запустить обучение?", "Внимание!", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                network.Train(network, drawSymbolsClass1, _ANSWER_SET);
                ResetAccuracy();
                TestForward();
            }
        }
        private void ResetAccuracy()
        {
            _accuracy = 0;
            _answersCount = 0;
            _rightAnswersCount = 0;
        }
        private void UpdateAccuracy()
        {
            _answersCount++;
            if (Label_RightAnswer.Text == Laber_NetworkAnswer.Text)
            {
                _rightAnswersCount++;
            }
            _accuracy = Math.Round(_rightAnswersCount / _answersCount, 3);
            label_Accuracy.Text = _accuracy.ToString();
        }

        private void TestForward()
        {
            random = new Random();
            int testCount = 5000;
            for (int i = 0; i < testCount; i++)
            {
                HandleFile();
                network.HandleOneDigit(network, drawSymbolsClass1.DATA_MATRIX);
                Laber_NetworkAnswer.Text = (_ANSWER_SET[Array.IndexOf(network.RESULTS, network.RESULTS.Max())]).ToString();
                UpdateAccuracy();
            }
        }
    }
}
