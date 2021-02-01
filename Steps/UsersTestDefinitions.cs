using System;
using NUnit.Framework;
using RestSharp;
using Newtonsoft.Json;
using System.Net;
using SpringRestApiTest.APIContext;
using SpringRestApiTest.Resources;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Newtonsoft.Json.Linq;

namespace SpecFlowSample.Steps
{
    [Binding]
    public class UsersTestSteps
    {

        APIClient apiClient;
        private IRestResponse response;
        JObject responseBody;
        int userId;
        [Given(@"User access the api")]
        public void GivenUserAccessTheApi()
        {
            apiClient = new APIClient();
        }

        public void assertResponse()
        {
            Console.WriteLine(JsonConvert.SerializeObject(response.Content, Formatting.Indented));
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        
        [When(@"User requests to view all users")]
        public void WhenUserRequestsToViewAllUsers()
        {
            response = apiClient.getUsers();
        }
        
        [Then(@"The service returns list of all users")]
        public void ThenTheServiceReturnsListOfAllUsers()
        {
            assertResponse();
        }

        [When(@"User requests to create a user with details")]
        public void WhenUserRequestsToCreateAUserWithDetails(Table table)
        {
            response = apiClient.createUser(table.CreateInstance<User>());
            responseBody = JObject.Parse(response.Content);
            userId = (int)responseBody.GetValue("userId");
        }

        [Then(@"The service should successfully create a user")]
        public void ThenTheServiceShouldSuccessfullyCreateAUser()
        {
            //assertResponse();
            Assert.Fail("Test Failure");
        }

        [When(@"User requests to delete the created user with userId")]
        public void WhenUserRequestsToDeleteTheCreatedUserWithUserId()
        {
            response = apiClient.deleteUser(userId);
        }

        [Then(@"The Service should successfully delete the user")]
        public void ThenTheServiceShouldSuccessfullyDeleteTheUser()
        {
            assertResponse();
        }
    }
}
