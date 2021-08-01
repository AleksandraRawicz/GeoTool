using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoTool
{
    public partial class InformationPanel : Form
    {
        public InformationPanel(int i)
        {
            InitializeComponent();
            if(i==2)
            {                
                panel3.Hide();
                panel2.Location = new System.Drawing.Point(10, 10);
                panel2.Show();
            }
            if(i==3)
            {
                panel2.Hide();
                panel3.Location = new System.Drawing.Point(10, 10);
                panel3.Show();
            }
        }

    }
}
