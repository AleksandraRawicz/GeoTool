using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Windows.Forms;

namespace GeoTool
{
    public partial class GeoTOOL : Form
    {
        public GeoTOOL()
        {
            InitializeComponent();
            CustomizeDesign();
        }

        private void CustomizeDesign()
        {
            panelSubMenuDane.Visible = false;
            panelSubMenuWykresy.Visible = false;
        }

        private void HideSubMenu()
        {
            if(panelSubMenuDane.Visible)
            {
                panelSubMenuDane.Visible = false;
            }
            if (panelSubMenuWykresy.Visible)
            {
                panelSubMenuWykresy.Visible = false;
            }
        }

        private void ShowSubMenu(Panel panelMenu)
        {
            if(!panelMenu.Visible)
            {
                HideSubMenu();
                panelMenu.Visible = true;
            }
            else
            {
                panelMenu.Visible = false;
            }
        }

        private void buttonDane_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelSubMenuDane);
        }

        private void buttonWykresy_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelSubMenuWykresy);
        }

        private Form activeForm = null;
        private void OpenChildForm(Form childForm)
        {
            if(activeForm!=null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void buttonRozetowe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new RosePanel());
        }


        private void buttonStereonet_Click(object sender, EventArgs e)
        {
            OpenChildForm(new StereonetPanel());
        }

        private void buttonDodajPomiar_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AddDataPanel());
        }

        private void buttonPrzegladajDane_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MeasurementsPanel());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteAccess.ExportData();
            }
            catch(Exception)
            {
                MessageBox.Show("file couldn't be created");
            }
        }

        private void buttonLaduj_Click(object sender, EventArgs e)
        {
            OpenChildForm(new InformationPanel(2));
            SQLiteAccess.ImportData();
        }

        private void buttonUstawienia_Click(object sender, EventArgs e)
        {
            OpenChildForm(new InformationPanel(3));
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new ContourGraphPanel());
        }
    }
}
