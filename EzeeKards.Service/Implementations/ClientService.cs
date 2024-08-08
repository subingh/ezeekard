using EzeeKard.Service.Converters;
using EzeeKard.Service.Interfaces;
using EzeeKards.Common.Helpers;
using EzeeKards.Data.Database;
using EzeeKards.Data.Entities.Domain;
using EzeeKards.Service.Implementation;
using EzeeKards.Service.Models.Users;
using LogBook.Common.Models.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.ComponentModel.Design;
using System.Net;

namespace EzeeKard.Service.Implementations
{
    public class ClientService : IClientService
    {
        private readonly ClientConvertion _converter;
        private readonly ApplicationDbContext _dbContext;
        private readonly IErrorService _errorService;

        public ClientService( ClientConvertion converter, ApplicationDbContext dbContext, IErrorService errorService)
        {
            _converter = converter;
            _dbContext = dbContext;
            _errorService = errorService;
        }

        /// <summary>
        /// create a client
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<OperationResult<ClientResponse>> CreateClientAsync(ClientRequest request)
        {
            var operation = new OperationResult<ClientResponse>();
            try
            {
                //convert the requested object into entity object
                var client = _converter.ToEntity(request);

                //check if requested image is null or not
                if (request.Image != null)
                {
                    // Define the folder path and ensure it exists
                    var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

                    //Check if directory exist or not, if not create directory
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    // Generate a unique file name for the image
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(request.Image.FileName);
                    var filePath = Path.Combine(folderPath, fileName);

                    // Save the image file to the folder
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await request.Image.CopyToAsync(stream);
                    }

                    // Set the ImageUrl property to the relative path
                    client.ImageUrl = $"/images/{fileName}";
                }
                _dbContext.Client.Add(client);
                await _dbContext.SaveChangesAsync();
                operation.Result = _converter.ToModel(client);
                operation.Status = HttpStatusCode.OK;
            }

            catch (Exception ex)
            {
                await _errorService.Exception(operation, ex);
            }
            return operation;
        }

       /// <summary>
       /// retrieve data from client table
       /// update data to the table
       /// </summary>
       /// <param name="clientId"></param>
       /// <param name="request"></param>
       /// <returns></returns>
        public async Task<OperationResult<ClientResponse>> UpdateClientAsync(Guid clientId, ClientRequest request)
        {
            var operation = new OperationResult<ClientResponse>();
            try
            {   //retrieve client data from database
                var clientData = await _dbContext.Client.FirstOrDefaultAsync(u => Guid.Equals(u.ClientId, clientId));

                //check if requested image is null or not
                if (request.Image != null)
                {
                    // Define the folder path and ensure it exists
                    var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

                    //Check if directory exist or not, if not create directory
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    // Generate a unique file name for the image
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(request.Image.FileName);
                    var filePath = Path.Combine(folderPath, fileName);

                    // Save the image file to the folder
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await request.Image.CopyToAsync(stream);
                    }

                    // Set the ImageUrl property to the relative path
                    clientData.ImageUrl = $"/images/{fileName}";
                }

                _converter.ToDomain(clientData, request);

                _dbContext.Update(clientData);
                var result = await _dbContext.SaveChangesAsync();
                if (result <= 0)
                {
                    operation.Exception = new Exception($"Client with {clientId} id is not updated in the database ");
                    operation.Status = HttpStatusCode.NotFound;
                    return operation;
                }

                operation.Result = _converter.ToModel(clientData);
                operation.Status = HttpStatusCode.OK;

                // Convert the updated client entity to a ClientResponse
                return operation;
            }
            catch (Exception ex)
            {
                await _errorService.Exception(operation, ex);
            }
            return operation;
        }

        /// <summary>
        /// Soft delete the client details
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public async Task<OperationResult<ClientResponse>> DeleteClientAsync(Guid clientId)
        {
            var operation = new OperationResult<ClientResponse>();
            try
            {
                // Retrieve the client from the database
                var client = await _dbContext.Client.FindAsync(clientId);
                if (client == null)
                {
                    // Client not found
                    operation.Status = HttpStatusCode.NotFound;
                    operation.Exception = new Exception("Client not found.");
                    return operation;
                }
                //Change the value of IsDeleted (flag to true)
                client.IsDeleted = !client.IsDeleted;

                //Update client entity in DbContext
                _dbContext.Client.Update(client);
                await _dbContext.SaveChangesAsync();
                var deletedClientDto = _converter.ToModel(client);
                operation.Result = deletedClientDto;
                operation.Status = HttpStatusCode.OK;
            }
            
            catch (Exception ex)
            {
                await _errorService.Exception(operation, ex);
            }
            return operation;
        }

        /// <summary>
        /// get all clients' name and imageurl
        /// </summary>
        /// <returns></returns>
        public async Task<OperationResult<IEnumerable<ClientResponse>>> GetAllAsync()
        {
            var operation = new OperationResult<IEnumerable<ClientResponse>>();
            try
            {
                var clients = await _dbContext.Client.ToListAsync();
                if (clients == null)
                {
                    operation.Exception = new Exception("No clients present.");
                    operation.Status = HttpStatusCode.NotFound;
                    return operation;
                }
                operation.Result = clients.Select(_converter.ToModel);
                operation.Status = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                await _errorService.Exception(operation, ex);
            }
            return operation;
        }


        /// <summary>
        /// get client details with id
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public async Task<OperationResult<ClientResponse>> GetByIdAsync(Guid clientId)
        {
            var operation = new OperationResult<ClientResponse>();
            try
            {
                var client = await _dbContext.Client.FirstOrDefaultAsync(u => u.ClientId == clientId);
                if (client == null)
                {
                    operation.Status = HttpStatusCode.NotFound;
                    return operation;
                }
                operation.Result = _converter.ToModel(client);
                operation.Status = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                await _errorService.Exception(operation, ex);
            }
            return operation;
        }
    }
}
