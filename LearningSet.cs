using System.Collections.Generic;
using Muestra;

namespace Aprendizaje {
    public class LearningSet {
        private List<Sample> standardDeviations;
        public LearningSet () {
            standardDeviations = new List<Sample> ();
        }
        public void setValues (List<Sample> raws) {
            foreach (var row in raws) {
                standardDeviations.Add (row);
            }
        }
        public void append (Sample val) {
            standardDeviations.Add (val);
        }
        public List<Sample> getStandardDeviations () {
            return standardDeviations;
        }
    }
}