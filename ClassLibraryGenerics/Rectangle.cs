namespace ClassLibraryGenerics
{
    /// <summary>
    /// Класс "Прямоугольник".
    /// </summary>
    public class Rectangle: IType
    {
        #region Поля
        private double a;  // меньшая сторона прямоугольника
        private double b;  // большая сторона прямоугольника

        /// <summary>
        /// Меньшая сторона прямоугольника.
        /// </summary>
        public double A
        {
            get { return a; }
        }

        /// <summary>
        /// Большая сторона прямоугольника.
        /// </summary>
        public double B
        {
            get { return b; }
        }

        /// <summary>
        /// Периметр прямоугольника.
        /// </summary>
        public double Perimeter 
        {
            get { return 2 * (a + b); }
        }

        /// <summary>
        /// Площадь прямоугольника.
        /// </summary>
        public double Area 
        {
            get { return a * b; }
        }
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Rectangle()
        {
            Random r = new Random();
            a = r.NextDouble() * 50;
            b = r.NextDouble() * 50;
        }

        /// <summary>
        /// Конструктор по переданным сторонам.
        /// </summary>
        /// <param name="a"> первая сторона </param>
        /// <param name="b"> вторая сторона </param>
        public Rectangle(double a, double b)
        {
            if (a > b)
                (a, b) = (b, a);
            this.a = a;
            this.b = b;
        }
        #endregion

        #region Переопределение ToString()
        /// <summary>
        /// Переопределение метода ToString().
        /// </summary>
        /// <returns> строковое представление полей класса </returns>
        public override string ToString()
        {
            return $"Сторона А: {A}\n" + $"Сторона Б: {B}\n" + $"Периметр: {Perimeter}\n" + $"Площадь: {Area}";
        }
        #endregion

        #region Методы для сравнения
        /// <summary>
        /// Сравнение прямоугольников по периметру.
        /// </summary>
        /// <param name="r1"> первый прямоугольник </param>
        /// <param name="r2"> второй прямоугольник </param>
        /// <returns> Если результат "больше" : 1; "меньше" : -1; "равно" : 0 </returns>
        public static int ComparerPerimeter(Rectangle r1, Rectangle r2)
        {
            if (r1.Perimeter > r2.Perimeter)
                return 1;
            else if (r1.Perimeter < r2.Perimeter)
                return -1;
            else
                return 0;
        }

        /// <summary>
        /// Сравнение прямоугольников по площади.
        /// </summary>
        /// <param name="r1"> первый прямоугольник </param>
        /// <param name="r2"> второй прямоугольник </param>
        /// <returns> Если результат "больше" : 1; "меньше" : -1; "равно" : 0 </returns>
        public static int ComparerArea(Rectangle r1, Rectangle r2)
        {
            if (r1.Area > r2.Area)
                return 1;
            else if (r1.Area < r2.Area)
                return -1;
            else
                return 0;
        }

        /// <summary>
        /// Сравнение прямоугольников по меньшей стороне.
        /// </summary>
        /// <param name="r1"> первый прямоугольник </param>
        /// <param name="r2"> второй прямоугольник </param>
        /// <returns> Если результат "больше" : 1; "меньше" : -1; "равно" : 0 </returns>
        public static int ComparerMinSide(Rectangle r1, Rectangle r2)
        {
            if (r1.A > r2.A)
                return 1;
            else if (r1.A < r2.A)
                return -1;
            else
                return 0;
        }

        /// <summary>
        /// Сравнение прямоугольников по большей стороне.
        /// </summary>
        /// <param name="r1"> первый прямоугольник </param>
        /// <param name="r2"> второй прямоугольник </param>
        /// <returns> Если результат "больше" : 1; "меньше" : -1; "равно" : 0 </returns>
        public static int ComparerMaxSide(Rectangle r1, Rectangle r2)
        {
            if (r1.B > r2.B)
                return 1;
            else if (r1.B < r2.B)
                return -1;
            else
                return 0;
        }

        /// <summary>
        /// Сравнение прямоугольников по сторонам, сначала по меньшей стороне, если равны - то по большей.
        /// </summary>
        /// <param name="r1"> первый прямоугольник </param>
        /// <param name="r2"> второй прямоугольник </param>
        /// <returns> Если результат "больше" : 1; "меньше" : -1; "равно" : 0 </returns>
        public static int ComparerSides(Rectangle r1, Rectangle r2)
        {
            int n = ComparerMinSide(r1, r2);
            if (n != 0) return n;
            return ComparerMaxSide(r1, r2);
        }
        #endregion
    }
}