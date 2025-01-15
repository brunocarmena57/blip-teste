using Core.Domain.Interfaces.Entities;
using Core.Domain.Interfaces.Repositories;
using Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Application.Services
{
    public class UserGitHubReposService : IUserGitHubReposService
    {
        private readonly IUserGitHubReposRepository _userGiHubReposRepository;

        public UserGitHubReposService(IUserGitHubReposRepository userGitHubReposRepository)
        {
            _userGiHubReposRepository = userGitHubReposRepository;
        }

        public async Task<List<Root>> GetRepositoriesFromUser() =>
            await _userGiHubReposRepository.GetRepositoriesFromUser();

        public async Task<List<Root>> GetByRepositorByName(string name)
        {
            List<Root> allReposByUser = await _userGiHubReposRepository.GetRepositoriesFromUser();

            var filteredByName = allReposByUser.Where(r => r.name.Contains(name)).ToList();

            return filteredByName;
        }
        
        public async Task<List<Root>> GetOldestFiveCSharpRepositories() =>
            await _userGiHubReposRepository.GetOldestFiveCSharpRepositories();
    }
}
