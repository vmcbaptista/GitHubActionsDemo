using System.Collections.Generic;

namespace GitHubActionsDemo.Services
{
    public interface IMessageService
    {
        IReadOnlyList<Message> GetMessages();
    }
}