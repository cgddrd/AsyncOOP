using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AsyncOOP
{
    class Watcher : IWatcher
    {
        public int Bytes { get; set; }
        public string Content { get; set; }
        public string Content2 { get; set; }

        private Watcher()
        {
        }

        private async Task<Watcher> InitializeAsync()
        {
            Bytes = await CountBytesAsync("http://bbc.co.uk");
            Content = await GetContentAsync("http://bbc.co.uk/");
            Content2 = GetContent("http://bbc.co.uk");

            return this;
        }

        public static Task<Watcher> CreateAsync()
        {
            var result = new Watcher();
            return result.InitializeAsync();
        }

        public async Task<int> CountBytesAsync(string url)
        {
            var client = new HttpClient();
            var bytes = await client.GetByteArrayAsync(url);
            return bytes.Length;
        }

        public async Task<string> GetContentAsync(string url)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return string.Empty;
        }

        public string GetContent(string url)
        {
            var client = new HttpClient();
            var response = client.GetAsync(url).GetAwaiter().GetResult();

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }

            return string.Empty;
        }
    }
}
