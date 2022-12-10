// Graph Engine
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Trinity;
using Trinity.Storage;
using Trinity.Configuration;

namespace Web7.DIDComm.DIDRegistry.Gateway
{
    class GatewayService
    {
        public unsafe static void Main(string[] args)
        {
            const int agent = 99;

            TrinityConfig.HttpPort = 8080 + agent;
#pragma warning disable CS0612 // Type or member is obsolete
            TrinityConfig.ServerPort = 5304 + agent;
#pragma warning restore CS0612 // Type or member is obsolete

            DIDRegistryGatewayService gatewayService = new DIDRegistryGatewayService();
            gatewayService.Start();

            Console.WriteLine("Press any key to exit Gateway...");
            Console.ReadLine();

            gatewayService.Stop();
        }
    }
}

