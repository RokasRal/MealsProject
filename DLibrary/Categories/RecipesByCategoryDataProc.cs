using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DLibrary
{
    public class RecipesByCategoryDataProc
    {
        public static async Task<RecipesByCategoryList> LoadMeal(string catname)
        {
           
               string url = $"https://www.themealdb.com/api/json/v1/1/filter.php?c={ catname }";
           

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    RecipesByCategoryList ml = JsonConvert.DeserializeObject<RecipesByCategoryList>(responseBody);
                    return ml;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<RecipesByAreaList> LoadMeals(string areaname)
        {

            string url = $"https://www.themealdb.com/api/json/v1/1/filter.php?a={ areaname }";


            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    RecipesByAreaList ml = JsonConvert.DeserializeObject<RecipesByAreaList>(responseBody);
                    return ml;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<IngredientList> LoadMealIngredients(string ingName)
        {

            string url = $"https://www.themealdb.com/api/json/v1/1/filter.php?i={ ingName }";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    IngredientList il = JsonConvert.DeserializeObject<IngredientList>(responseBody);
                    return il;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

    }
}
