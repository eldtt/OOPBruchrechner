using System;
using OOPBruchrechner.Modelle;

namespace OOPBruchrechner.Views {
    static class Eingabe {
        public static string Einlesen() {
            return Console.ReadLine();
        }

        // Validiert eingegebene Zahlen
        private static bool ZahlValidieren(ref int zahl) {
            bool istInvalide = true;
            // Eingabe wiederholt solange, bis valide Zahl erkannt
            while (istInvalide) {
                try {
                    string eingabe = Einlesen();
                    // Wenn user 'exit' während der Zahleneingabe eingibt, kehre zu den Optionen zurück
                    if (eingabe.ToUpper() == "EXIT") {
                        return false;
                    }
                    zahl = Convert.ToInt32(eingabe);
                    istInvalide = false;
                } catch (Exception) {
                    Console.WriteLine($"Konnte nicht als ganze Zahl erkannt werden. Bitte erneut versuchen.");
                }
            }
            return true;
        }

        public static bool BruecheEingeben(Bruch bruch1, Bruch bruch2, Operator aktuellerOperator) {
            var zaehler1 = bruch1.Zaehler;
            var nenner1 = bruch1.Nenner;
            var zaehler2 = bruch2.Zaehler;
            var nenner2 = bruch2.Nenner;


            // Zahlen als Input abfragen und validieren
            Ausgabe.Anzeigen("Bitte ersten Zähler eingeben.");

            // Wenn ZahlValidieren false, Eingabe abgebrochen
            if (!ZahlValidieren(ref zaehler1)) {
                return false;
            }

            bruch1.Zaehler = zaehler1;

            Ausgabe.BruecheAnzeigen(bruch1, bruch2, aktuellerOperator);
            // Bei Nenner auf Nulldivision achten
            while (nenner1 == 0) {
                Ausgabe.Anzeigen("Bitte ersten Nenner eingeben.");

                if (!ZahlValidieren(ref nenner1)) {
                    return false;
                }
                if (nenner1 == 0) {
                    Ausgabe.Anzeigen("Nenner dürfen nicht 0 sein!");
                }
            }

            bruch1.Nenner = nenner1;

            Ausgabe.BruecheAnzeigen(bruch1, bruch2, aktuellerOperator);
            Ausgabe.Anzeigen("Bitte zweiten Zähler eingeben.");

            if (!ZahlValidieren(ref zaehler2)) {
                return false;
            }

            bruch2.Zaehler = zaehler2;

            Ausgabe.BruecheAnzeigen(bruch1, bruch2, aktuellerOperator);

            // Bei Nenner auf Nulldivision achten
            while (nenner2 == 0) {
                Ausgabe.Anzeigen("Bitte zweiten Nenner eingeben.");
                if (!ZahlValidieren(ref nenner2)) {
                    return false;
                }
                if (nenner2 == 0) {
                    Ausgabe.Anzeigen("Nenner dürfen nicht 0 sein!");
                }
            }

            bruch2.Nenner = nenner2;

            Ausgabe.BruecheAnzeigen(bruch1, bruch2, aktuellerOperator);
            return true;
        }
    }
}
