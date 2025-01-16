using Core.Domain.Interfaces.Entities;
using Core.Domain.Interfaces.Repositories;
using Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

        public async Task<string> GetRepositoriesCarouselJson()
        {
            var oldestFiveCSharpRepos = await _userGiHubReposRepository.GetOldestFiveCSharpRepositories();

            var carousel = new
            {
                type = "application/vnd.lime.media-card+json",
                content = new
                {
                    items = oldestFiveCSharpRepos.Select(repo => new
                    {
                        header = new
                        {
                            type = "application/vnd.lime.media-link+json",
                            value = new
                            {
                                title = repo.name,
                                text = repo.description ?? "No description provided",
                                type = "image/jpeg",
                                uri = "https://avatars.githubusercontent.com/u/4369522?s=200&v=4"
                            }
                        }
                    }).ToList()
                }
            };
            var carouselJson = JsonConvert.SerializeObject(carousel);

            return carouselJson;
        }
    }
}
