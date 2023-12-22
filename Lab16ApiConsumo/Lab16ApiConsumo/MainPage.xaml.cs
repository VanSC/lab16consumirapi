using Lab16ApiConsumo.models;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lab16ApiConsumo
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }
        private const string BaseUrl = "https://peliculas-api-gamma.vercel.app";

        public async Task<ApiResponse> GetAsync(string endpoint)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                HttpResponseMessage response = await client.GetAsync(endpoint);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    ApiResponse result = JsonConvert.DeserializeObject<ApiResponse>(json);
                    return result;
                }
                else
                {
                    throw new Exception($"Error en la solicitud: {response.StatusCode}");
                }
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                ApiResponse response = await GetAsync("/peliculas");

                var movieList = response.results.Select(movie => new
                {
                    Title = movie.title,
                    Imagen = movie.image,
                    Author = movie.author,
                    Genre = movie.genre,
                }).ToList();

                CollectionViewDemo.ItemsSource = movieList;
            }
            catch (Exception ex)
            {
                // Manejar errores
                Console.WriteLine(ex.Message);
            }
        }
    }
}
