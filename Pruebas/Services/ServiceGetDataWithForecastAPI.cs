
using Pruebas.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Pruebas.Services
{
    public class ServiceGetDataWithForecastAPI
    {

        private HttpClient client = new();
        //public ServiceToParseForecastAPIInformationToClimaClass _serviceToParseForecastAPIInformationToClimaClass = new ServiceToParseForecastAPIInformationToClimaClass();
        public ServiceGetDataWithForecastAPI()
        {
            
        }

        public async Task<List<Root>> GetInfoFromForecastAPI(double latitude, double longitude)
        {
            List<Root>? apiDataOpenToWork = null;
            try
            {
                string BaseURL = "https://localhost:7232/Root?";
                string fragmentWithLatitudeAndLongitudeRAW = $"lat={latitude}&lon={longitude}";
                string fragmentWithLatitudeAndLongitudeReadyToUse = fragmentWithLatitudeAndLongitudeRAW.Replace(",", ".");
                string fullURL = $"{BaseURL}{fragmentWithLatitudeAndLongitudeReadyToUse}";
                HttpResponseMessage dataFromApiForecast = await client.GetAsync(fullURL);
                dataFromApiForecast.EnsureSuccessStatusCode();

                string readInfoFromApi = await dataFromApiForecast.Content.ReadAsStringAsync();
                
                apiDataOpenToWork = JsonSerializer.Deserialize<List<Root>>(readInfoFromApi);

                if(apiDataOpenToWork == null)
                {
                    throw new Exception("Api dont provides information");
                }

                //listWithForecastParsed = _serviceToParseForecastAPIInformationToClimaClass.ParseInformationFromAPIToClimaClass(apiDataOpenToWork);

                //if(listWithForecastParsed == null)
                //{
                //    throw new Exception("Service with Forecast Parsed dont return information");
                //}


            }
            catch(HttpRequestException exception)
            {
                Debug.Write(exception.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return apiDataOpenToWork!;
        }
        public async Task<List<Root>> GetInfoFromForecastAPI(string cityName)
        {
            List<Root>? apiDataOpenToWork = null;
            try
            {
                string BaseURL = "https://localhost:7232/GetForecastByCityName?";
                string fragmentWithCityName = $"cityName={cityName}";


                
                string fullURL = $"{BaseURL}{fragmentWithCityName}";
                HttpResponseMessage dataFromApiForecast = await client.GetAsync(fullURL);
                dataFromApiForecast.EnsureSuccessStatusCode();

                string readInfoFromApi = await dataFromApiForecast.Content.ReadAsStringAsync();

                apiDataOpenToWork = JsonSerializer.Deserialize<List<Root>>(readInfoFromApi);

                if (apiDataOpenToWork == null)
                {
                    throw new Exception("Api dont provides information");
                }


            }
            catch (HttpRequestException exception)
            {
                Debug.Write(exception.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return apiDataOpenToWork!;
        }
    }
}
