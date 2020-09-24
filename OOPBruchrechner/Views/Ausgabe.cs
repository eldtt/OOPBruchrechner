using System;
using System.Drawing;
using OOPBruchrechner.Modelle;

namespace OOPBruchrechner.Views {
    static class Ausgabe {
        // Programminformation, die beliebig erweitert werden können
        readonly static string[] programminformationen = new string[13] {
            "########################################################################",
            "# ____________________________________________________________________ #",
            "# Autor: Thomas Knott                                                  #",
            "# Heinrich-Hertz-Europakolleg                                          #",
            "# IA219                                                                #",
            "# Programm zur Berechnung von Brüchen.                                 #",
            "# ____________________________________________________________________ #",
            "# Anleitung:                                                           #",
            "# Entsprechende Optionen per Tastendruck auswählen, z.B. 'a' bei [a].  #",
            "# Optionen sind auswählbar, wenn sie auf dem Bildschirm gelistet sind. #",
            "# Bei der Zahleneingabe mit Befehl 'exit' abbrechen.                   #",
            "# ____________________________________________________________________ #",
            "########################################################################"
        };

        // Menüoptionen, die beliebig erweitert werden können
        readonly static string[] optionen = new string[6] {
            "[a] Mit Addition (+) fortfahren.",
            "[s] Mit Subtraktion (-) fortfahren.",
            "[m] Mit Multiplikation (*) fortfahren.",
            "[d] Mit Division (/) fortfahren.",
            "[h] Zurück zum Introbildschirm.",
            "[ESC] Programm beenden."
        };

        public static void Auflisten(Info info) {
            string[] liste;

            if (info == Info.SplashScreen) {
                liste = programminformationen;
            } else if (info == Info.Optionen) {
                liste = optionen;
            } else {
                liste = new string[0];
            }

            for (int i = 0; i < liste.Length; i++) {
                Anzeigen(liste[i]);
            }
        }

        public static void Leerzeichen() {
            Anzeigen("");
        }

        public static void Bereinigen() {
            Console.Clear();
        }

        internal static void BruecheAnzeigen(Bruch bruch1, Bruch bruch2, Operator aktuellerOperator) {
            Bereinigen();
            Anzeigen($"{bruch1} {(char)aktuellerOperator} {bruch2}");
            Leerzeichen();
        }

        internal static void ErgebnisAnzeigen(Bruch bruch1, Bruch bruch2, Bruch ergebnis, Operator aktuellerOperator) {
            Bereinigen();
            if (ergebnis.Zaehler != ergebnis.Nenner) {
                Anzeigen($"{bruch1} {(char)aktuellerOperator} {bruch2} = {ergebnis}");
            } else if (ergebnis.Zaehler == 1 && ergebnis.Nenner == 1) {
                Anzeigen($"{bruch1} {(char)aktuellerOperator} {bruch2} = {ergebnis} = 1");
            } else {
                Anzeigen($"{bruch1} {(char)aktuellerOperator} {bruch2} = {ergebnis} = -1");
            }

            Leerzeichen();
        }

        public static void Anzeigen(string text, Point koordinaten, bool zeilenumbruch = true) {
            Console.SetCursorPosition(koordinaten.X, koordinaten.Y);
            if (zeilenumbruch) {
                Console.WriteLine(text);
            } else {
                Console.Write(text);
            }
        }

        public static void Anzeigen(string text, bool zeilenumbruch = true) {
            if (zeilenumbruch) {
                Console.WriteLine(text);
            } else {
                Console.Write(text);
            }
        }
    }
}
