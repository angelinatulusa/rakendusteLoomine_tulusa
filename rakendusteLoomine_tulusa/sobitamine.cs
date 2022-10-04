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
        public sobitamine()
        {
            
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            this.Size = new Size(900, 900);
            tableLayoutPanel = new TableLayoutPanel
            {
                AutoSize = true,
                ColumnCount = 4,
                RowCount = 4,
                Location = new System.Drawing.Point(45, 30),
                BackColor = System.Drawing.Color.LightSteelBlue,
                Size = new Size(800,800)
            };
            
            this.Controls.Add(tableLayoutPanel);
        }
    }
}
