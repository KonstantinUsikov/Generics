namespace ClassLibraryGenerics
{
    /// <summary>
    /// Класс "Стек".
    /// </summary>
    /// <typeparam name="T"> тип данных, хранящихся в стеке </typeparam>
    public class MyStack<T> : Container<T>
    {
        #region Конструкторы
        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public MyStack()
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
        public MyStack(int capacity)
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
        /// Добавление элемента в стек.
        /// </summary>
        /// <param name="value"> значение, которое будет добавлено в стек </param>
        public override void Add(T value)
        {
            if (count == capacity)
            {
                capacity = capacity == 0 ? 1 : 2 * capacity;
                T[] newValues = new T[capacity];
                for (int i = 0; i <= capacity / 2 - 1; i++)
                    newValues[i] = values[i];
                values = newValues;
            }
            if (first == -1)
                first = last = 0;
            else
                last = count;
            values[count] = value;
            count++;
        }

        /// <summary>
        /// Удаление элемента из стека.
        /// </summary>
        /// <returns> значение, которое было удалено из стека </returns>
        public override T Remove()
        {
            if (count == 0)
                throw new Exception("Stack is empty!");
            count--;
            T res = values[count];
            values[count] = default(T);
            if (count == 0)
                first = last = -1;
            else
                last = count - 1;
            return res;
        }

        /// <summary>
        /// Просмотр верхнего элемента в стеке.
        /// </summary>
        /// <returns> верхний элемент в стеке </returns>
        public override T Peek()
        {
            if (count == 0)
                throw new Exception("Stack is empty!");
            return values[count - 1];
        }
        #endregion
    }
}