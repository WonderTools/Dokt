using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using NUnit.Framework;
using WonderTools.FakeHttpClient.RequestRules;
using WonderTools.FakeHttpClient.ResponseRules;

namespace WonderTools.FakeHttpClient.Tests
{
    public class RequestBodyTests
    {
        MockableHttpMessageHandler _messageHandler;
        HttpClient _client;
        private string _defaultUri = @"https://www.google.com/";

        [SetUp]
        public void SetUp()
        {
            _messageHandler = new MockableHttpMessageHandler();
            _client = new HttpClient(_messageHandler);
        }

        [Test]
        public void When_request_content_then_status_code()
        {
            var responseHttpCode = HttpStatusCode.Accepted;
            var content = "test";
            var withContentEncoding = content.CreateContent().WithContentEncoding("de");
            _messageHandler.BuildRule().WhenUri(_defaultUri).WithRequestContent(withContentEncoding).UseStatusCode(responseHttpCode);

            var response = _client.PostAsync(new Uri(_defaultUri),withContentEncoding).Result;

            Assert.AreEqual(responseHttpCode, response.StatusCode);
        }
    }
}
