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
    }
}