namespace AiWrappers.Core.Text;

public interface IAiRequesterByPrompts
{
    public Task<string?> RunRequest(string prompt);
}