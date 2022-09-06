﻿using Envoy.Models;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Envoy.Api.ServerComponent.VisitorAndProtectApis
{
    public class FlowsHelper : BaseHelper
    {
        private const string flowsUri = "flows";

        public async Task<FlowResponse> GetFlowsAsync()
        {
            try
            {
                var responseString = await GetAsync(flowsUri);
                return JsonConvert.DeserializeObject<FlowResponse>(responseString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new Exception("An error occured");
            }
        }

        public async Task<FlowResponse> GetFlowByIdAsync(int id)
        {
            try
            {
                var responseString = await GetAsync($"{flowsUri}/{id}");
                return JsonConvert.DeserializeObject<FlowResponse>(responseString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new Exception("An error occured");
            }
        }
    }
}