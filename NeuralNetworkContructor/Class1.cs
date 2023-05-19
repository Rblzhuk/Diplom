using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkContructor
{
    static public class NetworkParameters
    {
        public static string testSymbolsPath = Path.Combine(Environment.CurrentDirectory, "DataSets", "emnist-byclass-test.csv");
        public static string trainSymbolsPath = Path.Combine(Environment.CurrentDirectory, "DataSets", "emnist-byclass-train.csv");

        public static string[] ANSWER_SET = new string[]
        {
            "0","1","2","3","4","5","6","7","8","9",
            "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
            "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"
        };
        public static int[] NEURONS_COUNT = new int[]
        {
            128,64,62
        };
        public static double learningRate = 0.01d;//скорость обучения
        public static double regilarization = 0.5;//регуляризация (L2)
        public static double gradientMoment = 0.9;//скорость обновления весов

        public static double lossThreshold = 0.01;

        public static int epochCount = 50;
        public static int batchSize = 512;
        public static int minibatchSize = 32;
        public static int minibatchCount = batchSize/ minibatchSize;

        public static string activationMethod = "sigmoid";
    }
}
