using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOPBruchrechner.Modelle;

namespace Test {
    [TestClass]
    public class BruchTest {
        [TestMethod]
        public void BruchErstellenStandardkonstruktor() {
            var bruch = new Bruch();
            Assert.AreEqual(0, bruch.Zaehler);
            Assert.AreEqual(0, bruch.Nenner);
        }

        [TestMethod]
        public void BruchErstellenSpezialkonstruktor() {
            var bruch = new Bruch(1, 2);
            Assert.AreEqual(1, bruch.Zaehler);
            Assert.AreEqual(2, bruch.Nenner);
        }

        [TestMethod]
        public void BruchErstellenEigenschaften() {
            var bruch = new Bruch() {
                Zaehler = 1,
                Nenner = 2
            };
            Assert.AreEqual(1, bruch.Zaehler);
            Assert.AreEqual(2, bruch.Nenner);
        }

        [TestMethod]
        public void BruecheAddieren() {
            var bruch1 = new Bruch(5, 10);
            var bruch2 = new Bruch(5, 10);

            var ergebnis = bruch1.Addieren(bruch2);

            Assert.AreEqual(1, ergebnis.Zaehler);
            Assert.AreEqual(1, ergebnis.Nenner);
        }

        [TestMethod]
        public void BruecheAddierenNegativ() {
            var bruch1 = new Bruch(-5, -10);
            var bruch2 = new Bruch(-6, -10);

            var ergebnis = bruch1.Addieren(bruch2);

            Assert.AreEqual(11, ergebnis.Zaehler);
            Assert.AreEqual(10, ergebnis.Nenner);
        }

        [TestMethod]
        public void BruchZuweisen() {
            var bruch1 = new Bruch(1, 1);
            var bruch2 = new Bruch(5, 5);
            bruch1.Zuweisen(bruch2);
            Assert.IsTrue(bruch1.Equals(bruch2));
        }

        [TestMethod]
        public void BruchToString() {
            Assert.AreEqual("(1/1)", new Bruch(1, 1).ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BruecheAddierenNullImNenner() {
            var bruch1 = new Bruch();
            var bruch2 = new Bruch();

            _ = bruch1.Addieren(bruch2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NullImNennerSpezialkonstruktor() {
            _ = new Bruch(1, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NullImNennerEigenschaften() {
            _ = new Bruch() {
                Zaehler = 1,
                Nenner = 0
            };
        }
    }
}
