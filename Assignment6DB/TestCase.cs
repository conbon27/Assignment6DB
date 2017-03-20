using MySql.Data.MySqlClient;
using NUnit.Framework;
using System.Transactions;

namespace Assignment6DB
{
    [TestFixture]
    public class YourFixture
    {
        private TransactionScope scope;
        // creates connection variable
        private readonly MySqlConnection conn = new MySqlConnection("Server = danu6.it.nuigalway.ie; Database = mydb2463; Uid = mydb2463ca; Pwd = mi3tax");

        [SetUp]
        public void SetUp()
        {
            scope = new TransactionScope();
        }

        [TearDown]
        public void TearDown()
        {
            scope.Dispose();
        }

        [Test]
        public void TestAverage()
        {
            using (TransactionScope scope = new TransactionScope()) {
                Orders o1 = new Orders();
                // method to create new order table
                o1.orderCreation();
                // method to insert data into order table
                o1.Insert();
                o1.Add();
                // method to update data in table
                o1.updateTable();
                // method to delete
                o1.deleteDB();
                o1.AverageOrder();
                // assert
                Assert.AreEqual(144.84m, o1.AverageOrder());
            }
        }
        [Test]
        public void TestCustomerCount()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                Customer c1 = new Customer();
                
                c1.updateTable();
                int count = 1;                
                Assert.AreEqual(count, c1.CustomerCount());
            }
        }
        [Test]
        public void TestLargestOrder()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                Orders o1 = new Orders();
                // method to create new order
                // assertion
                decimal expected = 234.45m;
                Assert.AreEqual(expected, o1.LargestOrder());
            }
        }
        [Test]
        public void TestTotalOrder()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                Orders o1 = new Orders();
                // method to create new order
                // assertion
                decimal expected = 289.68m;
                Assert.AreEqual(expected, o1.TotalOrders());
            }
        }
        [Test]
        public void TestCheapest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                Product p1 = new Product();
                // method to create new order
                // assertion
                decimal expected = 0.65m;
                Assert.AreEqual(expected, p1.Cheap());
            }
        }
    }
}
