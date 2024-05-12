**README: AiWrappers Core Library - FluentRestRequester**

The FluentRestRequester class provides a fluent and intuitive interface for making HTTP requests within your .NET applications. It simplifies the construction of complex requests, handling of various content types, and integration with RESTful APIs.

**Key Features**

*   **Fluent Interface:** Chain methods to build requests in a readable and maintainable way.
    
*   **Flexible Content Handling:** Easily send JSON, XML, form data, or any other content type.
    
*   **Query Parameter Support:** Dynamically add query parameters to your requests.
    
*   **Async/Await:** Utilize async/await for non-blocking, high-performance operations.
    
*   **Generic Response Deserialization:** Automatically deserialize JSON responses into your models.
    

**Installation**

1.  Include the AiWrappers.Core.Requests namespace in your project.
    
2.  Install the System.Text.Json NuGet package if you're deserializing JSON responses.
    

**Usage**

C#

Plain textANTLR4BashCC#CSSCoffeeScriptCMakeDartDjangoDockerEJSErlangGitGoGraphQLGroovyHTMLJavaJavaScriptJSONJSXKotlinLaTeXLessLuaMakefileMarkdownMATLABMarkupObjective-CPerlPHPPowerShell.propertiesProtocol BuffersPythonRRubySass (Sass)Sass (Scss)SchemeSQLShellSwiftSVGTSXTypeScriptWebAssemblyYAMLXML`   using AiWrappers.Core.Requests;  // ...  var response = await FluentRestRequester.Create()      .BaseAddress("https://api.example.com")      .Endpoint("/resource")      .WithMethod(HttpMethod.Post)      .WithPayloadModel(new { name = "John Doe", age = 30 })      .WithHeader("Authorization", "Bearer your-api-token")      .SendAsync();  // ... (Process the 'response' object)   `

Verwende den Code [mit Vorsicht](/faq#coding).content\_copy

**Examples**

**Simple GET Request:**

C#

Plain textANTLR4BashCC#CSSCoffeeScriptCMakeDartDjangoDockerEJSErlangGitGoGraphQLGroovyHTMLJavaJavaScriptJSONJSXKotlinLaTeXLessLuaMakefileMarkdownMATLABMarkupObjective-CPerlPHPPowerShell.propertiesProtocol BuffersPythonRRubySass (Sass)Sass (Scss)SchemeSQLShellSwiftSVGTSXTypeScriptWebAssemblyYAMLXML`   var response = await FluentRestRequester.Create()      .BaseAddress("https://api.example.com")      .Endpoint("/users")      .AddQueryParameter("id", "123")      .SendAsync>();   `

Verwende den Code [mit Vorsicht](/faq#coding).content\_copy

**POST Request with JSON Payload:**

C#

Plain textANTLR4BashCC#CSSCoffeeScriptCMakeDartDjangoDockerEJSErlangGitGoGraphQLGroovyHTMLJavaJavaScriptJSONJSXKotlinLaTeXLessLuaMakefileMarkdownMATLABMarkupObjective-CPerlPHPPowerShell.propertiesProtocol BuffersPythonRRubySass (Sass)Sass (Scss)SchemeSQLShellSwiftSVGTSXTypeScriptWebAssemblyYAMLXML`   var model = new { name = "Jane Doe", email = "jane@example.com" };  var response = await FluentRestRequester.Create()      .BaseAddress("https://api.example.com")      .Endpoint("/users")      .WithMethod(HttpMethod.Post)      .WithPayloadModel(model)      .SendAsync();   `

Verwende den Code [mit Vorsicht](/faq#coding).content\_copy

**Advanced Usage**

*   **Custom Content Types:** Use WithContent and WithContentType for non-JSON data.
    
*   **Error Handling:** Catch exceptions (HttpRequestException, JsonException) to gracefully handle errors.
    
*   **Customization:** Extend FluentRestRequester to create your own specialized request builders.
    

**Important Notes**

*   Ensure you have proper error handling in your application to handle network issues and API failures.
    
*   For production use, consider adding logging and telemetry to monitor your requests.
    
*   If you encounter issues with complex JSON deserialization, explore using a more robust library like Newtonsoft.Json.
    

**Contributing**

We welcome contributions! Please create a pull request or open an issue if you find any bugs or have suggestions for improvements.
