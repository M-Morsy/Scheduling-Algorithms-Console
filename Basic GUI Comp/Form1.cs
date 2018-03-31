using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static int click_flag = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            /** Initializing test arrays **/
            string[] processes_arr = new string[3];
            double [] timing_arr = new double [4];
            processes_arr[0] = "P1";
            processes_arr[1] = "P3";
            processes_arr[2] = "P2";
            timing_arr[0] = 0  ;
            timing_arr[1] = 1  ;
            timing_arr[2] = 3.4 ;
            timing_arr[3] = 6 ;

            /** setting some attributes for the gannt chart **/
            flowLayoutPanel1.WrapContents = true;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Padding = new Padding(0);

            for (int i = 0; i < processes_arr.Length ; i++)
            {

                Label newLabel = new Label();
                Label newLabel2 = new Label();
                newLabel.Text = processes_arr[i];
                newLabel2.Text = Convert.ToString(timing_arr[i]);
                newLabel.Margin = new Padding(0);
                newLabel2.Margin    = new Padding(0)    ;
                newLabel2.Height    = newLabel.Height   ;
                newLabel2.Width     = newLabel.Width / 4;
                newLabel.TextAlign  = ContentAlignment.MiddleCenter;
                newLabel2.TextAlign = ContentAlignment.MiddleCenter;
                newLabel.BackColor  = Color.Gray    ;
                newLabel.ForeColor  = Color.White   ;
                newLabel2.BackColor = Color.Black   ;
                newLabel2.ForeColor = Color.White   ;

                //newLabel.BackColor = System.Drawing.Color.LightGray;
                flowLayoutPanel1.Controls.Add(newLabel2)    ;
                flowLayoutPanel1.Controls.Add(newLabel)     ;
                if (i == processes_arr.Length - 1)
                {   Label newLabel3 = new Label();
                    newLabel3.Text = Convert.ToString(timing_arr[i + 1]);
                    newLabel3.BackColor = Color.Black;
                    newLabel3.ForeColor = Color.White;
                    newLabel3.Height = newLabel.Height;
                    newLabel3.Width = newLabel.Width/4;
                    newLabel3.Margin = new Padding(0);
                    newLabel3.TextAlign = ContentAlignment.MiddleCenter;
                    flowLayoutPanel1.Controls.Add(newLabel3);
                }

            }
        }
    }
}

