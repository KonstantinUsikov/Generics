namespace ClassLibraryGenerics
{
    /// <summary>
    /// Статический класс для вычисления определенных интегралов.
    /// </summary>
    public static class Mathematics
    {
        /// <summary>
        /// Вычисление определенного интеграла.
        /// </summary>
        /// <param name="func"> подынтегральная функция </param>
        /// <param name="a"> нижний предел интегрирования </param>
        /// <param name="b"> верхний предел интегрирования </param>
        /// <param name="steps"> количество шагов </param>
        /// <returns> значение интеграла </returns>
        public static double Integral(Func<double, double> func, double a, double b, int steps)
        {
            double res = 0;
            double step = (b - a) / steps;
            double prev = func(a);
            for (int i = 1; i <= steps; i++)
            {
                double cur = func(a + i * step);
                res += 0.5 * step * (prev + cur);
                prev = cur;
            }
            return res;
        }

        /// <summary>
        /// Параллельное вычисление определенного интеграла.
        /// </summary>
        /// <param name="func"> подынтегральная функция </param>
        /// <param name="a"> нижний предел интегрирования </param>
        /// <param name="b"> верхний предел интегрирования </param>
        /// <param name="steps"> количество шагов </param>
        /// <returns> значение интеграла </returns>
        public static double IntegralParallel(Func<double, double> func, double a, double b, int steps)
        {
            double res = 0;
            double step = (b - a) / steps;  
            double[] values = new double[steps + 1];
            Parallel.For(0, steps + 1, i =>
                values[i] = func(a + step * i));
            for (int i = 0; i < steps; i++)
                res += values[i] + values[i + 1];
            res *= 0.5 * step;
            return res;
        }
    }
}