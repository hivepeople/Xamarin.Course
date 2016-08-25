using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Xamarin.Course.Advanced.CSharp
{
    namespace Async.Await.Example
    {
        [TestFixture]
        public class Example
        {
            public async Task<string> DoSlowStuff(string path, string url)
            {
                // Read a file...
                string fileContents;
                using (var fileReader = File.OpenText(path))
                {
                    fileContents = await fileReader.ReadToEndAsync();
                }

                // Now go fetch a web page...
                string pageContents;
                using (var httpClient = new HttpClient())
                using (HttpResponseMessage response = await httpClient.GetAsync(url))
                {
                    pageContents = await response.Content.ReadAsStringAsync();
                }

                // We can now work with both the file contents and the page contents
                return fileContents + pageContents;
            }

            public async Task DumpFileAndWebPageMixed(string path)
            {
                List<string> fileContents = new List<string>();
                List<string> webPageContents = new List<string>();

                using (var fileReader = File.OpenText(path))
                {
                    string line;
                    while ((line = await fileReader.ReadLineAsync()) != null)
                    {
                        fileContents.Add(line);
                    }
                }

                using (var httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.GetAsync("https://www.google.com/");
                    string charset = response.Content.Headers.ContentType?.CharSet;
                    Encoding encoding = (charset == null) ? Encoding.ASCII : Encoding.GetEncoding(charset);

                    using (var responseStream = await response.Content.ReadAsStreamAsync())
                    using (var responseReader = new StreamReader(responseStream, encoding))
                    {
                        string line;
                        while ((line = await responseReader.ReadLineAsync()) != null)
                        {
                            webPageContents.Add(line);
                        }
                    }
                }

                var query = fileContents.Zip(webPageContents, (l1, l2) => new { FileLine = l1, WebLine = l2 });

                foreach (var linePair in query)
                {
                    Console.WriteLine(linePair.FileLine);
                    Console.WriteLine(linePair.WebLine);
                }
            }

            [Test]
            public async Task CanPrintFile()
            {
                var path = TestContext.CurrentContext.TestDirectory + @"\..\..\01Interfaces.cs";
                await DumpFileAndWebPageMixed(path);
            }
        }
    }

    namespace Async.Await.Parallel
    {
        class Example
        {
            public async Task RunSerialVsParallel()
            {
                using (var client = new HttpClient())
                {
                    // Serial requests
                    var response1 = await client.GetAsync("url1");
                    var response2 = await client.GetAsync("url2");
                    var response3 = await client.GetAsync("url3");

                    // Total time taken = t1 + t2 + t3


                    // Parallel requests - need all
                    var responseTask1 = client.GetAsync("url1");
                    var responseTask2 = client.GetAsync("url2");
                    var responseTask3 = client.GetAsync("url3");

                    HttpResponseMessage[] responses = await Task.WhenAll(
                        responseTask1, responseTask2, responseTask3);

                    // Total time taken = max(t1, t2, t3)


                    // Parallel requests - need one
                    responseTask1 = client.GetAsync("url1");
                    responseTask2 = client.GetAsync("url2");
                    responseTask3 = client.GetAsync("url3");

                    Task<HttpResponseMessage> task = await Task.WhenAny(
                        responseTask1, responseTask2, responseTask3);

                    // Total time taken = min(t1, t2, t3)
                }
            }
        }
    }
}
