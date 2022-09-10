using EnvoyNetFrameworkSdk.Models;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EnvoyNetFrameworkSdk.SpacesApis
{
    public class SpacesHelper : BaseHelper
    {
        private const string spacesUri = "spaces";

        public async Task<SpaceResponse> GetSpacesAsync(string type = "DESK", int page = 1, int perPage = 250)
        {
            try
            {
                var responseString = await GetAsync($"{spacesUri}?type={type}&page={page}&perPage={perPage}");
                return JsonConvert.DeserializeObject<SpaceResponse>(responseString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new Exception("An error occured");
            }
        }

        public async Task<SpaceResponse> GetSpaceByIdAsync(int id)
        {
            try
            {
                var responseString = await GetAsync($"{spacesUri}/{id}");
                return JsonConvert.DeserializeObject<SpaceResponse>(responseString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new Exception("An error occured");
            }
        }
    }
}
