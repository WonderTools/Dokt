using System;
using System.Net;
using System.Net.Http;
using NUnit.Framework;

namespace FakeHttpClient.Tests
{
    public class Tests
    {
        [Test]
        public void When_uri_then_status_code()
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

        [Test]
        public void When_uri_starts_with_then_status_code()
        {
            MockableHttpMessageHandler messageHandler = new MockableHttpMessageHandler();

            messageHandler.BuildRule().WhenUriStartsWith("https")
                .UseStatusCode(HttpStatusCode.Accepted);
            messageHandler.BuildRule().WhenUriStartsWith("http")
                .UseStatusCode(HttpStatusCode.BadRequest);

            HttpClient client = new HttpClient(messageHandler);
            var response1 = client.SendAsync(new HttpRequestMessage() { RequestUri = new Uri("https://www.google.com") })
                .Result;
            Assert.AreEqual(HttpStatusCode.Accepted, response1.StatusCode);


            var response2 = client.SendAsync(new HttpRequestMessage() { RequestUri = new Uri("http://www.yahoo.com") })
                .Result;
            Assert.AreEqual(HttpStatusCode.BadRequest, response2.StatusCode);
        }

        [Test]
        public void When_uri_contains_with_then_status_code()
        {
            MockableHttpMessageHandler messageHandler = new MockableHttpMessageHandler();

            messageHandler.BuildRule().WhenUriContains("test")
                .UseStatusCode(HttpStatusCode.Accepted);
            messageHandler.BuildRule().WhenUriContains("1234")
                .UseStatusCode(HttpStatusCode.BadRequest);

            HttpClient client = new HttpClient(messageHandler);
            var response1 = client.SendAsync(new HttpRequestMessage() { RequestUri = new Uri("https://www.test.com") })
                .Result;
            Assert.AreEqual(HttpStatusCode.Accepted, response1.StatusCode);


            var response2 = client.SendAsync(new HttpRequestMessage() { RequestUri = new Uri("http://www.1234.com") })
                .Result;
            Assert.AreEqual(HttpStatusCode.BadRequest, response2.StatusCode);
        }

        [Test]
        public void When_uri_port_then_status_code()
        {
            MockableHttpMessageHandler messageHandler = new MockableHttpMessageHandler();

            messageHandler.BuildRule().WhenUriPort(80)
                .UseStatusCode(HttpStatusCode.Accepted);
            messageHandler.BuildRule().WhenUriPort(100)
                .UseStatusCode(HttpStatusCode.InternalServerError);

            HttpClient client = new HttpClient(messageHandler);
            var requestUri = new Uri("https://ip:80//www.test.com");
            var response1 = client.SendAsync(new HttpRequestMessage() { RequestUri = requestUri })
                .Result;
            Assert.AreEqual(HttpStatusCode.Accepted, response1.StatusCode);


            var response2 = client.SendAsync(new HttpRequestMessage() { RequestUri = new Uri("http://ip:100/www.1234.com") })
                .Result;
            Assert.AreEqual(HttpStatusCode.InternalServerError, response2.StatusCode);
        }
    }
}