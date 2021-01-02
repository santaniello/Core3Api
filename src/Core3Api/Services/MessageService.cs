using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.WebEncoders.Testing;

namespace Core3Api.Services
{
    public class MessageService : IMessageService
    {
        private readonly string message;

        public MessageService(IConfiguration config)
        {
             message = config.GetValue<string>("message:text");
        }
        

        public string GetMessage()
        {
            return message;
        }
    }
}