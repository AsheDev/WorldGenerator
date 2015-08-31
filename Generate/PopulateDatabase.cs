using Connections;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generate
{
    public class PopulateDatabaseNames
    {
        private readonly IDataSource _dataSource;

        public PopulateDatabaseNames(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        // Example file name:
        // C:\Users\Michael\Documents\Visual Studio 2013\Projects\WorldGenerator\Generate\Names\Adjectives.txt
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="delimiter">Expected delimiter is a pipe character: "|"</param>
        public void AddNames(string file, string delimiter)
        {
            // currently this only handles races and not deitys, adjectives, locations or whatnot (not really masculine/feminine either)

            DataTable nameListing = new DataTable();
            nameListing.Columns.Add("FK_RaceId", typeof(int)); // I think I can get rid of this?..
            nameListing.Columns.Add("Name", typeof(string));
            nameListing.Columns.Add("Masculine", typeof(bool));

            using (TextFieldParser parser = new TextFieldParser(file))
            {
                parser.Delimiters = new string[] { delimiter };
                while (true)
                {
                    string[] names = parser.ReadFields();
                    if (names == null) break;


                    foreach (string name in names)
                    {
                        DataRow row = nameListing.NewRow();
                        row["FK_RaceId"] = 0; // I think I can get rid of this?..
                        row["Name"] = name;
                        row["Masculine"] = false; // TODO
                        nameListing.Rows.Add(row);
                    }
                }
            }

            // call the database
            // move this somewhere else when you have time
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Names", nameListing);
            DataTable returnedTable = new Database("WorldGen").Crud("w.RaceNameAdd", parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="delimiter">Expected delimiter is a pipe character: "|"</param>
        public void AddAdjectives()
        {
            // currently this only handles races and not deitys, adjectives, locations or whatnot (not really masculine/feminine either)

            DataTable nameListing = new DataTable();
            nameListing.Columns.Add("Name", typeof(string));

            using (TextFieldParser parser = new TextFieldParser(@"C:\Users\Michael Ovies\Source\Repos\WorldGenerator\WorldGen.Database\WordsAndNames\Adjectives.txt"))
            {
                parser.Delimiters = new string[] { "|" };
                while (true)
                {
                    string[] names = parser.ReadFields();
                    if (names == null) break;

                    foreach (string name in names)
                    {
                        DataRow row = nameListing.NewRow();
                        row["Name"] = name;
                        nameListing.Rows.Add(row);
                    }
                }
            }

            // call the database
            // move this somewhere else when you have time
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Words", nameListing);
            DataTable returnedTable = _dataSource.Crud("w.AdjectiveAdd", parameters);
        }
    }
}
