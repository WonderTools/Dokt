# Dokt - A tool to test the HttpClient
This tool is used to test the client application which uses HttpClient to consume the web api's.
## Why Dokt?
We have following options available to test the HttpClient:
1. Using interfaces
2. Wiremock
3. Message Handler injection in HttpClient
4. Dokt

Using interface the disadvantage is that we have to write extra classes and methods to mock the attributes which we want to test which is a
overhead for the developer. Wiremock provides the facility of the mock testing with good readability, but it invokes the server in the test
machine for the testing which is an overhead for the machine. Message Handler injection in httpclient through the constructor is another way
of testing the httpclient, but it doesn't come with configurable readability.
Therefore, we come up with a better version of MessageHandler known as DoktHttpMessageHandler which provides the testing of the client application
using httpclient with better readability and easy configurability.
## Features
1. Configurable message handler
2. Confurable HttpRequests
3. Configurable HttpResponses
## Step to use the feature
1. Install the nuget package "WonderTools.Dokt" in your test project.
2. Create an object for DoktHttpMessageHandler.
3. Inject this message handler object in Http client through the constructor.
4. Configure this message handler according to your testing scenarios.

**Example:** 
 Initialization
```
var _messageHandler = new DoktHttpMessageHandler();
var client = new HttpClient(_messageHandler);
```
Configuring HttpStatusCode on the basis of request uri
``` var uri = @"https://www.google.com/";
 var responseHttpCode = HttpStatusCode.Accepted;
 _messageHandler.WhenRequest().WithUri(uri).
                      Respond().UsingStatusCode(responseHttpCode);
 ```
 Action and Assert
  ```
  var response = _client.GetAsync(new Uri(uri)).Result;
  Assert.AreEqual(responseHttpCode, response.StatusCode);
  ```
