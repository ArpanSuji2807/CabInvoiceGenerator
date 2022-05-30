using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceGeneratorException:Exception
    {
        public ExceptionType exceptionType;
        //Enum for declaring constants
        public enum ExceptionType
        {
            TIME_INVALID,
            DISTANCE_INVALID,
            NO_RIDES
        }
        //Constructor for custom Exception
        public InvoiceGeneratorException(ExceptionType exceptionType, string message) : base(message)
        {
            this.exceptionType = exceptionType;
        }
    }
}
