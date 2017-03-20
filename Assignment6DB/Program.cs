using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6DB
{
    class Program
    {
        static void Main(string[] args)
        {
            // instantiate new Product object to call methods
            Product p1 = new Product();
            // method to create new Product table
            p1.ProductCreation();

            // method to insert data into Product table
            p1.Insert();
            //return read
            p1.ReadTable();
            // method to add data to table
            p1.Add();
            //return read
            p1.ReadTable();
            // method to update data in table
            p1.updateTable();
            //return read
            p1.ReadTable();
            // method to delete
            p1.deleteDB();
            //return read
            p1.ReadTable();
            Console.ReadKey();

            // instantiate new customer object to call methods
            Customer c1 = new Customer();
            // method to create new Customer table
            c1.customerCreation();

            // method to insert data into Customer table
            c1.Insert();
            //return read
            c1.ReadTable();
            // method to add data to table
            c1.Add();
            //return read
            c1.ReadTable();
            // method to update data in table
            c1.updateTable();
            //return read
            c1.ReadTable();
            // method to delete
            c1.deleteDB();
            c1.CustomerCount();
            //return read
            c1.ReadTable();
            Console.ReadKey();

            Orders o1 = new Orders();
            // method to create new order table
            o1.orderCreation();

            // method to insert data into order table
            o1.Insert();
            //return read
            o1.ReadTable();
            // method to add data to table
            o1.Add();
            //return read
            o1.ReadTable();
            // method to update data in table
            o1.updateTable();
            //return read
            o1.ReadTable();
            // method to delete
            o1.deleteDB();
            // return read
            o1.ReadTable();
            // calculate average
            o1.AverageOrder();
            Console.ReadKey();
        }
    }
}
