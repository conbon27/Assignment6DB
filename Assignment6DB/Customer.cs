using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Assignment6DB
{
    class Customer
    {
        // creates connection variable
        private readonly MySqlConnection conn = new MySqlConnection("Server = danu6.it.nuigalway.ie; Database = mydb2463; Uid = mydb2463ca; Pwd = mi3tax");
        // creates reader
        MySqlDataReader reader = null;

        public void ReadTable()
        {
            try
            {
                // open connection
                conn.Open();

                // populate tables - 1 run for each table
                string readDB = @"SELECT * FROM CustomerTab;";
                MySqlCommand cmdRead = new MySqlCommand(readDB, conn);
                reader = cmdRead.ExecuteReader();
                while (reader.Read())
                {
                    // write out columns
                    Console.WriteLine(reader["ID"] + " " + reader["CustomerName"] + " " + reader["Address"] + " " + reader["PaymentType"]);
                }
            }
            catch (Exception ex)
            {
                // outputs error message
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        // creation method
        public void customerCreation()
        {
            MySqlCommand command = conn.CreateCommand();
            // this is where your SQL goes
            command.CommandText = "CREATE TABLE CustomerTab(ID int not null unique, CustomerName varchar(55) not null, Address varchar(100), PaymentType varchar(15) not null, PRIMARY KEY (ID));";
            command.Connection = conn;
            try
            {
                // opens connection
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // outputs error message
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // close the reader
                if (reader != null)
                {
                    reader.Close();
                }
                // close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        // insertion method
        public void Insert()
        {
            try
            {
                conn.Open();
                // populate table with data per columns
                string insertDB = @"INSERT INTO CustomerTab (ID, CustomerName, Address, PaymentType) VALUES ('101', 'Gerry Sleeze', '123 Fake Street', 'Credit Card'), ('102', 'Sinead Longworth', '23 Rememberance Lane','Cash'), ('103', 'Sinead Longworth', '23 Rememberance Lane','Cash');";
                MySqlCommand cmdInsert = new MySqlCommand(insertDB, conn);
                cmdInsert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // outputs error message
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        // add method
        public void Add()
        {
            try
            {
                conn.Open();
                // add data with data per columns
                string addDB = @"ALTER TABLE CustomerTab ADD (Complaints varchar(50));";
                // add data to DB command object
                MySqlCommand cmdAdd = new MySqlCommand(addDB, conn);
                cmdAdd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // outputs error message
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        // update data method
        public void updateTable()
        {
            try
            {
                conn.Open();
                // update data with data per columns
                string updateDB = @"UPDATE CustomerTab SET Complaints = 'Yes' WHERE ID = '101';";
                // update command object
                MySqlCommand cmdUpdate = new MySqlCommand(updateDB, conn);
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // outputs error message
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        // delete method
        public void deleteDB()
        {
            try
            {
                conn.Open();
                // delete data
                string deleteDB = @"DELETE FROM CustomerTab WHERE ID = '103';";
                // delete data 
                MySqlCommand cmdDelete = new MySqlCommand(deleteDB, conn);
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // outputs error message
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}