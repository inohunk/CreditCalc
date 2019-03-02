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

namespace Project_0
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double loanSum;
        double loanPrecent;
        double loanPeriod;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void dataOutput(object data)
        {
            outputBox.Text += data.ToString()+"\n";
        }
        private void initVariables()
        {
            
            loanSum = double.Parse(loanSizeField.Text);
            loanPrecent = double.Parse(loanPrecentField.Text);
            loanPeriod = double.Parse(loanPeriodField.Text);
        }
        private double getDiffPay()
        {
            double startPay = loanSum / loanPeriod;

            double monthDiff = getMonthPay() - startPay;
            MessageBox.Show(getMonthPay().ToString());
            MessageBox.Show(startPay.ToString());
            MessageBox.Show(monthDiff.ToString());

            return monthDiff * loanPeriod;
        }
        private bool allCorrect()
        {
            bool correct = false;
            if(loanSum >=10000 && loanSum <= 1000000)
            {
                if(loanPrecent>=9.5d && loanPrecent <= 23d)
                {
                    if (loanPeriod >= 6 && loanPeriod <=72)
                    {
                        correct = true;
                    }
                }
            }
            return correct;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            initVariables();
            
            dataOutput("Размер кредита: " + loanSum);
            dataOutput("Срок кредита: " + loanPeriod);
            dataOutput("Процентная ставка: " + loanPrecent);
            dataOutput("------------------------");
            dataOutput("Размер ежемесячной выплаты: " + (int)getMonthPay()+"р");
            dataOutput("Переплата: " + (int)getDiffPay());


            //outputBox.Text = getMonth(double.Parse(loanSize.Text), double.Parse(loanPeriod.Text), int.Parse(loanPrecent.Text)).ToString();
            //outputBox.Text = getMonthPay().ToString();
        }
        double getMonthPay()
        {
            
            double p = loanPrecent / 12 / 100;
            double k = (p * Math.Pow((1 + p), loanPeriod) / (Math.Pow(1 + p, loanPeriod) - 1));
            //double m = (n * p * Math.Pow(1 + p, y)) / (12 * (Math.Pow(1 + p, y) - 1));
            double m = k * loanSum;
            return m;
        }
        decimal getMonth(double S, double P, int N)
        {
            
            double x;
            x = S * (P+((P)
                /
                (Math.Pow(1+P,N)-1)));
            return Convert.ToDecimal(((S * P * Math.Pow(1 + P, N))/(12 * (Math.Pow(1 + P, N) - 1))));
        }
        double getMonthPrice(double sum, double year, double precent)
        {
            return (
                (sum * precent * Math.Pow(1 + precent, year))
                /
                12 * (Math.Pow(1 + precent, year) - 1)
                );
        }

    }
}
