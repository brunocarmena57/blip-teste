using Core.Domain.Interfaces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Domain.Interfaces.Repositories
{
    public interface IUserGitHubReposRepository
    {
        Task<List<Root>> GetRepositoriesFromUser();

        Task<List<Root>> GetOldestFiveCSharpRepositories();
        
    }
}
