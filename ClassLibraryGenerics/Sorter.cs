namespace ClassLibraryGenerics
{
    /// <summary>
    /// Статический класс для универсальной сортировки.
    /// </summary>
    public static class Sorter
    {
        #region Сортировка пузырьком O(N^2)
        /// <summary>
        /// Сортировка пузырьком.
        /// </summary>
        /// <typeparam name="T"> тип массива </typeparam>
        /// <param name="arr"> массив для сортировки </param>
        /// <param name="ascending"> если по возрастанию - true, иначе - false </param>
        public static void BubbleSort<T>(T[] arr, Func<T, T, int> comparer, bool ascending) 
        {
            bool swaps;
            for (int i = arr.Length - 1; i > 0; i--)
            {
                swaps = false;
                for (int j = 0; j < i; j++)
                    if (comparer(arr[j], arr[j + 1]) == 1)
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                        swaps = true;
                    }
                if (!swaps)
                    break;
            }
            if (!ascending)
                Array.Reverse(arr);
        }
        #endregion

        #region Сортировка вставками O(N^2)
        /// <summary>
        /// Сортировка вставками.
        /// </summary>
        /// <typeparam name="T"> тип массива </typeparam>
        /// <param name="arr"> массив для сортировки </param>
        /// <param name="ascending"> если по возрастанию - true, иначе - false </param>
        public static void InsertSort<T>(T[] arr, Func<T, T, int> comparer, bool ascending)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int j = i;
                while (comparer(arr[j], arr[j - 1]) == -1)
                {
                    (arr[j], arr[j - 1]) = (arr[j - 1], arr[j]);
                    j--;
                    if (j == 0)
                        break;
                }
            }
            if (!ascending)
                Array.Reverse(arr);
        }
        #endregion

        #region Сортировка слиянием O(N * logN)
        /// <summary>
        /// Сортировка слиянием.
        /// </summary>
        /// <typeparam name="T"> тип массива </typeparam>
        /// <param name="arr"> массив для сортировки </param>
        /// <param name="ascending"> если по возрастанию - true, иначе - false </param>
        public static void MergeSort<T>(T[] arr, Func<T, T, int> comparer, bool ascending) 
        {
            MergeSortRange(arr, comparer, 0, arr.Length - 1);
            if (!ascending)
                Array.Reverse(arr);
        }

        /// <summary>
        /// Сортировка слиянием.
        /// </summary>
        /// <typeparam name="T"> тип массива </typeparam>
        /// <param name="arr"> массив для сортировки </param>
        /// <param name="ascending"> если по возрастанию - true, иначе - false </param>
        /// <param name="left"> левая граница сортировки (как правило, 0) </param>
        /// <param name="right"> правая граница сортировки (как правило, длина массива - 1) </param>
        public static void MergeSortRange<T>(T[] arr, Func<T, T, int> comparer, int left, int right) 
        {
            if (right - left > 1)
            {
                int a1 = left;
                int b1 = (left + right) / 2;
                int a2 = (left + right) / 2 + 1;
                int b2 = right;
                MergeSortRange(arr, comparer, a1, b1);
                MergeSortRange(arr, comparer, a2, b2);
                T[] M = new T[right - left + 1];
                for (int k = left; k <= right; k++)
                    M[k - left] = arr[k];
                int i = a1;
                int j = a2;
                for (int k = left; k <= right; k++)
                    if (i <= b1 && j <= b2)
                        if (comparer(M[i - left], M[j - left]) == -1)
                        {
                            arr[k] = M[i - left];
                            i++;
                        }
                        else
                        {
                            arr[k] = M[j - left];
                            j++;
                        }
                    else if (i > b1)
                    {
                        arr[k] = M[j - left];
                        j++;
                    }
                    else
                    {
                        arr[k] = M[i - left];
                        i++;
                    }

            }
            else if (right - left == 1 && comparer(arr[left], arr[right]) == 1)
                (arr[left], arr[right]) = (arr[right], arr[left]);
        }
        #endregion

        #region Быстрая сортировка O(N * logN)
        /// <summary>
        /// Быстрая сортировка.
        /// </summary>
        /// <typeparam name="T"> тип массива </typeparam>
        /// <param name="arr"> массив для сортировки </param>
        /// <param name="ascending"> если по возрастанию - true, иначе - false </param>
        public static void QuickSort<T>(T[] arr, Func<T, T, int> comparer, bool ascending)
        {
            QuickSortRange(arr, comparer, 0, arr.Length - 1);
            if (!ascending)
                Array.Reverse(arr);
        }

        /// <summary>
        /// Быстрая сортировка.
        /// </summary>
        /// <typeparam name="T"> тип массива </typeparam>
        /// <param name="arr"> массив для сортировки </param>
        /// <param name="ascending"> если по возрастанию - true, иначе - false </param>
        /// <param name="left"> левая граница сортировки (как правило, 0) </param>
        /// <param name="right"> правая граница сортировки (как правило, длина массива - 1) </param>
        public static void QuickSortRange<T>(T[] arr, Func<T, T, int> comparer, int left, int right) 
        {
            int a = left;
            int b = right;
            T p = arr[(left + right) / 2];
            while (a < b)
            {
                while (comparer(arr[a], p) == -1)
                    a++;
                while (comparer(arr[b], p) == 1)
                    b--;
                if (a <= b)
                {
                    (arr[a], arr[b]) = (arr[b], arr[a]);
                    a++;
                    b--;
                }
            }
            if (left < b)
                QuickSortRange(arr, comparer, left, b);
            if (a < right)
                QuickSortRange(arr, comparer, a, right);
        }
        #endregion
    }
}