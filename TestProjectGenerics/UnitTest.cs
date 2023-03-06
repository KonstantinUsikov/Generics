using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraryGenerics;

namespace TestProjectGenerics {
    [TestClass]
    public class UnitTest {
        [TestMethod]
        public void BubleSortTest() {
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
        public void InsertSortTest() {
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
        public void MergeSortTest() {
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
        public void QuickSortTest() {
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
        public void AllSortsTest() {
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
            for (int i = 0; i < arr1.Length; i++) {
                Assert.AreEqual(arr1[i], arr2[i]);
                Assert.AreEqual(arr1[i], arr3[i]);
                Assert.AreEqual(arr1[i], arr4[i]);
                Assert.AreEqual(arr2[i], arr3[i]);
                Assert.AreEqual(arr2[i], arr4[i]);
                Assert.AreEqual(arr3[i], arr4[i]);
            }
        }

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
}