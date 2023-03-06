using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraryGenerics;
using System;

namespace TestProjectGenerics
{
    [TestClass]
    public class SortUnitTest
    {
        [TestMethod]
        public void BubleSortTest()
        {
            Rectangle rect1 = new Rectangle(5, 6);
            Rectangle rect2 = new Rectangle(10, 12);
            Rectangle rect3 = new Rectangle(3, 13);
            Rectangle rect4 = new Rectangle(2, 20);
            Rectangle rect5 = new Rectangle(5, 4);
            Rectangle[] arr = new Rectangle[] { rect1, rect2, rect3, rect4, rect5 };
            Sorter.BubbleSort(arr, Rectangle.ComparerMinSide, true);
            Assert.AreSame(arr[0], rect4);
            Assert.AreSame(arr[1], rect3);
            Assert.AreSame(arr[2], rect5);
            Assert.AreSame(arr[3], rect1);
            Assert.AreSame(arr[4], rect2);
        }

        [TestMethod]
        public void InsertSortTest()
        {
            Rectangle rect1 = new Rectangle(5, 6);
            Rectangle rect2 = new Rectangle(10, 12);
            Rectangle rect3 = new Rectangle(3, 13);
            Rectangle rect4 = new Rectangle(2, 20);
            Rectangle rect5 = new Rectangle(5, 4);
            Rectangle[] arr = new Rectangle[] { rect1, rect2, rect3, rect4, rect5 };
            Sorter.InsertSort(arr, Rectangle.ComparerMinSide, true);
            Assert.AreSame(arr[0], rect4);
            Assert.AreSame(arr[1], rect3);
            Assert.AreSame(arr[2], rect5);
            Assert.AreSame(arr[3], rect1);
            Assert.AreSame(arr[4], rect2);
        }

        [TestMethod]
        public void MergeSortTest()
        {
            Rectangle rect1 = new Rectangle(5, 6);
            Rectangle rect2 = new Rectangle(10, 12);
            Rectangle rect3 = new Rectangle(3, 13);
            Rectangle rect4 = new Rectangle(2, 20);
            Rectangle rect5 = new Rectangle(5, 4);
            Rectangle[] arr = new Rectangle[] { rect1, rect2, rect3, rect4, rect5 };
            Sorter.MergeSort(arr, Rectangle.ComparerMinSide, true);
            Assert.AreSame(arr[0], rect4);
            Assert.AreSame(arr[1], rect3);
            Assert.AreSame(arr[2], rect5);
            Assert.AreSame(arr[3], rect1);
            Assert.AreSame(arr[4], rect2);
        }

        [TestMethod]
        public void QuickSortTest()
        {
            Rectangle rect1 = new Rectangle(5, 6);
            Rectangle rect2 = new Rectangle(10, 12);
            Rectangle rect3 = new Rectangle(3, 13);
            Rectangle rect4 = new Rectangle(2, 20);
            Rectangle rect5 = new Rectangle(5, 4);
            Rectangle[] arr = new Rectangle[] { rect1, rect2, rect3, rect4, rect5 };
            Sorter.QuickSort(arr, Rectangle.ComparerMinSide, true);
            Assert.AreSame(arr[0], rect4);
            Assert.AreSame(arr[1], rect3);
            Assert.AreSame(arr[2], rect5);
            Assert.AreSame(arr[3], rect1);
            Assert.AreSame(arr[4], rect2);
        }

        [TestMethod]
        public void AllSortsTest()
        {
            Rectangle rect1 = new Rectangle(5, 6);
            Rectangle rect2 = new Rectangle(10, 12);
            Rectangle rect3 = new Rectangle(3, 13);
            Rectangle rect4 = new Rectangle(2, 20);
            Rectangle rect5 = new Rectangle(5, 4);
            Rectangle[] arr1 = new Rectangle[] { rect1, rect2, rect3, rect4, rect5 };
            Rectangle[] arr2 = new Rectangle[] { rect1, rect2, rect3, rect4, rect5 };
            Rectangle[] arr3 = new Rectangle[] { rect1, rect2, rect3, rect4, rect5 };
            Rectangle[] arr4 = new Rectangle[] { rect1, rect2, rect3, rect4, rect5 };
            Sorter.BubbleSort(arr1, Rectangle.ComparerMinSide, true);
            Sorter.InsertSort(arr2, Rectangle.ComparerMinSide, true);
            Sorter.MergeSort(arr3, Rectangle.ComparerMinSide, true);
            Sorter.QuickSort(arr4, Rectangle.ComparerMinSide, true);
            for (int i = 0; i < arr1.Length; i++)
            {
                Assert.AreEqual(arr1[i], arr2[i]);
                Assert.AreEqual(arr1[i], arr3[i]);
                Assert.AreEqual(arr1[i], arr4[i]);
                Assert.AreEqual(arr2[i], arr3[i]);
                Assert.AreEqual(arr2[i], arr4[i]);
                Assert.AreEqual(arr3[i], arr4[i]);
            }
        }
    }

