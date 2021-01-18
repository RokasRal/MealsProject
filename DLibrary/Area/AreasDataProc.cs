using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DLibrary
{
    public class AreasDataProc
    {
        public static async Task<AreasList> LoadAreas()
        {
           
            string url = $"https://www.themealdb.com/api/json/v1/1/list.php?a=list";
          

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    AreasList ml = JsonConvert.DeserializeObject<AreasList>(responseBody);

                    return ml;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
