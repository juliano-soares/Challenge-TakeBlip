using Api.Entities;
using Api.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;

namespace Api.Services
{
    public class ChallengeService : RepositoriesService
    {
        public async Task<List<RepositorieData>> GetRepositoriesChallenge()
        {
            var request = new HttpClient();
            var repositorios = new List<RepositorieData>();

            request.DefaultRequestHeaders.Accept.Clear();
            request.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            request.DefaultRequestHeaders.Add("User-Agent", "challenge");
            var baseUrl = "https://api.github.com/users/takenet/repos";

            try
            {
                var response = request.GetStringAsync(baseUrl).Result;
                var responseList = JsonConvert.DeserializeObject<List<RepositorieData>>(response);

                repositorios = responseList
                    .Where(x => !string.IsNullOrEmpty(x.Language) && x.Language.Equals("C#", StringComparison.OrdinalIgnoreCase))
                    .OrderBy(x => x.CreatedAt).ToList();

                if (repositorios.Count == 0)
                {
                    return null;

                }
                return repositorios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
