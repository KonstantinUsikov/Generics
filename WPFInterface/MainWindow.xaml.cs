using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClassLibraryGenerics;
using Color = ClassLibraryGenerics.Color;
using ComboBoxItem = System.Windows.Controls.ComboBoxItem;
using Rectangle = ClassLibraryGenerics.Rectangle;

namespace WPFInterface {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        #region Integral

        void Try_Calc_Integral(object sender, object e) {
            if (!IsInitialized) return;
            bool failed = false;
            if (!Check_Double(Tx_Left.Text)) {
                Tx_Left.Background = Brushes.Red;
                failed = true;
            } else Tx_Left.Background = Brushes.White;
            if (!Check_Double(Tx_Right.Text)) {
                Tx_Right.Background = Brushes.Red;
                failed = true;
            } else Tx_Right.Background = Brushes.White;
            if (!Check_Steps(Tx_Steps.Text)) {
                Tx_Steps.Background = Brushes.Red;
                failed = true;
            } else Tx_Steps.Background = Brushes.White;

            if (failed) return;

            Func<double, double> function;

            switch (Cb_Integral.SelectedIndex) {
                case 0:
                    function = (x) => x * x;
                    break;
                case 1:
                    function = (x) => x;
                    break;
                case 2:
                    function = (x) => Math.Sin(x);
                    break;
                case 3:
                    function = (x) => Math.Cos(x);
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }

            Stopwatch timer = Stopwatch.StartNew();
            double result;
            if (Rb_Parallel.IsChecked.Value) {
                result = Mathematics.IntegralParallel(function, double.Parse(Tx_Left.Text), double.Parse(Tx_Right.Text),
                    int.Parse(Tx_Steps.Text));
            } else {
                result = Mathematics.Integral(function, double.Parse(Tx_Left.Text), double.Parse(Tx_Right.Text),
                    int.Parse(Tx_Steps.Text));
            }

            StringBuilder sb = new();
            sb.Append($"{result}\n");
            sb.Append($"{timer.ElapsedMilliseconds}мс");
            Tx_Integral_Output.Text = sb.ToString();
        }

        bool Check_Double(string value) {
            if (!double.TryParse(value, out _)) return false;
            return true;
        }

        bool Check_Steps(string value) {
            if (!int.TryParse(value, out int parsed)) return false;
            if (parsed < 1) return false;
            return true;
        }

        #endregion

        #region Collections

        MyStack<Car> stCar = new();
        MyQueue<Car> quCar = new();

        MyStack<Student> stStudent = new();
        MyQueue<Student> quStudent = new();

        MyStack<Rectangle> stRectangle = new();
        MyQueue<Rectangle> quRectangle = new();

        private void Add_Element(object sender, RoutedEventArgs e) {
            if (!IsInitialized) return;
            string[] collections = new string[] { "Стэк", "Очередь" };
            string[] types = new string[] { "Автомобиль", "Студент", "Прямоугольник" };
            int selectedCollectionIndex = Cb_Collection.SelectedIndex;
            int selectedTypeIndex = Cb_Type_Collection.SelectedIndex;
            string selectedCollection = collections[selectedCollectionIndex];
            string selectedType = types[selectedTypeIndex];
            TextBox adder = new();
            adder.Margin = new(2);
            adder.Width = 400;
            adder.IsReadOnly = true;
            switch (selectedType) {
                case "Автомобиль": {
                        Car car = new();
                        adder.Text = car.ToString();
                        adder.Height = 170;
                        if (selectedCollection == "Стэк") {
                            stCar.Add(car);
                            WrP_Collection.Children.Insert(0, adder);
                        } else {
                            quCar.Add(car);
                            WrP_Collection.Children.Add(adder);
                        }
                        break;
                    }
                case "Студент": {
                        Student student = new();
                        adder.Text = student.ToString();
                        adder.Height = 150;
                        if (selectedCollection == "Стэк") {
                            stStudent.Add(student);
                            WrP_Collection.Children.Insert(0, adder);
                        } else {
                            quStudent.Add(student);
                            WrP_Collection.Children.Add(adder);
                        }
                        break;
                    }
                case "Прямоугольник": {
                        Rectangle rectangle = new();
                        adder.Text = rectangle.ToString();
                        adder.Height = 130;
                        if (selectedCollection == "Стэк") {
                            stRectangle.Add(rectangle);
                            WrP_Collection.Children.Insert(0, adder);
                        } else {
                            quRectangle.Add(rectangle);
                            WrP_Collection.Children.Add(adder);
                        }
                        break;
                    }
                default: {
                        break;
                    }
            }
        }

