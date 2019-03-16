using System;
using System.Net;
using System.Net.Http;
using NUnit.Framework;

namespace WonderTools.FakeHttpClient.Tests
{
    public class RuleTests
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
        public void When_callback_then_perform_action()
        {
            var uri = @"https://www.google.com/";
            var responseHttpCode = HttpStatusCode.Accepted;
            var isCalled = false;
            Action<HttpRequestMessage> callBackAction = (x) => { isCalled = true; };
            _messageHandler.BuildRule().WhenUri(uri).AddCallBack(callBackAction)
                .UseStatusCode(responseHttpCode);

             _client.GetAsync(uri);

            Assert.IsTrue(isCalled);
        }

        [Test]
        public void When_exception_is_set_to_throw_then_throw_the_exception()
        {
            var uri = @"https://www.google.com/";
            var responseHttpCode = HttpStatusCode.Accepted;
            var exception = new ArgumentException();

            _messageHandler.BuildRule().WhenUri(uri).AddExceptionFactory((r)=> exception)
                .UseStatusCode(responseHttpCode);
            try
            {
                _client.GetAsync(uri);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exception.GetType(),e.InnerException.GetType());
            }
        }
    }
}
