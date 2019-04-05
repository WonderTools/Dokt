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
//HttpMessageHandler is what does the sending of request and re in HttpClient.
//In Dokt, we have created a FakeMessageHandler. This fake message handler is configurable, to respond with any response for specified requests.
THere are also mechanism to throw Exception and excute calls  backs 

## Features
1. Respond for a specified request
2. Throw excption for a specified request
3. Execute callback for a specified request
4. Linq for configuration

**Example 1: ** 
```
var _messageHandler = new DoktHttpMessageHandler();
var client = new HttpClient(_messageHandler);
var responseHttpCode = HttpStatusCode.Accepted;
var content = "test";

_messageHandler.WhenRequest().WithUri(_defaultUri).Respond(content).UsingStatusCode(responseHttpCode);

 var response = _client.GetAsync(new Uri(_defaultUri)).Result;
 var result = response.Content.ReadAsStringAsync().Result;

 Assert.AreEqual(content, result);
  ```
**Example 2: Response content configuration** 
```
var responseHttpCode = HttpStatusCode.Accepted;
var content = "test";
_messageHandler.WhenRequest().WithUri(_defaultUri).Respond(content).UsingStatusCode(responseHttpCode);

var response = _client.GetAsync(new Uri(_defaultUri)).Result;
var result = response.Content.ReadAsStringAsync().Result;

Assert.AreEqual(content, result);
```
