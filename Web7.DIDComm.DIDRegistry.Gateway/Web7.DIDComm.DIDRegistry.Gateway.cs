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
        public override void CreateHandler(CreateRequest request, out CreateResponse response)
        {
            throw new NotImplementedException();
        }

        public override void DeactivateHandler(DeactivateRequest request, out DeactivateResponse response)
        {
            throw new NotImplementedException();
        }

        public override void ReadHandler(ReadRequest request, out ReadResponse response)
        {
            throw new NotImplementedException();
        }

        public override void UpdateHandler(UpdateRequest request, out UpdateResponse response)
        {
            throw new NotImplementedException();
        }
    }
}
