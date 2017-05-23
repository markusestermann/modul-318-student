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
using SwissTransportClient;
using SwissTransport;

namespace SwissTransportWindowsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new VMMainUI();

            textBox.Focus();
        }

        //private async void ComboBox_KeyUp(object sender, KeyEventArgs e)
        //{
        //    string search = comboBox1.Text;

        //    if (search.Length >= 3)
        //    {
        //        Transport t = new Transport();

        //        List<string> a = new List<string>();
        //        var gs = await t.GetStations(search);
        //        var sl = gs.StationList;

        //        foreach (Station s in sl)
        //        {
        //            a.Add(s.Name);
        //        }

        //        comboBox1.ItemsSource = a;

        //        comboBox1.IsDropDownOpen = true;
        //    }
        //}
    }
}
