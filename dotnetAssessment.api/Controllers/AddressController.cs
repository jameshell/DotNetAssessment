using Microsoft.AspNetCore.Mvc;
using dotnetAssessment.core.Models;
using dotnetAssessment.business.Services;
using Microsoft.AspNetCore.Authorization;

namespace dotnetAssessment.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            this._addressService = addressService;
        }

        [HttpGet]
        [Route("")]
         public IEnumerable<Address> GetAllAddresses() => _addressService.GetAllAddresses();

        [HttpGet]
        [Route("{addressId}")]
         public Address GetAddressById(Guid addressId) => _addressService.GetAddressById(addressId);

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public void AddAddress([FromBody] Address address) => _addressService.AddAddress(address);

        [HttpDelete]
        [Route("{addressId}")]
        [AllowAnonymous]
        public void DeleteAddress(Guid addressId) => _addressService.DeleteAddress(addressId);
    }
}