using System;
using OOPBruchrechner.Modelle;

namespace OOPBruchrechner.Controllers {
    public static class Berechnung {
        public static Bruch BruchBerechnen(Bruch bruch1, Bruch bruch2, Operator aktuellerOperator) {
            if (aktuellerOperator == Operator.Addition) {
                return bruch1.Addieren(bruch2);
            } else if (aktuellerOperator == Operator.Subtraktion) {
                return bruch1.Subtrahieren(bruch2);
            } else if (aktuellerOperator == Operator.Multiplikation) {
                return bruch1.Multiplizieren(bruch2);
            } else if (aktuellerOperator == Operator.Division) {
                return bruch1.Dividieren(bruch2);
            } else {
                throw new NotImplementedException();
            }
        }
    }
}
