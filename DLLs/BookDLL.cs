using BookStoreMVC.Models;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;

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

            using (_httpClient)
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

        public async Task<Book?> getBookByIDHttpClient(string uri)
        {
            HttpClientHandler handler = new HttpClientHandler();
            using (var client = new HttpClient(handler,false))
            {
                var response = await _httpClient.GetAsync(uri);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var book = System.Text.Json.JsonSerializer.Deserialize<Book>(responseString,
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

        public async Task<bool> BookItHttpClient(string uri, Guid id)
        {
            using (_httpClient)
            {
                Book bookResponse = new Book();
                bookResponse = await getBookByIDHttpClient(uri + "/" + id);
                Book book = new Book
                {
                    Id = bookResponse.Id,
                    author = bookResponse.author,
                    title = bookResponse.title,
                    description = bookResponse.description,
                    name = bookResponse.name,
                    quantity = bookResponse.quantity - 1,
                };

                var json = JsonConvert.SerializeObject(book);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync(uri, content);
                return true;
            }
        }

        public async Task<bool> createBookHttpClient(Book book, string uri)
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
