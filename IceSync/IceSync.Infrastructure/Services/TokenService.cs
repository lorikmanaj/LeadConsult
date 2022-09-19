using IceSync.DomainModel.Models.Configurations;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IceSync.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly string baseURL = "https://api-test.universal-loader.com/authenticate";
        private IConfiguration _configuration;
        private IMemoryCache _memoryCache;
        private HttpClient _httpClient;

        public TokenService(
            IConfiguration configuration,
            IMemoryCache memoryCache)
        {
            _configuration = configuration;
            _memoryCache = memoryCache;
            _httpClient = new HttpClient();
        }

        public async Task<string> GetToken()
        {
            var token = _memoryCache.Get<string>("token");

            if (string.IsNullOrEmpty(token) || !TokenIsValid(token))
            {
                var credentials = GetCredentials();
                var credentialsSerialized = JsonConvert.SerializeObject(credentials);
                var data = new StringContent(credentialsSerialized, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(baseURL, data);

                token = response.Content.ReadAsStringAsync().Result;
                _memoryCache.Set<string>("token", token);
            }
            return token;
        }

        public bool TokenIsValid(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return false;
            }

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);
            var tokenExp = jwt.Claims.First(claim => claim.Type.Equals("exp")).Value;
            var ticks = long.Parse(tokenExp);

            return ticks < DateTime.Now.Ticks;
        }

        private Credential GetCredentials()
        {
            var configuration = _configuration.GetSection("Credentials");
            return new Credential(configuration["apiCompanyId"], configuration["apiUserId"], configuration["apiUserSecret"]);
        }
    }
}
