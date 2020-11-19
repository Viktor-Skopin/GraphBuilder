using System;
using System.Windows.Forms;
using MeterReadingsLibrary;

namespace GraphForms
{
    public partial class MainForm : Form
    {
        Barometer barometer = new Barometer();
        Anemometer anemometer = new Anemometer();

        public MainForm()
        {
            InitializeComponent();
            MainTimer.Start();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            //Барометр
            //Вывод текущего значения
            barometer.SetCurrentValue(IndicationEmulator.GetRandomValue(740, 760));
            BarCurTB.Text = Convert.ToString(barometer.CurrentValue);
            //Вывод среднего значения
            barometer.CalculateAverage();
            BarAveTB.Text = Convert.ToString(barometer.AverageValue);
            //Отрисовка графика
            barometer.FillChart(BarometrChart);
            //Вывод прогноза
            barometer.GetForecastValue();
            BarForTB.Text = Convert.ToString(barometer.Forecast);

            //Анемометр
            //Вывод текущего значения
            anemometer.SetCurrentValue(IndicationEmulator.GetRandomValue(0, 14));
            AneCurTB.Text = Convert.ToString(anemometer.CurrentValue);
            //Вывод среднего значения
            anemometer.CalculateAverage();
            AneAveTB.Text = Convert.ToString(anemometer.AverageValue);
            //Отрисовка графика
            anemometer.FillChart(AnemometerChart);
            //Вывод прогноза
            anemometer.GetForecastValue();
            AneForTB.Text = Convert.ToString(anemometer.Forecast);
        }
    }
}
