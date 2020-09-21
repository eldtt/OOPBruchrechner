using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOPBruchrechner;

namespace Test {
    [TestClass]
    public class BruchTest
    {
        [TestMethod]
        public void BruchErstellenKonstruktor()
        {
            var bruch = new Bruch(1, 2);
            Assert.AreEqual(1, bruch.Zaehler);
            Assert.AreEqual(2, bruch.Nenner);
        }

        [TestMethod]
        public void BruchErstellenEigenschaften()
        {
            var bruch = new Bruch() {
                Zaehler = 1,
                Nenner = 2
            };
            Assert.AreEqual(1, bruch.Zaehler);
            Assert.AreEqual(2, bruch.Nenner);
        }

        [TestMethod]
        public void BruecheAddieren()
        {
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
        [ExpectedException(typeof(ArgumentException))]
        public void NullImNennerKonstruktor()
        {
            _ = new Bruch(1, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NullImNennerEigenschaften()
        {
            _ = new Bruch() {
                Zaehler = 1,
                Nenner = 0
            };
        }
    }
}
