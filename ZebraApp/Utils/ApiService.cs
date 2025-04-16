using Newtonsoft.Json;
using RestSharp;
using ZebraApp.Exception;
using ZebraApp.ViewModel;

namespace ZebraApp.Utils;

public class ApiService
{
    private async Task<RestClient> GetClient()
    {
        var url = Preferences.Get("Url", null);
        if (string.IsNullOrEmpty(url))
        {
            throw new MissingUrlException();
        }

        var options = new RestClientOptions(url);
        return new RestClient(options);
    }

    public async Task<bool> ChangeSpoolLocationAsync(int spoolId, string location)
    {
        var client = await GetClient();
        var request = new RestRequest($"spool/{spoolId}", Method.Patch)
            .AddHeader("Content-Type", "application/json")
            .AddJsonBody(new { location });

        RestResponse response = await client.ExecuteAsync(request);

        return response.IsSuccessful;
    }

    public async Task<List<Spool>> GetSpoolsAsync()
    {
        var client = await GetClient();
        var request = new RestRequest("spool", Method.Get);

        RestResponse response = await client.ExecuteAsync(request);
        if (response.IsSuccessful)
        {
            if (response?.Content != null)
            {
                var spools = JsonConvert.DeserializeObject<List<Spool>>(response.Content);
                if (spools is not null)
                {
                    return spools;
                }
            }
        }

        return new List<Spool>();
    }

    public async Task<List<string>> GetSpoolLocationsAsync()
    {
        return new List<string>
        {
            "Vše", "Police", "Tiskárna" 
        };
        
        //TODO: Add all locations to API and fetch it here
    }
}