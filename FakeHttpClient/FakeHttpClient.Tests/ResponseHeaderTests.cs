using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;

namespace WonderTools.FakeHttpClient.Tests
{
    public class ResponseHeaderTests
    {
        FlugHttpMessageHandler _messageHandler;
        HttpClient _client;
        private string _defaultUri= @"https://www.google.com/";

        [SetUp]
        public void SetUp()
        {
            _messageHandler = new FlugHttpMessageHandler();
            _client = new HttpClient(_messageHandler);
        }

        [Test]
        public void When_request_then_use_range_response()
        {
            var responseHttpCode = HttpStatusCode.Accepted;
            var responseRange = "byte";
            _messageHandler.WhenRequest().WithUri(_defaultUri).Respond().UsingAcceptRangeHeader(responseRange).UsingStatusCode(responseHttpCode);

            var response = _client.GetAsync(new Uri("https://www.google.com")).Result;

            Assert.AreEqual(responseRange, response.Headers.AcceptRanges.ToString());
            Assert.AreEqual(responseHttpCode, response.StatusCode);
        }

        [Test]
        public void When_request_then_use_transfer_encoding_response()
        {
            var responseHttpCode = HttpStatusCode.Accepted;
            var responseRange = "byte";
            var transferEncoding = "trailer";
            _messageHandler.WhenRequest().WithUri(_defaultUri).Respond().UsingAcceptRangeHeader(responseRange).UsingTransferEncodingHeader(transferEncoding).UsingStatusCode(responseHttpCode);

            var response = _client.GetAsync(new Uri(_defaultUri)).Result;
            
            Assert.AreEqual(transferEncoding, response.Headers.TransferEncoding.ToString());
        }
       
        [Test]
        public void When_request_then_use_server_in_response()
        {
            var responseHttpCode = HttpStatusCode.Accepted;
            var responseRange = "byte";
            _messageHandler.WhenRequest().WithUri(_defaultUri).Respond().UsingAcceptRangeHeader(responseRange).UsingServerHeader("Kestrel").UsingStatusCode(responseHttpCode);

            var response = _client.GetAsync(new Uri(_defaultUri)).Result;

            Assert.AreEqual("Kestrel", response.Headers.Server.ToString());
        }

        [Test]
        public void When_request_then_use_proxy_authenticate_in_response()
        {
            var responseHttpCode = HttpStatusCode.Accepted;
            var responseRange = "byte";
            var proxyAuthenticate = "Basic";
            _messageHandler.WhenRequest().WithUri(_defaultUri).Respond().UsingAcceptRangeHeader(responseRange).UsingProxyAuthenticateHeader(proxyAuthenticate).UsingStatusCode(responseHttpCode);

            var response = _client.GetAsync(new Uri(_defaultUri)).Result;

            Assert.AreEqual(proxyAuthenticate, response.Headers.ProxyAuthenticate.ToString());
        }

        [Test]
        public void When_request_then_use_pragma_in_response()
        {
            var responseHttpCode = HttpStatusCode.Accepted;
            var responseRange = "byte";
            var proxyAuthenticate = "Basic";
            _messageHandler.WhenRequest().WithUri(_defaultUri).Respond().UsingAcceptRangeHeader(responseRange).UsingProxyAuthenticateHeader(proxyAuthenticate).UsingPragmaHeader("Cache-Control","no-cache").UsingStatusCode(responseHttpCode);

            var response = _client.GetAsync(new Uri(_defaultUri)).Result;

            Assert.AreEqual("Cache-Control=no-cache", response.Headers.Pragma.ToString());
        }
    }
}
