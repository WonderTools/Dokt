# Dokt - A tool to mock the behaviour of HttpClient in unit/integration tests
When you are building an application, and that application communicates with web services using HttpClient, testing your application could be difficult. This difficulty is because of the concrete nature of HttpClient. Dokt is a tool that could come to rescue in these scenarios. 

## Testing classes that use HttpClient without Dokt
Let's understand how we can test classes that use HttpClient. Even without using Dokt there are several ways to test classes that use HttpClient. We found these methods less efficient, and we have built Dokt to improve these inefficiencies.

1. Encapsulating HttpClient/Wrapping HttpClient

Encapsulating HttpClient inside a wrapper class using interface, so we can mock it for testing. But the drawback is here, you have to write wrapper class and various methods depends on the requirement for testing which is quite overhead for the developer.

2. Wiremock

Wiremock is a library for stubbing and mocking web servieces. It constructs a HTTP server that we could connect to as we would to an actual web service. But it has overhead of invoking the server.

3. Mocking HttpMessageHandler used by HttpClient

Mocking a HttpMessageHandler by creating a mock object of HttpMessageHandler and injecting it into constructor of HttpClient.But mocking it doesn't provide good readability makes it more complex during configuration.

## Dokt's style
HttpMessageHandler allows you to configure response based on specific request and allow you to send the configured response.
In Dokt, we have created a FakeMessageHandler. This fake message handler is configurable, to respond with any response for specified requests.
There are also mechanism to throw Exception and excute calls backs 

## Features
Sample usage : https://github.com/WonderTools/Dokt.Example
1. Respond for a specified request
2. Throw excption for a specified request
3. Execute callback for a specified request
4. Linq for configuration

**Example 1: Uri configuration** 
```
var _messageHandler = new DoktHttpMessageHandler();
var client = new HttpClient(_messageHandler);
var responseHttpCode = HttpStatusCode.Accepted;
var content = "test";

_messageHandler.WhenRequest().WithUri("https://www.google.com").Respond(content).UsingStatusCode(responseHttpCode);

 var response = _client.GetAsync(new Uri("https://www.google.com")).Result;
 var result = response.Content.ReadAsStringAsync().Result;

 Assert.AreEqual(content, result);
  ```
**Example 2: Response content configuration** 
```
var responseHttpCode = HttpStatusCode.Accepted;
var content = "test";
_messageHandler.WhenRequest().WithUri("https://www.google.com").Respond(content).UsingStatusCode(responseHttpCode);

var response = _client.GetAsync(new Uri("https://www.google.com")).Result;
var result = response.Content.ReadAsStringAsync().Result;

Assert.AreEqual(content, result);
```
**Example 3: Response Header configuration** 
```
 var responseHttpCode = HttpStatusCode.Accepted;
 var responseRange = "byte";
 
 _messageHandler.WhenRequest().WithUri(_defaultUri).Respond().UsingAcceptRangeHeader(responseRange).UsingStatusCode(responseHttpCode);
var response = _client.GetAsync(new Uri("https://www.google.com")).Result

Assert.AreEqual(responseRange, response.Headers.AcceptRanges.ToString());
Assert.AreEqual(responseHttpCode, response.StatusCode);
```
**Example 4: Call backs configuration** 
```
var responseHttpCode = HttpStatusCode.Accepted;
var isCalled = false;
Action<HttpRequestMessage> callBackAction = (x) => { isCalled = true; };
_messageHandler.WhenRequest().WithUri(uri).Execute(callBackAction).Respond()
                .UsingStatusCode(responseHttpCode);

_client.GetAsync(uri);

Assert.IsTrue(isCalled);
```
**Example 5: Exception configuration** 
```
var responseHttpCode = HttpStatusCode.Accepted;
var exception = new ArgumentException();
_messageHandler.WhenRequest().WithUri("https://www.google.com").Throw((r) => exception);
try
{
  await _client.GetAsync("https://www.google.com");
}
catch (Exception e)
{
   Assert.AreEqual(exception.GetType(),e.GetType());
}
```
