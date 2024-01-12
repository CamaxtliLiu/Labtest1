using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
namespace LabTest1.Service
{


public class ApiClient
{
    private HttpClient _httpClient;

    public ApiClient()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
    }

    public async Task<string> GetPostsAsync()
    {
        var response = await _httpClient.GetAsync("posts");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> AddPostAsync(string title, string body)
    {
        var postData = new
        {
            title,
            body
        };

        var response = await _httpClient.PostAsJsonAsync("posts", postData);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> UpdatePostAsync(int postId, string title, string body)
    {
        var putData = new
        {
            id = postId,
            title,
            body
        };

        var response = await _httpClient.PutAsJsonAsync($"posts/{postId}", putData);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> DeletePostAsync(int postId)
    {
        var response = await _httpClient.DeleteAsync($"posts/{postId}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}
}