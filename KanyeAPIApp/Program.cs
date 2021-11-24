//Author: Shamoun Hennawi
//Date: 23.11.2021
using System.Net;
using System.Web;
using System.Text.Json;

string URL = "https://api.kanye.rest/";
using var client = new HttpClient();

ConsoleKey choice;
do
{
    Console.WriteLine(await GetNewQuote(URL));
    Console.WriteLine("New quote? Press e");
    choice = Console.ReadKey().Key;
} while (choice == ConsoleKey.E);

async Task<string> GetNewQuote(string url)
{
    var response = await client.GetAsync(url);
    var kanyeResponseString = await response.Content.ReadAsStringAsync();
    var kanyeResponseObject = JsonSerializer.Deserialize<KanyeApiModel>(kanyeResponseString);
    return kanyeResponseObject.quote;
}

class KanyeApiModel {
    public string quote { get; set; }
}