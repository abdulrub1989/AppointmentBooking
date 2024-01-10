using Microsoft.Identity.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;

// See https://aka.ms/new-console-template for more information
//using TestProj;

//Console.WriteLine("Hello, World!");

//decimal numberToConvert = 90.56m; // Change this to the decimal value you want to convert
//string words = DecimalToWords.ConvertDecimalToWords(numberToConvert);
//Console.WriteLine(words);

//if (AnoOtherDateValidation.IsValidDate(2012, 2, 31))
//{
//	Console.WriteLine("Date is Valid");
//}
//else
//{
//	Console.WriteLine("Date is not Valid");
//}

//Console.ReadLine();

await ConsumeApiAsync();


static async Task ConsumeApiAsync()
{
    string clientId = "c9484aae-d7d9-4d03-9f2d-a884c7ae8355";
    string tenantId = "999d5e4e-b16b-4eaf-aa97-ac9afa915c91";
    string clientSecret = "Pyh8Q~g7oJ8kjDsDAid4-SMJXxMeHMWl64sHUbIc";
    string apiUrl = "https://graph.microsoft.com/v1.0/me/bookings";

    var confidentialClient = ConfidentialClientApplicationBuilder
        .Create(clientId)
        .WithClientSecret(clientSecret)
        .WithAuthority(new Uri($"https://login.microsoftonline.com/{tenantId}"))
        .Build();

    var authResult = await confidentialClient.AcquireTokenForClient(new[] { "https://graph.microsoft.com/Bookings.Read.All" })
        .ExecuteAsync();

    using (HttpClient client = new HttpClient())
    {
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authResult.AccessToken}");

        try
        {
            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }
    }
}



