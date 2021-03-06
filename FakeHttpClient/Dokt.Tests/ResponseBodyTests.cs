﻿using System;
using System.Net;
using System.Net.Http;
using NUnit.Framework;

namespace WonderTools.Dokt.Tests
{
    public class ResponseBodyTests
    {
        DoktHttpMessageHandler _messageHandler;
        HttpClient _client;
        string _defaultUri = @"https://www.google.com/";

        [SetUp]
        public void SetUp()
        {
            _messageHandler = new DoktHttpMessageHandler();
            _client = new HttpClient(_messageHandler);
        }

        [Test]
        public void When_request_then_use_content_response()
        {
            var responseHttpCode = HttpStatusCode.Accepted;
            var content = "test";
            _messageHandler.WhenRequest().WithUri(_defaultUri).Respond(content).UsingStatusCode(responseHttpCode);

            var response = _client.GetAsync(new Uri(_defaultUri)).Result;
            var result = response.Content.ReadAsStringAsync().Result;

             Assert.AreEqual(content, result);
        }

        [Test]
        public void When_request_then_use_content_type_response()
        {
            var responseHttpCode = HttpStatusCode.Accepted;
            var contentType = "text/html";
            _messageHandler.WhenRequest().WithUri(_defaultUri).Respond()
                .UsingContentTypeHeader(contentType).UsingStatusCode(responseHttpCode);

            var response = _client.GetAsync(new Uri(_defaultUri)).Result;
            Assert.AreEqual(contentType, response.Content.Headers.ContentType.ToString());
            
        }

        [Test]
        public void When_request_then_use_content_range_response()
        {
            var responseHttpCode = HttpStatusCode.Accepted;
            _messageHandler.WhenRequest().WithUri(_defaultUri).Respond().UsingContentRangeHeader(22234, 62887922).UsingStatusCode(responseHttpCode);

            var response = _client.GetAsync(new Uri(_defaultUri)).Result;

            Assert.AreEqual("bytes 22234-62887922/*", response.Content.Headers.ContentRange.ToString());
        }

        [Test]
        public void When_request_then_use_content_encoding_response()
        {
            var responseHttpCode = HttpStatusCode.Accepted;
            var contentEncoding = "gzip";
            _messageHandler.WhenRequest().WithUri(_defaultUri).Respond().UsingContentRangeHeader(22234, 62887922).UsingContentEncodingHeader(contentEncoding).UsingStatusCode(responseHttpCode);

            var response = _client.GetAsync(new Uri(_defaultUri)).Result;

            Assert.AreEqual(contentEncoding, response.Content.Headers.ContentEncoding.ToString());
        }

        [Test]
        public void When_request_then_use_content_language_response()
        {
            var responseHttpCode = HttpStatusCode.Accepted;
            var contentEncoding = "gzip";
            var contentLanguage = "de";
            _messageHandler.WhenRequest().WithUri(_defaultUri).Respond().UsingContentRangeHeader(22234, 62887922).UsingContentEncodingHeader(contentEncoding).UsingContentLanguageHeader(contentLanguage).UsingStatusCode(responseHttpCode);

            var response = _client.GetAsync(new Uri(_defaultUri)).Result;

            Assert.AreEqual(contentLanguage, response.Content.Headers.ContentLanguage.ToString());
        }
    }
}
