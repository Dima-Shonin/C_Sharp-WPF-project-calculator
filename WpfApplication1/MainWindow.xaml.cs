using System;
using System.Collections.Generic;
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

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string left = "";
        string rigt = "";
        string operation = "";
        public MainWindow()
        {
            InitializeComponent();
            foreach (UIElement item in LayoutRoot.Children)
            {
                if (item is Button)
                {
                    ((Button)item).Click += Button_Click;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = (string)((Button)e.OriginalSource).Content;
            textblock.Text += s;
            int num;
            bool res = Int32.TryParse(s, out num);
            if (res == true)
            {
                if (operation == "")
                {
                    left += s;
                }
                else
                {
                    rigt += s;
                }
            }
            else
            {
                if (s == "=")
                {
                    Update_RightOP();
                     textblock.Text += left;
                    operation = "";
                    
                }
                
                else if (s == "Clear")
                {
                    left = "";
                    rigt = "";
                    operation = "";
                    textblock.Text = "";
                }
                else
                {
                    if(rigt != "")
                    {
                        Update_RightOP();                        
                        rigt = "";
                    }
                    operation = s;
                }
            }
        }

        private void Update_RightOP()
        {
            int num1 = Int32.Parse(left);
            int num2 = Int32.Parse(rigt);
            switch(operation)
            {
                case "+":
                    left = (num1 + num2).ToString();
                    break;
                case "-":
                    left = (num1 - num2).ToString();
                    break;
                case "*":
                    left = (num1 * num2).ToString();
                    break;
                case "/":
                    try
                    {
                        left = (num1 / num2).ToString();
                    }
                    catch (DivideByZeroException)
                    {
                        MessageBox.Show("Ошибка деление на 0","Исключение",MessageBoxButton.OK);
                        left = "";
                        rigt = "";
                        operation = "";
                        textblock.Text = "";
                    }
                   
                    break;
                default:
                    break;
            }
        }


    }
}
