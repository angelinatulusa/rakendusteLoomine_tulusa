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
        Timer timer;//1000, et taimer loeks sekundites
        int[]num1=new int[4];
        int[]num2=new int[4];
        //nuppu "Start" ehk mängu alustamiseks ja nuppu vormi sulgemiseks
        Button start,kinni;
        //nuppu, et uuesti küsimusi genereerida
        Button v_kord;
        //edenemisriba, mis näitab sekundeid
        ProgressBar result;
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
            v_kord=new Button
            {
                Text = "Teised tehed",
                AutoSize = false,
                Size = new System.Drawing.Size(120, 21),
                BackColor = System.Drawing.Color.LightSteelBlue,
                Location = new System.Drawing.Point(0, 30),
            };//nupp, mis tekitab uuesti küsimusi
            start = new Button
            {
                Text = "START",
                AutoSize = false,
                Size = new System.Drawing.Size(250, 100),
                Font = new Font("Times New Roman", 20, FontStyle.Bold),
                BackColor = System.Drawing.Color.LightSalmon,
                Location = new System.Drawing.Point(300,100),
            };//nupp, mis näitab küsimusi ja käivitab taimeri
            kinni = new Button
            {
                Text = "kinni",
                AutoSize = false,
                Size = new System.Drawing.Size(75, 50),
                Font = new Font("Times New Roman", 10, FontStyle.Bold),
                BackColor = System.Drawing.Color.LightCyan,
                Location = new System.Drawing.Point(750, 50),
            };//nuppu, mis sulgeb vormi
            result = new ProgressBar
            {
                Width = 400,
                Height = 30,
                Location = new Point(300, 10),
                Value = 0,
                Minimum = 0,
                Maximum = 120,
                Step = 1,
            };
            l_nimed = new string[5, 4];
            v_kord.Click += V_kord_Click;//käivitusnupp "Teised tehed"
            start.Click += Start_Click;//käivitusnupp "Start"
            this.Controls.Add(start);
        }
        public void Start_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            tableLayoutPanel.Controls.Clear();
            timer = new Timer { Interval = 1000 };
            timer.Start();
            timer.Enabled = true;
            timer.Tick += Timer_Tick;
            this.Controls.Add(kinni);
            kinni.Click += Kinni_Click;
            this.DoubleClick += Matem_DoubleClick;
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
            this.Controls.Add(result);

            this.Controls.Add(v_kord);
        }//kuvab näiteid ja taimerit
        private void Result()
        {
            result.PerformStep();
        }//käivitab edenemisriba
        private void Kinni_Click(object sender, EventArgs e)
        {
            this.Close();
        }//sulgeb vormi
        int tik = 120;//sekundite piirang
        private void V_kord_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            tableLayoutPanel.Controls.Clear();
            timer.Stop();
            timer = new Timer { Interval = 100 };
            start.Click += Start_Click;
            this.Controls.Add(start);
        }//tühjendab vormi ja käivitab Start
        private void Matem_DoubleClick(object sender, EventArgs e)
        {
            timeLabel.Text = timer.ToString();
            tableLayoutPanel.Controls.Add(timeLabel);
        }
        private bool Kontroll()
        {
            if (num1[0] + num2[0] == vastused[0].Value 
                && num1[1] - num2[1] == vastused[1].Value 
                && num1[2] / num2[2] == vastused[2].Value 
                && num1[3] * num2[3] == vastused[3].Value)
            {
                return true;
            }
            else { return false; }
        }//vastuste õigsuse kontrollimine
        private void Timer_Tick(object sender, EventArgs e)
        {
            tik -=1;
            Result();
            timeLabel.Text="aega veel:"+tik.ToString();
            if (Kontroll())
            {
                timer.Stop();
                MessageBox.Show("Sinu vastused on õiged", "Palju õnne!");
                Convert.ToInt32(tik);
                if (tik < 120 && tik>60)
                {
                    MessageBox.Show("Sul on suurepärane tulemus!", ":>");
                }
                else if (tik<60 && tik>10)
                {
                    MessageBox.Show("Sul on keskmine tulemus", "Saad paremini!");
                }
                else
                {
                    MessageBox.Show("Sul läheb liiga kaua aega", "Liiga kaua((");
                }
            }

        }//taimer, ajaväljund, kui kõik vastused on õiged, siis kuvab olenevalt sekundite arvust, mis tulemuse inimene on saanud
    }
}
