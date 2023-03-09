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
        private IUnitOfWork _unitOfWork;
        private readonly ILogger<AddressController> _logger;
        public AddressController(IUnitOfWork unitOfWork, ILogger<AddressController> logger)
        {
            this._unitOfWork = unitOfWork;
            this._logger = logger;
        }

        [HttpGet]
        [Route("")]
         public IEnumerable<Address> GetAllAddresses() => _unitOfWork.AddressRepository.GetAll();

        [HttpGet]
        [Route("{addressId}")]
         public Address GetAddressById(Guid addressId) => _unitOfWork.AddressRepository.GetById(addressId);

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public void AddAddress([FromBody] Address address)
        {
            try
            {
                _unitOfWork.AddressRepository.Insert(address);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when creating an address: {address.Id} {ex}");
                _unitOfWork.Rollback();
            }
        }

        [HttpDelete]
        [Route("{addressId}")]
        [AllowAnonymous]
        public void DeleteAddress(Guid addressId)
        {
            try
            {
                _unitOfWork.AddressRepository.Delete(addressId);
                _unitOfWork.Commit();
            }
            catch (System.Exception)
            {
                _logger.LogError($"Error when deleting an address: {addressId}");
                _unitOfWork.Rollback();
            }
        }
    }
}