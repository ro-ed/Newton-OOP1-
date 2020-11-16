using System;
using System.Collections.Generic;
using System.Text;


namespace Logic.Exceptions
{
    public class DateTimeException : Exception
    {
        public override string Message
        {
            get
            {
                return "Enter valid date format. ";
            }
        }
        public DateTimeException()
        {
           


        }
       
    }
}