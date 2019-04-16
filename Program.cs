using System;
using System.Collections.Generic;
using System.IO;
using Algoritmo;
using Aprendizaje;
using Muestra;
using Recuperacion;
using Sensores;

namespace myoCSharp {
    class Program {
        static int nSENSORS = 8;
        public static List<List<string>> readCSV (string ruta) {
            try {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader (ruta)) {

                    var raw = new List<string> ();
                    var raws = new List<List<string>> ();
                    string line;
                    // Read and display lines from the file until the end of 
                    // the file is reached.
                    while ((line = sr.ReadLine ()) != null) {
                        raw = new List<string> ();
                        string[] cells = line.Split (',');
                        foreach (var cell in cells) {
                            raw.Add (cell);
                        }
                        raws.Add (raw);
                        //raw.Clear ();
                        //raw.TrimExcess();
                    }
                    //Console.WriteLine (" : {0}", raws.Count);                 
                    return raws;
                }
            } catch (Exception e) {
                // Let the user know what went wrong.
                Console.WriteLine ("The file could not be read:");
                Console.WriteLine (e.Message);
                return null;
            }
        }

        //Metodo que realiza el procesamiento necesario para llenar cada uno de los sensores con su clase correspondiente        
        public static List<Sensors> fillSensors (List<List<string>> raws) {
            //Console.WriteLine ("Count: {}", raws.Count);
            var _out = new List<Sensors> ();
            var aux = new Sensors ();
            int fin, content;
            string clase;
            fin = raws[1].Count - 1;
            clase = raws[1][fin];
            for (var row = 1; row < raws.Count; row++) {
                fin = raws[row].Count - 1;
                if (clase != raws[row][fin]) {
                    _out.Add (aux);
                    clase = raws[row][fin];
                    aux = new Sensors ();
                    row--;
                    continue;
                }
                for (var sensor = 0; sensor < fin; sensor++) {
                    content = Convert.ToInt32 (raws[row][sensor]);
                    aux.append (sensor + 1, content);
                    aux.setClass (clase);
                }
            }
            _out.Add (aux);
            return _out;
        }
        //DEBUG
        public static void printSensors (List<Sensors> raws) {
            for (var row = 0; row < raws.Count; row++) {
                for (var sensor = 1; sensor <= nSENSORS; sensor++) {
                    Console.Write ("[");
                    raws[row].printVector (sensor);
                    Console.WriteLine ("]");
                }
                Console.WriteLine ();
            }
        }
        //DEBUG
        public static void printSamples (List<Sample> raws) {
            for (var row = 0; row < raws.Count; row++) {
                Console.Write (raws[row].getClase () + "[");
                for (var pos = 0; pos < raws[row].getStandardDev ().Count; pos++) {
                    Console.Write (raws[row].getStandardDev () [pos] + "\t");
                }
                Console.WriteLine ("]");
            }
        }
        static void Main (string[] args) {
            var time = 30;
            var res = new List<List<string>> ();
            var sets = new List<Sensors> ();
            var muestras = new List<Sample> ();
            var aux = new Sample ();
            var _out = new LearningSet ();
            float operationRes;
            var clasificador = new KNN (1);
            var test = new RecoverySet ();
            var count = 0;
            float efectividad;

            //Leer los datos de la pulsera almacenados para pruebas
            res = readCSV ("excel/valores-final.csv");
            //Llenando de de la clase sensores para dividir por clases
            sets = fillSensors (res);

            //printSensors(sets);

            //Ciclo para genera las muestras totales para el clasificador
            for (var periodo = 0; periodo < sets[0].getVector (1).Count / time; periodo++) {
                for (var set = 0; set < sets.Count; set++) {
                    aux = new Sample ();
                    aux.setStandardDeviation (sets[set], time * periodo, time * (periodo + 1));
                    aux.setClase (sets[set].getClass ());
                    muestras.Add (aux);
                    //aux.clear ();
                }
            }

            printSamples (muestras);

            //Ciclo para tomar unicamente el n de las muestras para la fase de aprendizaje
            operationRes = (muestras.Count * 66) / 100;
            for (var row = 0; row < operationRes; row++) {
                _out.append (muestras[row]);
            }

            //printSamples(_out.getStandardDeviations());
            clasificador.learning (_out);

            for (var row = (int) operationRes; row < muestras.Count; row++) {
                test.append (muestras[row]);
            }

            for (var samp = 0; samp < test.getStandardDeviation ().Count; samp++) {
                clasificador.recovery (test.getStandardDeviation () [samp]);
            }

            for (var samp = 0; samp < test.getStandardDeviation ().Count; samp++) {
                count = count + clasificador.validation (test.getStandardDeviation () [samp]);
            }

            efectividad = (count * 100) / (float) (test.getStandardDeviation ().Count);
            Console.WriteLine ("Efectividad: {0}", efectividad);
        }
    }
}