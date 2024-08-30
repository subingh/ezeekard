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
                FirstName = clientRequest.FirstName,
                LastName = clientRequest.LastName,
                UserName = clientRequest.UserName,
                Password = clientRequest.Password,
                ImageUrl = $"Images/{clientRequest.UserName}"
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
                FirstName = client.FirstName,
                LastName = client.LastName,
                UserName = client.UserName,
                Password = client.Password,
                Image = client.ImageUrl,
                IsDeleted = client.IsDeleted,
                CreatedBy = client.UserName,
                CreatedDate = client.CreatedDate,
                UpdatedBy = client.UpdatedBy,
                UpdatedDate = client.UpdatedDate
            };
        }

        public void ToDomain(Client client, ClientRequest request) 
        {
            client.UserName = request.UserName;
            client.FirstName = request.FirstName;
            client.LastName = request.LastName;
            client.Password = request.Password;
        }
    }
}
