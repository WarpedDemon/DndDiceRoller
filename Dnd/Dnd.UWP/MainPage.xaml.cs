using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;

namespace Dnd.UWP
{
    public sealed partial class MainPage
    {
        public int outputTotal = 0;
        public int output = 0;

        public bool cleanRoll = true;
        public bool maxRoll = false;
        public bool minRoll = false;

        List<string> historyList = new List<string>();
        List<string> itemsList = new List<string>();

        public MainPage()
        {
            this.InitializeComponent();
        }

        public void ClearAll()
        {
            outputTotal = 0;
            output = 0;

            cleanRoll = true;
            maxRoll = false;
            minRoll = false;

            historyList.Clear();

            history.Text = " ";
            selected.Text = " ";
            total.Text = " ";

            selected.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);
            total.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);
        }

        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            int randomOutput = random.Next(min, max);

            if (randomOutput == min)
            {
                //min
                if (!maxRoll)
                {
                    minRoll = true;
                }
                else
                {
                    //dirty
                    cleanRoll = false;
                }
            }
            else if (randomOutput + 1 == max)
            {
                //max
                if (!minRoll)
                {
                    maxRoll = true;
                }
                else
                {
                    //dirty
                    cleanRoll = false;
                }
            }
            else
            {
                //normal
                cleanRoll = false;
                maxRoll = false;
                minRoll = false;
            }

            output = randomOutput + 1;
            //Debug.WriteLine("You have data: " + output.ToString());
            return output;
        }

        public void historyToTotal()
        {
            int numberTotal = 0;
            foreach (string roll in historyList)
            {
                numberTotal += Convert.ToInt32(roll);
                //Debug.WriteLine(roll);
            }
            //Debug.WriteLine(numberTotal.ToString());
            total.Text = numberTotal.ToString();
        }

        public string historyToOutput()
        {
            string outputText = "";

            foreach (string roll in historyList)
            {
                outputText += roll + " + ";
                //Debug.WriteLine(roll);
            }

            historyToTotal();

            return outputText;
        }

        public void SetSUM(int min, int max)
        {
            //Debug.WriteLine(output);
            historyList.Add(output.ToString());

            string historyOutput = historyToOutput();
            history.Text = historyOutput.Remove(historyOutput.Length - 3);

            selected.Text = output.ToString();

            //Controls Current Colour
            selected.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);

            if (Convert.ToInt32(output)-1 == min) {
                selected.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
            }

            if (Convert.ToInt32(output) == max)
            {
                selected.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
            }

            //Controls Current Colour
            total.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);

            if (maxRoll && cleanRoll)
            {
                total.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
            }

            if (minRoll && cleanRoll)
            {
                total.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
            }
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            output = RandomNumber(0, 2);
            SetSUM(0, 2);
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            output = RandomNumber(0, 3);
            SetSUM(0, 3);
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            output = RandomNumber(0, 4);
            SetSUM(0, 4);
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            output = RandomNumber(0, 6);
            SetSUM(0, 6);
        }

        private void Button_Click5(object sender, RoutedEventArgs e)
        {
            output = RandomNumber(0, 8);
            SetSUM(0, 8);
        }

        private void Button_Click6(object sender, RoutedEventArgs e)
        {
            output = RandomNumber(0, 10);
            SetSUM(0, 10);
        }

        private void Button_Click7(object sender, RoutedEventArgs e)
        {
            output = RandomNumber(0, 12);
            SetSUM(0, 12);
        }

        private void Button_Click8(object sender, RoutedEventArgs e)
        {
            output = RandomNumber(0, 20);
            SetSUM(0, 20);
        }

        private void Button_Click9(object sender, RoutedEventArgs e)
        {
            output = RandomNumber(0, 100);
            SetSUM(0, 100);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
        }
    }
}
