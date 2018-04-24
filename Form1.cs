using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastMath
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Int16 maxnum = 12;
        public Int16 minutes = 1;
        public Int16 minutes_timer = 1;
        public Int16 seconds_timer = 59;
        public Int16 ds_timer = 9;
        public static int solved_ = 0;
        public static List<String> operations = new List<string>();
        public static bool graphenabled = false;
        public static bool ingametimer = false;
        public static bool rateofcalculations = false;
        public static int rnd_num1 = 0;
        public static int rnd_num2 = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        public void GenerateRandom()
        {
            label3.Text = "";
            Random r = new Random();
            rnd_num1 = r.Next(1, maxnum);
            rnd_num2 = r.Next(1, maxnum);
            
            label3.Text = rnd_num1.ToString();
            int rndoperation_index = r.Next(0, operations.ToArray().Length);
            if(operations.ToArray()[rndoperation_index]=="addition")
            {
                label3.Text = label3.Text + "    +    ";
                label3.Text = label3.Text + rnd_num2;
            }
            else if (operations.ToArray()[rndoperation_index] == "subtraction")
            {
                label3.Text = label3.Text + "    -    ";
                if ((rnd_num1 - rnd_num2) < 0)
                {
                    int temp_rndnum_ = rnd_num1;
                    rnd_num1 = rnd_num2;
                    rnd_num2 = temp_rndnum_;
                }
                label3.Text = rnd_num1 + "    -     " + rnd_num2;
            }
            else if (operations.ToArray()[rndoperation_index] == "multiplication")
            {
                label3.Text = label3.Text + "    ·    ";
                label3.Text = label3.Text + rnd_num2;
            }
            else if (operations.ToArray()[rndoperation_index] == "division")
            {
                label3.Text = label3.Text + "    /    ";
                while(rnd_num1%rnd_num2!=0)
                {
                    rnd_num2 = r.Next(1, maxnum);
                }
                label3.Text = label3.Text + rnd_num2;
            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked && !checkBox4.Checked)
            {
                MessageBox.Show("Please select at least one skill to practice!");
            }
            else
            {
                maxnum = Convert.ToInt16(numericUpDown2.Value);
                minutes = Convert.ToInt16(numericUpDown1.Value);
                minutes_timer = Convert.ToInt16(numericUpDown1.Value-1);
                if (checkBox1.Checked)
                {
                    operations.Add("addition");
                }
                if (checkBox2.Checked)
                {
                    operations.Add("division");
                }
                if (checkBox3.Checked)
                {
                    operations.Add("multiplication");
                }
                if (checkBox4.Checked)
                {
                    operations.Add("subtraction");
                }
                if (checkBox5.Checked)
                {
                    chart1.Visible = true;
                    label11.Visible = true;
                }
                if (!checkBox5.Checked)
                {
                    chart1.Visible = false;
                    label11.Visible = false;
                }
                if (checkBox6.Checked)
                {
                    label8.Visible = true;
                }
                if (!checkBox6.Checked)
                {
                    label8.Visible = false;
                }
                if (checkBox7.Checked == true)
                {
                    label10.Visible = true;
                }
                if (checkBox7.Checked == false)
                {
                    label10.Visible = false;
                }

                panel1.Visible = false;
                GenerateRandom();
                timer1.Start();
                this.AcceptButton = button2;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (minutes_timer == 0 && seconds_timer == 1 && ds_timer == 2)
            {
                panel3.Visible = false;
                label9.Text = solved_.ToString() + " Correct";
                double rate = (double)solved_ / (minutes * 60);
                label10.Text = "Rate of calculations : " + Math.Round(rate, 1) + "/second";
                chart1.Series[0].Points.AddY(solved_);
                timer1.Stop();

            }
            ds_timer--;
            if (ds_timer == 1)
            {
                ds_timer = 9;
                seconds_timer--;
            }
            label8.Text = minutes_timer.ToString() + ":" + seconds_timer.ToString() + ":" + ds_timer.ToString();
            
            if (seconds_timer == 1 && minutes_timer!=0)
            {
                seconds_timer = 59;
                minutes_timer--;
            }
            
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(label3.Text.Contains("+"))
            {
                if((rnd_num1+rnd_num2).ToString()==textBox1.Text)
                {
                    solved_++;
                    GenerateRandom();
                    textBox1.Clear();
                }
            }
            else if(label3.Text.Contains("-"))
            {
                if ((rnd_num1 - rnd_num2).ToString() == textBox1.Text)
                {
                    solved_++;
                    GenerateRandom();
                    textBox1.Clear();
                }
            }
            else if(label3.Text.Contains("·"))
            {
                if ((rnd_num1 * rnd_num2).ToString() == textBox1.Text)
                {
                    solved_++;
                    GenerateRandom();
                    textBox1.Clear();
                }
            }
            else if(label3.Text.Contains("/"))
            {
                if ((rnd_num1 / rnd_num2).ToString() == textBox1.Text)
                {
                    solved_++;
                    GenerateRandom();
                    textBox1.Clear();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            maxnum = 12;
            minutes = 1;
            minutes_timer = 1;
            seconds_timer = 59;
            ds_timer = 9;
            solved_ = 0;
            operations = new List<string>();
            graphenabled = false;
            ingametimer = false;
            rateofcalculations = false;
            rnd_num1 = 0;
            rnd_num2 = 0;
            panel3.Visible = true;
            panel1.Visible = true;
        }
    }
}
