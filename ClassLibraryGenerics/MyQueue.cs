namespace ClassLibraryGenerics
{
    /// <summary>
    /// Класс "Очередь".
    /// </summary>
    /// <typeparam name="T"> тип данных, хранящихся в очереди </typeparam>
    public class MyQueue<T> : Container<T>
    {
        #region Конструкторы
        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public MyQueue()
        {
            count = 0;
            capacity = 0;
            values = new T[0];
            first = -1;
            last = -1;
        }

        /// <summary>
        /// Конструктор по вместимости.
        /// </summary>
        /// <param name="capacity"> вместимость </param>
        public MyQueue(int capacity)
        {
            count = 0;
            this.capacity = capacity;
            values = new T[capacity];
            first = -1;
            last = -1;
        }
        #endregion

        #region Методы
        /// <summary>
        /// Добавление элемента в очередь.
        /// </summary>
        /// <param name="value"> значение, которое будет добавлено в очередь </param>
        public override void Add(T value)
        {
            if (count == capacity)
            {
                capacity = capacity == 0 ? 1 : 2 * capacity;
                T[] newValues = new T[capacity];
                int ind = 0;
                if (first < last)
                {
                    for (int i = first; i <= last; i++)
                        newValues[ind++] = values[i];
                }
                else if (last < first)
                {
                    for (int i = first; i < capacity; i++)
                        newValues[ind++] = values[i];
                    for (int i = 0; i <= last; i++)
                        newValues[ind++] = values[i];
                }
                else if (first != -1 && last != -1)
                {
                    newValues[0] = values[0];
                }
                values = newValues;
            }
            if (first == -1)
                first = last = 0;
            else
                last = last == capacity - 1 ? 0 : last + 1;
            values[last] = value;
            count++;
        }

        /// <summary>
        /// Удаление элемента из очереди.
        /// </summary>
        /// <returns> значение, которое было удалено из очереди </returns>
        public override T Remove()
        {
            if (count == 0)
                throw new Exception("Queue is empty!");
            T res = values[first];
            values[first] = default(T);
            count--;
            if (count == 0)
                first = last = -1;
            else
                first = first == capacity - 1 ? 0 : first + 1;
            return res;
        }

        /// <summary>
        /// Просмотр первого элемента в очереди.
        /// </summary>
        /// <returns> первый элемент в очереди </returns>
        public override T Peek()
        {
            if (count == 0)
                throw new Exception("Queue is empty!");
            return values[first];
        }
        #endregion
    }
}