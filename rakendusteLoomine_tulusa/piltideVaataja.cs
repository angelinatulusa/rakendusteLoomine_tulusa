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
        public piltideVaataja()
        {
            Height = 400;
            Width = 500;
            Text = "piltide vaataja";

            tableLayoutPanel1 = new TableLayoutPanel
            {
                AutoSize = true,
                ColumnCount = 2,
                RowCount = 2,
                Location = new System.Drawing.Point(0, 0),
                Size = new System.Drawing.Size(500, 400),
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
                TabStop=false
            };
            tableLayoutPanel1.Controls.Add(pictureBox, 0, 0);
            tableLayoutPanel1.SetCellPosition(pictureBox, new TableLayoutPanelCellPosition(0, 0));
            tableLayoutPanel1.SetColumnSpan(pictureBox, 2);
            close = new Button
            {
                Text="sule",
                Dock=System.Windows.Forms.DockStyle.Fill
            };
            clear = new Button
            {
                Text = "kustuta",
                Dock = System.Windows.Forms.DockStyle.Fill
            };
            show = new Button
            {
                Text = "näita",
                Dock = System.Windows.Forms.DockStyle.Fill
            };
            Button[] buttons = {clear, show,close};
            flowLayoutPanel1 = new FlowLayoutPanel
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                FlowDirection=FlowDirection.RightToLeft,
                AutoSize=true,
                WrapContents=false,
                AutoScroll=true,

            };
            foreach (Button button in buttons)
            {
                flowLayoutPanel1.Controls.Add(button);
            }
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 1, 1);
            this.Controls.Add(flowLayoutPanel1);
            //tableLayoutPanel1.Controls.Add(close,1,1);
            //tableLayoutPanel1.Controls.Add(clear, 1, 1);
            //tableLayoutPanel1.Controls.Add(show, 1, 1);
        }
    }
}
