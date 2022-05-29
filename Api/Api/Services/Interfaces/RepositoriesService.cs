using Api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Services.Interfaces
{
    public interface RepositoriesService
    {
        Task<List<RepositorieData>> GetRepositoriesChallenge();
    }
}
