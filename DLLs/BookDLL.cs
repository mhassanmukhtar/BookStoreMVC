using BookStoreMVC.Models;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

namespace BookStoreMVC.DLLs
{
    public class BookDLL
    {
        private readonly HttpClient _httpClient;
        public BookDLL() 
        {
            _httpClient = new HttpClient();
        }
        public async Task<List<Book>?> getBookHttpClient(string uri)
        {

            using(_httpClient)
            {
                var response = await _httpClient.GetAsync(uri);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var book = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(responseString,
                        new JsonSerializerOptions()
                        {
                            PropertyNameCaseInsensitive = true
                        });
                    return book;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<bool> deleteBookHttpClient(string uri)
        {
            using (_httpClient)
            {
                var response = await _httpClient.DeleteAsync(uri);
                return true;
            }
        }

        public async Task<bool> createBookHttpClient(Book book,string uri)
        {
            using (_httpClient)
            {
                var json = JsonConvert.SerializeObject(book);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(uri, content);
                var responseBody = await response.Content.ReadAsStringAsync();

                return true;
            }
        }


    }
}
