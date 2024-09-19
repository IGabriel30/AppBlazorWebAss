using AppBlazorWebAss.Data.DTOs;
using System.Net.Http.Json;

namespace AppBlazorWebAss.Data.Services
{
    public class ProductIJGZService
    {
        private readonly HttpClient _httpClient;

        public ProductIJGZService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("IJGZAPI");
        }

        // Método para obtener lista de productos
        public async Task<List<ProductIJGZDTO>> GetProductsAsync()
        {
            // Se realiza una solicitud GET para obtener la lista de productos en formato JSON
            var response = await _httpClient.GetFromJsonAsync<ProductResponse>("products");

            // Devuelve la lista obtenida o una lista vacía si es nula
            return response?.Content ?? new List<ProductIJGZDTO>();
        }

        // Método para crear nuevo producto
        public async Task<ProductIJGZDTO> CreateProductAsync(ProductIJGZDTO producto)
        {
            // Realiza solicitud POST para crear nuevo producto en formato JSON
            var response = await _httpClient.PostAsJsonAsync("products", producto);

            // Asegura que la solicitud sea exitosa; de lo contrario, lanzará una excepción
            response.EnsureSuccessStatusCode();

            // Lee la respuesta en formato JSON y la convierte a un objeto ProductIJGZDTO
            var productResult = await response.Content.ReadFromJsonAsync<ProductIJGZDTO>();

            // Devuelve el producto creado o un nuevo ProductIJGZDTO si es nulo
            return productResult ?? new ProductIJGZDTO();
        }
    }

    // Clase para deserializar la respuesta de productos
    public class ProductResponse
    {
        public List<ProductIJGZDTO> Content { get; set; }
        // Agrega más propiedades si es necesario
    }
}
