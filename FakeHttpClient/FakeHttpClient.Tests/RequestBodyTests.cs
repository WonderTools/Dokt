using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using NUnit.Framework;

namespace WonderTools.FakeHttpClient.Tests
{
    public class RequestBodyTests
    {
        FlugHttpMessageHandler _messageHandler;
        HttpClient _client;
        private string _defaultUri = @"https://www.google.com/";

        [SetUp]
        public void SetUp()
        {
            _messageHandler = new FlugHttpMessageHandler();
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
