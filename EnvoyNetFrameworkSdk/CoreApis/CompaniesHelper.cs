using EnvoyNetFrameworkSdk.Models;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EnvoyNetFrameworkSdk.CoreApis
{
    public class CompaniesHelper : BaseHelper
    {
        private const string companiesUri = "companies";

        public async Task<CompanyResponse> GetCompaniesAsync()
        {
            try
            {
                var responseString = await GetAsync(companiesUri);
                return JsonConvert.DeserializeObject<CompanyResponse>(responseString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new Exception("An error occured");
            }
        }
    }
}
