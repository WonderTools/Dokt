using System;
using System.Net;
using System.Net.Http;
using NUnit.Framework;

namespace FakeHttpClient.Tests
{
    public class Tests
    {
        [Test]
        public void When_test()
        {
            MockableHttpMessageHandler messageHandler = new MockableHttpMessageHandler();

            messageHandler.BuildRule().WhenUri("https://www.google.com/")
                .UseStatusCode(HttpStatusCode.Accepted);
            messageHandler.BuildRule().WhenUri("https://www.yahoo.com/")
                .UseStatusCode(HttpStatusCode.BadRequest);

            HttpClient client = new HttpClient(messageHandler);
            var response1 = client.SendAsync(new HttpRequestMessage() { RequestUri = new Uri("https://www.google.com") })
                .Result;
            Assert.AreEqual(HttpStatusCode.Accepted, response1.StatusCode);


            var response2 = client.SendAsync(new HttpRequestMessage() { RequestUri = new Uri("https://www.yahoo.com") })
                .Result;
            Assert.AreEqual(HttpStatusCode.BadRequest, response2.StatusCode);
        }
    }
}