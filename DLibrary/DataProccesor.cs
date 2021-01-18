using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DLibrary
{
     public class DataProccesor
    {
        //Task that takes care of requests that contain number. Random recie will come with 0, while any other with id 
        public static async Task<MealModel> LoadMeal(int mealNumber = 0)
        {
            string url = "";
            string mn = mealNumber.ToString();
            if (mealNumber > 0)
            {
                url = $"https://www.themealdb.com/api/json/v1/1/lookup.php?i={ mn }";
            }
            else
            {
                url = $"https://www.themealdb.com/api/json/v1/1/random.php";
            }

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    MealList ml = JsonConvert.DeserializeObject<MealList>(responseBody); 
                    return ml.meals[0];
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        //This task takes care of request that are searching for recipe by name 
        public static async Task<MealModel> LoadMeal(string mn)
        {
            
            string url = $"https://themealdb.com/api/json/v1/1/search.php?s={ mn }";
                   

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
        
                    MealList ml = JsonConvert.DeserializeObject<MealList>(responseBody);
                    
                    return ml.meals[0];
                                     
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
