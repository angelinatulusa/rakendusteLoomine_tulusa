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
    public partial class piltideVaataja : Form
    {
        TableLayoutPanel tableLayoutPanel1;
        PictureBox pictureBox;
        Button close, clear, show, next, back,rohkem,vahem;//vormi sulgemine, ekraani puhastamine pildist, oma pildi valimine, pildi ümberlülitamine järgmisele, pildi vahetamine eelmisele, pildi suurendamine ja vähendamine
        CheckBox stretch, rotate, center;//venitage pilt täisekraanile, pöörake 90 kraadi, liigutage pilti keskele
        FlowLayoutPanel flowLayoutPanel1;
        OpenFileDialog openFileDialog;
        Bitmap suurus;//pildi suurus
        string picture = "valge";//muutuja, et kontrollida, milline pilt parajasti ekraanil on
        public piltideVaataja()
        {
            Height = 450;
            Width = 1310;
            Text = "piltide vaataja";
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All files (*.*)|*.*";
            tableLayoutPanel1 = new TableLayoutPanel
            {
                AutoSize = true,
                ColumnCount = 2,
                RowCount = 2,
                Location = new System.Drawing.Point(20, 0),
                BackColor = System.Drawing.Color.LightGray,
                Size = new System.Drawing.Size(300, 400),
                TabIndex = 0,
            };
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.Controls.Add(tableLayoutPanel1);
            pictureBox = new System.Windows.Forms.PictureBox
            {
                Image = new Bitmap(@"..\..\valge.jpg"),
                BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D,
                Dock = System.Windows.Forms.DockStyle.Fill,
                Location = new System.Drawing.Point(2, 2),
                TabIndex = 0,
                TabStop = false,
            };
            tableLayoutPanel1.Controls.Add(pictureBox, 0, 0);
            tableLayoutPanel1.SetCellPosition(pictureBox, new TableLayoutPanelCellPosition(0, 0));
            tableLayoutPanel1.SetColumnSpan(pictureBox, 2);
            stretch = new CheckBox { Text = "stretch" };
            rotate = new CheckBox { Text = "pöörata 90°" };
            stretch.CheckedChanged += Stretch_CheckedChanged;
            tableLayoutPanel1.Controls.Add(stretch, 0, 1);
            close = new Button
            {
                Text = "sule",
                AutoSize = true,
                Font = new Font("Times New Roman", 10, FontStyle.Bold),
                BackColor = System.Drawing.Color.LightCoral,
                Location = new System.Drawing.Point(800, 50),
            };//vormi sulgemine
            clear = new Button
            {
                Text = "kustuta",
                AutoSize = true,
                Font = new Font("Times New Roman", 10, FontStyle.Bold),
                BackColor = System.Drawing.Color.LightCoral,
                Location = new System.Drawing.Point(800, 50),
            };//vormi tühjendamine
            show = new Button
            {
                Text = "näita",
                AutoSize = true,
                Font = new Font("Times New Roman", 10, FontStyle.Bold),
                BackColor = System.Drawing.Color.LightCyan,
                Location = new System.Drawing.Point(800, 50),
            };//pildivalik
            next = new Button
            {
                Text = "järgmiseks",
                AutoSize = true,
                Font = new Font("Times New Roman", 10, FontStyle.Bold),
                BackColor = System.Drawing.Color.LightGoldenrodYellow,
                Location = new System.Drawing.Point(800, 50),
            };//lülituda järgmisele pildile
            back = new Button
            {
                Text = "eelmine",
                AutoSize = true,
                Font = new Font("Times New Roman", 10, FontStyle.Bold),
                BackColor = System.Drawing.Color.LightGoldenrodYellow,
                Location = new System.Drawing.Point(800, 50),
            };//lülituda eelmisele pildile
            center = new CheckBox { Text = "keskusesse" };//pildi asukoht keskel
            rohkem = new Button
            {
                Text = "suurendama",
                AutoSize = true,
                Font = new Font("Times New Roman", 10, FontStyle.Bold),
                BackColor = System.Drawing.Color.LightGreen,
                Location = new System.Drawing.Point(800, 50),
            };//pildi suurendamine
            vahem = new Button
            {
                Text = "vähenema",
                AutoSize = true,
                Font = new Font("Times New Roman", 10, FontStyle.Bold),
                BackColor = System.Drawing.Color.LightPink,
                Location = new System.Drawing.Point(800, 50),
            };//pildi vähendamine
            //kontrollides, millist nuppu vajutati, ja vastavat toimingut
            close.Click += Tegevus;
            clear.Click += Tegevus;
            show.Click += Tegevus;
            rohkem.Click += Tegevus;
            vahem.Click += Tegevus;
            center.CheckedChanged += new EventHandler(R_Tegevus);
            Button[] buttons = { clear, show, close, rohkem, vahem };
            flowLayoutPanel1 = new FlowLayoutPanel
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                AutoSize = true,
                WrapContents = false,

            };
            //nuppude kuvamine ekraanil
            foreach (Button button in buttons)
            {
                flowLayoutPanel1.Controls.Add(button);
            }
            flowLayoutPanel1.Controls.Add(center);
            tableLayoutPanel1.Controls.Add(next, 1, 2);
            tableLayoutPanel1.Controls.Add(rotate, 1, 1);
            tableLayoutPanel1.Controls.Add(back, 0, 2);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 1, 1);
            this.Controls.Add(flowLayoutPanel1);
            next.Click += Next_Click;
            back.Click += Back_Click;
         }

        int l = 0;//pilti laius
        int k = 0;//pilti kõrgus
        private void Back_Click(object sender, EventArgs e)
        {
            if (picture == "valge")
            {
                pictureBox.Image = new Bitmap(@"..\..\neponimausii.jpg");
                picture = "neponimausii";
                l = 200;
                k = 250;
                if (rotate.Checked == true)
                {
                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
                }
                suurus = new Bitmap(pictureBox.Image, l, k);

            }
            else if (picture == "neponimausii")
            {
                pictureBox.Image = new Bitmap(@"..\..\kot.jpg");
                picture = "kot";
                l = 200;
                k = 200;
                if (rotate.Checked == true)
                {
                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
                }
                suurus = new Bitmap(pictureBox.Image, l, k);
            }
            else if (picture == "kot")
            {
                pictureBox.Image = new Bitmap(@"..\..\kass.png");
                picture = "kass";
                l = 200;
                k = 260;
                if (rotate.Checked == true)
                {
                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
                }
                suurus = new Bitmap(pictureBox.Image, l, k);
            }
            else
            {
                pictureBox.Image = new Bitmap(@"..\..\valge.jpg");
                picture = "valge";
                l = 1200;
                k = 550;
                suurus = new Bitmap(pictureBox.Image, l, k);
            }

        }//vaheta pilt tagasi
        private void Next_Click(object sender, EventArgs e)
        {
            if (picture=="valge")
            {
                pictureBox.Image = new Bitmap(@"..\..\kass.png");
                picture = "kass";
                l = 200;
                k = 200;
                if (rotate.Checked==true)
                {
                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
                }
                suurus = new Bitmap(pictureBox.Image, l, k);
            }
            else if (picture=="kass")
            {
                pictureBox.Image = new Bitmap(@"..\..\kot.jpg");
                picture = "kot";
                l = 200;
                k = 200;
                if (rotate.Checked == true)
                {
                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
                }
                suurus = new Bitmap(pictureBox.Image, l, k);
            }
            else if (picture == "kot")
            {
                pictureBox.Image = new Bitmap(@"..\..\neponimausii.jpg");
                picture = "neponimausii";
                l = 200;
                k = 250;
                if (rotate.Checked == true)
                {
                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
                }
                suurus = new Bitmap(pictureBox.Image, l, k);
            }
            else
            {
                pictureBox.Image = new Bitmap(@"..\..\valge.jpg");
                picture = "valge";
                l = 1200;
                k = 550;
                suurus = new Bitmap(pictureBox.Image, l, k);
            }

        }//vaheta pilti edasi
        private void R_Tegevus(object sender, EventArgs e)
        {
            if (center.Checked)
            {
                pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            else
            {
                pictureBox.SizeMode = PictureBoxSizeMode.Normal;
            }
        }//teisaldage pilt keskele
        private void Tegevus(object sender, EventArgs e)
        {
            Button nupp_sender = (Button)sender;
            if (nupp_sender.Text=="näita")
            {
                if (openFileDialog.ShowDialog()==DialogResult.OK)
                {
                    pictureBox.Load(openFileDialog.FileName);
                }
            }
            else if (nupp_sender.Text=="kustuta")
            {
                pictureBox.Image = null;
            }
            else if (nupp_sender.Text=="sule")
            {
                this.Close();
            }
            else if (nupp_sender.Text == "suurendama")
            {
                l += 20;
                k += 20;
                suurus = new Bitmap(pictureBox.Image, l,k); //muuda pildi suurust, muuta see suuremaks
                pictureBox.Image = suurus;
                pictureBox.Show();
            }
            else if (nupp_sender.Text == "vähenema")
            {
                l -= 20;
                k -= 20;
                suurus = new Bitmap(pictureBox.Image, l, k); //muuda pildi suurust, muuta see väiksemaks
                pictureBox.Image = suurus;
                pictureBox.Show();
            }
        }//kontrollida, millist nuppu vajutati ja vastav toiming toimub
        private void Stretch_CheckedChanged(object sender, EventArgs e)
        {
            if (stretch.Checked)
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            else
                pictureBox.SizeMode = PictureBoxSizeMode.Normal;

        }//pildi venitamine
    }
}