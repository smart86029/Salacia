using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Salacia.HumanResources.App.Organizations;

namespace Salacia.HumanResources.Api
{
    public class OrganizationService : OrganizationGrpc.OrganizationGrpcBase
    {
        private readonly ILogger<OrganizationService> logger;
        private readonly OrganizationApp organizationApp;

        public OrganizationService(
            ILogger<OrganizationService> logger,
            OrganizationApp organizationApp)
        {
            this.logger = logger;
            this.organizationApp = organizationApp;
        }
    }
}