    [TestClass]
    public class StackQueueUnitTest
    {
        [TestMethod]
        public void MyStackRectangleTest()
        {
            Rectangle rect1 = new Rectangle(5, 6);
            Rectangle rect2 = new Rectangle(10, 12);
            Rectangle rect3 = new Rectangle(3, 13);
            Rectangle rect4 = new Rectangle(2, 20);
            Rectangle rect5 = new Rectangle(5, 4);
            MyStack<Rectangle> st = new MyStack<Rectangle>();
            st.Add(rect1);
            st.Add(rect2);
            st.Add(rect3);
            st.Add(rect4);
            st.Add(rect5);
            Assert.AreEqual(st.Remove(), rect5);
            Assert.AreEqual(st.Remove(), rect4);
            Assert.AreEqual(st.Remove(), rect3);
            Assert.AreEqual(st.Remove(), rect2);
            Assert.AreEqual(st.Remove(), rect1);
            Assert.AreEqual(st.Count, 0);
        }

        [TestMethod]
        public void MyQueueRectangleTest()
        {
            Rectangle rect1 = new Rectangle(5, 6);
            Rectangle rect2 = new Rectangle(10, 12);
            Rectangle rect3 = new Rectangle(3, 13);
            Rectangle rect4 = new Rectangle(2, 20);
            Rectangle rect5 = new Rectangle(5, 4);
            MyQueue<Rectangle> q = new MyQueue<Rectangle>();
            q.Add(rect1);
            q.Add(rect2);
            q.Add(rect3);
            q.Add(rect4);
            q.Add(rect5);
            Assert.AreEqual(q.Remove(), rect1);
            Assert.AreEqual(q.Remove(), rect2);
            Assert.AreEqual(q.Remove(), rect3);
            Assert.AreEqual(q.Remove(), rect4);
            Assert.AreEqual(q.Remove(), rect5);
            Assert.AreEqual(q.Count, 0);
        }

        [TestMethod]
        public void MyStackCarTest()
        {
            Car car1 = new Car("BMW", 2012, 220, 1.5, Color.Black, 15000);
            Car car2 = new Car("Audi", 2018, 200, 1.8, Color.White, 55000);
            Car car3 = new Car("Renault", 2005, 185, 1.3, Color.Gray, 25000);
            MyStack<Car> st = new MyStack<Car>();
            st.Add(car1);
            st.Add(car2);
            st.Add(car3);
            Assert.AreEqual(st.Remove(), car3);
            Assert.AreEqual(st.Remove(), car2);
            Assert.AreEqual(st.Remove(), car1);
            Assert.AreEqual(st.Count, 0);
        }

        [TestMethod]
        public void MyQueueCarTest()
        {
            Car car1 = new Car("BMW", 2012, 220, 1.5, Color.Black, 15000);
            Car car2 = new Car("Audi", 2018, 200, 1.8, Color.White, 55000);
            Car car3 = new Car("Renault", 2005, 185, 1.3, Color.Gray, 25000);
            MyQueue<Car> q = new MyQueue<Car>();
            q.Add(car1);
            q.Add(car2);
            q.Add(car3);
            Assert.AreEqual(q.Remove(), car1);
            Assert.AreEqual(q.Remove(), car2);
            Assert.AreEqual(q.Remove(), car3);
            Assert.AreEqual(q.Count, 0);
        }

        [TestMethod]
        public void MyStackStudentTest()
        {
            Student student1 = new Student("Иванов", "Иван", "Иванович", 18, 180, 75, 4.5);
            Student student2 = new Student("Петров", "Петр", "Петрович", 20, 185, 85, 3.8);
            Student student3 = new Student("Александров", "Александр", "Александрович", 25, 178, 70, 4.2);
            MyStack<Student> st = new MyStack<Student>();
            st.Add(student1);
            st.Add(student2);
            st.Add(student3);
            Assert.AreEqual(st.Remove(), student3);
            Assert.AreEqual(st.Remove(), student2);
            Assert.AreEqual(st.Remove(), student1);
            Assert.AreEqual(st.Count, 0);
        }

        [TestMethod]
        public void MyQueueStudentTest()
        {
            Student student1 = new Student("Иванов", "Иван", "Иванович", 18, 180, 75, 4.5);
            Student student2 = new Student("Петров", "Петр", "Петрович", 20, 185, 85, 3.8);
            Student student3 = new Student("Александров", "Александр", "Александрович", 25, 178, 70, 4.2);
            MyQueue<Student> q = new MyQueue<Student>();
            q.Add(student1);
            q.Add(student2);
            q.Add(student3);
            Assert.AreEqual(q.Remove(), student1);
            Assert.AreEqual(q.Remove(), student2);
            Assert.AreEqual(q.Remove(), student3);
            Assert.AreEqual(q.Count, 0);
        }
    }

