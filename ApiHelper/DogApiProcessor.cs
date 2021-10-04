using ApiHelper.Models;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public static async Task<DogModel> GetImageUrl(string breed, string nbImg)
        {
            try
            {
                /// TODO : GetImageUrl()
                /// TODO : Compléter le modèle manquant
                /// 

                Console.WriteLine("           HEEELLLLLOOOOOOOOO            ");
                string url = $"https://dog.ceo/api/breed/{breed}/images/random/{nbImg}";

                using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        DogModel breedimg = await response.Content.ReadAsAsync<DogModel>();
                        return breedimg;
                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;

            
        }
    }
}
