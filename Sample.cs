using System;
using System.Collections.Generic;
using Sensores;

namespace Muestra {
    public class Sample {
        const int nSENSORS = 8;
        private List<float> standardDev;
        string clase;
        public Sample () {
            standardDev = new List<float> ();
        }
        public void setStandardDeviation (Sensors data, int inicio, int fin) {
            var aux = new List<int> ();
            for (var sensor = 1; sensor <= nSENSORS; sensor++) {
                aux = new List<int> ();
                for (var iterator = inicio; iterator < fin; iterator++) {
                    aux.Add (data.getVector (sensor) [iterator]);
                }
                standardDev.Add (doMath (aux));
                //aux.Clear ();
            }
        }
        public float doMath (List<int> vals) {
            return standardDeviation (vals, arithmeticMean (vals));
        }
        public float arithmeticMean (List<int> vals) {
            float val = 0;
            foreach (var value in vals) {
                val = val + value;
            }
            return val / vals.Count;
        }
        public float standardDeviation (List<int> vals, float mean) {
            float val = 0;
            foreach (var value in vals) {
                val = val + (float) Math.Pow (Math.Abs (value - mean), 2);
            }
            return (float) Math.Sqrt (val / vals.Count);
        }
        public List<float> getStandardDev () {
            return standardDev;
        }
        public void clear () {
            standardDev.Clear ();
        }
        public void setClase (string cad) {
            clase = cad;
        }
        public string getClase () {
            return clase;
        }
    }
}