    [TestClass]
    public class IntegralUnitTest
    {
        [TestMethod]
        public void IntegralTest1()
        {
            double a = 1;
            double b = 2;
            int steps = 100000;
            double test = Math.Round(Mathematics.Integral((x) => x * x, a, b, steps), 2);
            double test2 = Math.Round(Mathematics.Integral((x) => x, a, b, steps), 2);
            double test3 = Math.Round(Mathematics.Integral((x) => Math.Sin(x), a, b, steps), 3);
            double test4 = Math.Round(Mathematics.Integral((x) => Math.Cos(x), a, b, steps), 3);

            Assert.AreEqual(test, 2.33);
            Assert.AreEqual(test2, 1.50);
            Assert.AreEqual(test3, 0.956);
            Assert.AreEqual(test4, 0.068);
        }

        [TestMethod]
        public void IntegralTest2()
        {
            double a = 0;
            double b = 100;
            int steps = 100000000;
            double test = Math.Round(Mathematics.Integral((x) => x * x, a, b, steps), 2);
            double test2 = Math.Round(Mathematics.Integral((x) => x, a, b, steps), 2);
            double test3 = Math.Round(Mathematics.Integral((x) => Math.Sin(x), a, b, steps), 3);
            double test4 = Math.Round(Mathematics.Integral((x) => Math.Cos(x), a, b, steps), 3);

            Assert.AreEqual(test, 333333.33);
            Assert.AreEqual(test2, 5000.00);
            Assert.AreEqual(test3, 0.138);
            Assert.AreEqual(test4, -0.506);
        }

        [TestMethod]
        public void IntegralParallelTest1()
        {
            double a = 1;
            double b = 2;
            int steps = 100000;
            double test = Math.Round(Mathematics.IntegralParallel((x) => x * x, a, b, steps), 2);
            double test2 = Math.Round(Mathematics.IntegralParallel((x) => x, a, b, steps), 2);
            double test3 = Math.Round(Mathematics.IntegralParallel((x) => Math.Sin(x), a, b, steps), 3);
            double test4 = Math.Round(Mathematics.IntegralParallel((x) => Math.Cos(x), a, b, steps), 3);

            Assert.AreEqual(test, 2.33);
            Assert.AreEqual(test2, 1.50);
            Assert.AreEqual(test3, 0.956);
            Assert.AreEqual(test4, 0.068);
        }

        [TestMethod]
        public void IntegralParallelTest2()
        {
            double a = 0;
            double b = 100;
            int steps = 100000000;
            double test = Math.Round(Mathematics.IntegralParallel((x) => x * x, a, b, steps), 2);
            double test2 = Math.Round(Mathematics.IntegralParallel((x) => x, a, b, steps), 2);
            double test3 = Math.Round(Mathematics.IntegralParallel((x) => Math.Sin(x), a, b, steps), 3);
            double test4 = Math.Round(Mathematics.IntegralParallel((x) => Math.Cos(x), a, b, steps), 3);

            Assert.AreEqual(test, 333333.33);
            Assert.AreEqual(test2, 5000.00);
            Assert.AreEqual(test3, 0.138);
            Assert.AreEqual(test4, -0.506);
        }

        [TestMethod]
        public void AllIntegralTest()
        {
            double a = 3;
            double b = 10;
            int steps = 100000000;
            double integralTest = Math.Round(Mathematics.IntegralParallel((x) => x * x, a, b, steps), 2);
            double integralTest2 = Math.Round(Mathematics.IntegralParallel((x) => x, a, b, steps), 2);
            double integralTest3 = Math.Round(Mathematics.IntegralParallel((x) => Math.Sin(x), a, b, steps), 3);
            double integralTest4 = Math.Round(Mathematics.IntegralParallel((x) => Math.Cos(x), a, b, steps), 3);
            double integralParallelTest = Math.Round(Mathematics.IntegralParallel((x) => x * x, a, b, steps), 2);
            double integralParallelTest2 = Math.Round(Mathematics.IntegralParallel((x) => x, a, b, steps), 2);
            double integralParallelTest3 = Math.Round(Mathematics.IntegralParallel((x) => Math.Sin(x), a, b, steps), 3);
            double integralParallelTest4 = Math.Round(Mathematics.IntegralParallel((x) => Math.Cos(x), a, b, steps), 3);

            Assert.AreEqual(integralTest, 324.33);
            Assert.AreEqual(integralTest2, 45.50);
            Assert.AreEqual(integralTest3, -0.151);
            Assert.AreEqual(integralTest4, -0.685);

            Assert.AreEqual(integralTest, integralParallelTest);
            Assert.AreEqual(integralTest2, integralParallelTest2);
            Assert.AreEqual(integralTest3, integralParallelTest3);
            Assert.AreEqual(integralTest4, integralParallelTest4);
        }
    }
}