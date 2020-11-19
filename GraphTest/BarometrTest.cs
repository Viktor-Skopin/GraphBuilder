using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeterReadingsLibrary;

namespace GraphTest
{
    [TestClass]
    public class BarometrTest
    {
        [TestMethod]
        public void AverageTest_1()
        {
            Barometer barometer = new Barometer();

            barometer.SetCurrentValue(5);

            barometer.SetCurrentValue(15);

            barometer.CalculateAverage();

            Assert.AreEqual(10,barometer.AverageValue);
        }

        [TestMethod]
        public void AverageTest_2()
        {
            Barometer barometer = new Barometer();

            barometer.SetCurrentValue(-10);

            barometer.SetCurrentValue(10);

            barometer.CalculateAverage();

            Assert.AreEqual(0, barometer.AverageValue);
        }

        [TestMethod]
        public void AverageTest_3()
        {
            Barometer barometer = new Barometer();

            barometer.SetCurrentValue(0.15);

            barometer.SetCurrentValue(1.25);

            barometer.CalculateAverage();

            Assert.AreEqual(0.7 , barometer.AverageValue);
        }

        [TestMethod]
        public void AverageTest_4()
        {
            Barometer barometer = new Barometer();

            barometer.SetCurrentValue(-15.53);

            barometer.CalculateAverage();

            Assert.AreEqual(-15.5, barometer.AverageValue);
        }

        [TestMethod]
        public void AverageTest_5()
        {
            Barometer barometer = new Barometer();

            barometer.CalculateAverage();

            Assert.AreEqual(0, barometer.AverageValue);
        }
    }
}
