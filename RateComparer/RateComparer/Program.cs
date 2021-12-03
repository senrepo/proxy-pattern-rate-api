using AbcInsurance;
using AbcInsurance.Model;
using AppConfig;
using System;
using System.Threading.Tasks;

namespace RateComparer
{
    class Program
    {
        static void Main(string[] args)
        {

            /* Proxy Pattern -> 
             * 
             * Clients send all requests to a proxy that does have external access that then makes the requests on behalf of the original client. 
             * The proxy can optionally cache content locally optimizing the use of network bandwidth and providing faster responses to clients.
             * 
             * 
             * Here, the Proxy responsibilities are to read the config and establish the connection to Web api also take care of the serialize/deserialize the request and responses
             */

            var proxy = new AbcInsuranceProxy();
            var rateResponse = proxy.GetRate();
            Console.WriteLine($"Premium: {rateResponse.Premium}, Term Months: {rateResponse.TermInMonths}, Rate Process Status: { rateResponse.Status}");

        }
    }
}
