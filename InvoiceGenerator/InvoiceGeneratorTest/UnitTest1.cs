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
        [Test]
        public void GivenMultipleRides_ShouldReturnResult()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            Ride[] rides = {new Ride(3,5),new Ride(4,6)};
            double actual = invoiceGenerator.MultipleRides(rides);
            Assert.AreEqual(actual,35,46);
        }
    }
}