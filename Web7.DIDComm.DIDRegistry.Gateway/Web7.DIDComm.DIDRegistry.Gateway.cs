using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Trinity;
using Trinity.Core.Lib;
using Trinity.Storage;

namespace Web7.DIDComm.DIDRegistry.Gateway
{
    public class DIDRegistryGatewayService : DIDRegistryGatewayServerBase
    {
        public DIDRegistryGatewayService()
        {
        }

        public override void SendMessageHandler(SendMessageRequest request)
        {
            Console.WriteLine("messageText: '" + request.messageText + "'");
        }
    }
}
