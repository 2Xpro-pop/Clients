using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using RestSharp;

namespace Bll.Rest;
public class RestAuth : IAuthClient
{
    private readonly MementoMoriApi _api;

    public RestAuth(MementoMoriApi api)
    {
        _api = api;
    }

    public async Task CreateUserAsync(string login, string password, string role, int branchOfficeId)
    {
        var rest = new RestRequest(_api.CreateUser).AddJsonBody(new
        {
            login,
            password,
            role,
            branchOfficeId
        });

        await _api.RestClient.PostAsync(rest);
    }

    public async Task<JwtResponse> GetAccessToken(string refreshToken)
    {
        var rest = new RestRequest(_api.GetAccessToken + "/" + refreshToken);

        return await _api.RestClient.PostAsync<JwtResponse>(rest);
    }
    public async Task<JwtResponse> LoginAsync(string login, string password)
    {
        var rest = new RestRequest($"{_api.Login}/{login}/{password}");

        return await _api.RestClient.GetAsync<JwtResponse>(rest);
    }
}
