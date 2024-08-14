using EzeeKards.Common.Helpers;
using EzeeKards.Data.Entities.Domain;
using EzeeKards.Service.Models.Users;

namespace EzeeKard.Service.Converters
{
    public class ClientConvertion
    { 

        public Client ToEntity(ClientRequest clientRequest)
        {
            if (clientRequest == null)
            {
                throw new ArgumentNullException(nameof(clientRequest), "Client cannot be null");
            }

            return new Client
            {   
                ClientName = clientRequest.ClientName,
                ImageUrl = $"Images/{clientRequest.ClientName}"
            };
        }

        public ClientResponse ToModel(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client), "Client cannot be null");
            }
            return new ClientResponse
            {   
                ClientId = client.ClientId,
                ClientName = client.ClientName,
                Image = client.ImageUrl,
                IsDeleted = client.IsDeleted,
                CreatedBy = client.ClientName,
                CreatedDate = client.CreatedDate,
                UpdatedBy = client.UpdatedBy,
                UpdatedDate = client.UpdatedDate
            };
        }

        public void ToDomain(Client client, ClientRequest request) 
        {
            client.ClientName = request.ClientName;
        }
    }
}
