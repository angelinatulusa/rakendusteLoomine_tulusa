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
        Button close, clear, show;
        CheckBox stretch;
        FlowLayoutPanel flowLayoutPanel1;
        OpenFileDialog openFileDialog;
        RadioButton center;
        public piltideVaataja()
        {
            Height = 500;
            Width = 1150;
            Text = "piltide vaataja";
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All files (*.*)|*.*";
            tableLayoutPanel1 = new TableLayoutPanel
            {
                AutoSize = true,
                ColumnCount = 2,
                RowCount = 2,
                Location = new System.Drawing.Point(20, 0),
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
                //Image = new Bitmap(@"..\..\kass.png"),
                BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D,
                Dock = System.Windows.Forms.DockStyle.Fill,
                Location = new System.Drawing.Point(2, 2),
                TabIndex=0,
                TabStop=false,
                Size = new System.Drawing.Size(200,200) 
            };
            tableLayoutPanel1.Controls.Add(pictureBox, 0, 0);
            tableLayoutPanel1.SetCellPosition(pictureBox, new TableLayoutPanelCellPosition(0, 0));
            tableLayoutPanel1.SetColumnSpan(pictureBox, 2);
            stretch = new CheckBox
            {
                Text= "stretch"
            };
            stretch.CheckedChanged += Stretch_CheckedChanged;
            tableLayoutPanel1.Controls.Add(stretch, 0, 1);
            close = new Button{Text = "sule"};
            clear = new Button{Text = "kustuta"};
            show = new Button{Text = "näita"};
            center = new RadioButton { Text = "keskusesse" };
            close.Click += Tegevus;
            clear.Click += Tegevus;
            show.Click += Tegevus;
            center.CheckedChanged += new EventHandler(R_Tegevus);
            Button[] buttons = {clear, show, close};
            flowLayoutPanel1 = new FlowLayoutPanel
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                FlowDirection=FlowDirection.RightToLeft,
                AutoSize=true,
                WrapContents=false,
                //AutoScroll=true,

            };
            foreach (Button button in buttons)
            {
                flowLayoutPanel1.Controls.Add(button);
            }
            flowLayoutPanel1.Controls.Add(center);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 1, 1);
            this.Controls.Add(flowLayoutPanel1);
            
        }
        private void R_Tegevus(object sender, EventArgs e)
        {
            RadioButton radio_sender = (RadioButton)sender;
            if (radio_sender.Text == "keskusesse")
            {
                pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
                center.Checked = false;
            }
        }
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
        }
        private void Stretch_CheckedChanged(object sender, EventArgs e)
        {
            if (stretch.Checked)
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            else
                pictureBox.SizeMode = PictureBoxSizeMode.Normal;

        }
    }
}
