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

namespace WPFInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Integral

        void Try_Calc_Integral(object sender, object e)
        {
            if(!IsInitialized) return;
            bool failed = false;
            if (!Check_Double(Tx_Left.Text))
            {
                Tx_Left.Background = Brushes.Red;
                failed = true;
            }
            else Tx_Left.Background = Brushes.White;
            if (!Check_Double(Tx_Right.Text))
            {
                Tx_Right.Background = Brushes.Red;
                failed = true;
            }
            else Tx_Right.Background = Brushes.White;
            if (!Check_Steps(Tx_Steps.Text))
            {
                Tx_Steps.Background = Brushes.Red;
                failed = true;
            }
            else Tx_Steps.Background = Brushes.White;

            if (failed) return;

            Func<double, double> function;
            
            switch (Cb_Integral.SelectedIndex)
            {
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
            if (Rb_Parallel.IsChecked.Value)
            {
                result = Mathematics.IntegralParallel(function, double.Parse(Tx_Left.Text), double.Parse(Tx_Right.Text),
                    int.Parse(Tx_Steps.Text));
            }
            else
            {
                result = Mathematics.Integral(function, double.Parse(Tx_Left.Text), double.Parse(Tx_Right.Text),
                    int.Parse(Tx_Steps.Text));
            }

            StringBuilder sb = new();
            sb.Append($"{result}\n");
            sb.Append($"{timer.Elapsed}");
            Tx_Integral_Output.Text = sb.ToString();
        }

        bool Check_Double(string value)
        {
            if (!double.TryParse(value, out _)) return false;
            return true;
        }

        bool Check_Steps(string value)
        {
            if (!int.TryParse(value, out int parsed)) return false;
            if (parsed < 1) return false;
            return true;
        }

        #endregion

        #region Collections

        

        #endregion
        
        #region Sorting
        
        
        
        #endregion
    }
}