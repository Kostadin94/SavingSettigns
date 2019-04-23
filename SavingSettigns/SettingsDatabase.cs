using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography;

namespace SavingSettigns
{
    internal class SettingsDatabase
    {
        private DataSet mAllData;

        public DataSet AllData
        {
            get { return mAllData; }
            set { mAllData = value; }
        }
        public XMLReader DataSource;
        public SettingsDatabase(string FileName)
        {
            DataSource = new XMLReader();
            FilePath =FolderPath+FileName;
            if (AllData == null)
            {
                if (File.Exists(FilePath))
                    AllData = DataSource.Read(FilePath);
                else
                    AllData = new DataSet("Settings");
            }
        }
        public string FilePath;
        public static string FolderPath
        {
            get { return Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\Settings\\"; }
            set { }
        }

       public bool Save()
        {
            DataSource.Save(AllData, FilePath);
            return true;
        }

        public void Save(string FilePath)
        {
            DataSource.Save(AllData, FilePath);
        }

        public void AddTable(DataTable t)
        {
            if (t.DataSet != null && t.DataSet != AllData)
            {
                t = t.Copy();
            }
            AllData.Tables.Add(t);
        }

       public DataTable GetTable(string name)
        {
            return AllData.Tables[name];
        }
    }
    internal class XMLReader
    {
        public void Dispose() { }
        public XMLReader() { }
        public System.Data.DataSet Read(string FilePath)
        {
            if (File.Exists(FilePath) && IsValid(FilePath))
            {
                try
                {
                    DataSet s = new DataSet();
                    s.ReadXml(FilePath);
                    return s;
                }
                catch
                {
                    System.Windows.MessageBox.Show("Failed to read XML file " + FilePath);
                }
            }
            return null;
        }

   
        public bool IsValid(string FilePath)
        {
            return (Path.GetExtension(FilePath) == ".xml");
        }
        public void Save(System.Data.DataSet Data, string FilePath)
        {
            if (!Directory.Exists(Path.GetDirectoryName(FilePath)))
                Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
            

           Data.WriteXml(FilePath);
        }
    }
}