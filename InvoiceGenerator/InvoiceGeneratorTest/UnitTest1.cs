using CabInvoiceGenerator;
using NUnit.Framework;

namespace InvoiceGeneratorTest
{
    public class Tests
    {
        [Test]
        public void GivenTimeAndDistance_ShouldReturnTotalFare()
        {
            InvoiceGenerator invoice = new InvoiceGenerator(CategoryOfRides.NORMAL_RIDE); 
            double actual = invoice.CalculateFare(2,3);
            Assert.AreEqual(actual,23);
        }
        [Test]
        public void GivenMultipleRides_ShouldReturnResult()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(CategoryOfRides.NORMAL_RIDE);
            Ride[] rides = {new Ride(3,5),new Ride(4,6)};
            double actual = invoiceGenerator.MultipleRides(rides);
            Assert.AreEqual(actual,35,46);
        }
        [Test]
        public void GivenMultipleRides_ShouldReturnInvoiceSummary()
        {
            InvoiceGenerator invoice = new InvoiceGenerator(CategoryOfRides.NORMAL_RIDE);
            Ride[] rides = { new Ride(2, 3), new Ride(4, 5),new Ride(5,6)};
            InvoiceSummary result = invoice.MultipleRidesInvoice(rides);
            Assert.AreEqual(result.totalNumberOfRides,rides.Length);
        }
        [Test]
        public void GivenUserId_ShouldReturnInvoiceSummary()
        {
            InvoiceGenerator invoice = new InvoiceGenerator(CategoryOfRides.NORMAL_RIDE);
            Ride[] rides = { new Ride(2, 3), new Ride(4, 5), new Ride(5, 6) };
            invoice.MapUserId("arpan2807",rides);
            InvoiceSummary summary = invoice.GetRideInvoiceSummary("arpan2807");
            Assert.AreEqual(summary.totalNumberOfRides,3);
        }
        [Test]
        public void GivenInput_ShouldReturnPremiumRidesInvoiceSummary()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(CategoryOfRides.PREMIUM_RIDE);
            Ride[] rides = { new Ride(2, 3), new Ride(4, 5), new Ride(5, 6) };
            InvoiceSummary summary = invoiceGenerator.RidesCategory(rides);
            Assert.AreEqual(summary.totalNumberOfRides, rides.Length);
        }
    }
}