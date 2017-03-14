using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Assignment6DB
{
    class Orders
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

                // populate table
                string readDB = @"SELECT * FROM OrderTab;";
                MySqlCommand cmdRead = new MySqlCommand(readDB, conn);
                reader = cmdRead.ExecuteReader();
                while (reader.Read())
                {
                    // write out columns
                    Console.WriteLine(reader["OID"] + " " + reader["CustomerID"] + " " + reader["OrderPrice"]);
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
        public void orderCreation()
        {
            MySqlCommand command = conn.CreateCommand();
            // this is where your SQL goes
            command.CommandText = "CREATE TABLE OrderTab(OID int not null unique, CustomerID int not null, OrderPrice decimal(5,2) not null, PRIMARY KEY (OID));";
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
                string insertDB = @"INSERT INTO OrderTab(OID, CustomerID, OrderPrice) VALUES ('1001', '1', '234.45'), ('1002', '2', '55.23'), ('1003', '2', '55.23');";
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
                string addDB = @"ALTER TABLE OrderTab ADD (Terms varchar(50));";
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
                string updateDB = @"UPDATE OrderTab SET Terms = 'Cash' WHERE ID = '1001';";
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
                string deleteDB = @"DELETE FROM OrderTab WHERE ID = '1003';";
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
