using System;

namespace OOPBruchrechner.Modelle {
    public class Bruch {
        #region Eigenschaften
        private int nenner;

        public int Zaehler { get; set; }
        public int Nenner {
            get { return nenner; }
            set {
                if (value != 0)
                    nenner = value;
                else {
                    throw new ArgumentException("Nenner darf nicht null sein!");
                }
            }
        }
        #endregion

        #region Konstruktoren
        public Bruch() { }

        public Bruch(int zaehler, int nenner) {
            Zaehler = zaehler;
            Nenner = nenner;
        }
        #endregion

        #region Worker
        public Bruch Addieren(Bruch andererBruch) {
            int ergebnisZaehler = Zaehler * andererBruch.Nenner + andererBruch.Zaehler * Nenner;
            int ergebnisNenner = Nenner * andererBruch.Nenner;
            Kuerzen(ref ergebnisZaehler, ref ergebnisNenner);
            return new Bruch(ergebnisZaehler, ergebnisNenner);
        }

        public void Zuweisen(Bruch bruch) {
            Zaehler = bruch.Zaehler;
            Nenner = bruch.Nenner;
        }

        public override string ToString() {
            return $"({Zaehler}/{Nenner})";
        }

        public bool Equals(Bruch bruch) {
            if (Zaehler == bruch.Zaehler && Nenner == bruch.Nenner) {
                return true;
            }
            else {
                return false;
            }
        }

        private void Kuerzen(ref int zaehler, ref int nenner) {
            try {
                // Wert des größten gemeinsamen Teilers
                int ggt = GroestenGemeinsamenTeilenErmitteln(zaehler, nenner);
                if (ggt != 0) {
                    zaehler /= ggt;
                    nenner /= ggt;
                }

                if (nenner < 0) {
                    nenner *= -1;
                    zaehler *= -1;
                }
            } catch (Exception) {
                Console.WriteLine("Bruch kann nicht gekürzt werden.");
            }
        }

        private int GroestenGemeinsamenTeilenErmitteln(int antwortZaehler, int antwortNenner) {
            int x = Math.Abs(antwortZaehler);
            int y = Math.Abs(antwortNenner);
            int m;

            if (x > y) {
                m = y;
            } else {
                m = x;
            }

            for (int i = m; i >= 1; i--) {
                if (x % i == 0 && y % i == 0) {
                    return i;
                }
            }

            return 1;
        }
        #endregion
    }
}
