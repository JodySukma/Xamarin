using Latihan2Xamarin.Helper;
using Latihan2Xamarin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Latihan2Xamarin.Service
{
    public class DataService
    {
        public async Task<bool> Login(string email, string password)
        {
            using (var client = new HttpClient { Timeout = TimeSpan.FromSeconds(30) })
            {
                try
                {
                    var loginDict = new Dictionary<string, string> {
                        { "username", email }, { "password", password }
                    };

                    var postData = JsonConvert.SerializeObject(loginDict);
                    HttpContent stringContent = new StringContent(postData);
                    stringContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var builder = new UriBuilder(new Uri(UrlHelper.LOGIN_URL));

                    var respose = await client.PostAsync(builder.Uri, stringContent);
                    if (!respose.IsSuccessStatusCode)
                        return false;

                    var byteResult = await respose.Content.ReadAsByteArrayAsync();

                    var result = Encoding.UTF8.GetString(byteResult, 0, byteResult.Length);
                    if (!result.Equals("true", StringComparison.OrdinalIgnoreCase))
                        return false;
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public async Task<List<Sale>> GetListSales()
        {
            using (var client = new HttpClient { Timeout = TimeSpan.FromSeconds(30) })
            {
                try
                {
                    // accept application/jason only
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var builder = new UriBuilder(new Uri(UrlHelper.SALES_URL));

                    var response = await client.GetAsync(builder.Uri);
                    if (!response.IsSuccessStatusCode)
                        return null;

                    var byteResult = await response.Content.ReadAsByteArrayAsync();
                    var result = Encoding.UTF8.GetString(byteResult, 0, byteResult.Length);

                    var modelResult = JsonConvert.DeserializeObject<List<Sale>>(result);

                    return modelResult;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public async Task<List<Customer>> GetListCustomers()
        {
            using (var client = new HttpClient { Timeout = TimeSpan.FromSeconds(30) })
            {
                try
                {
                    //Accept application/json only
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var builder = new UriBuilder(new Uri(UrlHelper.CUSTOMERS_URL));
                    var response = await client.GetAsync(builder.Uri);
                    if (!response.IsSuccessStatusCode)
                        return null;
                    var byteResult = await response.Content.ReadAsByteArrayAsync();
                    var result = Encoding.UTF8.GetString(byteResult, 0, byteResult.Length);
                    var modelResult = JsonConvert.DeserializeObject<List<Customer>>(result);
                    return modelResult;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public async Task<bool> PostNewSale(Sale sale)
        {
            using (var client = new HttpClient { Timeout = TimeSpan.FromSeconds(30) })
            {
                try
                {
                    var postData = JsonConvert.SerializeObject(sale);
                    HttpContent stringContent = new StringContent(postData);
                    stringContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    var builder = new UriBuilder(new Uri(UrlHelper.SALES_URL));

                    var response = await client.PostAsync(builder.Uri, stringContent);
                    if (!response.IsSuccessStatusCode)
                        return false;

                    var byteResult = await response.Content.ReadAsByteArrayAsync();
                    var result = Encoding.UTF8.GetString(byteResult, 0, byteResult.Length);

                    var modelResult = JsonConvert.DeserializeObject<Sale>(result);
                    if (modelResult == null)
                        return false;

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public async Task<bool> PostNewCustomer(Customer customer)
        {
            using (var client = new HttpClient { Timeout = TimeSpan.FromSeconds(30) })
            {
                try
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", EncryptHelper.ToBasicAuth("alkademi", "alkademi123"));

                    var postData = JsonConvert.SerializeObject(customer);
                    HttpContent stringContent = new StringContent(postData);
                    stringContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var builder = new UriBuilder(new Uri(UrlHelper.CUSTOMERS_URL));

                    var response = await client.PostAsync(builder.Uri, stringContent);
                    if (!response.IsSuccessStatusCode)
                        return false;

                    var byteResult = await response.Content.ReadAsByteArrayAsync();
                    var result = Encoding.UTF8.GetString(byteResult, 0, byteResult.Length);

                    var modelResult = JsonConvert.DeserializeObject<Customer>(result);
                    if (modelResult == null)
                        return false;

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
