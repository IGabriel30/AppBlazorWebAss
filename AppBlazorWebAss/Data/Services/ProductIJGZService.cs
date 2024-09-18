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

        //metodo para obtener lista de productos
        public async Task<List<ProductIJGZDTO>> GetProductsAsync()
        {
            //se realiza una solicitud get para obtener la lista de proudctos en formato json
            var list = await _httpClient.GetFromJsonAsync<List<ProductIJGZDTO>>("products");
            //devuelve la lista obtenida o una lista vacía si es nula
            if (list != null)
                return list;
            else
                return new List<ProductIJGZDTO>();
        }

        //metodo para crear nuevo producto
        public async Task<ProductIJGZDTO> CreateProductAsync(ProductIJGZDTO producto)
        {
            //realiza solicitud POST oara crear nuevo producto en formato JSON.
            var response = await _httpClient.PostAsJsonAsync("products", producto);

            //asegura q la solicitud sea exitosa sino lanzará una excepción
            response.EnsureSuccessStatusCode();
            //lee la respuesta n formato JSON y la convierte a un objeto ProductIJGZDTO
            var productResult = await response.Content.ReadFromJsonAsync<ProductIJGZDTO>();

            //devuelve el producto creado o un nuevo   ProductIJGZDTO si es nulo
            if(productResult != null) 
                return productResult;
            else 
                return new ProductIJGZDTO();

        }
    }
}
