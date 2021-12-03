
using AbcInsurance.Model;
using AppConfig;
using System;
using System.Threading.Tasks;

namespace AbcInsurance
{
    public class AbcInsuranceProxy
    {

        private readonly IRestHttpClient client = null;

        public AbcInsuranceProxy()
        {
            client = new RestHttpClient();
        }

        public RateResponse GetRate()
        {
            var url = ConfigReader.GetApiUrl("AbcInsurance", "Rate");
            var response = client.Get<RateResponse>(url).Result;
            return response;
        }
    }
}
