using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        public readonly int MIN_FARE;
        public readonly int FARE_PER_KM;
        public readonly int FARE_PER_MIN;
        RideRepository repo = new RideRepository();
        public InvoiceGenerator(CategoryOfRides ride)
        {
            try
            {
                if(ride.Equals(CategoryOfRides.NORMAL_RIDE))
                {
                    this.MIN_FARE = 5;
                    this.FARE_PER_KM = 10;
                    this.FARE_PER_MIN = 1;
                }
                if(ride.Equals(CategoryOfRides.PREMIUM_RIDE))
                {
                    this.MIN_FARE = 20;
                    this.FARE_PER_KM = 15;
                    this.FARE_PER_MIN=2;
                }
            }
            catch(InvoiceGeneratorException ex)
            {
                throw new InvoiceGeneratorException(InvoiceGeneratorException.ExceptionType.NO_RIDES,"Null rides");
            }
        }
        public double CalculateFare(int distance,int time)
        {
            try
            {
                if(distance <=0)
                {
                    throw new InvoiceGeneratorException(InvoiceGeneratorException.ExceptionType.DISTANCE_INVALID, "Distance is Invalid");
                }
                if(time <=0)
                {
                    throw new InvoiceGeneratorException(InvoiceGeneratorException.ExceptionType.TIME_INVALID, "Time is Invalid");
                }
            }
            catch (InvoiceGeneratorException ex)
            {
                throw ex;
            }
            double calulateFare = distance * FARE_PER_KM + time * FARE_PER_MIN;
            return Math.Max(calulateFare,MIN_FARE);
        }
        public double MultipleRides(Ride[] rides)
        {
            double result = 0;
            try
            {
                if(rides == null)
                {
                    throw new InvoiceGeneratorException(InvoiceGeneratorException.ExceptionType.NO_RIDES, "Null rides");
                }
            }
            catch(InvoiceGeneratorException ex)
            {
                throw ex;
            }
            foreach(var ride in rides)
            {
                result += CalculateFare(ride.distance,ride.time); 
            }
            return result/rides.Length;
        }
        public InvoiceSummary MultipleRidesInvoice(Ride[] rides)
        {
            double result = 0;
            try
            {
                if (rides == null)
                {
                    throw new InvoiceGeneratorException(InvoiceGeneratorException.ExceptionType.NO_RIDES, "Null rides");
                }
            }
            catch (InvoiceGeneratorException ex)
            {
                throw ex;
            }
            foreach (var ride in rides)
            {
                result += CalculateFare(ride.distance, ride.time);
            }
            return new InvoiceSummary(rides.Length, result);
        }
        public void MapUserId(string userId,Ride[] rides)
        {
            this.repo.AddRides(userId, rides);
        }
        public InvoiceSummary GetRideInvoiceSummary(string userId)
        {
            Ride[] result = this.repo.GetRides(userId);
            return MultipleRidesInvoice(result);
        }
        public InvoiceSummary RidesCategory(Ride[] rides)
        {
            double result=0;
            try
            {
                if (rides == null)
                {
                    throw new InvoiceGeneratorException(InvoiceGeneratorException.ExceptionType.NO_RIDES, "Null rides");
                }
            }
            catch (InvoiceGeneratorException ex)
            {
                throw ex;
            }
            foreach(var data in rides)
            {
                result += CalculateFare(data.distance,data.time);
            }
            return new InvoiceSummary(rides.Length,result);
        }
    }
}
