using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DLibrary
{
    public class DataProccesorCat
    {
        public static async Task<CategoryList> LoadCategory()
        {
            string url = "https://www.themealdb.com/api/json/v1/1/categories.php";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    CategoryList cl = JsonConvert.DeserializeObject<CategoryList>(responseBody);
                    
                    return cl;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
