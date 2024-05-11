using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace AiWrapper.Core.Requests;

public class FluentRestRequester
{
    private readonly HttpClient _client;
    private HttpRequestMessage _request;
    private HttpContent _content;
    private string _baseUrl;
    private string _endpoint;
    private MediaTypeHeaderValue _contentType;
    private readonly Dictionary<string, string> _queryParameters = new Dictionary<string, string>();

    public FluentRestRequester()
    {
        _client = new HttpClient();
    }

    public static FluentRestRequester Create() => new FluentRestRequester();

    public FluentRestRequester BaseAddress(string baseAddress)
    {
        _baseUrl = baseAddress;
        _client.BaseAddress = new Uri(baseAddress);
        return this;
    }

    public FluentRestRequester Endpoint(string endpoint)
    {
        _endpoint = endpoint;
        return this;
    }

    public FluentRestRequester WithMethod(HttpMethod method)
    {
        _request = new HttpRequestMessage(method, _endpoint);
        return this;
    }

    public FluentRestRequester WithPayloadModel<T>(T model)
    {
        
        // if T is string
        if (model is string)
        {
            _content = new StringContent(model.ToString(), Encoding.UTF8, "application/json");
            return this;
        }
        
        
        
        var jsonContent = JsonSerializer.Serialize(model);
        _content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        return this;
    }

    public FluentRestRequester WithJsonContent(string jsonContent)
    {
        _content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        return this;
    }

    public FluentRestRequester WithHeader(string name, string value)
    {
        _request.Headers.Add(name, value);
        return this;
    }
    
    public FluentRestRequester WithContentType(string contentType)
    {
        //var contentType = new MediaTypeHeaderValue(contentType);
        _contentType = new MediaTypeHeaderValue(contentType);
        return this;
        
    }
    
    public FluentRestRequester WithContent(HttpContent content)
    {
        _content = content;
        return this;
    }

    public FluentRestRequester AddQueryParameter(string name, string value)
    {
        _queryParameters.Add(name, value);
        return this;
    }

    private void PrepareRequest()
    {
        if (_request == null)
        {
            throw new InvalidOperationException("HTTP method and endpoint must be specified.");
        }

        if (_content != null)
        {
            _request.Content = _content;
            if(_contentType != null)
                _request.Content.Headers.ContentType = _contentType;
            
        }

        if (_queryParameters.Count > 0)
        {
            var builder = new StringBuilder(_baseUrl + _endpoint);
            builder.Append('?');
            foreach (var param in _queryParameters)
            {
                builder.Append($"{param.Key}={param.Value}&");
            }
            builder.Length--; // Remove the last '&'
            _request.RequestUri = new Uri(builder.ToString());
        }
    }

    public async Task<HttpResponseMessage> SendAsync()
    {
        PrepareRequest();
        return await _client.SendAsync(_request);
    }

    public async Task<T> SendAsync<T>()
    {
        PrepareRequest();
        var response = await _client.SendAsync(_request);
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
        
        return JsonSerializer.Deserialize<T>(responseBody, options);
    }
}