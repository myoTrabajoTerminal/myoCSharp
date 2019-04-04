using Muestra;
using System.Collections.Generic;

namespace Recuperacion {
    public class RecoverySet {
        private List<Sample> standardDeviations;
        public RecoverySet () {
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
        public List<Sample> getStandardDeviation () {
            return standardDeviations;
        }
    }
}