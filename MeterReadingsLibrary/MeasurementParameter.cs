using System;
using System.Windows.Forms.DataVisualization.Charting;

namespace MeterReadingsLibrary
{
    /// <summary>
    /// Переменный параметр
    /// </summary>
    public abstract class MeasurementParameter
    {
        /// <summary>
        /// Текущее значение
        /// </summary>
        public double CurrentValue { get; set; }

        /// <summary>
        /// Среднее значение
        /// </summary>
        public double AverageValue { get; set; }

        /// <summary>
        /// Кэш текущихзначений
        /// </summary>
        private double[] ValueCash = new double[10];

        /// <summary>
        /// Кэш средних значений
        /// </summary>
        private double[] AverageValueCash = new double[10];

        /// <summary>
        /// Предел значений
        /// </summary>
        public double Minimum, Maximum;

        /// <summary>
        /// Прогноз значения
        /// </summary>
        public double Forecast { get; set; }

        /// <summary>
        /// Вычеслить среднее значение
        /// </summary>
        public void CalculateAverage()
        {
            var Average = ValueCash[0];
            int k = 1;
            for (int i = 1; i < ValueCash.Length; i++)
            {
                if (ValueCash[i] != 0)
                {
                    Average += ValueCash[i];
                    k++;
                }
            }

            AverageValue = Math.Round(Average / k, 1);

            WriteAverageValue();
        }

        /// <summary>
        /// Записать текущее значение
        /// </summary>
        private void WriteCurrentValue()
        {
            for (int i = ValueCash.Length - 1; i > 0; i--)
            {
                ValueCash[i] = ValueCash[i - 1];
            }

            ValueCash[0] = CurrentValue;
        }

        /// <summary>
        /// Записать среднее значение
        /// </summary>
        private void WriteAverageValue()
        {
            for (int i = AverageValueCash.Length - 1; i > 0; i--)
            {
                AverageValueCash[i] = AverageValueCash[i - 1];
            }

            AverageValueCash[0] = AverageValue;
        }

        /// <summary>
        /// Выставить текущее значенее
        /// </summary>
        /// <param name="value">Значенее</param>
        public void SetCurrentValue(double value)
        {
            CurrentValue = value;
            WriteCurrentValue();
        }

        /// <summary>
        /// Отрисовать график на элементе chart
        /// </summary>
        /// <param name="chart">Элемент chart для отрисовки</param>
        public void FillChart(Chart chart)
        {
            //Очистка графика
            chart.Series[0].Points.Clear();
            chart.Series[1].Points.Clear();

            //Отрисовка графика
            for (int i = AverageValueCash.Length - 1; i >= 0; i--)
            {               
                chart.Series[1].Points.Add(AverageValueCash[i]);
                chart.Series[0].Points.Add(ValueCash[i]);
            }
        }

        /// <summary>
        /// Расчитать проноз значения
        /// </summary>
        public void GetForecastValue()
        {
            double MathMean = (Minimum + Maximum) / 2;

            if(CurrentValue > MathMean)
            {
                Forecast = Math.Round((CurrentValue + Minimum) / 2,1);
            }
            else
            {
                Forecast = Math.Round((CurrentValue + Maximum) / 2,1);
            }
        }
    }

    /// <summary>
    /// Барометр
    /// </summary>
    public class Barometer : MeasurementParameter
    {
        
        public Barometer()
        {
            Minimum = 740;
            Maximum = 760;
        }
    }

    /// <summary>
    /// Анемометр
    /// </summary>
    public class Anemometer : MeasurementParameter
    {
        public Anemometer()
        {
            Minimum = 0;
            Maximum = 14;
        }
    }
}
