using CabInvoiceGenerator;
using NUnit.Framework;

namespace InvoiceGeneratorTest
{
    public class Tests
    {
        [Test]
        public void GivenTimeAndDistance_ShouldReturnTotalFare()
        {
            InvoiceGenerator invoice = new InvoiceGenerator(); 
            double actual = invoice.CalculateFare(2,3);
            Assert.AreEqual(actual,23);
        }
    }
}