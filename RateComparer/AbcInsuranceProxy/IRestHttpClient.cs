using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AbcInsurance
{
    public interface IRestHttpClient
    {
        Task<T> Get<T>(string url);
        Task<T2> Post<T1, T2>(string url, T1 request);
    }

}