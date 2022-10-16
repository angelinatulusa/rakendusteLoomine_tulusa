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
        int r = 0;//muutujad mänguvälja loomiseks r-rida
        int t=0;//t-tulp

        public Timer timer = new Timer { Interval = 500 };//aeg, mille möödudes pildid kaovad, kui pildid ei ühti

        Label timeLabel,time,katse,katseLabel;
        Timer timer2 = new Timer { Interval = 1000 };//1000, et taimer loeks sekundites

        Label firstClicked = null;
        Label secondClicked = null;
        //et valida mängu raskusaste(igal pool sama palju katseid)
        Label keerukus;
        Button lihtsalt,keskmine,raske,kinni;//kinni-nupu jaoks, mis mängu sulgeb
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
            };
            //nupud ja Label raskusastme valimiseks
            lihtsalt = new Button
            {
                Text = "lihtsalt",
                AutoSize = false,
                Size = new System.Drawing.Size(250, 100),
                Font = new Font("Times New Roman", 20, FontStyle.Bold),
                BackColor = System.Drawing.Color.LightSeaGreen,
                Location = new System.Drawing.Point(50, 100),
            };
            keskmine = new Button
            {
                Text = "keskmine",
                AutoSize = false,
                Size = new System.Drawing.Size(250, 100),
                Font = new Font("Times New Roman", 20, FontStyle.Bold),
                BackColor = System.Drawing.Color.LightGoldenrodYellow,
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
                BackColor = System.Drawing.Color.LightGray,
                Font = new Font("Arial", 30, FontStyle.Bold),
            };
            //vormi sulgemiseks
            kinni = new Button
            {
                Text = "kinni",
                AutoSize = false,
                Size = new System.Drawing.Size(75, 50),
                Font = new Font("Times New Roman", 10, FontStyle.Bold),
                BackColor = System.Drawing.Color.LightCyan,
                Location = new System.Drawing.Point(800, 50),
            };
            //katsed (1 klõps-üks katse)
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
            //aeg
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
            //sõltuvalt sellest, milline nupp on valitud, algab mängu vastav raskusaste
            lihtsalt.Click += Tegevus;
            keskmine.Click += Tegevus;
            raske.Click += Tegevus;
            
        }
        private void Tegevus(object sender, EventArgs e)
        {
            Button nupp_sender = (Button)sender;
            if (nupp_sender.Text=="lihtsalt")
	        {
                lihtsalt.Click += Lihtsalt_Click;
	        }
            else if (nupp_sender.Text=="keskmine")
	        {
                keskmine.Click += Keskmine_Click;
	        }
            else if (nupp_sender.Text=="raske")
	        {
                raske.Click += Raske_Click;
	        }
        }

        private void Lihtsalt_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            tableLayoutPanel1.Controls.Clear();
            this.Controls.Add(kinni);
            kinni.Click += Kinni_Click;
            this.Controls.Add(katseLabel);
            this.Controls.Add(katse);
            this.Controls.Add(time);
            this.Controls.Add(timeLabel);
            timer2.Enabled = true;
            timer2.Tick += Timer2_Tick;

            this.Controls.Add(this.tableLayoutPanel1);
            List<string> icons = new List<string>()//ikoonid (pildid), mis peavad paari otsima
            {
                "?", "?", "k", "k", "v", "v", 
                "e", "e", "a", "a", "t", "t",
            };

            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));

            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));

            for (int i = 0; i < 3; i++)//silmus lisamiseks labeli
            {
                for (int j = 0; j < 4; j++)
                {
                    lbl1 = new Label()
                    {
                        BackColor = System.Drawing.Color.LightSeaGreen,
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
            foreach (Control control in tableLayoutPanel1.Controls)//piltide lisamine juhuslikult
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

        }//kui valitud on lihtne raskusaste, on väli 3*4

        private void Kinni_Click(object sender, EventArgs e)
        {
            this.Close();
        }//vormi sulgemine

        int tik=60;//sekundit
        private void Timer2_Tick(object sender, EventArgs e)
        {
            tik -= 1;
            timeLabel.Text = tik.ToString();
            if (tik==0)
            {
                using (var muusika = new SoundPlayer(@"..\..\lose.wav"))
                {
                    muusika.Play();
                    MessageBox.Show("Sul sai aega otsa((", ":<");
                    this.Close();
                }
            }

        }//taimer lihtsate raskuste jaoks (seal on 60 sekundit),kui aeg otsa saab, mängitakse kaotusest lugu ja ekraanile kuvatakse teade kaotuse kohta
        private void Keskmine_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            tableLayoutPanel1.Controls.Clear();
            this.Controls.Add(kinni);
            kinni.Click += Kinni_Click;
            this.Controls.Add(katseLabel);
            this.Controls.Add(katse);
            this.Controls.Add(time);
            this.Controls.Add(timeLabel);
            timer2.Enabled = true;
            timer2.Tick += Timer2_Tick1;

            this.Controls.Add(this.tableLayoutPanel1);
            List<string> icons = new List<string>()//ikoonid (pildid), mis peavad paari otsima
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

            for (int i = 0; i < 4; i++)//silmus lisamiseks labeli
            {
                for (int j = 0; j < 4; j++)
                {
                    lbl1 = new Label()
                    {
                        BackColor = System.Drawing.Color.LightGoldenrodYellow,
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
            foreach (Control control in tableLayoutPanel1.Controls)//piltide lisamine juhuslikult
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
        }//kui on valitud keskmine raskusaste, siis on väli 4 * 4
        int ttik = 120;//sekundit
        private void Timer2_Tick1(object sender, EventArgs e)
        {
            ttik -= 1;
            timeLabel.Text = ttik.ToString();
            if (ttik == 0)
            {
                using (var muusika = new SoundPlayer(@"..\..\lose.wav"))
                {
                    muusika.Play();
                    MessageBox.Show("Sul sai aega otsa((", ":<");
                    this.Close();
                }
            }
        }//taimer keskmise raskusastme jaoks(seal on 120 sekundit),kui aeg otsa saab, mängitakse kaotusest lugu ja ekraanile kuvatakse teade kaotuse kohta

        private void Raske_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            tableLayoutPanel1.Controls.Clear();
            this.Controls.Add(kinni);
            kinni.Click += Kinni_Click;
            this.Controls.Add(katseLabel);
            this.Controls.Add(katse);
            this.Controls.Add(time);
            this.Controls.Add(timeLabel);
            timer2.Enabled = true;
            timer2.Tick += Timer2_Tick2;

            this.Controls.Add(this.tableLayoutPanel1);
            List<string> icons = new List<string>()//ikoonid (pildid), mis peavad paari otsima
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

            for (int i = 0; i < 4; i++)//silmus lisamiseks labeli
            {
                for (int j = 0; j < 5; j++)
                {
                    lbl1 = new Label()
                    {
                        BackColor = System.Drawing.Color.LightSalmon,
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
            foreach (Control control in tableLayoutPanel1.Controls)//piltide lisamine juhuslikult
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
        }//kui valitud on raske raskusaste, on väli 4 * 5
        int tikk=180;//sekundit
        private void Timer2_Tick2(object sender, EventArgs e)
        {
            tikk -= 1;
            timeLabel.Text = tikk.ToString();
            if (tikk == 0)
            {
                using (var muusika = new SoundPlayer(@"..\..\lose.wav"))
                {
                    muusika.Play();
                    MessageBox.Show("Sul sai aega otsa((", ":<");
                    this.Close();
                }
            }
        }//raskete raskuste taimer (seal on 180 sekundit),kui aeg otsa saab, mängitakse kaotusest lugu ja ekraanile kuvatakse teade kaotuse kohta

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }//taimer, et saaksite pilte näha, kui paar ei sobinud
        int katsed = 80;//katsete arv
        private void Lbl1_Click(object sender, EventArgs e)
        {
            katsed -= 1;
            katse.Text = katsed.ToString();
            if (katsed == 0)
            {
                using(var muusika=new SoundPlayer(@"..\..\lose.wav"))
                {
                    muusika.Play();
                    MessageBox.Show("Sul pole enam katseid((", ":<");
                    this.Close();
                }
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

        }//kui katsed on lõppenud, ilmub ekraanile teade ja kaotusest mängitakse muusikat
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
            using(var muusik=new SoundPlayer(@"..\..\win.wav"))
            {
                muusik.Play();
                MessageBox.Show("Sa leised kõik paarid!!!", "Palju õnne!");
                this.Close();
            }
        }//kui kõik paarid on kokku kogutud, kuvatakse ekraanile sellekohane teade ja mängitakse muusikat
    }
}
