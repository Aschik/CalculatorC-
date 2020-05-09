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

namespace Kalkulator
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Double value = 0;
        String operation = "";
        bool operation_pressed = false;
        


        public MainWindow()
        {
            InitializeComponent();
        }

        // Klikniecia na cyferki 
        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            if (txtDisplay.Text == "0"||(operation_pressed))
                txtDisplay.Clear();


            Button b = (Button)sender;
            txtDisplay.Text = txtDisplay.Text + b.Content;
            operation_pressed = false;


        }

        //CE 
        private void BtnClearEntry_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = "0";


        }


        private void Operator_Click(object sender, RoutedEventArgs e)
        {

            Button b = (Button)sender;

            operation = b.ContentStringFormat;
            value = Double.Parse(txtDisplay.Text);
            operation_pressed = true;
            equation.Content = value + " " + operation;

        }

        private void BtnEquals_Click(object sender, RoutedEventArgs e)
        {
            
            

                equation.Content = "";
                switch (operation)
                {

                    case "+":
                        txtDisplay.Text = (value + Double.Parse(txtDisplay.Text)).ToString();
                        break;
                    case "-":
                        txtDisplay.Text = (value - Double.Parse(txtDisplay.Text)).ToString();
                        break;
                    case "x":
                        txtDisplay.Text = (value * Double.Parse(txtDisplay.Text)).ToString();
                        break;
                    case "/":
                        if (Double.Parse(txtDisplay.Text) == 0)
                        {
                            MessageBox.Show("Prosze nie dzielic przez 0!");
                            txtDisplay.Text = "";
                            value = 0;

                        }
                        else
                        {
                            txtDisplay.Text = (value / Double.Parse(txtDisplay.Text)).ToString();
                        }

                        break;
                    default:
                        break;




                 // Koniec switcha 

                

                 }

        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {

            txtDisplay.Text="0";
            value = 0;


        }

        private void BtnPositiveNegative_Click(object sender, RoutedEventArgs e)
        {
          
            if (txtDisplay.Text!="" && txtDisplay.Text!="0")
            {

                value = Double.Parse(txtDisplay.Text);
                value = value * (-1);
                txtDisplay.Text = value.ToString();


            }


        }

        private void ButtonBCSP_Click(object sender, RoutedEventArgs e)
        {

            if(txtDisplay.Text.Length>0 && operation_pressed==false)
            {

                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1);

            }

        }

        private void Common_Click(object sender, RoutedEventArgs e)
        {

            bool isAlreadyCommon = txtDisplay.Text.Contains(',');
            if (isAlreadyCommon == false && txtDisplay.Text.Length != 0)
            {
                txtDisplay.Text += ',';
            }


        }
    }
}
