using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebPruebaDevHive.Models;

namespace WebPruebaDevHive.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Inmueble>> GetInmueblesAsync()
        {
            var response = await _httpClient.GetAsync("api/Inmuebles");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Inmueble>>() ?? new List<Inmueble>();
        }

        public async Task<Inmueble> GetInmuebleByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/Inmuebles/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Inmueble>();
        }

        public async Task<Inmueble> CreateInmuebleAsync(Inmueble inmueble)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Inmuebles", inmueble);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Inmueble>();
        }

        public async Task<bool> UpdateInmuebleAsync(int id, Inmueble inmueble)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Inmuebles/{id}", inmueble);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteInmuebleAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Inmuebles/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
