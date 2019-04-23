using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Data;

namespace SavingSettigns
{
    class Settings
    {
        public SettingsDatabase Data;

        public Settings(string FileName)
        {
            Data = new SettingsDatabase(FileName);
        }

        //public void Init()
        //{
        //    if (File.Exists(Data.FilePath))
        //    {
        //        try
        //        {
        //            foreach (Metric m in MainWindow.AllData)
        //            {
        //                DataTable t = SettingsDatabase.Instance.GetTable(m.Info.Name);
        //                if (t != null)
        //                {
        //                    m.Instance.Keywords = t.Rows[0]["Keywords"].ToString().Trim(new char[] { '"', ' ', ';' }).Split(';');
        //                }
        //            }
        //        }
        //        catch { }
        //        try
        //        {
        //            DataTable ex = SettingsDatabase.Instance.GetTable("ExcelExtractor");
        //            if (ex != null)
        //            {
        //                ExcelExtractor.Instance.IdCol = Convert.ToInt32(ex.Rows[0]["ID"].ToString());
        //                ExcelExtractor.Instance.TextCol = Convert.ToInt32(ex.Rows[0]["Text"].ToString());
        //                ExcelExtractor.Instance.FilePath = ex.Rows[0]["Path"].ToString();
        //            }
        //            ExcelExtractor.Instance.Read(ExcelExtractor.Instance.FilePath);
        //        }
        //        catch { }
        //    }
        //}
        public void SaveSettings()
        {
            Data.AllData = new DataSet("Settings");

            //Adding textbox value
            DataTable tb = new DataTable(Program.mWindow.tb1.Name);            
            tb.Columns.Add("Value");
            DataRow row = tb.NewRow();
            row["Value"] = Program.mWindow.tb1.Text;
            tb.Rows.Add(row);
            Data.AllData.Tables.Add(tb);

            //Adding radio buttons
            DataTable rb1 = new DataTable("Radio1");
            rb1.Columns.Add("Value");
            DataRow row1 = rb1.NewRow();
            row1["Value"] = Program.mWindow.radioButton1.IsChecked;
            rb1.Rows.Add(row1);
            Data.AllData.Tables.Add(rb1);

            DataTable rb2 = new DataTable("Radio2");
            rb2.Columns.Add("Value");
            DataRow row2 = rb2.NewRow();
            row2["Value"] = Program.mWindow.radioButton2.IsChecked;
            rb2.Rows.Add(row2);
            Data.AllData.Tables.Add(rb2);

            DataTable rb3 = new DataTable("Radio3");
            rb3.Columns.Add("Value");
            DataRow row3 = rb3.NewRow();
            row3["Value"] = Program.mWindow.radioButton3.IsChecked;
            rb3.Rows.Add(row3);
            Data.AllData.Tables.Add(rb3);

            //Adding checkboxes
            #region Checkboxes
            DataTable cb1 = new DataTable("Checkbox1");
            cb1.Columns.Add("Value");
            DataRow cbrow1 = cb1.NewRow();
            cbrow1["Value"] = Program.mWindow.checkBox1.IsChecked;
            cb1.Rows.Add(cbrow1);
            Data.AllData.Tables.Add(cb1);
            
            DataTable cb2 = new DataTable("Checkbox2");
            cb2.Columns.Add("Value");
            DataRow cbrow2= cb2.NewRow();
            cbrow2["Value"] = Program.mWindow.checkBox2.IsChecked;
            cb2.Rows.Add(cbrow2);
            Data.AllData.Tables.Add(cb2);
            
            DataTable cb3 = new DataTable("Checkbox3");
            cb3.Columns.Add("Value");
            DataRow cbrow3 = cb3.NewRow();
            cbrow3["Value"] = Program.mWindow.checkBox3.IsChecked;
            cb3.Rows.Add(cbrow3);
            Data.AllData.Tables.Add(cb3);
            
            DataTable cb4 = new DataTable("Checkbox4");
            cb4.Columns.Add("Value");
            DataRow cbrow4 = cb4.NewRow();
            cbrow4["Value"] = Program.mWindow.checkBox4.IsChecked;
            cb4.Rows.Add(cbrow4);
            Data.AddTable(cb4);
            
            DataTable cb5 = new DataTable("Checkbox5");
            cb5.Columns.Add("Value");
            DataRow cbrow5 = cb5.NewRow();
            cbrow5["Value"] = Program.mWindow.checkBox5.IsChecked;
            cb5.Rows.Add(cbrow5);
            Data.AllData.Tables.Add(cb5);
            
            DataTable cb6 = new DataTable("Checkbox6");
            cb6.Columns.Add("Value");
            DataRow cbrow6 = cb6.NewRow();
            cbrow6["Value"] = Program.mWindow.checkBox6.IsChecked;
            cb6.Rows.Add(cbrow6);
            Data.AllData.Tables.Add(cb6);
            #endregion Checkboxes   

            //Adding Combobox

            DataTable cbox1 = new DataTable("Combobox");
            cbox1.Columns.Add("Value");
            DataRow cxrow1 = cbox1.NewRow();
            cxrow1["Value"] = Program.mWindow.comboBox1.SelectedIndex;
            cbox1.Rows.Add(cxrow1);
            Data.AllData.Tables.Add(cbox1);
            
            Data.Save();

            Logger.WriteToFile("Settings: Settings saved");
        }

        public void Init()
        {
            if (File.Exists(Data.FilePath))
            {
                Logger.WriteToFile("Settings:Reading settings");
                Program.mWindow.tb1.Text = Data.GetTable(Program.mWindow.tb1.Name).Rows[0]["Value"].ToString();
                Program.mWindow.radioButton1.IsChecked = Convert.ToBoolean(Data.GetTable("Radio1").Rows[0]["Value"].ToString());
                Program.mWindow.radioButton2.IsChecked = Convert.ToBoolean(Data.GetTable("Radio2").Rows[0]["Value"].ToString());
                Program.mWindow.radioButton3.IsChecked = Convert.ToBoolean(Data.GetTable("Radio3").Rows[0]["Value"].ToString());
                Program.mWindow.checkBox1.IsChecked = Convert.ToBoolean(Data.GetTable("Checkbox1").Rows[0]["Value"].ToString());
                Program.mWindow.checkBox2.IsChecked = Convert.ToBoolean(Data.GetTable("Checkbox2").Rows[0]["Value"].ToString());
                Program.mWindow.checkBox3.IsChecked = Convert.ToBoolean(Data.GetTable("Checkbox3").Rows[0]["Value"].ToString());
                Program.mWindow.checkBox4.IsChecked = Convert.ToBoolean(Data.GetTable("Checkbox4").Rows[0]["Value"].ToString());
                Program.mWindow.checkBox5.IsChecked = Convert.ToBoolean(Data.GetTable("Checkbox5").Rows[0]["Value"].ToString());
                Program.mWindow.checkBox6.IsChecked = Convert.ToBoolean(Data.GetTable("Checkbox6").Rows[0]["Value"].ToString());
                Program.mWindow.comboBox1.SelectedIndex = Convert.ToInt32(Data.GetTable("Combobox").Rows[0]["Value"].ToString());
            }
        }
    }
}
