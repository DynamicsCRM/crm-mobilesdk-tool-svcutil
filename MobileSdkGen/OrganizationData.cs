using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using System.Linq;

namespace MobileSdkGen
{
    class OrganizationData
    {
        public EntityMetadata[] Entities { get; private set; }
        public OptionSetMetadataBase[] OptionSets { get; private set; }

        public OrganizationData(IOrganizationService orgService)
        {
            var optionSetRequest = new RetrieveAllOptionSetsRequest();
            var entityRequest = new RetrieveAllEntitiesRequest
            {
                EntityFilters = EntityFilters.Entity | EntityFilters.Attributes,
                RetrieveAsIfPublished = false
            };

            OptionSets = ((RetrieveAllOptionSetsResponse)orgService.Execute(optionSetRequest))
                .OptionSetMetadata.OrderBy(o => o.Name).ToArray();

            Entities = ((RetrieveAllEntitiesResponse)orgService.Execute(entityRequest))
                .EntityMetadata.OrderBy(e => e.LogicalName).ToArray();
        }
    }
}
