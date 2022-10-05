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
    public partial class koikVormid : Form
    {
        Button pilt, matem, parid;
        public koikVormid()
        {
            this.Size = new System.Drawing.Size(600, 300);
            BackColor = Color.LightBlue;
            pilt = new Button()
            {
                Text = "pildid",
                Location=new System.Drawing.Point(100,125),
                Size = new System.Drawing.Size(100, 50),
                BackColor = Color.LightYellow,
            };
            matem = new Button()
            {
                Text="matemaatika",
                Location = new System.Drawing.Point(250, 125),
                Size = new System.Drawing.Size(100, 50),
                BackColor = Color.LightCoral,
            };
            parid = new Button()
            {
                Text="parid",
                Location = new System.Drawing.Point(400, 125),
                Size = new System.Drawing.Size(100, 50),
                BackColor = Color.LightGoldenrodYellow,
            };
            pilt.Click += Pilt_Click;
            matem.Click += Matem_Click;
            parid.Click += Parid_Click;
            this.Controls.Add(pilt);
            this.Controls.Add(matem);
            this.Controls.Add(parid);
        }

        private void Parid_Click(object sender, EventArgs e)
        {
            sobitamine Parid = new sobitamine();
            Parid.ShowDialog();
        }

        private void Matem_Click(object sender, EventArgs e)
        {
            matem Matem = new matem ();
            Matem.ShowDialog();
        }

        private void Pilt_Click(object sender, EventArgs e)
        {
            piltideVaataja PiltideVaataja = new piltideVaataja();
            PiltideVaataja.ShowDialog();
        }
    }
}
