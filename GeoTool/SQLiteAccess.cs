using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using Dapper;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Windows.Forms;

namespace GeoTool
{
    class SQLiteAccess
    {
        public static DataSet LoadData()
        {
            using (SQLiteConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Open();
                SQLiteDataAdapter dataadapter = new SQLiteDataAdapter("select * from Point", conn);
                DataSet ds = new System.Data.DataSet();

                dataadapter.Fill(ds, "Info");
                return ds;        
            }
        }
        public static List<Measurement> LoadList(string command)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = conn.Query<Measurement>(command, new DynamicParameters());
                return output.ToList();
            }
        }
        public static List<String> LoadTypes()
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = conn.Query<String>("SELECT Type from Point group by Type", new DynamicParameters());
                return output.ToList();
            }
        }
        public static List<String> LoadAges()
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = conn.Query<String>("SELECT Age from Point group by Age", new DynamicParameters());
                return output.ToList();
            }
        }
        public static void SaveData(Measurement myData)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {   
                conn.Execute("insert into Point (Latitude, Longitude, Strike, Dip, Type, Age) values (@Latitude, @Longitude, @Strike, @Dip, @Type, @Age)", myData);
            }
        }
        public static void DeleteData(int id)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                var sqlStatement = "DELETE from Point WHERE Id = @Id";
                conn.Execute(sqlStatement, new { Id = id });
            }
        }
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
        public static void ImportData()
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "csv|*.csv", ValidateNames = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (var reader = new StreamReader(ofd.FileName))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        try
                        {
                            var records = csv.GetRecords<Measurement>();
                            string error = "";
                            int cnt = 0;
                            foreach (var r in records)
                            {
                                bool ok = true;
                                cnt++;
                                if (r.Dip < 0 || r.Dip > 90)
                                    ok = false;
                                if (r.Strike < 0 || r.Strike > 360)
                                    ok = false;
                                if ((r.Latitude < -90 || r.Latitude > 90))
                                    ok = false;
                                if (r.Longitude < -180 || r.Longitude > 180)
                                    ok = false;

                                if (ok)
                                    SaveData(r);
                                else
                                    error += "line " + cnt + "\n";
                            }
                            if(error!="")
                                MessageBox.Show("Some of records are incorrect and were discarded: \n" + error);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Input file is incorrect");
                        }
                    }
                }
            }
        }
        public static void ExportData()
        {
            List<Measurement> data = LoadList("select * from Point");

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "csv|*.csv", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var writer = new StreamWriter(sfd.FileName))
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.WriteRecords(data);
                    }
                }
            }
        }
    }
}
