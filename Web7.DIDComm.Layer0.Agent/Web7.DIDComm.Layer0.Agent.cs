using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Trinity;
using Trinity.Core.Lib;
using Trinity.Storage;

namespace Web7.DIDComm.Layer0.Agent
{
    public class Layer0AgentService : Layer0AgentServerBase
    {
        public Layer0AgentService()
        {
        }

        public override void SendMessageHandler(SendMessageRequest request)
        {
            string messageText = request.messageText;

            Console.WriteLine("messageText: '" + messageText + "'");
        }
    }
}