        private void Remove_Element(object sender, RoutedEventArgs e) {
            if (!IsInitialized) return;
            string[] types = new string[] { "Автомобиль", "Студент", "Прямоугольник" };
            int selectedTypeIndex = Cb_Type_Collection.SelectedIndex;
            string selectedType = types[selectedTypeIndex];
            if (Cb_Collection.SelectedIndex == 0) {
                if (selectedType == "Автомобиль")
                {
                    if (stCar.Count == 0) return;
                    stCar.Remove();
                }
                else if (selectedType == "Студент")
                {
                    if (stStudent.Count == 0) return;
                    stStudent.Remove();
                }
                else if (selectedType == "Прямоугольник")
                {
                    if (stRectangle.Count == 0) return;
                    stRectangle.Remove();
                }
                WrP_Collection.Children.RemoveAt(0);
            } else {
                if (selectedType == "Автомобиль")
                {
                    if (quCar.Count == 0) return;
                    quCar.Remove();
                }
                else if (selectedType == "Студент")
                {
                    if (quStudent.Count == 0) return;
                    quStudent.Remove();
                }
                else if (selectedType == "Прямоугольник")
                {
                    if (quRectangle.Count == 0) return;
                    quRectangle.Remove();
                }
                WrP_Collection.Children.RemoveAt(0);
            }
        }

        private void Clear_Collection(object sender, RoutedEventArgs e) {
            if (!IsInitialized) return;
            stCar = new();
            quCar = new();
            stStudent = new();
            quStudent = new();
            stRectangle = new();
            quRectangle = new();
            WrP_Collection.Children.Clear();
        }
        #endregion

        #region Sorting

        List<Student> students = new();
        List<Car> cars = new();
        List<Rectangle> rectangles = new();

        string Random_String(int length) {
            Random rnd = new();
            StringBuilder sb = new();
            for (int i = 0; i < length; i++) {
                sb.Append((char)rnd.Next('a', 'z' + 1));
            }
            return sb.ToString();
        }

        private void Sorting_Fill(object sender, RoutedEventArgs e) {
            if (!IsInitialized) return;
            Random rnd = new();
            students.Clear();
            cars.Clear();
            rectangles.Clear();
            WrP_Sorting.Children.Clear();

            switch (Cb_Sorting.SelectedIndex) {
                case 0: {
                        for (int i = 0; i < 10; i++) {
                            Student adding = new Student();
                            students.Add(adding);
                        }

                        break;
                    }
                case 1: {
                        for (int i = 0; i < 10; i++) {
                            Car adding = new Car();
                            cars.Add(adding);
                        }

                        break;
                    }
                case 2: {
                        for (int i = 0; i < 10; i++) {
                            Rectangle adding = new Rectangle(rnd.NextDouble() * 100, rnd.NextDouble() * 100);
                            rectangles.Add(adding);
                        }

                        break;
                    }
                default:
                    throw new IndexOutOfRangeException();
            }
            Refill_Panel();
        }

