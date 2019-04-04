using System;
using System.Collections.Generic;
using Aprendizaje;
using Muestra;

namespace Algoritmo {
    public class KNN {
        private int k;
        private List<Sample> dataArray;
        private float porcentajeEficiencia;
        public KNN (int val) {
            dataArray = new List<Sample> ();
            k = val;
        }
        public float mathDistance (Sample test, Sample tester) {
            float aux = 0;
            for (var sensor = 0; sensor < test.getStandardDev ().Count; sensor++) {
                aux = aux + (float) Math.Pow (test.getStandardDev () [sensor] - tester.getStandardDev () [sensor], 2);
            }
            return (float) Math.Sqrt (aux);
        }
        public void learning (LearningSet raws) {
            for (var row = 0; row < raws.getStandardDeviations ().Count; row++) {
                dataArray.Add (raws.getStandardDeviations () [row]);
            }
        }
        public string recovery(Sample dataTest){
            float aux;
            float _out = mathDistance(dataTest, dataArray[0]);
            var match = dataArray[0].getClase();
            for(var record = 1; record < dataArray.Count; record++){
                aux = mathDistance(dataTest, dataArray[record]);
                if(aux < _out){
                    _out = aux;
                    match = dataArray[record].getClase();
                }
            }
            Console.WriteLine(match[0] + "\t" + dataTest.getClase()[0]);
            return match;
        }
        public int validation (Sample dataTest) {
            var val = recovery (dataTest);
            if (dataTest.getClase () == val) {
                return 1;
            } else return 0;
        }
        public void printArray () {
            for (var samp = 0; samp < dataArray.Count; samp++) {
                for (var clase = 0; clase < dataArray[samp].getClase ().Length; clase++) {
                    Console.Write (dataArray[samp].getClase () [clase] + "[");
                    for (var sensor = 0; sensor < dataArray[samp].getStandardDev ().Count; sensor++) {
                        Console.Write (dataArray[samp].getStandardDev () [sensor] + ",");
                    }
                    Console.WriteLine ("]");
                }
            }
        }

    } //class
}