using dotnetAssessment.core.Models;
using System.Collections.Generic;

namespace dotnetAssessment.business.Services
{
    public interface IAddressService
    {
        IEnumerable<Address> GetAllAddresses();
        Address GetAddressById();
        Task<Address> AddAddress();
        Task DeleteDeveloper();
    }
}