        void Refill_Panel() {
            WrP_Sorting.Children.Clear();
            switch (Cb_Sorting.SelectedIndex) {
                case 0: {
                        foreach (var student in students) {
                            string adder = student.ToString();
                            TextBox aa = new();
                            aa.Text = adder;
                            aa.Margin = new(2);
                            aa.Height = 150;
                            aa.Width = 400;
                            aa.IsReadOnly = true;
                            WrP_Sorting.Children.Add(aa);
                        }

                        break;
                    }
                case 1: {
                        foreach (var car in cars) {
                            string adder = car.ToString();
                            TextBox aa = new();
                            aa.Text = adder;
                            aa.Margin = new(2);
                            aa.Height = 170;
                            aa.Width = 400;
                            aa.IsReadOnly = true;
                            WrP_Sorting.Children.Add(aa);
                        }

                        break;
                    }
                case 2: {
                        foreach (var rectangle in rectangles) {
                            string adder = rectangle.ToString();
                            TextBox aa = new();
                            aa.Text = adder;
                            aa.Margin = new(2);
                            aa.Height = 130;
                            aa.Width = 400;
                            aa.IsReadOnly = true;
                            WrP_Sorting.Children.Add(aa);
                        }
                        break;
                    }
                default:
                    throw new IndexOutOfRangeException();
            }
        }
        delegate void Sort_Method<T>(T[] arr, Func<T, T, int> compare, bool ascending);
        delegate int Sort_Comparer<T>(T first, T second);
        private void Sorting_Sort(object sender, RoutedEventArgs e) {
            if (!IsInitialized) return;
            
            
            Stopwatch timer = Stopwatch.StartNew();
            
            switch (Cb_Sorting.SelectedIndex) {
                case 0: {
                        Student[] t = students.ToArray();
                        Sort_Method<Student> Sorting_Mt;
                        switch (Cb_Sort_Method.SelectedIndex) {
                            case 0:
                                Sorting_Mt = Sorter.BubbleSort;
                                break;
                            case 1:
                                Sorting_Mt = Sorter.InsertSort;
                                break;
                            case 2:
                                Sorting_Mt = Sorter.MergeSort;
                                break;
                            case 3:
                                Sorting_Mt = Sorter.QuickSort;
                                break;
                            default:
                                throw new IndexOutOfRangeException();
                        }
                        switch (Cb_Sort_Type.SelectedIndex) {
                            case 0:
                                Sorting_Mt(t, Student.ComparerLastNameAlphabet, Tg_Ascending.IsChecked.Value);
                                break;
                            case 1:
                                Sorting_Mt(t, Student.ComparerLastNameLength,
                                            Tg_Ascending.IsChecked.Value);
                                break;
                            case 2:
                                Sorting_Mt(t, Student.ComparerFirstNameAlphabet,
                                            Tg_Ascending.IsChecked.Value);
                                break;
                            case 3:
                                Sorting_Mt(t, Student.ComparerFirstNameLength,
                                            Tg_Ascending.IsChecked.Value);
                                break;
                            case 4:
                                Sorting_Mt(t, Student.ComparerPatronymicAlphabet,
                                            Tg_Ascending.IsChecked.Value);
                                break;
                            case 5:
                                Sorting_Mt(t, Student.ComparerPatronymicLength,
                                            Tg_Ascending.IsChecked.Value);
                                break;
                            case 6:
                                Sorting_Mt(t, Student.ComparerAge,
                                            Tg_Ascending.IsChecked.Value);
                                break;
                            case 7:
                                Sorting_Mt(t, Student.ComparerHeight,
                                            Tg_Ascending.IsChecked.Value);
                                break;
                            case 8:
                                Sorting_Mt(t, Student.ComparerWeight,
                                            Tg_Ascending.IsChecked.Value);
                                break;
                            case 9:
                                Sorting_Mt(t, Student.ComparerAverageMark,
                                            Tg_Ascending.IsChecked.Value);
                                break;
                            case 10:
                                Sorting_Mt(t, Student.ComparerComplex,
                                            Tg_Ascending.IsChecked.Value);
                                break;
                            default:
                                throw new IndexOutOfRangeException();
                        }

                        students = t.ToList();
                        break;
                    }
                case 1: {
                        Car[] t = cars.ToArray();
                        Sort_Method<Car> Sorting_Mt;
                        switch (Cb_Sort_Method.SelectedIndex) {
                            case 0:
                                Sorting_Mt = Sorter.BubbleSort;
                                break;
                            case 1:
                                Sorting_Mt = Sorter.InsertSort;
                                break;
                            case 2:
                                Sorting_Mt = Sorter.MergeSort;
                                break;
                            case 3:
                                Sorting_Mt = Sorter.QuickSort;
                                break;
                            default:
                                throw new IndexOutOfRangeException();
                        }
                        switch (Cb_Sort_Type.SelectedIndex) {
                            case 0:
                                Sorting_Mt(t, Car.ComparerBrandAlphabet,
                                            Tg_Ascending.IsChecked.Value);
                                break;
                            case 1:
                                Sorting_Mt(t, Car.ComparerBrandLength,
                                            Tg_Ascending.IsChecked.Value);
                                break;
                            case 2:
                                Sorting_Mt(t, Car.ComparerYear,
                                            Tg_Ascending.IsChecked.Value);
                                break;
                            case 3:
                                Sorting_Mt(t, Car.ComparerMaxSpeed,
                                            Tg_Ascending.IsChecked.Value);
                                break;
                            case 4:
                                Sorting_Mt(t, Car.ComparerVolume,
                                            Tg_Ascending.IsChecked.Value);
                                break;
                            case 5:
                                Sorting_Mt(t, Car.ComparerMileage,
                                            Tg_Ascending.IsChecked.Value);
                                break;
                            case 6:
                                Sorting_Mt(t, Car.ComparerColor,
                                            Tg_Ascending.IsChecked.Value);
                                break;
                            case 7:
                                Sorting_Mt(t, Car.ComparerComplex,
                                            Tg_Ascending.IsChecked.Value);
                                break;
                            default:
                                throw new IndexOutOfRangeException();
                        }

                        cars = t.ToList();
                        break;
                    }
                case 2: {
                        Rectangle[] t = rectangles.ToArray();
                        Sort_Method<Rectangle> Sorting_Mt;
                        switch (Cb_Sort_Method.SelectedIndex) {
                            case 0:
                                Sorting_Mt = Sorter.BubbleSort;
                                break;
                            case 1:
                                Sorting_Mt = Sorter.InsertSort;
                                break;
                            case 2:
                                Sorting_Mt = Sorter.MergeSort;
                                break;
                            case 3:
                                Sorting_Mt = Sorter.QuickSort;
                                break;
                            default:
                                throw new IndexOutOfRangeException();
                        }
                        switch (Cb_Sort_Type.SelectedIndex) {
                            case 0:
                                Sorting_Mt(t, Rectangle.ComparerPerimeter,
                                            Tg_Ascending.IsChecked.Value);
                                break;
                            case 1:
                                Sorting_Mt(t, Rectangle.ComparerArea,
                                            Tg_Ascending.IsChecked.Value);
                                break;
                            case 2:
                                Sorting_Mt(t, Rectangle.ComparerMinSide,
                                            Tg_Ascending.IsChecked.Value);
                                break;
                            case 3:
                                Sorting_Mt(t, Rectangle.ComparerMaxSide,
                                            Tg_Ascending.IsChecked.Value);
                                break;
                            case 4:
                                Sorting_Mt(t, Rectangle.ComparerSides,
                                            Tg_Ascending.IsChecked.Value);
                                break;

                        }
                        rectangles = t.ToList();
                        break;
                    }
                default:
                    throw new IndexOutOfRangeException();

            }

            Tx_Sorting_Result.Text = $"{timer.ElapsedMilliseconds}мс";
            Refill_Panel();
        }

