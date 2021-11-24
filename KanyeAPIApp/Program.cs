//Author: Shamoun Hennawi
//Date: 23.11.2021
using System.Net;
using System.Web;

string URL = "https://api.kanye.rest/";

ConsoleKey choice;
do
{
    Console.WriteLine(GetRequest(URL));
    Console.WriteLine("New quote? Press e");
    choice = Console.ReadKey().Key;
} while (choice == ConsoleKey.E);

string GetRequest(string url)
{
    HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
    string result = null;
    using (HttpWebResponse resp = req.GetResponse() as HttpWebResponse)
    {
        StreamReader reader = new StreamReader(resp.GetResponseStream());
        result = reader.ReadToEnd();
    }
    return result;
}