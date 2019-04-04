using System;
using Muestra;
using Recuperacion;
using Aprendizaje;
using Algoritmo;

namespace myoCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //var sensors = new Sensors();
            //var sample = new Sample();
            //var recovery = new RecoverySet();
            //var learning = new LearningSet();
            var knn = new KNN(1);
        }
    }
}
