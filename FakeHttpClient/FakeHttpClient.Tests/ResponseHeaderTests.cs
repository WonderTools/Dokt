using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WonderTools.FakeHttpClient.Tests
{
    public class ResponseHeaderTests
    {
        MockableHttpMessageHandler _messageHandler;
        HttpClient _client;

        [SetUp]
        public void SetUp()
        {
            _messageHandler = new MockableHttpMessageHandler();
            _client = new HttpClient(_messageHandler);
        }

        [Test]
        public void When_request_then_use_range_response()
        {
            var uri = @"https://www.google.com/";
            var responseHttpCode = HttpStatusCode.Accepted;
            var responseRange = "byte";
            _messageHandler.BuildRule().WhenUri(uri).UseAcceptRangeInResponse(responseRange).UseStatusCode(responseHttpCode);

            var response = _client.GetAsync(new Uri("https://www.google.com")).Result;

            Assert.AreEqual(responseRange, response.Headers.AcceptRanges.ToString());
            Assert.AreEqual(responseHttpCode, response.StatusCode);
        }

        [Test]
        public void When_request_then_use_transfer_encoding_response()
        {
            var uri = @"https://www.google.com/";
            var responseHttpCode = HttpStatusCode.Accepted;
            var responseRange = "byte";
            var transferEncoding = "trailer";
            _messageHandler.BuildRule().WhenUri(uri).UseAcceptRangeInResponse(responseRange).UseTransferEncodingInResponse(transferEncoding).UseStatusCode(responseHttpCode);

            var response = _client.GetAsync(new Uri("https://www.google.com")).Result;

            Assert.AreEqual(responseRange, response.Headers.AcceptRanges.ToString());
            Assert.AreEqual(transferEncoding, response.Headers.TransferEncoding.ToString());
            Assert.AreEqual(responseHttpCode, response.StatusCode);
        }
    }
}
