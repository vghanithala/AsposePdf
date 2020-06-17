using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Aspose.Pdf;
using Aspose.Pdf.Operators;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AsposPdfTest.Lambda
{
    public class Function
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FunctionHandler(string input, ILambdaContext context)
        {
            string isFileSaved = "false";
            try
            {
                AsposPdf asposPdf = new AsposPdf();
                Document document = asposPdf.CreatePdf(input);

                if (document != null)
                {
                    isFileSaved = "true";
                }
            }
            catch(Exception ex)
            {
                LambdaLogger.Log("Exception occured while processing" + ex.ToString());
            }
            return isFileSaved;
        }
    }
}
