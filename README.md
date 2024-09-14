✨ AiWrappers: Your Gateway to AI Wonders ✨
------------------------------------------

Unleash the boundless potential of artificial intelligence with AiWrappers, your elegant toolkit for effortlessly interacting with the most cutting-edge AI APIs.

### 💫 Why Choose AiWrappers?

*   **Effortless AI Integration:** Seamlessly connect your applications to the brilliance of Google, Perplexity, OpenAI, and more.

*   **Fluent API Choreography:** Craft AI requests with intuitive, chainable methods that feel like composing a symphony of code.

*   **Abstraction Excellence:** Focus on the magic of AI, not the intricacies of API requests and responses. AiWrappers handles the heavy lifting for you.

*   **Extensibility Enchantment:** Customize and expand the library to effortlessly incorporate new AI providers and capabilities.


### ✨ Installation & Initiation

1.  Enrich your project with the AiWrappers library.

2.  Choose your AI adventure: Install the specific AiWrappers packages for your desired providers (e.g., AiWrappers.Perplexity).


### 🪄 Usage Examples: A Glimpse into AI's Realm

**Querying the Oracle of Perplexity:**

C#

```csharp
using AiWrappers.Perplexity;
using AiWrappers.Core.Text; // Updated import


// ...


var answer = await PerplexityRequester.Create()
    .WithApiKey("your-perplexity-api-key")
    .RunRequest("What is the meaning of life?"); // Updated method call


Conversing with the OpenAI Muse:
```
    
    
C#

```csharp
using AiWrappers.OpenAI;
using AiWrappers.Cordve.Text; // Updated import


// ...


var completion = await OpenAIRequester.Create()
    .WithApiKey("your-openai-api-key")
    .WithModel("text-davinci-003") // Choose your AI model
    .RunRequest("Once upon a time..."); // Updated method call
```

🔮 The AiWrappers Arsenal

*   **Core:** The foundational magic that empowers all interactions with AI providers.

*   **Provider-Specific Packages:** Each package unlocks the unique capabilities of a particular AI platform (e.g., AiWrappers.Perplexity, AiWrappers.OpenAI).


🙌 Join the AI Revolution!

Whether you're a seasoned AI sorcerer or just beginning your journey, AiWrappers empowers you to weave AI into your applications with ease and grace.

*   **Explore the Documentation:** Delve deeper into the mystical arts of AiWrappers through our comprehensive documentation.

*   **Share Your Creations:** Showcase your AI-powered projects and inspire others on the endless possibilities.

*   **Contribute Your Magic:** Help us expand the realm of AiWrappers by contributing your own code, ideas, or enchantments.

Let's embark on an extraordinary AI adventure together!

