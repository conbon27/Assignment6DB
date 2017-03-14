using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Assignment6DB
{
    [TestFixture]
    public class YourFixture
    {
        private TransactionScope scope;

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
        public void testAverage()
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
                o1.averageOrder();
                // assert
                 Assert.AreEqual(114.970000, o1.avg);
            }
        }
    }
}
