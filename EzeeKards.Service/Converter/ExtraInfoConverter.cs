using Azure.Core;
using EzeeKards.Data.Entities.Domain;
using EzeeKards.Service.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzeeKards.Service.Converter
{
    public class ExtraInfoConverter
    {
        public ClientExtraInfo ClientToEntity(ExtraInfoClientRequest request)
        {
            return new ClientExtraInfo
            {   
                Id = Guid.NewGuid(),
                CWebsite = request.CWebsite,
                CCountry = request.CCountry,
                CState = request.CState,
                CCity = request.CCity,
                CStreet = request.CStreet,
                CMapUrl = request.CMapUrl,
                CPhoneNumber = request.CPhoneNumber,
                CEmail = request.CEmail,
                CDescription = request.CDescription,
                CSocialMedias = request.CSocialMedias
            };
        }

        public ExtraInfoClientResponse ClientToModel(ClientExtraInfo entity)
        {
            return new ExtraInfoClientResponse
            {
                ClientId = entity.ClientId,
                ExtraInfoId = entity.Id,
                CWebsite = entity.CWebsite,
                CCountry = entity.CCountry,
                CState = entity.CState,
                CCity = entity.CCity,
                CStreet = entity.CStreet,
                CMapUrl = entity.CMapUrl,
                CPhoneNumber = entity.CPhoneNumber,
                CEmail = entity.CEmail,
                CDescription = entity.CDescription,
                CSocialMedias = entity.CSocialMedias
            };
        }

        public CompanyExtraInfo CompanyToEntity(ExtraInfoCompanyRequest request)
        {
            return new CompanyExtraInfo
            {
                Id = Guid.NewGuid(),
                Designation = request.Designation,
                Country = request.Country,
                State = request.State,
                City = request.City,
                Street = request.Street,
                MapUrl = request.MapUrl,
                Website = request.Website,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Description = request.Description,
                SocialMedias= request.SocialMedias
            };
        }

        public ExtraInfoCompanyResponse CompanyToModel(CompanyExtraInfo entity)
        {
            return new ExtraInfoCompanyResponse
            {
                CompanyId = entity.CompanyId,
                ExtraInfoId = entity.Id,    
                Designation = entity.Designation,
                Country = entity.Country,
                State = entity.State,
                City = entity.City,
                Street = entity.Street,
                MapUrl = entity.MapUrl,
                Website = entity.Website,
                PhoneNumber = entity.PhoneNumber,
                Email = entity.Email,
                SocialMedias = entity.SocialMedias,
                Description = entity.Description
            };
        }

        public void ClientToDomain(ClientExtraInfo extraInfo, ExtraInfoClientRequest request)
        {
            extraInfo.CCountry = request.CCountry;
            extraInfo.CState = request.CState;
            extraInfo.CCity = request.CCity;
            extraInfo.CStreet = request.CStreet;
            extraInfo.CPhoneNumber = request.CPhoneNumber;
            extraInfo.CEmail = request.CEmail;
            extraInfo.CWebsite = request.CWebsite;
            extraInfo.CDescription = request.CDescription;
            extraInfo.CSocialMedias = request.CSocialMedias;
        }

        public void CompanyToDomain(CompanyExtraInfo extraInfo, ExtraInfoCompanyRequest request)
        {
            extraInfo.Designation = request.Designation;
            extraInfo.Country = request.Country;
            extraInfo.State = request.State;
            extraInfo.City = request.City;
            extraInfo.Street = request.Street;
            extraInfo.MapUrl = request.MapUrl;
            extraInfo.Website = request.Website;
            extraInfo.PhoneNumber = request.PhoneNumber;
            extraInfo.Email = request.Email;
        }
    }
}
