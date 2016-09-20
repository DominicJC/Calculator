/**
static utility class for the simple calculator.
**/

using System.Data;

namespace Calculator
{
    static class Calculate
    {
        //Main calculate method. Receives the input string and puts in into a data table.
        //String is calculated & parsed into a decimal which is returned to caller. 
        public static decimal calculate(string sum)
        {
              DataTable table = new DataTable();
              table.Columns.Add("sum", typeof(string), sum);
              DataRow row = table.NewRow();
              table.Rows.Add(row);
              return decimal.Parse((string)row["sum"]);
        }

        //Boolean check if string ends with an operator.
        public static bool CheckForDoubleOperator(string checkString)
        {
            if (checkString.EndsWith("+") || checkString.EndsWith("-")
                || checkString.EndsWith("*") || checkString.EndsWith("/"))
            {
                return true;
            }
            else return false;
        }

        //Boolean check if string contains an operator.
        public static bool CheckContainsOperators(string checkString)
        {
            if (checkString.Contains("+") || checkString.Contains("-")
                || checkString.Contains("*") || checkString.Contains("/"))
            {
                return true;
            }
            else return false;
        }
    }
}
