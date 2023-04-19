namespace Movies.Loader.CLI.Services;

public class MovieLoader
{
    public async Task GetMoviesFromServer()
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
            else
            {
                Console.WriteLine("Simple error");
            }
        }
    }
}
