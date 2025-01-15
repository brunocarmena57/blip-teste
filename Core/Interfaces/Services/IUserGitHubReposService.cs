using Core.Domain.Interfaces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Domain.Interfaces.Services
{
    public interface IUserGitHubReposService
    {
        Task<List<Root>> GetRepositoriesFromUser();

        Task<List<Root>> GetByRepositorByName(string name);
        
        Task<List<Root>> GetOldestFiveCSharpRepositories();
    }
}
