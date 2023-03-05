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
            sb.Append($"{timer.Elapsed}");
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

        MyStack<IType> st = new();
        MyQueue<IType> qu = new();

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
            adder.Height = 30;
            adder.Width = 50;
            adder.IsReadOnly = true;
            switch (selectedType) {
                case "Автомобиль": {
                        Car car = new();
                        adder.Text = car.ToString();
                        if (selectedCollection == "Стэк") {
                            st.Add(car);
                            WrP_Collection.Children.Insert(0, adder);
                        } else {
                            qu.Add(car);
                            WrP_Collection.Children.Add(adder);
                        }
                        break;
                    }
                case "Студент": {
                        Student student = new();
                        adder.Text = student.ToString();
                        if (selectedCollection == "Стэк") {
                            st.Add(student);
                            WrP_Collection.Children.Insert(0, adder);
                        } else {
                            qu.Add(student);
                            WrP_Collection.Children.Add(adder);
                        }
                        break;
                    }
                case "Прямоугольник": {
                        Rectangle rectangle = new();
                        adder.Text = rectangle.ToString();
                        if (selectedCollection == "Стэк") {
                            st.Add(rectangle);
                            WrP_Collection.Children.Insert(0, adder);
                        } else {
                            qu.Add(rectangle);
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
            if (Cb_Collection.SelectedIndex == 0) {
                if (st.Count == 0) return;
                st.Remove();
                WrP_Collection.Children.RemoveAt(0);
            } else {
                if (qu.Count == 0) return;
                qu.Remove();
                WrP_Collection.Children.RemoveAt(0);
            }
        }

        private void Clear_Collection(object sender, RoutedEventArgs e) {
            if (!IsInitialized) return;
            st = new();
            qu = new();
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
                            Student adding = new Student(Random_String(rnd.Next(3, 20)), Random_String(rnd.Next(3, 20)),
                                Random_String(rnd.Next(3, 20)), rnd.Next(18, 30), 150 + (rnd.NextDouble() * 60),
                                50 + (rnd.NextDouble() * 50), 2 + (rnd.NextDouble() * 3));
                            students.Add(adding);
                        }

                        break;
                    }
                case 1: {
                        for (int i = 0; i < 10; i++) {
                            Car adding = new Car(Random_String(rnd.Next(3, 12)), rnd.Next(-1000, 3000), rnd.NextDouble() * 1000, rnd.NextDouble() * 1000,
                                (Color)rnd.Next((int)Color.White, (int)Color.Violet + 1), rnd.NextDouble() * 1000000);
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
                            string adder = $"ФИО: {student.LastName} {student.FirstName} {student.Patronymic}\n" +
                                           $"Возраст: {student.Age}\n" +
                                           $"Рост: {student.Height}\n" +
                                           $"Вес: {student.Weight}\n" +
                                           $"Средний Балл: {student.AverageMark}";
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
                            string adder = $"Брэнд: {car.Brand}\n" +
                                           $"Год Выпуска: {car.Year}\n" +
                                           $"Пробег: {car.Mileage}\n" +
                                           $"Максимальная Скорость: {car.MaxSpeed}\n" +
                                           $"Цвет: {car.Color}\n" +
                                           $"Объем Двигателя: {car.Volume}";
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
                            string adder = $"Сторона А: {rectangle.A}\n" +
                                           $"Сторона Б: {rectangle.B}\n" +
                                           $"Периметр: {rectangle.Perimeter}\n" +
                                           $"Площадь: {rectangle.Area}";
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
        private void Sorting_Sort(object sender, RoutedEventArgs e) {
            if (!IsInitialized) return;
            Stopwatch timer = Stopwatch.StartNew();
            switch (Cb_Sorting.SelectedIndex) {
                case 0: {
                        Student[] t = students.ToArray();
                        switch (Cb_Sort_Type.SelectedIndex) {
                            case 0:
                                switch (Cb_Sort_Method.SelectedIndex) {
                                    case 0:
                                        Sorter.BubbleSort(t, Student.ComparerLastNameAlphabet,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 1:
                                        Sorter.InsertSort(t, Student.ComparerLastNameAlphabet,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 2:
                                        Sorter.MergeSort(t, Student.ComparerLastNameAlphabet,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 3:
                                        Sorter.QuickSort(t, Student.ComparerLastNameAlphabet,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    default:
                                        throw new IndexOutOfRangeException();
                                }
                                break;
                            case 1:
                                switch (Cb_Sort_Method.SelectedIndex) {
                                    case 0:
                                        Sorter.BubbleSort(t, Student.ComparerLastNameLength,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 1:
                                        Sorter.InsertSort(t, Student.ComparerLastNameLength,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 2:
                                        Sorter.MergeSort(t, Student.ComparerLastNameLength,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 3:
                                        Sorter.QuickSort(t, Student.ComparerLastNameLength,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    default:
                                        throw new IndexOutOfRangeException();
                                }
                                break;
                            case 2:
                                switch (Cb_Sort_Method.SelectedIndex) {
                                    case 0:
                                        Sorter.BubbleSort(t, Student.ComparerFirstNameAlphabet,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 1:
                                        Sorter.InsertSort(t, Student.ComparerFirstNameAlphabet,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 2:
                                        Sorter.MergeSort(t, Student.ComparerFirstNameAlphabet,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 3:
                                        Sorter.QuickSort(t, Student.ComparerFirstNameAlphabet,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    default:
                                        throw new IndexOutOfRangeException();
                                }
                                break;
                            case 3:
                                switch (Cb_Sort_Method.SelectedIndex) {
                                    case 0:
                                        Sorter.BubbleSort(t, Student.ComparerFirstNameLength,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 1:
                                        Sorter.InsertSort(t, Student.ComparerFirstNameLength,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 2:
                                        Sorter.MergeSort(t, Student.ComparerFirstNameLength,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 3:
                                        Sorter.QuickSort(t, Student.ComparerFirstNameLength,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    default:
                                        throw new IndexOutOfRangeException();
                                }
                                break;
                            case 4:
                                switch (Cb_Sort_Method.SelectedIndex) {
                                    case 0:
                                        Sorter.BubbleSort(t, Student.ComparerPatronymicAlphabet,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 1:
                                        Sorter.InsertSort(t, Student.ComparerPatronymicAlphabet,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 2:
                                        Sorter.MergeSort(t, Student.ComparerPatronymicAlphabet,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 3:
                                        Sorter.QuickSort(t, Student.ComparerPatronymicAlphabet,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    default:
                                        throw new IndexOutOfRangeException();
                                }
                                break;
                            case 5:
                                switch (Cb_Sort_Method.SelectedIndex) {
                                    case 0:
                                        Sorter.BubbleSort(t, Student.ComparerPatronymicLength,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 1:
                                        Sorter.InsertSort(t, Student.ComparerPatronymicLength,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 2:
                                        Sorter.MergeSort(t, Student.ComparerPatronymicLength,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 3:
                                        Sorter.QuickSort(t, Student.ComparerPatronymicLength,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    default:
                                        throw new IndexOutOfRangeException();
                                }
                                break;
                            case 6:
                                switch (Cb_Sort_Method.SelectedIndex) {
                                    case 0:
                                        Sorter.BubbleSort(t, Student.ComparerAge,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 1:
                                        Sorter.InsertSort(t, Student.ComparerAge,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 2:
                                        Sorter.MergeSort(t, Student.ComparerAge,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 3:
                                        Sorter.QuickSort(t, Student.ComparerAge,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    default:
                                        throw new IndexOutOfRangeException();
                                }
                                break;
                            case 7:
                                switch (Cb_Sort_Method.SelectedIndex) {
                                    case 0:
                                        Sorter.BubbleSort(t, Student.ComparerHeight,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 1:
                                        Sorter.InsertSort(t, Student.ComparerHeight,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 2:
                                        Sorter.MergeSort(t, Student.ComparerHeight,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 3:
                                        Sorter.QuickSort(t, Student.ComparerHeight,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    default:
                                        throw new IndexOutOfRangeException();
                                }
                                break;
                            case 8:
                                switch (Cb_Sort_Method.SelectedIndex) {
                                    case 0:
                                        Sorter.BubbleSort(t, Student.ComparerWeight,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 1:
                                        Sorter.InsertSort(t, Student.ComparerWeight,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 2:
                                        Sorter.MergeSort(t, Student.ComparerWeight,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 3:
                                        Sorter.QuickSort(t, Student.ComparerWeight,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    default:
                                        throw new IndexOutOfRangeException();
                                }
                                break;
                            case 9:
                                switch (Cb_Sort_Method.SelectedIndex) {
                                    case 0:
                                        Sorter.BubbleSort(t, Student.ComparerAverageMark,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 1:
                                        Sorter.InsertSort(t, Student.ComparerAverageMark,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 2:
                                        Sorter.MergeSort(t, Student.ComparerAverageMark,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 3:
                                        Sorter.QuickSort(t, Student.ComparerAverageMark,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    default:
                                        throw new IndexOutOfRangeException();
                                }
                                break;
                            case 10:
                                switch (Cb_Sort_Method.SelectedIndex) {
                                    case 0:
                                        Sorter.BubbleSort(t, Student.ComparerComplex,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 1:
                                        Sorter.InsertSort(t, Student.ComparerComplex,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 2:
                                        Sorter.MergeSort(t, Student.ComparerComplex,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 3:
                                        Sorter.QuickSort(t, Student.ComparerComplex,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    default:
                                        throw new IndexOutOfRangeException();
                                }
                                break;
                            default:
                                throw new IndexOutOfRangeException();
                        }

                        students = t.ToList();
                        break;
                    }
                case 1: {
                        Car[] t = cars.ToArray();
                        switch (Cb_Sort_Type.SelectedIndex) {
                            case 0:
                                switch (Cb_Sort_Method.SelectedIndex) {
                                    case 0:
                                        Sorter.BubbleSort(t, Car.ComparerBrandAlphabet,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 1:
                                        Sorter.InsertSort(t, Car.ComparerBrandAlphabet,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 2:
                                        Sorter.MergeSort(t, Car.ComparerBrandAlphabet,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 3:
                                        Sorter.QuickSort(t, Car.ComparerBrandAlphabet,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    default:
                                        throw new IndexOutOfRangeException();
                                }
                                break;
                            case 1:
                                switch (Cb_Sort_Method.SelectedIndex) {
                                    case 0:
                                        Sorter.BubbleSort(t, Car.ComparerBrandLength,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 1:
                                        Sorter.InsertSort(t, Car.ComparerBrandLength,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 2:
                                        Sorter.MergeSort(t, Car.ComparerBrandLength,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 3:
                                        Sorter.QuickSort(t, Car.ComparerBrandLength,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    default:
                                        throw new IndexOutOfRangeException();
                                }
                                break;
                            case 2:
                                switch (Cb_Sort_Method.SelectedIndex) {
                                    case 0:
                                        Sorter.BubbleSort(t, Car.ComparerYear,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 1:
                                        Sorter.InsertSort(t, Car.ComparerYear,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 2:
                                        Sorter.MergeSort(t, Car.ComparerYear,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 3:
                                        Sorter.QuickSort(t, Car.ComparerYear,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    default:
                                        throw new IndexOutOfRangeException();
                                }
                                break;
                            case 3:
                                switch (Cb_Sort_Method.SelectedIndex) {
                                    case 0:
                                        Sorter.BubbleSort(t, Car.ComparerMaxSpeed,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 1:
                                        Sorter.InsertSort(t, Car.ComparerMaxSpeed,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 2:
                                        Sorter.MergeSort(t, Car.ComparerMaxSpeed,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 3:
                                        Sorter.QuickSort(t, Car.ComparerMaxSpeed,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    default:
                                        throw new IndexOutOfRangeException();
                                }
                                break;
                            case 4:
                                switch (Cb_Sort_Method.SelectedIndex) {
                                    case 0:
                                        Sorter.BubbleSort(t, Car.ComparerVolume,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 1:
                                        Sorter.InsertSort(t, Car.ComparerVolume,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 2:
                                        Sorter.MergeSort(t, Car.ComparerVolume,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 3:
                                        Sorter.QuickSort(t, Car.ComparerVolume,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    default:
                                        throw new IndexOutOfRangeException();
                                }
                                break;
                            case 5:
                                switch (Cb_Sort_Method.SelectedIndex) {
                                    case 0:
                                        Sorter.BubbleSort(t, Car.ComparerMileage,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 1:
                                        Sorter.InsertSort(t, Car.ComparerMileage,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 2:
                                        Sorter.MergeSort(t, Car.ComparerMileage,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 3:
                                        Sorter.QuickSort(t, Car.ComparerMileage,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    default:
                                        throw new IndexOutOfRangeException();
                                }
                                break;
                            case 6:
                                switch (Cb_Sort_Method.SelectedIndex) {
                                    case 0:
                                        Sorter.BubbleSort(t, Car.ComparerColor,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 1:
                                        Sorter.InsertSort(t, Car.ComparerColor,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 2:
                                        Sorter.MergeSort(t, Car.ComparerColor,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 3:
                                        Sorter.QuickSort(t, Car.ComparerColor,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    default:
                                        throw new IndexOutOfRangeException();
                                }
                                break;
                            case 7:
                                switch (Cb_Sort_Method.SelectedIndex) {
                                    case 0:
                                        Sorter.BubbleSort(t, Car.ComparerComplex,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 1:
                                        Sorter.InsertSort(t, Car.ComparerComplex,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 2:
                                        Sorter.MergeSort(t, Car.ComparerComplex,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 3:
                                        Sorter.QuickSort(t, Car.ComparerComplex,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    default:
                                        throw new IndexOutOfRangeException();
                                }
                                break;
                            default:
                                throw new IndexOutOfRangeException();
                        }

                        cars = t.ToList();
                        break;
                    }
                case 2: {
                        Rectangle[] t = rectangles.ToArray();
                        switch (Cb_Sort_Type.SelectedIndex) {
                            case 0:
                                switch (Cb_Sort_Method.SelectedIndex) {
                                    case 0:
                                        Sorter.BubbleSort(t, Rectangle.ComparerPerimeter,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 1:
                                        Sorter.InsertSort(t, Rectangle.ComparerPerimeter,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 2:
                                        Sorter.MergeSort(t, Rectangle.ComparerPerimeter,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 3:
                                        Sorter.QuickSort(t, Rectangle.ComparerPerimeter,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    default:
                                        throw new IndexOutOfRangeException();
                                }
                                break;
                            case 1:
                                switch (Cb_Sort_Method.SelectedIndex) {
                                    case 0:
                                        Sorter.BubbleSort(t, Rectangle.ComparerArea,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 1:
                                        Sorter.InsertSort(t, Rectangle.ComparerArea,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 2:
                                        Sorter.MergeSort(t, Rectangle.ComparerArea,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 3:
                                        Sorter.QuickSort(t, Rectangle.ComparerArea,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    default:
                                        throw new IndexOutOfRangeException();
                                }
                                break;
                            case 2:
                                switch (Cb_Sort_Method.SelectedIndex) {
                                    case 0:
                                        Sorter.BubbleSort(t, Rectangle.ComparerMinSide,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 1:
                                        Sorter.InsertSort(t, Rectangle.ComparerMinSide,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 2:
                                        Sorter.MergeSort(t, Rectangle.ComparerMinSide,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 3:
                                        Sorter.QuickSort(t, Rectangle.ComparerMinSide,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    default:
                                        throw new IndexOutOfRangeException();
                                }
                                break;
                            case 3:
                                switch (Cb_Sort_Method.SelectedIndex) {
                                    case 0:
                                        Sorter.BubbleSort(t, Rectangle.ComparerMaxSide,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 1:
                                        Sorter.InsertSort(t, Rectangle.ComparerMaxSide,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 2:
                                        Sorter.MergeSort(t, Rectangle.ComparerMaxSide,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 3:
                                        Sorter.QuickSort(t, Rectangle.ComparerMaxSide,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    default:
                                        throw new IndexOutOfRangeException();
                                }
                                break;
                            case 4:
                                switch (Cb_Sort_Method.SelectedIndex) {
                                    case 0:
                                        Sorter.BubbleSort(t, Rectangle.ComparerSides,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 1:
                                        Sorter.InsertSort(t, Rectangle.ComparerSides,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 2:
                                        Sorter.MergeSort(t, Rectangle.ComparerSides,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    case 3:
                                        Sorter.QuickSort(t, Rectangle.ComparerSides,
                                            Tg_Ascending.IsChecked.Value);
                                        break;
                                    default:
                                        throw new IndexOutOfRangeException();
                                }
                                break;

                        }

                        rectangles = t.ToList();
                        break;
                    }
                default:
                    throw new IndexOutOfRangeException();

            }

            Tx_Sorting_Result.Text = timer.Elapsed.ToString();
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