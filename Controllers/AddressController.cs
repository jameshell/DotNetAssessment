using Microsoft.AspNetCore.Mvc;
using dotnetAssessment.Models;
using dotnetAssessment.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace dotnetAssessment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private IRepository<Address> addressRepository;
        public AddressController(IRepository<Address> addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        [HttpGet]
        [Route("")]
         public IEnumerable<Address> GetAllAddresses() => addressRepository.GetAll();

        [HttpGet]
        [Route("{addressId}")]
         public Address GetAddressById(Guid addressId) => addressRepository.GetById(addressId);

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public void AddAddress([FromBody] Address address) => addressRepository.Insert(address);

        [HttpDelete]
        [Route("{addressId}")]
        [AllowAnonymous]
        public void DeleteAddress(Guid addressId) => addressRepository.Delete(addressId);
    }
}