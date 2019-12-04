using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Device.Location;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SwissTransport;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //timer1.Start();
        }

        private void cmdShowHelloMessage_Click(object sender, EventArgs e)
        {
            MessageBox.Show("sali");

            Transport transport = new Transport();

            MessageBox.Show(transport.ToString());
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            FillAutocomplete();
        }

        private async void FillAutocomplete()
        {
            string search = textBox1.Text;

            if (search.Length >= 3)
            {
                Transport t = new Transport();
                //textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
                //textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection a = new AutoCompleteStringCollection();
                var gs = await t.GetStations(search);
                var sl = gs.StationList;

                a.Add("");

                foreach (Station s in sl)
                {
                    a.Add(s.Name);
                }

                textBox1.AutoCompleteCustomSource = a;
            }
        }


        private async void FillCombo()
        {
            string search = comboBox1.Text;

            if (search.Length >= 3)
            {
                Transport t = new Transport();
                //textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
                //textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;

                List<string> a = new List<string>();
                var gs = await t.GetStations(search);
                var sl = gs.StationList;

                foreach (Station s in sl)
                {
                    a.Add(s.Name);
                }

                while (comboBox1.Items.Count > 1)
                    comboBox1.Items.RemoveAt(0);

                //comboBox1.Items.Clear(); // setzt den Cursor an den anfang zurück
                
                if(a.Count >0)
                    comboBox1.Items.AddRange(a.ToArray());
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //FillAutocomplete();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //FillAutocomplete();
        }

        private void comboBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Up
                && e.KeyCode != Keys.Down)
            {
                FillCombo();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Station s = new Transport().GetStations("Hildisrieden, Post").StationList[0];

            //label1.Text = Transport.RequestsRemaining.ToString();

            ////TimeSpan ts = TimeSpan.Parse("0d00:05:06");

            ////SmtpClient client = new SmtpClient("mail.estermann.it", 25);

            ////MailMessage mail = new MailMessage("markus@estermann.it", "markus@estermann.it", "betreff", "Text");
            ////client.Send(mail);

            //GeoCoordinateWatcher x = new GeoCoordinateWatcher();
            //x.ToString();
        }
    }
}
