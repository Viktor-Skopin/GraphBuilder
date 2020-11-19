using System;

namespace MeterReadingsLibrary
{
    public static class IndicationEmulator
    {
        /// <summary>
        /// Возвращает случайное число в заданном диапазоне
        /// </summary>
        /// <param name="MinimuValue">Минимальное значение</param>
        /// <param name="MaximimValue">Максимальное значение</param>
        /// <returns>Случайное число</returns>
        static public double GetRandomValue(double MinimuValue, double MaximimValue)
        {
            Random rnd = new Random();
            return Math.Round(rnd.NextDouble() * (MaximimValue - MinimuValue) + MinimuValue, 1);           
        }
    }
}
