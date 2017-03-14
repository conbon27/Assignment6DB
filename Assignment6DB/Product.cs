using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Assignment6DB
{
    class Product
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
                string readDB = @"SELECT * FROM ProductTab;";
                MySqlCommand cmdRead = new MySqlCommand(readDB, conn);
                reader = cmdRead.ExecuteReader();
                while (reader.Read())
                {
                    // write out columns
                    Console.WriteLine(reader["ID"] + " " + reader["ProductName"]);
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
        public void ProductCreation()
        {
            MySqlCommand command = conn.CreateCommand();
            // this is where your SQL goes
            command.CommandText = "CREATE TABLE ProductTab(ID int not null unique, ProductName varchar(55) not null,ProductDesc varchar(100),Price decimal(5,2) not null, PRIMARY KEY (ID));";
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
                string insertDB = @"INSERT INTO ProductTab(ID, ProductName, ProductDesc, Price) VALUES('1', 'Popcorn', 'Salty stuff', '1.00'),('2', 'Cheese', 'cheesey strings', '2.30'), ('3', 'Sweetcorn', 'Canned goodness','0.65'), ('4', 'Sweetcorn', 'Canned goodness','0.65');";
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
                string addDB = @"ALTER TABLE ProductTab ADD (Misc varchar(50));";
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
                string updateDB = @"UPDATE ProductTab SET Price = '1.05' WHERE ID = '1';";
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
                string deleteDB = @"DELETE FROM ProductTab WHERE ID = '4';";
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