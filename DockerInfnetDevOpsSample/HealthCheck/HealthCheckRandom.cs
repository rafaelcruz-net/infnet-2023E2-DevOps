﻿using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace DockerInfnetDevOpsSample.HealthCheck
{
    public class HealthCheckRandom : IHealthCheck
    {
        private HttpClient _httpClient;

        public HealthCheckRandom(IHttpClientFactory httpClientFactory)
        {
            this._httpClient = httpClientFactory.CreateClient();
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {

            this._httpClient.DefaultRequestHeaders.TryAddWithoutValidation("appkey", "appkey_key");
            this._httpClient.DefaultRequestHeaders.TryAddWithoutValidation("appsecret", "appkey_secret");

            HttpResponseMessage response = null;

            if (Random.Shared.Next() % 2 == 0) 
            {
                response = await this._httpClient.GetAsync("http://httpbin.org/status/200");
            } 
            else
            {
                response = await this._httpClient.GetAsync("http://httpbin.org/status/500");
            }

            return response.IsSuccessStatusCode ? HealthCheckResult.Healthy() : HealthCheckResult.Unhealthy(description: "Deu ruim na chamada");
        }
    }
}