        private void Sorting_Clear(object sender, RoutedEventArgs e) {
            if (!IsInitialized) return;
            students.Clear();
            cars.Clear();
            rectangles.Clear();
            WrP_Sorting.Children.Clear();
            Cb_Sort_Type.Items.Clear();
            switch (Cb_Sorting.SelectedIndex) {
                case 0:
                    Cb_Sort_Type.Items.Add(new ComboBoxItem() { Content = "Фамилия", IsSelected = true });
                    Cb_Sort_Type.Items.Add(new ComboBoxItem() { Content = "Длина Фамилии" });
                    Cb_Sort_Type.Items.Add(new ComboBoxItem() { Content = "Имя" });
                    Cb_Sort_Type.Items.Add(new ComboBoxItem() { Content = "Длина Имени" });
                    Cb_Sort_Type.Items.Add(new ComboBoxItem() { Content = "Отчество" });
                    Cb_Sort_Type.Items.Add(new ComboBoxItem() { Content = "Длина Отчества" });
                    Cb_Sort_Type.Items.Add(new ComboBoxItem() { Content = "Возраст" });
                    Cb_Sort_Type.Items.Add(new ComboBoxItem() { Content = "Рост" });
                    Cb_Sort_Type.Items.Add(new ComboBoxItem() { Content = "Вес" });
                    Cb_Sort_Type.Items.Add(new ComboBoxItem() { Content = "Средний Балл" });
                    Cb_Sort_Type.Items.Add(new ComboBoxItem() { Content = "Комплексный" });
                    break;
                case 1:
                    Cb_Sort_Type.Items.Add(new ComboBoxItem() { Content = "Название Брэнда", IsSelected = true });
                    Cb_Sort_Type.Items.Add(new ComboBoxItem() { Content = "Длина Названия Брэнда" });
                    Cb_Sort_Type.Items.Add(new ComboBoxItem() { Content = "Год Выпуска" });
                    Cb_Sort_Type.Items.Add(new ComboBoxItem() { Content = "Максимальная Скорость" });
                    Cb_Sort_Type.Items.Add(new ComboBoxItem() { Content = "Объем двигателя" });
                    Cb_Sort_Type.Items.Add(new ComboBoxItem() { Content = "Пробег" });
                    Cb_Sort_Type.Items.Add(new ComboBoxItem() { Content = "Цвет" });
                    Cb_Sort_Type.Items.Add(new ComboBoxItem() { Content = "Комплексный" });
                    break;
                case 2:
                    Cb_Sort_Type.Items.Add(new ComboBoxItem() { Content = "Периметр", IsSelected = true });
                    Cb_Sort_Type.Items.Add(new ComboBoxItem() { Content = "Площадь" });
                    Cb_Sort_Type.Items.Add(new ComboBoxItem() { Content = "Сторона А" });
                    Cb_Sort_Type.Items.Add(new ComboBoxItem() { Content = "Сторона Б" });
                    Cb_Sort_Type.Items.Add(new ComboBoxItem() { Content = "По Сторонам" });
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }
        }

        #endregion
    }
}