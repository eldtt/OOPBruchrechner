using System;
using OOPBruchrechner.Modelle;
using OOPBruchrechner.Views;

namespace OOPBruchrechner.Controllers {
    public class Hauptprogramm {
        private bool programmLaeuft;

        private Bruch bruch1;
        private Bruch bruch2;
        private Bruch ergebnis;


        public void Run() {
            Init();

            // SplashScreen anzeigen
            Ausgabe.Bereinigen();
            Ausgabe.Auflisten(Info.SplashScreen);
            Ausgabe.Leerzeichen();
            Ausgabe.Auflisten(Info.Optionen);

            // Hauptschleife
            while (programmLaeuft) {
                OptionenVerarbeiten();
            }
        }

        // Verarbeitet die Nutzereingaben
        private void OptionenVerarbeiten() {
            // Liest Knopfdrücke ein
            var keyInfo = Console.ReadKey(true);

            // Konsole bereinigen
            Console.Clear();

            // Wähle Option basierend auf Tastendruck
            if (keyInfo.Key == ConsoleKey.A) {
                // Addition ausgewählt
                BruecheVerarbeiten(Operator.Addition);
            } else if (keyInfo.Key == ConsoleKey.S) {
                // Subtraktion ausgewählt
                BruecheVerarbeiten(Operator.Subtraktion);
            } else if (keyInfo.Key == ConsoleKey.M) {
                // Multiplikation ausgewählt
                BruecheVerarbeiten(Operator.Multiplikation);
            } else if (keyInfo.Key == ConsoleKey.D) {
                // Division ausgewählt
                BruecheVerarbeiten(Operator.Division);
            } else if (keyInfo.Key == ConsoleKey.Escape) {
                // Programm beenden ausgewählt
                Console.WriteLine("Programm wird beendet. Beliebige Taste betätigen zum schließen...");
                Console.ReadKey();

                // Programm schließen
                programmLaeuft = false;
            } else if (keyInfo.Key == ConsoleKey.H) {
                // Zurück zum Programmanfang
                Run();
            } else {
                // Invalide Eingabe. Nichts passiert.
            }
        }

        private void BruecheVerarbeiten(Operator gewaehlterOperator) {
            // Absprung vom Hauptmenü           
            Ausgabe.BruecheAnzeigen(bruch1, bruch2, gewaehlterOperator);

            // Absprung in Zahleneingabe, wahr wenn alle Zahlen valide und
            // es keinen Abbruch gab per 'exit' Eingabe
            if (Eingabe.BruecheEingeben(bruch1, bruch2, gewaehlterOperator)) {
                // Berechnung dem Ergebnis zuweisen
                ergebnis.Zuweisen(Berechnung.BruchBerechnen(bruch1, bruch2, gewaehlterOperator));
                Ausgabe.ErgebnisAnzeigen(bruch1, bruch2, ergebnis, gewaehlterOperator);
            } else {
                Run();
            }

            // Brüche zurücksetzen
            BruecheZurucksetzen();

            // Menü anzeigen
            Ausgabe.Auflisten(Info.Optionen);
        }

        public void BruecheZurucksetzen() {
            bruch1 = new Bruch();
            bruch2 = new Bruch();
            ergebnis = new Bruch();
        }

        private void Init() {
            Console.CursorVisible = false;
            programmLaeuft = true;
            BruecheZurucksetzen();
        }
    }
}
