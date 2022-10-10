using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rakendusteLoomine_tulusa
{
    public partial class matem : Form
    {
        
        Random random = new Random();
        Label timeLabel;
        TableLayoutPanel tableLayoutPanel;
        NumericUpDown[] vastused=new NumericUpDown[4]; // {summa,lahutamine,jagamine,korrutamine}
        string[,] l_nimed;
        string[] tehed = new string[4] { "+", "-", "/", "*" };
        string text;
        Timer timer=new Timer { Interval = 1000 };//1000 чтобы таймер считал в секундах
        int[]num1=new int[4];
        int[]num2=new int[4];
        Button start;
        int punktid;
        Label p_arv;
        Button v_kord;
        public matem()
        {
            
            this.Size = new Size(850, 300);
            tableLayoutPanel = new TableLayoutPanel
            {
                AutoSize = true,
                ColumnCount = 5,
                RowCount = 4,
                Location = new System.Drawing.Point(50, 60),
                BackColor = System.Drawing.Color.LightSteelBlue,
            };
            timeLabel = new Label
            {
                Text = "aega veel: ",
                AutoSize = false,
                BorderStyle = BorderStyle.FixedSingle,
                Size = new System.Drawing.Size(200, 30),
                Font = new Font("Times New Roman", 20, FontStyle.Bold)
            };
            /*p_arv = new Label
            {
                Text = "Sinu punktid: ",
                Size = new System.Drawing.Size(200, 30),
                Font = new Font("Times New Roman", 17, FontStyle.Bold),
                Location = new System.Drawing.Point(0,30)
            };*/
            v_kord=new Button
            {
                Text = "Teised küsimused",
                AutoSize = false,
                Size = new System.Drawing.Size(120, 21),
                BackColor = System.Drawing.Color.LightSteelBlue,
                Location = new System.Drawing.Point(0, 30),
            };
            start = new Button
            {
                Text = "START",
                AutoSize = false,
                Size = new System.Drawing.Size(250, 100),
                Font = new Font("Times New Roman", 20, FontStyle.Bold),
                BackColor = System.Drawing.Color.LightSalmon,
                Location = new System.Drawing.Point(300,100),
            };
            l_nimed = new string[5, 4];
            timer.Enabled = true;
            //timer.Start();
            start.Click += Start_Click;
            this.Controls.Add(start);
            

        }
        public void Start_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.DoubleClick += Matem_DoubleClick;
            timer.Tick += Timer_Tick;
            for (int i = 0; i < 4; i++)
            {
                tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
                for (int j = 0; j < 5; j++)
                {
                    tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
                    var l_nimi = "L" + j.ToString() + i.ToString();
                    l_nimed[j, i] = l_nimi;
                    if (j == 1) { text = tehed[i]; }
                    else if (j == 3) { text = "="; }
                    else if (j == 4) { text = "vastus"; }
                    else if (j == 0)
                    {
                        int a = random.Next(20);
                        text = a.ToString();//l_nimi
                        num1[i] = a;
                    }
                    else if (j == 2)
                    {
                        int a = random.Next(10);
                        text = a.ToString();//l_nimi
                        num2[i] = a;
                    }
                    if (j == 4)
                    {
                        vastused[i] = new NumericUpDown
                        {
                            Name = tehed[i],
                            DecimalPlaces = 5,
                            Minimum = -20,
                        };
                        tableLayoutPanel.Controls.Add(vastused[i], j, i);
                    }
                    else
                    {
                        Label l = new Label { Text = text };
                        tableLayoutPanel.Controls.Add(l, j, i);
                    }

                }
            }
            this.Controls.Add(tableLayoutPanel);
            this.Controls.Add(timeLabel);
            v_kord.Click += V_kord_Click;
            this.Controls.Add(v_kord);

            //this.Controls.Add(p_arv);
        }
        private void V_kord_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.DoubleClick += Matem_DoubleClick;
            timer.Tick += Timer_Tick;
            for (int i = 0; i < 4; i++)
            {
                tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
                for (int j = 0; j < 5; j++)
                {
                    tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
                    var l_nimi = "L" + j.ToString() + i.ToString();
                    l_nimed[j, i] = l_nimi;
                    if (j == 1) { text = tehed[i]; }
                    else if (j == 3) { text = "="; }
                    else if (j == 4) { text = "vastus"; }
                    else if (j == 0)
                    {
                        int a = random.Next(20);
                        text = a.ToString();//l_nimi
                        num1[i] = a;
                    }
                    else if (j == 2)
                    {
                        int a = random.Next(10);
                        text = a.ToString();//l_nimi
                        num2[i] = a;
                    }
                    if (j == 4)
                    {
                        vastused[i] = new NumericUpDown
                        {
                            Name = tehed[i],
                            DecimalPlaces = 5,
                            Minimum = -20,
                        };
                        tableLayoutPanel.Controls.Add(vastused[i], j, i);
                    }
                    else
                    {
                        Label l = new Label { Text = text };
                        tableLayoutPanel.Controls.Add(l, j, i);
                    }

                }
            }
            this.Controls.Add(tableLayoutPanel);
            this.Controls.Add(timeLabel);
        }

        int tik = 0;
        private void Matem_DoubleClick(object sender, EventArgs e)
        {
            timer.Start();
            timeLabel.Text = timer.ToString();
            tableLayoutPanel.Controls.Add(timeLabel);
        }
        private bool Kontroll()
        {
            timeLabel.Text = tik.ToString();
            if (num1[0] + num2[0] == vastused[0].Value 
                && num1[1] - num2[1] == vastused[1].Value 
                && num1[2] / num2[2] == vastused[2].Value 
                && num1[3] * num2[3] == vastused[3].Value)
            {
                return true;
            }
            else { return false; }
        }
        /*private void Punktid()
        {
            if (num1[0] + num2[0] == vastused[0].Value
                && num1[1] - num2[1] == vastused[1].Value
                && num1[2] / num2[2] == vastused[2].Value
                && num1[3] * num2[3] == vastused[3].Value)
            {
                punktid+=10;
                p_arv.Text = punktid.ToString();
            }
        }*/
        private void Timer_Tick(object sender, EventArgs e)
        {
            tik++;
            timeLabel.Text=tik.ToString();
            if (Kontroll())
            {
                timer.Stop();
                MessageBox.Show("Sinu vastused on õiged", "Palju õnne!");
            }
        }

        
    }
}
