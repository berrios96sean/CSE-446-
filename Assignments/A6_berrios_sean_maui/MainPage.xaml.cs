using Microsoft.Extensions.Caching.Memory;
using System.Runtime.Caching;
using static System.Net.Mime.MediaTypeNames;
using MemoryCache = Microsoft.Extensions.Caching.Memory.MemoryCache;

namespace A6_berrios_sean_maui;

public partial class MainPage : ContentPage
{
	int count = 0;
    private static IMemoryCache cache = new MemoryCache(new MemoryCacheOptions());

    public MainPage()
	{
		InitializeComponent();
	}

    private async void EncryptButton_Clicked(object sender, EventArgs e)
    {
        string query = EncryptEntry.Text;

        string result;
        try
        {

            if (cache.TryGetValue(query, out result))
            {
                EncryptLabel.Text = "Query is repeated Displaying the cached result";
            }
            else
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync("https://venus.sod.asu.edu/WSRepository/Services/EncryptionRest/Service.svc/Encrypt?text=" + query);
                response.EnsureSuccessStatusCode();
                result = (await response.Content.ReadAsStringAsync()).Replace(@"""", "");
                cache.Set(query, result, TimeSpan.FromSeconds(10));
                EncryptLabel.Text = "";
            }
        }
        catch (HttpRequestException ex)
        {
            result = ex.ToString(); 
        }
        EncryptLabel.Text = result;
        DecryptEntry.Text = result; 
    }
    private async void DecryptButton_Clicked(object sender, EventArgs e)
    {
        string query = DecryptEntry.Text;

        string result;
        try
        {
            if (cache.TryGetValue(query, out result))
            {
                DecryptLabel.Text = "Query repeated Displaying the cached result";
            }
            else
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync("https://venus.sod.asu.edu/WSRepository/Services/EncryptionRest/Service.svc/Decrypt?text=" + query);
                response.EnsureSuccessStatusCode();
                result = (await response.Content.ReadAsStringAsync()).Replace(@"""", "");
                cache.Set(query, result, TimeSpan.FromSeconds(10));
                DecryptLabel.Text = "";
            }
        }
        catch (HttpRequestException ex)
        {
            result = ex.ToString();
        }
        DecryptLabel.Text = result;
    }
}

