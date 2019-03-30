using System;
using System.Net;
using System.Net.Http;
using NUnit.Framework;
using WonderTools.Dokt;

namespace WonderTools.Flug.Tests
{
    public class RequestBodyTests
    {
        DoktHttpMessageHandler _messageHandler;
        HttpClient _client;
        private string _defaultUri = @"https://www.google.com/";

        [SetUp]
        public void SetUp()
        {
            _messageHandler = new DoktHttpMessageHandler();
            _client = new HttpClient(_messageHandler);
        }

        [Test]
        public void When_request_content_then_status_code()
        {
            var responseHttpCode = HttpStatusCode.Accepted;
            var content = "test";
            var withContentEncoding = new StringContent(content);

            _messageHandler
                .WhenRequest()
                    .WithUri(_defaultUri)
                    .WithContent(withContentEncoding)
                .Respond()
                    .UsingStatusCode(responseHttpCode);

            var response = _client.PostAsync(new Uri(_defaultUri),withContentEncoding).Result;

            Assert.AreEqual(responseHttpCode, response.StatusCode);
        }
    }
}
