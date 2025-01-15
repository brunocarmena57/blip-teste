using Core.Domain.Interfaces.Entities;
using Core.Domain.Interfaces.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infrastructure.GitHub.Repository
{
    public class UserGitHubReposRepository : IUserGitHubReposRepository
    {
        private readonly IHttpClientFactory _clientFactory;

        public UserGitHubReposRepository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<Root>> GetRepositoriesFromUser()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.github.com/orgs/takenet/repos");
            request.Headers.Add("Accept", "application/vnd.github.v3+json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            var responseStream = await response.Content.ReadAsStreamAsync();

            StreamReader reader = new StreamReader(responseStream);

            return JsonConvert.DeserializeObject<List<Root>>(reader.ReadToEnd());
        }

        public async Task<List<Root>> GetOldestFiveCSharpRepositories()
        {
            var allRepositories = await GetRepositoriesFromUser();

            // Filter only repositories that have the language property set to "C#"
            // Order them by created date ascending
            // Take the first 5
            var oldestFiveCSharpRepos = allRepositories
                .Where(repo => string.Equals(repo.language, "C#", StringComparison.OrdinalIgnoreCase))
                .OrderBy(repo => repo.created_at)
                .Take(5)
                .ToList();

            return oldestFiveCSharpRepos;
        }

    }
}
