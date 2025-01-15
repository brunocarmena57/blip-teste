using Core.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace GitHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubController : ControllerBase
    {

        private IUserGitHubReposService _userGitHubReposService;

        public GitHubController(IUserGitHubReposService userGitHubReposService) =>
        _userGitHubReposService = userGitHubReposService;

        [HttpGet]
        [Route("GetAllRepositories")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var dataResponse = await _userGitHubReposService.GetRepositoriesFromUser();

                return Ok(dataResponse);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("GetByRepositoryName")]
        public async Task<IActionResult> GetByRepositoryName(string reponame)
        {
            try
            {
                if (!string.IsNullOrEmpty(reponame))
                {
                    var responseData = await _userGitHubReposService.GetByRepositorByName(reponame);
                    return Ok(responseData);
                }
                else
                {
                    return BadRequest("Favor informar o nome do repositório para busca.");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("GetOldestFiveCSharpRepositories")]
        public async Task<IActionResult> GetOldestFiveCSharpRepositories()
        {
            try
            {
                var responseData = await _userGitHubReposService.GetOldestFiveCSharpRepositories();
                return Ok(responseData);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
