using dotnetAssessment.core.Models;
using System.Collections.Generic;

namespace dotnetAssessment.business.Services
{
    public interface IAddressService
    {
        IEnumerable<Address> GetAllAddresses();
        Address GetAddressById(Guid addressId);
        void AddAddress(Address address);
        void DeleteDeveloper(Guid addressId);
    }
}