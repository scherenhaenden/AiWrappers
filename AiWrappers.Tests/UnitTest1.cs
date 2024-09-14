using System.Text.Json;
using AiWrappers.Core.Requests;

namespace AiWrappers.Tests;
// Modellklasse für die Anfrage
public class ChatCompletionRequest
{
    public string Model { get; set; }
    public List<Message> Messages { get; set; }
    public int? MaxTokens { get; set; } // Optional
    public double Temperature { get; set; }
    public double TopP { get; set; }
    public bool ReturnCitations { get; set; }
    public List<string> SearchDomainFilter { get; set; }
    public bool ReturnImages { get; set; }
    public bool ReturnRelatedQuestions { get; set; }
    public string SearchRecencyFilter { get; set; }
    public int TopK { get; set; }
    public bool Stream { get; set; }
    public int PresencePenalty { get; set; }
    public int FrequencyPenalty { get; set; }
}

// Modellklasse für Nachrichten
public class Message
{
    public string Role { get; set; }
    public string Content { get; set; }
}

// Optional: Modellklasse für die Antwort (angepasst an die tatsächliche API-Antwort)
public class ChatCompletionResponse
{
    // Beispielhafte Eigenschaften
    public string Id { get; set; }
    public string Object { get; set; }
    public int Created { get; set; }
    public string Model { get; set; }
    public List<Choice> Choices { get; set; }
    // Weitere Eigenschaften je nach API-Antwort
}

public class Choice
{
    public int Index { get; set; }
    public Message Message { get; set; }
    public string FinishReason { get; set; }
}


public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test1()
    {
        
            // Ihr API-Token (ersetzen Sie <token> durch Ihren tatsächlichen Token)
            var token = "tokenPerplexity";

            // Erstellen des Anfrage-Payloads
            var requestPayload = new ChatCompletionRequest
            {
                Model = "llama-3.1-sonar-small-128k-online",
                Messages = new List<Message>
                {
                    new Message { Role = "system", Content = "Be precise and concise." },
                    new Message { Role = "user", Content = "How many stars are there in our galaxy?" }
                },
                // MaxTokens ist optional, daher können Sie es weglassen oder auf null setzen
                MaxTokens = null,
                Temperature = 0.2,
                TopP = 0.9,
                ReturnCitations = true,
                SearchDomainFilter = new List<string> { "perplexity.ai" },
                ReturnImages = false,
                ReturnRelatedQuestions = false,
                SearchRecencyFilter = "month",
                TopK = 0,
                Stream = false,
                PresencePenalty = 0,
                FrequencyPenalty = 1
            };

            // Konfigurieren des FluentRestRequester
            
            var requester = FluentRestRequester.Create()
                .BaseAddress("https://api.perplexity.ai")
                .Endpoint("/chat/completions")
                .WithMethod(HttpMethod.Post)
                .WithHeader("Authorization", $"Bearer {token}")
                // Content-Type wird automatisch auf "application/json" gesetzt durch WithPayloadModel
                .WithPayloadModel(requestPayload);

            try
            {
                // Senden der Anfrage und Empfang der Antwort
                var response = await requester.SendAsyncWithResult<ChatCompletionResponse>();

                // Ausgabe der Antwort (beispielhaft)
                Console.WriteLine(JsonSerializer.Serialize(response, new JsonSerializerOptions { WriteIndented = true }));
            }
            catch (HttpRequestException ex)
            {
                Assert.Fail();
                // Fehlerbehandlung
                Console.WriteLine($"Fehler bei der Anfrage: {ex.Message}");
            }
        
        Assert.Pass();
    }
}