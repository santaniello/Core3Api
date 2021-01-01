using System;
using Microsoft.Extensions.WebEncoders.Testing;

namespace Core3Api.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            //return Environment.GetEnvironmentVariable("message");
            return "teste";
        }
    }
}