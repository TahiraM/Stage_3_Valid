using System;
using System.Collections.Generic;
using System.Text;

namespace Stage3_Verification
{
    class Validations
    {
        public static string Error(string value)
        {
            value = "- Field Cannot be empty";
            return value;
        }
        public static string StriVal(string value)
        {

            return value;
        }

        public static Nullable<int> IntVal(string variable)
        {

            if (variable == "")
            {
                return 0;
            }
            else
            {
                Nullable<int> i = Convert.ToInt32(variable);
                return i;
            }

        }

        public static Nullable<double> DoubVal(string amount)
        {
            if (amount == "")
            {
                return 0;
            }
            else
            {
                Nullable<double> p = Convert.ToDouble(amount);
                return p;
            }

        }


    }
}
