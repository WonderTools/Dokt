using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using WonderTools.FakeHttpClient.RequestRules;
using WonderTools.FakeHttpClient.ResponseRules;

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
            _messageHandler.WhenRequest().WhenUri(uri).AddCallBack(callBackAction).Respond()
                .UseStatusCode(responseHttpCode);

             _client.GetAsync(uri);

            Assert.IsTrue(isCalled);
        }

        [Test]
        public async Task When_exception_is_set_to_throw_then_throw_the_exception()
        {
            var uri = @"https://www.google.com/";
            var responseHttpCode = HttpStatusCode.Accepted;
            var exception = new ArgumentException();

            _messageHandler.WhenRequest().WhenUri(uri).Throw((r) => exception);
            try
            {
                await _client.GetAsync(uri);
            }
            catch (Exception e)
            {
                Assert.AreEqual(exception.GetType(),e.GetType());
            }
        }
    }
}
