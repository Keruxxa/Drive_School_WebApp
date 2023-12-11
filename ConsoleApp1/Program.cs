using Newtonsoft.Json;

using (var httpClient = new HttpClient())
{
    try
    {
        HttpResponseMessage response = await httpClient.GetAsync("https://localhost:7117/User/GetAll");

        if (response.IsSuccessStatusCode)
        {
            string jsonString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(jsonString);
        }
        else
        {
            Console.WriteLine($"Ошибка {response.StatusCode}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
    }
}