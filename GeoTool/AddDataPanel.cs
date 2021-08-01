using System;
using System.Windows.Forms;
using System.Device.Location;

namespace GeoTool
{
    public partial class AddDataPanel : Form
    {
        public AddDataPanel()
        {
            InitializeComponent();
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            TypeBox.Items.Add("Fault");
            TypeBox.Items.Add("Layer");
            TypeBox.Items.Add("Other");

            AgeBox.Items.Add("Cambrian");
            AgeBox.Items.Add("Ordovician");
            AgeBox.Items.Add("Silurian");
            AgeBox.Items.Add("Devonian");
            AgeBox.Items.Add("Carboniferous");
            AgeBox.Items.Add("Permian");
        }

        private GeoCoordinateWatcher Watcher = null;
        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            double x = 0;double y=0;
            int bieg, upad;
            string typ="";
            string wiek="";

            bool poprawny=true;
            string error = "";           

            if (LatitudeBox.Text != "")
            {
                if (double.TryParse(LatitudeBox.Text, out x)) 
                {
                    if (x < -90 || x > 90)
                    { poprawny = false; error += "incorrect value of latitude \n"; }
                }
                else
                { poprawny = false; error += "incorrect value of latitude \n"; }
            }

            if (LongitudeBox.Text != "")
            {
                if (double.TryParse(LongitudeBox.Text, out y)) 
                {
                    if (y < -180 || y> 180)
                    { poprawny = false; error += "incorrect value of longitude \n"; }
                }
                else
                { poprawny = false; error += "incorrect value of longitude \n"; }
            }

            if (int.TryParse(StrikeBox.Text, out bieg))
            {
                if (bieg < 0 || bieg > 360)
                { poprawny = false; error += "incorrect value of dip direction \n"; }
            }
            else
            { poprawny = false; error += "incorrect value of dip direction \n"; }

            if (int.TryParse(DipBox.Text, out upad))
            {
                if (upad < 0 || upad > 90)
                { poprawny = false; error += "incorrect value of dip \n"; }
            }
            else
            { poprawny = false; error += "incorrect value of dip \n"; }

            typ = TypeBox.Text;
            wiek = AgeBox.Text;
           
            if (poprawny)
            {
                Measurement nowy = new Measurement(x,y,bieg,upad,typ,wiek);
                SQLiteAccess.SaveData(nowy);
                MessageBox.Show("new data was added");
                Wyczysc(this);
            }
            else
            {
                MessageBox.Show(error);
            }
        }

        private void Wyczysc(Control ctrl)
        {
            foreach (Control c in ctrl.Controls)
            {
                if (c is TextBox || c is ComboBox)
                {
                    c.Text = String.Empty;
                }

                if (c.Controls.Count > 0)
                {
                    Wyczysc(c);
                }
            }
        }

        private void buttonLokalizuj_Click(object sender, EventArgs e)
        {
            Watcher = new GeoCoordinateWatcher();
            Watcher.StatusChanged += Watcher_StatusChanged;           
            Watcher.Start();
        }
        private void Watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            if (e.Status == GeoPositionStatus.Ready)
            {
                if (Watcher.Position.Location.IsUnknown)
                {
                    MessageBox.Show("Cannot find location data");                    
                }
                else
                {
                    LatitudeBox.Text = Watcher.Position.Location.Latitude.ToString();
                    LongitudeBox.Text = Watcher.Position.Location.Longitude.ToString();
                }
            }
        }        
    }
}
