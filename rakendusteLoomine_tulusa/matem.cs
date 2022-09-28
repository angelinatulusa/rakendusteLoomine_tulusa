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
        Label timeLabel;
        TableLayoutPanel tableLayoutPanel;
        string[,] l_nimed;
        string[] tehed = new string[4] { "+", "-", "/", "*" };
        string text;
        public matem()
        {
            this.Size = new Size(660, 400);
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
            l_nimed = new string[5, 4];
            for (int i = 0; i < 4; i++)
            {
                tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
                for (int j = 0; j < 5; j++)
                {
                    tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
                    var l_nimi = "L" + j.ToString() + i.ToString();
                    l_nimed[j, i] = l_nimi;
                    if (j==1)
                    {
                        text = tehed[i];
                    }
                    else if (j==3)
                    {
                        text = "=";
                    }
                    else if (j==4)
                    {
                        text = "vastus";
                    }
                    else
                    {
                        text = l_nimi;
                    }
                    Label l=new Label { Text = text };
                    tableLayoutPanel.Controls.Add(l,j,i);
                }
            }
            this.Controls.Add(tableLayoutPanel);
            this.Controls.Add(timeLabel);
            
        }
    }
}
