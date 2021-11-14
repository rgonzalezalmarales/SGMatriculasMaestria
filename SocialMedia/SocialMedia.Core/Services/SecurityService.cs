﻿using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SecurityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Security> GetLoginByCredentialsAsync(UserLogin userLogin)
        {
            return await _unitOfWork.SecurityRepository.GetLoginByCredentialsAsync(userLogin);
        }

        public async Task RegisterUser(Security security)
        {
            await _unitOfWork.SecurityRepository.AddAsync(security);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
