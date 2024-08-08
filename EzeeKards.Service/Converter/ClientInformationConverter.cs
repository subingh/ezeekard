using EzeeKards.Data.Entities.Domain;
using EzeeKards.Service.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EzeeKards.Service.Converter
{
    public class ClientInformationConverter
    {
        public List<ClientDetails> ClientToDomain(List<Client> clients, List<ClientExtraInfo> clientExtraInfos, List<Company> companies, List<CompanyExtraInfo> companyExtraInfoList)
        {
            var clientDetailsList = new List<ClientDetails>();

            foreach (var client in clients)
            {
                var clientDetails = new ClientDetails
                {
                    ClientId = client.ClientId,
                    ClientName = client.ClientName,
                    ImageURl = client.ImageUrl
                };
                clientDetailsList.Add(clientDetails);
                
                // For Client Extra Informations
                var clientExtraInfoList = clientExtraInfos.Where(e => e.ClientId == client.ClientId).ToList();
                foreach(var clientExtraInfo in clientExtraInfoList)
                {
                    var clientDetail = new ClientDetails
                    {
                        CWebsite = clientExtraInfo.CWebsite,
                        CCountry = clientExtraInfo.CCountry,
                        CState = clientExtraInfo.CState,
                        CCity = clientExtraInfo.CCity,
                        CStreet = clientExtraInfo.CStreet,
                        CMapUrl = clientExtraInfo.CMapUrl,
                        CEmail = clientExtraInfo.CEmail,
                        CDescription = clientExtraInfo.CDescription,
                        CPhoneNumber = clientExtraInfo.CPhoneNumber,
                        CSocialMedias = clientExtraInfo.CSocialMedias,
                    };
                    clientDetailsList.Add(clientDetail);
                }

                //For Company
                var clientCompanies = companies.Where(c => c.ClientId == client.ClientId).ToList();
                foreach (var company in clientCompanies)
                {
                    var clientCompanyDetail = new ClientDetails
                    {
                        CompanyName = company.CompanyName,
                        CompanyLogo = company.CompanyLogo,
                    };
                    clientDetailsList.Add(clientCompanyDetail);

                    // Retrieve all extra info associated with the company
                    var companyExtrasList = companyExtraInfoList.Where(e => e.CompanyId == company.CompanyId).ToList();
                    foreach (var companyExtraInfo in companyExtrasList)
                    {
                        var clientCompanyExtraInfoDetails = new ClientDetails
                        {
                            Designation = companyExtraInfo.Designation,
                            Country = companyExtraInfo.Country,
                            State = companyExtraInfo.State,
                            City = companyExtraInfo.City,
                            Street = companyExtraInfo.Street,
                            Website = companyExtraInfo.Website,
                            Description = companyExtraInfo.Description,
                            SocialMedias = companyExtraInfo.SocialMedias,
                            PhoneNumber = companyExtraInfo.PhoneNumber,
                            Email = companyExtraInfo.Email,
                            MapUrl = companyExtraInfo.MapUrl,
                        };

                        clientDetailsList.Add(clientCompanyExtraInfoDetails);
                    }
                }
            }

            return clientDetailsList;
        }


        public List<ClientDetails> ClientToModel(Client client, List<ClientExtraInfo> clientExtraInfos, List<Company> companies, List<CompanyExtraInfo> companyExtraInfoList)
        {
            // Create a list to store the detailed client information
            var clientDetailsList = new List<ClientDetails>();
            var clientDetails = new ClientDetails
            {
                ClientId = client.ClientId,
                ClientName = client.ClientName,
                ImageURl = client.ImageUrl
            };
            clientDetailsList.Add(clientDetails);

            // For Client Extra Informations
            var clientExtraInfoList = clientExtraInfos.Where(e => e.ClientId == client.ClientId).ToList();
            foreach (var clientExtraInfo in clientExtraInfoList)
            {
                var clientDetail = new ClientDetails
                {
                    CWebsite = clientExtraInfo.CWebsite,
                    CCountry = clientExtraInfo.CCountry,
                    CState = clientExtraInfo.CState,
                    CCity = clientExtraInfo.CCity,
                    CStreet = clientExtraInfo.CStreet,
                    CMapUrl = clientExtraInfo.CMapUrl,
                    CEmail = clientExtraInfo.CEmail,
                    CDescription = clientExtraInfo.CDescription,
                    CPhoneNumber = clientExtraInfo.CPhoneNumber,
                    CSocialMedias = clientExtraInfo.CSocialMedias,
                };
                clientDetailsList.Add(clientDetail);
            }

            //For Company
            var clientCompanies = companies.Where(c => c.ClientId == client.ClientId).ToList();
            foreach (var company in clientCompanies)
            {
                var clientCompanyDetail = new ClientDetails
                {
                    CompanyName = company.CompanyName,
                    CompanyLogo = company.CompanyLogo,
                };
                clientDetailsList.Add(clientCompanyDetail);

                // Retrieve all extra info associated with the company
                var companyExtrasList = companyExtraInfoList.Where(e => e.CompanyId == company.CompanyId).ToList();
                foreach (var companyExtraInfo in companyExtrasList)
                {
                    var clientCompanyExtraInfoDetails = new ClientDetails
                    {
                        Designation = companyExtraInfo.Designation,
                        Country = companyExtraInfo.Country,
                        State = companyExtraInfo.State,
                        City = companyExtraInfo.City,
                        Street = companyExtraInfo.Street,
                        Website = companyExtraInfo.Website,
                        Description = companyExtraInfo.Description,
                        SocialMedias = companyExtraInfo.SocialMedias,
                        PhoneNumber = companyExtraInfo.PhoneNumber,
                        Email = companyExtraInfo.Email,
                        MapUrl = companyExtraInfo.MapUrl,
                    };

                    clientDetailsList.Add(clientCompanyExtraInfoDetails);
                }
            }
            return clientDetailsList;
        }
    }
}
