using System;
using System.Net;
using System.Net.Http;
using FakeHttpClient;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Console.WriteLine("Hello World!");

            MockableHttpMessageHandler messageHandler = new MockableHttpMessageHandler();
            //messageHandler
            //    .When(HttpMethod.Get).WhenUri("/sdfkljasl/asdfa/das")
            //    .Execute()
            //    .Throw()
            //    .Respond()

            messageHandler.BuildRule().When((req) => req.RequestUri.AbsoluteUri == "https://www.google.com/")
                .Use(r => { r.StatusCode = HttpStatusCode.Accepted; });
            messageHandler.BuildRule().When((req) => req.RequestUri.AbsoluteUri == "https://www.yahoo.com/")
                .Use(r => { r.StatusCode = HttpStatusCode.BadRequest; });

            HttpClient client = new HttpClient(messageHandler);
            var response1 = client.SendAsync(new HttpRequestMessage() { RequestUri = new Uri("https://www.google.com") })
                .Result;
            Console.WriteLine("The response code is " + response1.StatusCode);


            var response = client.SendAsync(new HttpRequestMessage() { RequestUri = new Uri("https://www.yahoo.com") })
                .Result;
            Console.WriteLine("The response code is " + response.StatusCode);

            Assert.Pass();
        }
    }
}