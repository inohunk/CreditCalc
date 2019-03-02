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
        double clientPay;
        double clientPayPrecent;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void dataOutput(object data)
        {
            outputBox.Text += data.ToString() + "\n";
        }
        private void clearOutput()
        {
            outputBox.Text = null;
        }
        private void initVariables()
        {
            try
            {
                loanSum = double.Parse(loanSizeField.Text);
                loanPrecent = double.Parse(loanPrecentField.Text);
                loanPeriod = double.Parse(loanPeriodField.Text);
                clientPay = double.Parse(clientPayField.Text);
                clientPayPrecent = double.Parse(clientPayPrecentField.Text);
            }
            catch (Exception e)
            {


                ////throw new FormatException();
            }
        }
        private double getDiffPay()
        {
            double startPay = loanSum / loanPeriod;
            double monthDiff = getMonthPay() - startPay;
            return monthDiff * loanPeriod;
        }
        private double getClientPay()
        {
            return clientPay + ((clientPayPrecent / 100) * loanSum);
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
                        if(clientPay >=0 && clientPayPrecent >=0)
                        {
                            correct = true;
                        }
                    }
                }
            }
            return correct;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
            initVariables();
            if (allCorrect())
            {
                clearOutput();
                dataOutput("Размер кредита: " + loanSum +"р");
                dataOutput("Срок кредита: " + loanPeriod+" мес");
                dataOutput("Процентная ставка: " + loanPrecent+"%");
                dataOutput("------------------------");
                dataOutput("Размер ежемесячной выплаты: " + (int)getMonthPay() + "р");
                dataOutput("Переплата: " + (int)getDiffPay()+"р");
                dataOutput("Плата за оформление: " + getClientPay() + "р");
                dataOutput("Сумма переплат: " + (int)(getDiffPay() + getClientPay()) + "р");
                dataOutput("Общая сумма: " + (int)(getDiffPay() + getClientPay() + loanSum) + "р");
            }
            else
            {
                MessageBox.Show("Проверьте правильность данных!");
            }
        }
        double getMonthPay()
        {   
            double p = loanPrecent / 12 / 100;
            double k = (p * Math.Pow((1 + p), loanPeriod) / (Math.Pow(1 + p, loanPeriod) - 1));
            double m = k * loanSum;
            return m;
        }
    }
}
