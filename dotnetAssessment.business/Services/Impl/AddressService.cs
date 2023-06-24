using dotnetAssessment.core.Models;
using dotnetAssessment.data.Repositories;
using Microsoft.Extensions.Logging;

namespace dotnetAssessment.business.Services.Impl
{
    public class AddressService : IAddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public AddressService(IUnitOfWork unitOfWork, ILogger logger)
        {
            this._unitOfWork = unitOfWork;
            this._logger = logger;
        }

        public void AddAddress(Address address)
        {
            try
            {
                _unitOfWork.AddressRepository.Insert(address);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when creating an address: {address.Id} Details:{ex}");
                _unitOfWork.Rollback();
            }
        }

        public void DeleteAddress(Guid addressId)
        {
            try
            {
                _unitOfWork.AddressRepository.Delete(addressId);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when deleting an address: {addressId}. Details:{ex}");
                _unitOfWork.Rollback();
            }
        }

        public Address GetAddressById(Guid addressId) => _unitOfWork.AddressRepository.GetById(addressId);

        public IEnumerable<Address> GetAllAddresses() => _unitOfWork.AddressRepository.GetAll();
    }
}