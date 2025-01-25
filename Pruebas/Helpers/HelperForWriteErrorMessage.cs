using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas.Helpers
{
    class HelperForWriteErrorMessage
    {
        public static void WriteCompleteError(string methodName, string errorMessage, string nameClass, int errorCode)
        {
            Debug.WriteLine($"Error in method: {methodName}\nClass: {nameClass}");
            WriteErrorMessage(errorMessage);
            Debug.WriteLine($"Error code: {errorCode}");
        }
        private static void WriteErrorMessage(string message)
        {
            Debug.WriteLine("Error Message: ", message);
        }

    }
}
