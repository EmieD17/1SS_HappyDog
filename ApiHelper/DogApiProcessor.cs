using ApiHelper.Models;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiHelper
{
    public class DogApiProcessor
    {
        public static async Task<DogBreedModel> LoadBreedList()
        {
            ///TODO : À compléter LoadBreedList
            /// Attention le type de retour n'est pas nécessairement bon
            /// J'ai mis quelque chose pour avoir une base
            /// TODO : Compléter le modèle manquant

            string url;

            url = $"https://dog.ceo/api/breeds/list/all";


            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    DogBreedModel breeds_list = await response.Content.ReadAsAsync<DogBreedModel>();
                    return breeds_list;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

            //return new List<string>();
        }

        public static async Task<string> GetImageUrl(string breed)
        {
            /// TODO : GetImageUrl()
            /// TODO : Compléter le modèle manquant
            return string.Empty;
        }
    }
}
