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
    public partial class sobitamine : Form
    {
        TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
        Label lbl1;
        int r = 0;
        int t=0;
        public sobitamine()
        {
            Random random = new Random();
            List<string> icons = new List<string>()
            {
                "!", "!", "N", "N", ",", ",", "k", "k",
                "b", "b", "v", "v", "w", "w", "z", "z"
            };

            this.Size = new System.Drawing.Size(550, 550);
            this.Text = "Piltide Leidmise Mäng";
            this.MaximizeBox = false;

            tableLayoutPanel1 = new TableLayoutPanel()
            {
                ColumnCount = 4,
                Location = new System.Drawing.Point(3, 4),
                Name = "tableLayoutPanel1",
                RowCount = 4,
                Size = new System.Drawing.Size(527, 506),
                TabIndex = 0,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
                BackColor = System.Drawing.Color.CornflowerBlue,
            };
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));

            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));

            this.Controls.Add(this.tableLayoutPanel1);

            for (int i = 0; i <3; i++)
            {
                for (int j = 0; j <=3; j++)
                {
                    lbl1 = new Label()
                    {
                        BackColor = System.Drawing.Color.CornflowerBlue,
                        AutoSize = false,
                        Dock = System.Windows.Forms.DockStyle.Fill,
                        TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                        Font = new System.Drawing.Font("Webbings", 48, System.Drawing.FontStyle.Bold),
                        Text = "c"
                    };
                    tableLayoutPanel1.Controls.Add(lbl1, r, t);
                    r++;
                }
                t++;
            }
            ////1 rida
            //lbl1 = new Label()
            //{
            //    BackColor = System.Drawing.Color.CornflowerBlue,
            //    AutoSize = false,
            //    Dock = System.Windows.Forms.DockStyle.Fill,
            //    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
            //    Font = new System.Drawing.Font("Webbings", 48, System.Drawing.FontStyle.Bold),
            //    Text = "c"
            //};
            //tableLayoutPanel1.Controls.Add(lbl1, 0, 0);
            //lbl1 = new Label()
            //{
            //    BackColor = System.Drawing.Color.CornflowerBlue,
            //    AutoSize = false,
            //    Dock = System.Windows.Forms.DockStyle.Fill,
            //    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
            //    Font = new System.Drawing.Font("Webbings", 48, System.Drawing.FontStyle.Bold),
            //    Text = "c"
            //};
            //tableLayoutPanel1.Controls.Add(lbl1, 1, 0);
            //lbl1 = new Label()
            //{
            //    BackColor = System.Drawing.Color.CornflowerBlue,
            //    AutoSize = false,
            //    Dock = System.Windows.Forms.DockStyle.Fill,
            //    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
            //    Font = new System.Drawing.Font("Webbings", 48, System.Drawing.FontStyle.Bold),
            //    Text = "c"
            //};
            //tableLayoutPanel1.Controls.Add(lbl1, 2, 0);
            //lbl1 = new Label()
            //{
            //    BackColor = System.Drawing.Color.CornflowerBlue,
            //    AutoSize = false,
            //    Dock = System.Windows.Forms.DockStyle.Fill,
            //    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
            //    Font = new System.Drawing.Font("Webbings", 48, System.Drawing.FontStyle.Bold),
            //    Text = "c"
            //};
            //tableLayoutPanel1.Controls.Add(lbl1, 3, 0);
            ////2 rida
            //lbl1 = new Label()
            //{
            //    BackColor = System.Drawing.Color.CornflowerBlue,
            //    AutoSize = false,
            //    Dock = System.Windows.Forms.DockStyle.Fill,
            //    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
            //    Font = new System.Drawing.Font("Webbings", 48, System.Drawing.FontStyle.Bold),
            //    Text = "c"
            //};
            //tableLayoutPanel1.Controls.Add(lbl1, 0, 1);
            //lbl1 = new Label()
            //{
            //    BackColor = System.Drawing.Color.CornflowerBlue,
            //    AutoSize = false,
            //    Dock = System.Windows.Forms.DockStyle.Fill,
            //    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
            //    Font = new System.Drawing.Font("Webbings", 48, System.Drawing.FontStyle.Bold),
            //    Text = "c"
            //};
            //tableLayoutPanel1.Controls.Add(lbl1, 1, 1);
            //lbl1 = new Label()
            //{
            //    BackColor = System.Drawing.Color.CornflowerBlue,
            //    AutoSize = false,
            //    Dock = System.Windows.Forms.DockStyle.Fill,
            //    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
            //    Font = new System.Drawing.Font("Webbings", 48, System.Drawing.FontStyle.Bold),
            //    Text = "c"
            //};
            //tableLayoutPanel1.Controls.Add(lbl1, 2, 1);
            //lbl1 = new Label()
            //{
            //    BackColor = System.Drawing.Color.CornflowerBlue,
            //    AutoSize = false,
            //    Dock = System.Windows.Forms.DockStyle.Fill,
            //    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
            //    Font = new System.Drawing.Font("Webbings", 48, System.Drawing.FontStyle.Bold),
            //    Text = "c"
            //};
            //tableLayoutPanel1.Controls.Add(lbl1, 3, 1);
            ////3 rida
            //lbl1 = new Label()
            //{
            //    BackColor = System.Drawing.Color.CornflowerBlue,
            //    AutoSize = false,
            //    Dock = System.Windows.Forms.DockStyle.Fill,
            //    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
            //    Font = new System.Drawing.Font("Webbings", 48, System.Drawing.FontStyle.Bold),
            //    Text = "c"
            //};
            //tableLayoutPanel1.Controls.Add(lbl1, 0, 2);
            //lbl1 = new Label()
            //{
            //    BackColor = System.Drawing.Color.CornflowerBlue,
            //    AutoSize = false,
            //    Dock = System.Windows.Forms.DockStyle.Fill,
            //    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
            //    Font = new System.Drawing.Font("Webbings", 48, System.Drawing.FontStyle.Bold),
            //    Text = "c"
            //};
            //tableLayoutPanel1.Controls.Add(lbl1, 1, 2);
            //lbl1 = new Label()
            //{
            //    BackColor = System.Drawing.Color.CornflowerBlue,
            //    AutoSize = false,
            //    Dock = System.Windows.Forms.DockStyle.Fill,
            //    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
            //    Font = new System.Drawing.Font("Webbings", 48, System.Drawing.FontStyle.Bold),
            //    Text = "c"
            //};
            //tableLayoutPanel1.Controls.Add(lbl1, 2, 2);
            //lbl1 = new Label()
            //{
            //    BackColor = System.Drawing.Color.CornflowerBlue,
            //    AutoSize = false,
            //    Dock = System.Windows.Forms.DockStyle.Fill,
            //    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
            //    Font = new System.Drawing.Font("Webbings", 48, System.Drawing.FontStyle.Bold),
            //    Text = "c"
            //};
            //tableLayoutPanel1.Controls.Add(lbl1, 3, 2);
            ////4 rida
            //lbl1 = new Label()
            //{
            //    BackColor = System.Drawing.Color.CornflowerBlue,
            //    AutoSize = false,
            //    Dock = System.Windows.Forms.DockStyle.Fill,
            //    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
            //    Font = new System.Drawing.Font("Webbings", 48, System.Drawing.FontStyle.Bold),
            //    Text = "c"
            //};
            //tableLayoutPanel1.Controls.Add(lbl1, 0, 3);
            //lbl1 = new Label()
            //{
            //    BackColor = System.Drawing.Color.CornflowerBlue,
            //    AutoSize = false,
            //    Dock = System.Windows.Forms.DockStyle.Fill,
            //    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
            //    Font = new System.Drawing.Font("Webbings", 48, System.Drawing.FontStyle.Bold),
            //    Text = "c"
            //};
            //tableLayoutPanel1.Controls.Add(lbl1, 1, 3);
            //lbl1 = new Label()
            //{
            //    BackColor = System.Drawing.Color.CornflowerBlue,
            //    AutoSize = false,
            //    Dock = System.Windows.Forms.DockStyle.Fill,
            //    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
            //    Font = new System.Drawing.Font("Webbings", 48, System.Drawing.FontStyle.Bold),
            //    Text = "c"
            //};
            //tableLayoutPanel1.Controls.Add(lbl1, 2, 3);
            //lbl1 = new Label()
            //{
            //    BackColor = System.Drawing.Color.CornflowerBlue,
            //    AutoSize = false,
            //    Dock = System.Windows.Forms.DockStyle.Fill,
            //    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
            //    Font = new System.Drawing.Font("Webbings", 48, System.Drawing.FontStyle.Bold),
            //    Text = "c"
            //};
            //tableLayoutPanel1.Controls.Add(lbl1, 3, 3);
        }

        

        //private void AssignIconsToSquares()
        //{
        //    foreach (Control control in tableLayoutPanel1.Controls)
        //    {
        //        Label iconLabel = control as Label;
        //        if (iconLabel != null)
        //        {
        //            int randomNumber = random.Next(icons.Count);
        //            iconLabel.Text = icons[randomNumber];
        //            icons.RemoveAt(randomNumber);
        //        }
        //    }
        //}
        //private void Lbl1_Click(object sender, EventArgs e)
        //{
        //    Label clickedLabel = sender as Label;

        //    if (clickedLabel != null)
        //    {
        //        if (clickedLabel.ForeColor == Color.Black)
        //            return;

        //        clickedLabel.ForeColor = Color.Black;
        //    }
        //}
    }
}
