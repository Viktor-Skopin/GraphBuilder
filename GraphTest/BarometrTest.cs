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

        [TestMethod]
        public void CurrentTest_1()
        {
            Barometer barometer = new Barometer();

            barometer.SetCurrentValue(5);

            Assert.AreEqual(5, barometer.CurrentValue);
        }

        [TestMethod]
        public void CurrentTest_2()
        {
            Barometer barometer = new Barometer();

            barometer.SetCurrentValue(0);

            Assert.AreEqual(0, barometer.CurrentValue);
        }

        [TestMethod]
        public void CurrentTest_3()
        {
            Barometer barometer = new Barometer();

            barometer.SetCurrentValue(-10);

            Assert.AreEqual(-10, barometer.CurrentValue);
        }

        [TestMethod]
        public void CurrentTest_4()
        {
            Barometer barometer = new Barometer();

            barometer.SetCurrentValue(0.735);

            Assert.AreEqual(0.735, barometer.CurrentValue);
        }

        [TestMethod]
        public void CerrentTest_5()
        {
            Barometer barometer = new Barometer();

            barometer.SetCurrentValue(-4.872);

            Assert.AreEqual(-4.872, barometer.CurrentValue);
        }

        [TestMethod]
        public void ForecastTest_1()
        {
            Barometer barometer = new Barometer();

            barometer.Minimum = 0;
            barometer.Maximum = 10;

            barometer.SetCurrentValue(5);

            barometer.GetForecastValue();

            Assert.AreEqual(7.5, barometer.Forecast);
        }

        [TestMethod]
        public void ForecastTest_2()
        {
            Barometer barometer = new Barometer();

            barometer.Minimum = 0;
            barometer.Maximum = 10;

            barometer.SetCurrentValue(6);

            barometer.GetForecastValue();

            Assert.AreEqual(3, barometer.Forecast);
        }

        [TestMethod]
        public void ForecastTest_3()
        {
            Barometer barometer = new Barometer();

            barometer.Minimum = 0;
            barometer.Maximum = 10;

            barometer.SetCurrentValue(-10);

            barometer.GetForecastValue();

            Assert.AreEqual(0, barometer.Forecast);
        }

        [TestMethod]
        public void ForecastTest_4()
        {
            Barometer barometer = new Barometer();

            barometer.Minimum = -10;
            barometer.Maximum = 0;

            barometer.SetCurrentValue(-5);

            barometer.GetForecastValue();

            Assert.AreEqual(-2.5, barometer.Forecast);
        }

        [TestMethod]
        public void ForecastTest_5()
        {
            Barometer barometer = new Barometer();

            barometer.Minimum = -10;
            barometer.Maximum = 10;

            barometer.SetCurrentValue(0);

            barometer.GetForecastValue();

            Assert.AreEqual(5, barometer.Forecast);
        }
    }
}
