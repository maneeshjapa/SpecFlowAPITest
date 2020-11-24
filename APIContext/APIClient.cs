using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using SpringRestApiTest.Resources;
using System;
using System.Collections.Generic;
using System.Net;
namespace SpringRestApiTest.APIContext

{
    class APIClient
    {

        RestClient client = new RestClient();
        RestRequest request;
        IRestResponse response;

        public APIClient()
        {
            client.BaseUrl = new Uri("https://springboottodorestapi.herokuapp.com/");
        }

        public IRestResponse getUsers()
        {
            request = new RestRequest("api/v1/users", Method.GET);
            return response = client.Execute(request);
        }

        public IRestResponse createUser(User userData)
        {
            request = new RestRequest("api/v1/users", Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddJsonBody(JsonConvert.SerializeObject(userData));
            Console.WriteLine(request);
            return response = client.Execute(request);
        }

        public IRestResponse deleteUser(int userId)
        {
            request = new RestRequest("api/v1/users/{userId}", Method.DELETE);
            request.AddParameter("userId", userId, ParameterType.UrlSegment);
            return response = client.Execute(request);
        }
    }
}