using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rakendusteLoomine_tulusa
{
    public partial class sobitamine : Form
    {
        Random random = new Random();
        
        TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
        Label lbl1;
        int r = 0;//перемнные для создания игрового поля r-rida
        int t=0;//t-tulp

        public Timer timer = new Timer { Interval = 500 };//время, спустя которое картинки пропадают, когда картинки не совпадают

        Label timeLabel,time,katse,katseLabel;
        Timer timer2 = new Timer { Interval = 1000 };//1000 чтобы таймер считал в секундах

        Label firstClicked = null;
        Label secondClicked = null;
        Label keerukus;

        Button lihtsalt,keskmine,raske,kinni;
        public sobitamine()
        {
            this.Size = new System.Drawing.Size(900, 900);
            this.Text = "Mäng - leia pildi paar";
            this.MaximizeBox = false;

            tableLayoutPanel1 = new TableLayoutPanel()
            {
                ColumnCount = 4,
                Location = new System.Drawing.Point(3, 4),
                RowCount = 4,
                Size = new System.Drawing.Size(550, 550),
                TabIndex = 0,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
                BackColor = System.Drawing.Color.CornflowerBlue,
            };
            lihtsalt = new Button
            {
                Text = "lihtsalt",
                AutoSize = false,
                Size = new System.Drawing.Size(250, 100),
                Font = new Font("Times New Roman", 20, FontStyle.Bold),
                BackColor = System.Drawing.Color.LightSalmon,
                Location = new System.Drawing.Point(50, 100),
            };
            keskmine = new Button
            {
                Text = "keskmine",
                AutoSize = false,
                Size = new System.Drawing.Size(250, 100),
                Font = new Font("Times New Roman", 20, FontStyle.Bold),
                BackColor = System.Drawing.Color.LightSalmon,
                Location = new System.Drawing.Point(325, 100),
            };
            raske = new Button
            {
                Text = "raske",
                AutoSize = false,
                Size = new System.Drawing.Size(250, 100),
                Font = new Font("Times New Roman", 20, FontStyle.Bold),
                BackColor = System.Drawing.Color.LightSalmon,
                Location = new System.Drawing.Point(600, 100),
            };
            keerukus = new Label
            {
                Text = "Vali keerukus:",
                AutoSize = true,
                Location = new System.Drawing.Point(285, 15),
                Font = new Font("Arial", 30, FontStyle.Bold),
            };
            kinni = new Button
            {
                Text = "kinni",
                AutoSize = false,
                Size = new System.Drawing.Size(75, 50),
                Font = new Font("Times New Roman", 10, FontStyle.Bold),
                BackColor = System.Drawing.Color.LightCyan,
                Location = new System.Drawing.Point(800, 50),
            };
            katseLabel = new Label
            {
                Text = "veel katsed: ",
                AutoSize = true,
                Size = new System.Drawing.Size(200, 30),
                Font = new Font("Times New Roman", 21, FontStyle.Bold),
                Location = new System.Drawing.Point(600, 25),
            };
            katse = new Label
            {
                Text = "80",
                AutoSize = true,
                Size = new System.Drawing.Size(200, 30),
                Font = new Font("Times New Roman", 21, FontStyle.Bold),
                Location = new System.Drawing.Point(755, 25),
            };
            time = new Label
            {
                Text = "aega veel:",
                AutoSize = true,
                Size = new System.Drawing.Size(200, 30),
                Font = new Font("Times New Roman", 21, FontStyle.Bold),
                Location = new System.Drawing.Point(600, 55),
            };
            timeLabel = new Label
            {
                Text = "0",
                AutoSize = true,
                Size = new System.Drawing.Size(200, 30),
                Font = new Font("Times New Roman", 18, FontStyle.Bold),
                Location = new System.Drawing.Point(725, 60),
            };
            this.Controls.Add(keskmine);
            this.Controls.Add(lihtsalt);
            this.Controls.Add(raske);
            this.Controls.Add(keerukus);

            timer.Tick += Timer_Tick;
            lihtsalt.Click += Lihtsalt_Click;
            keskmine.Click += Keskmine_Click;
            raske.Click += Raske_Click;
            
        }

        private void Lihtsalt_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.Controls.Add(kinni);
            kinni.Click += Kinni_Click;
            this.Controls.Add(katseLabel);
            this.Controls.Add(katse);
            this.Controls.Add(time);
            this.Controls.Add(timeLabel);
            timer2.Enabled = true;
            timer2.Tick += Timer2_Tick;

            this.Controls.Add(this.tableLayoutPanel1);
            List<string> icons = new List<string>()//иконки(картинки), которым надо искать пару
            {
                "?", "?", "k", "k", "v", "v", "u", "u",
                "e", "e", "a", "a", "t", "t",
            };

            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));

            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));

            for (int i = 0; i < 3; i++)//цикл для добавления лейблов
            {
                for (int j = 0; j < 4; j++)
                {
                    lbl1 = new Label()
                    {
                        BackColor = System.Drawing.Color.CornflowerBlue,
                        AutoSize = false,
                        Dock = System.Windows.Forms.DockStyle.Fill,
                        TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                        Font = new System.Drawing.Font("Webdings", 48, System.Drawing.FontStyle.Bold),
                        Text = "c",
                    };
                    tableLayoutPanel1.Controls.Add(lbl1, r, t);
                    r++;

                }
                t++;
                r = 0;
            }
            foreach (Control control in tableLayoutPanel1.Controls)//добавление иконок рандомно
            {
                Label iconLabel1 = control as Label;
                if (iconLabel1 != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel1.Text = icons[randomNumber];
                    icons.RemoveAt(randomNumber);
                }
                iconLabel1.ForeColor = iconLabel1.BackColor;
                iconLabel1.Click += Lbl1_Click;
            }

        }

        private void Kinni_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int tik=60;
        private void Timer2_Tick(object sender, EventArgs e)
        {
            tik -= 1;
            timeLabel.Text = tik.ToString();
            if (tik==0)
            {
                MessageBox.Show("Sul sai aega otsa((", ":<");
                this.Close();
            }
            
        }

        private void Keskmine_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.Controls.Add(kinni);
            kinni.Click += Kinni_Click;
            this.Controls.Add(katseLabel);
            this.Controls.Add(katse);
            this.Controls.Add(time);
            this.Controls.Add(timeLabel);
            timer2.Enabled = true;
            timer2.Tick += Timer2_Tick1;

            this.Controls.Add(this.tableLayoutPanel1);
            List<string> icons = new List<string>()//иконки(картинки), которым надо искать пару
            {
                "?", "?", "k", "k", "v", "v", "u", "u",
                "e", "e", "a", "a", "t", "t", "n", "n"
            };

            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));

            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));

            for (int i = 0; i < 4; i++)//цикл для добавления лейблов
            {
                for (int j = 0; j < 4; j++)
                {
                    lbl1 = new Label()
                    {
                        BackColor = System.Drawing.Color.CornflowerBlue,
                        AutoSize = false,
                        Dock = System.Windows.Forms.DockStyle.Fill,
                        TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                        Font = new System.Drawing.Font("Webdings", 48, System.Drawing.FontStyle.Bold),
                        Text = "c",
                    };
                    tableLayoutPanel1.Controls.Add(lbl1, r, t);
                    r++;

                }
                t++;
                r = 0;
            }
            foreach (Control control in tableLayoutPanel1.Controls)//добавление иконок рандомно
            {
                Label iconLabel1 = control as Label;
                if (iconLabel1 != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel1.Text = icons[randomNumber];
                    icons.RemoveAt(randomNumber);
                }
                iconLabel1.ForeColor = iconLabel1.BackColor;
                iconLabel1.Click += Lbl1_Click;
            }
        }
        int ttik = 120;
        private void Timer2_Tick1(object sender, EventArgs e)
        {
            ttik -= 1;
            timeLabel.Text = ttik.ToString();
            if (ttik == 0)
            {
                MessageBox.Show("Sul sai aega otsa((", ":<");
                this.Close();
            }
        }

        private void Raske_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.Controls.Add(kinni);
            kinni.Click += Kinni_Click;
            this.Controls.Add(katseLabel);
            this.Controls.Add(katse);
            this.Controls.Add(time);
            this.Controls.Add(timeLabel);
            timer2.Enabled = true;
            timer2.Tick += Timer2_Tick2;

            this.Controls.Add(this.tableLayoutPanel1);
            List<string> icons = new List<string>()//иконки(картинки), которым надо искать пару
            {
                "?", "?", "k", "k", "v", "v", "u", "u","!","!",
                "e", "e", "a", "a", "t", "t", "n", "n","w","w"
            };

            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));

            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));

            for (int i = 0; i < 4; i++)//цикл для добавления лейблов
            {
                for (int j = 0; j < 5; j++)
                {
                    lbl1 = new Label()
                    {
                        BackColor = System.Drawing.Color.CornflowerBlue,
                        AutoSize = false,
                        Dock = System.Windows.Forms.DockStyle.Fill,
                        TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                        Font = new System.Drawing.Font("Webdings", 48, System.Drawing.FontStyle.Bold),
                        Text = "c",
                    };
                    tableLayoutPanel1.Controls.Add(lbl1, r, t);
                    r++;

                }
                t++;
                r = 0;
            }
            foreach (Control control in tableLayoutPanel1.Controls)//добавление иконок рандомно
            {
                Label iconLabel1 = control as Label;
                if (iconLabel1 != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel1.Text = icons[randomNumber];
                    icons.RemoveAt(randomNumber);
                }
                iconLabel1.ForeColor = iconLabel1.BackColor;
                iconLabel1.Click += Lbl1_Click;
            }
        }
        int tikk=180;
        private void Timer2_Tick2(object sender, EventArgs e)
        {
            tikk -= 1;
            timeLabel.Text = tikk.ToString();
            if (tikk == 0)
            {
                MessageBox.Show("Sul sai aega otsa((", ":<");
                this.Close();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }
        int katsed = 80;
        private void Lbl1_Click(object sender, EventArgs e)
        {
            katsed -= 1;
            katse.Text = katsed.ToString();
            if (katsed == 0)
            {
                MessageBox.Show("Sul pole enam katseid((", ":<");
                this.Close();
            }
            if (timer.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    return;
                }

                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;

                CheckForWinner();

                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }

                timer.Start();
            }
            
        }
        public void CheckForWinner()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }
            MessageBox.Show("Sa leised kõik paarid!!!", "Palju õnne!");
            Close();
        }
    }
}
