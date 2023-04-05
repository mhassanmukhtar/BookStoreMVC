using BookStoreMVC.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System;
using System.Text.Json;

namespace BookStoreMVC.DLLs
{
    public class BookingDLL : IBookingDLL
    {
        private readonly HttpClient _httpClient;
        public BookingDLL()
        {
            _httpClient = new HttpClient();
        }
        public async Task<bool> CreateBooking(Booking booking, string uri)
        {
            using (_httpClient)
            {
                var json = JsonConvert.SerializeObject(booking);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(uri, content);
                var responseBody = await response.Content.ReadAsStringAsync();

                return true;
            }
        }

        public async Task<List<Booking>?> getBookingsHttpClient(string uri)
        {
            using (_httpClient)
            {
                var response = await _httpClient.GetAsync(uri);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var booking = System.Text.Json.JsonSerializer.Deserialize<List<Booking>>(responseString,
                        new JsonSerializerOptions()
                        {
                            PropertyNameCaseInsensitive = true
                        });
                    return booking;
                }
                else
                {
                    return null;
                }
            }
        }


    }
}
