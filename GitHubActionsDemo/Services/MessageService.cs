using System.Collections.Generic;

namespace GitHubActionsDemo.Services
{
    public class MessageService : IMessageService
    {
        public IReadOnlyList<Message> GetMessages() => new List<Message>{ new("Message A") };
    }
}