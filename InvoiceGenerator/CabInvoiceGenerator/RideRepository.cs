using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class RideRepository
    {
        Dictionary<string, Ride[]> rideDict = new Dictionary<string, Ride[]>();
        public void AddRides(string userId, Ride[] rides)
        {
            if(!rideDict.ContainsKey(userId))
            {
                rideDict.Add(userId, rides);
            }
        }
        public Ride[] GetRides(string userId)
        {
            foreach(var ride in rideDict)
            {
                if (ride.Key == userId)
                {
                    return ride.Value;
                }
            }
            return null;
        }
    }
}
