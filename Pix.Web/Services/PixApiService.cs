using System.Net.Http.Json;
using Pix.Web.Models;

namespace Pix.Web.Services;

public class PixApiService
{
    private readonly HttpClient _httpClient;


    public PixApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }


    public async Task<PixViewModel?> GerarPixAsync(
        PixViewModel model)
    {
        var response =
            await _httpClient.PostAsJsonAsync(
                "/api/pix",
                model
            );


        if (!response.IsSuccessStatusCode)
        {
            return null;
        }


        var resultado =
            await response.Content
            .ReadFromJsonAsync<PixViewModel>();


        return resultado;
    }
}