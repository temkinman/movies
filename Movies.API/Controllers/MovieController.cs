
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;
using System.Diagnostics;

namespace Movies.API.Controllers;

public class MovieController : ControllerBase
{
    [HttpGet("initial_movies")]
    public async Task<IActionResult> GetInitialMovies()
    {
        using (var client = new HttpClient())
        {
            int yearFrom = 2022;
            int yearTo = 2023;
            int limit = 1;
            int page = 1;

            var queryString = $"?page={page}&limit={limit}&year={yearFrom}&year={yearTo}";

            client.BaseAddress = new Uri("https://api.kinopoisk.dev/v1/movie");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("X-API-KEY", "C4XQ5RZ-CMNM6BC-JGPDT21-PGQRZQB");

            var requestUri = new Uri(client.BaseAddress + queryString);
            
            CancellationToken cts = new CancellationToken();

            var response = await client.GetAsync(requestUri, cts);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
            else //web api sent error response 
            {
                Console.WriteLine("Simple error");
            }
        }

        return Ok();
    }
}
