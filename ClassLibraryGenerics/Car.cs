namespace ClassLibraryGenerics {
    /// <summary>
    /// Перечисление "Цвет".
    /// </summary>
    public enum Color {
        White,
        Gray,
        Black,
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Indigo,
        Violet
    }

    /// <summary>
    /// Класс "Автомобиль".
    /// </summary>
    public class Car : IType {
        #region Поля
        private static string[] brands = new string[] { "Audi", "BMW", "Ford", "Honda", "Hyundai", "Kia", "Lada", "Mazda", "Mercedes-Benz", "Mitsubishi", "Nissan", "Renault", "Skoda", "Toyota", "Volkswagen", "Lexus", "Subaru", "Suzuki", "Cadillac", "Chevrolet", "Hummer", "Jeep", "Tesla", "Opel", "Porsche", "Bentley", "Bugatti", "Citroen", "Ferrari", "Fiat", "Jaguar", "Lamborghini", "Land Rover", "Maserati", "Maybach", "Peugeot", "Rolls-Royce", "Rover", "Volvo", "Smart" };

        private string brand;  // марка
        private int year;  // год выпуска
        private double maxSpeed;  // максимальная скорость (км/ч)
        private double volume;  // объем двигателя (л)
        private Color color;  // цвет
        private double mileage;  // пробег (км)

        /// <summary>
        /// Марка автомобиля.
        /// </summary>
        public string Brand {
            get { return brand; }
        }

        /// <summary>
        /// Год выпуска автомобиля.
        /// </summary>
        public int Year {
            get { return year; }
        }

        /// <summary>
        /// Максимальная скорость автомобиля (км/ч).
        /// </summary>
        public double MaxSpeed {
            get { return maxSpeed; }
        }

        /// <summary>
        /// Объем двигателя автомобиля (л).
        /// </summary>
        public double Volume {
            get { return volume; }
        }

        /// <summary>
        /// Цвет автомобиля.
        /// </summary>
        public Color Color {
            get { return color; }
        }

        /// <summary>
        /// Пробег автомобиля (км).
        /// </summary>
        public double Mileage {
            get { return mileage; }
        }
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Car() {
            Color[] colors = new Color[] { Color.Red, Color.Green, Color.Blue, Color.Gray, Color.White, Color.Black };
            Random r = new Random();
            brand = brands[r.Next(0, brands.Length - 1)];
            year = r.Next(1990, 2020);
            maxSpeed = r.Next(160, 230);
            volume = 10 + r.NextDouble() * 4;
            color = colors[r.Next(0, colors.Length - 1)];
            mileage = r.NextDouble() * 1000000;
        }

        /// <summary>
        /// Конструктор по переданным параметрам.
        /// </summary>
        public Car(string brand, int year, double maxSpeed, double volume, Color color, double mileage) {
            this.brand = brand;
            this.year = year;
            this.maxSpeed = maxSpeed;
            this.volume = volume;
            this.color = color;
            this.mileage = mileage;
        }
        #endregion

        #region Переопределение ToString()
        /// <summary>
        /// Переопределение метода ToString().
        /// </summary>
        /// <returns> строковое представление полей класса </returns>
        public override string ToString() {
            return $"Брэнд: {brand}\n" + $"Год Выпуска: {year}\n" + $"Пробег: {mileage}\n" + $"Максимальная Скорость: {maxSpeed}\n" + $"Цвет: {color}\n" + $"Объем Двигателя: {volume}";
        }
        #endregion

        #region Методы для сравнения
        /// <summary>
        /// Сравнение автомобилей по марке (по алфавиту).
        /// </summary>
        /// <param name="c1"> первый автомобиль </param>
        /// <param name="c2"> второй автомобиль </param>
        /// <returns> Если результат "больше" : 1; "меньше" : -1; "равно" : 0 </returns>
        public static int ComparerBrandAlphabet(Car c1, Car c2) {
            return c1.Brand.CompareTo(c2.Brand);
        }

        /// <summary>
        /// Сравнение автомобилей по марке (по длине).
        /// </summary>
        /// <param name="c1"> первый автомобиль </param>
        /// <param name="c2"> второй автомобиль </param>
        /// <returns> Если результат "больше" : 1; "меньше" : -1; "равно" : 0 </returns>
        public static int ComparerBrandLength(Car c1, Car c2) {
            return c1.Brand.Length.CompareTo(c2.Brand.Length);
        }

        /// <summary>
        /// Сравнение автомобилей по году выпуска.
        /// </summary>
        /// <param name="c1"> первый автомобиль </param>
        /// <param name="c2"> второй автомобиль </param>
        /// <returns> Если результат "больше" : 1; "меньше" : -1; "равно" : 0 </returns>
        public static int ComparerYear(Car c1, Car c2) {
            if (c1.Year > c2.Year)
                return 1;
            else if (c1.Year < c2.Year)
                return -1;
            else
                return 0;
        }

        /// <summary>
        /// Сравнение автомобилей по максимальной скорости.
        /// </summary>
        /// <param name="c1"> первый автомобиль </param>
        /// <param name="c2"> второй автомобиль </param>
        /// <returns> Если результат "больше" : 1; "меньше" : -1; "равно" : 0 </returns>
        public static int ComparerMaxSpeed(Car c1, Car c2) {
            if (c1.MaxSpeed > c2.MaxSpeed)
                return 1;
            else if (c1.MaxSpeed < c2.MaxSpeed)
                return -1;
            else
                return 0;
        }

        /// <summary>
        /// Сравнение автомобилей по объему двигателя.
        /// </summary>
        /// <param name="c1"> первый автомобиль </param>
        /// <param name="c2"> второй автомобиль </param>
        /// <returns> Если результат "больше" : 1; "меньше" : -1; "равно" : 0 </returns>
        public static int ComparerVolume(Car c1, Car c2) {
            if (c1.Volume > c2.Volume)
                return 1;
            else if (c1.Volume < c2.Volume)
                return -1;
            else
                return 0;
        }

        /// <summary>
        /// Сравнение автомобилей по цвету (по перечислению).
        /// </summary>
        /// <param name="c1"> первый автомобиль </param>
        /// <param name="c2"> второй автомобиль </param>
        /// <returns> Если результат "больше" : 1; "меньше" : -1; "равно" : 0 </returns>
        public static int ComparerColor(Car c1, Car c2) {
            if (c1.color > c2.color)
                return 1;
            else if (c1.color < c2.color)
                return -1;
            else
                return 0;
        }

        /// <summary>
        /// Сравнение автомобилей по пробегу.
        /// </summary>
        /// <param name="c1"> первый автомобиль </param>
        /// <param name="c2"> второй автомобиль </param>
        /// <returns> Если результат "больше" : 1; "меньше" : -1; "равно" : 0 </returns>
        public static int ComparerMileage(Car c1, Car c2) {
            if (c1.Mileage > c2.Mileage)
                return 1;
            else if (c1.Mileage < c2.Mileage)
                return -1;
            else
                return 0;
        }

        /// <summary>
        /// Сравнение автомобилей в следующем порядке: максимальная скорость - объем двигателя - пробег - год выпуска.
        /// </summary>
        /// <param name="c1"> первый автомобиль </param>
        /// <param name="c2"> второй автомобиль </param>
        /// <returns> Если результат "больше" : 1; "меньше" : -1; "равно" : 0 </returns>
        public static int ComparerComplex(Car c1, Car c2) {
            int n = ComparerMaxSpeed(c1, c2);
            if (n != 0) return n;
            n = ComparerVolume(c1, c2);
            if (n != 0) return n;
            n = ComparerMileage(c1, c2);
            if (n != 0) return n;
            return ComparerYear(c1, c2);
        }
        #endregion
    }
}