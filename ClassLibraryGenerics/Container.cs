namespace ClassLibraryGenerics
{
    /// <summary>
    /// Класс "Контейнер".
    /// </summary>
    /// <typeparam name="T"> тип данных, хранящихся в контейнере </typeparam>
    public abstract class Container<T>
    {
        #region Поля
        protected T[] values;  // массив для хранения элементов
        protected int count;  // количество элементов в контейнере
        protected int capacity;  // максимальная вместимость 
        protected int first;  // индекс первого элемента в контейнере
        protected int last;  // индекс последнего элемента в контейнере

        /// <summary>
        /// Массив для хранения элементов.
        /// </summary>
        public T[] Values
        {
            get { return values; }
        }

        /// <summary>
        /// Количество элементов в контейнере.
        /// </summary>
        public int Count
        {
            get { return count; }
        }

        /// <summary>
        /// Максимальная вместимость.
        /// </summary>
        public int Capacity
        {
            get { return capacity; }
        }

        /// <summary>
        /// Индекс первого элемента в контейнере.
        /// </summary>
        public int First
        {
            get { return first; }
        }

        /// <summary>
        /// Индекс последнего элемента в контейнере.
        /// </summary>
        public int Last
        {
            get { return last; }
        }
        #endregion

        #region Переопределение ToString()
        /// <summary>
        /// Переопределение метода ToString().
        /// </summary>
        /// <returns> строковое представление элементов контейнера </returns>
        public override string ToString()
        {
            string res = "";
            if (first < last)
            {
                for (int i = first; i <= last; i++)
                    res += $"{values[i]} ";
            }
            else if (last < first)
            {
                for (int i = first; i < count; i++)
                    res += $"{values[i]} ";
                for (int i = 0; i <= last; i++)
                    res += $"{values[i]} ";
            }
            else if (first != -1 && last != -1)
            {
                res = values[first].ToString();
            }
            return res;
        }

        /// <summary>
        /// Получение всей информации о контейнере.
        /// </summary>
        /// <returns> массив всех элементов, все поля класса </returns>
        public virtual string GetInfo()
        {
            string res = "";
            for (int i = 0; i < capacity; i++)
            {
                res += $"{values[i]} ";
            }
            return res + '\n' + $"count: {count}, capacity: {capacity}, first: {first}, last: {last}";
        }
        #endregion

        #region Абстрактные методы
        /// <summary>
        /// Абстрактный метод для добавления элемента в контейнер.
        /// </summary>
        /// <param name="value"> значение, которое будет добавлено в контейнер </param>
        public abstract void Add(T value);

        /// <summary>
        /// Абстрактный метод для удаления элемента из контейнера.
        /// </summary>
        /// <returns> значение, которое было удалено из контейнера </returns>
        public abstract T Remove();

        /// <summary>
        /// Абстрактный метод для просмотра верхнего элемента в контейнере.
        /// </summary>
        /// <returns> значение верхнего элемента в контейнере </returns>
        public abstract T Peek();
        #endregion
    }
}