using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzeeKards.Service.Models.Users
{
    public class ExtraInfoCompanyRequest
    {
        public string Designation { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string MapUrl { get; set; }
        public string Website { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string SocialMedias { get; set; }
        public string Description { get; set; }
    }

    public class ExtraInfoCompanyResponse: Base
    {
        public Guid CompanyId { get; set; }
        public Guid ExtraInfoId { get; set; }
        public string Designation { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string MapUrl { get; set; }
        public string Website { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string SocialMedias { get; set; }
        public string Description { get; set; }
    }


    public class ExtraInfoClientRequest
    {
        public string CCountry { get; set; }
        public string CState { get; set; }
        public string CCity { get; set; }
        public string CStreet { get; set; }
        public string CMapUrl { get; set; }
        public string CPhoneNumber { get; set; }
        public string CEmail { get; set; }
        public string CWebsite { get; set; }
        public string CDescription { get; set; }
        public string CSocialMedias { get; set; }
    }
    public class ExtraInfoClientResponse: Base
    {
        public Guid ClientId { get; set; }
        public Guid ExtraInfoId { get; set; }
        public string CCountry { get; set; }
        public string CState { get; set; }
        public string CCity { get; set; }
        public string CStreet { get; set; }
        public string CMapUrl { get; set; }
        public string CWebsite { get; set; }
        public string CPhoneNumber { get; set; }
        public string CEmail { get; set; }
        public string CDescription { get; set; }
        public string CSocialMedias { get; set; }
    }
}
