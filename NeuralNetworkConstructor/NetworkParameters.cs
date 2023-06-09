using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkConstructor
{
    public class NetworkParameters
    {
        public static string rootDirectory = Environment.CurrentDirectory;
        public static string testSymbolsPath = Path.Combine(rootDirectory, "DataSets", "emnist-byclass-test.csv");
        //public static string testSymbolsPath = Path.Combine(rootDirectory, "DataSets", "emnist-byclass-train.csv");
        public static string trainSymbolsPath = Path.Combine(rootDirectory, "DataSets", "emnist-byclass-train.csv");
        public static string weightsPath = Path.Combine(rootDirectory, "Weights");
        public static string accuracyPath = Path.Combine(rootDirectory, "Accuracy", "Accuracy.xml");
        public static string averageLossPath = Path.Combine(rootDirectory, "AverageLoss", "AverageLoss.xml");

        public static int trainFileSize = 697932;
        public static int testFileSize = 116323;

        public static int accuracyTestsCount = 10000;

        public static string[] ANSWER_SET = new string[]
        {
            "0","1","2","3","4","5","6","7","8","9",
            "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
            "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"
        };

        public static int[] NEURONS_COUNT = new int[]
        {
            196,392,196
        };

        //Настройка гиперпараметров нейросети
        public static double learningRate = 0.025d;//скорость обучения
        public static double regilarization = 0.9;//регуляризация (L2)
        public static double gradientMoment = 0.9;//скорость обновления весов

        public static double lossThreshold = 0.01;

        public static int epochCount = 250;
        public static int batchSize = 400;
        public static int minibatchSize = 20;
        public static int minibatchCount = batchSize / minibatchSize;

        //Настройка параметров изображения
        public static int imageRows = 28;
        public static int imageColumns = 28;

        public static int standartComponentWeight = 224;
        public static int standartComponentHeight = 224;
        
        public static int drawComponentWeight = 448;
        public static int drawComponentHeight = 448;
    }
}
