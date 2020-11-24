using System;
using NUnit.Framework;
using RestSharp;
using Newtonsoft.Json;
using System.Net;
using SpringRestApiTest.APIContext;
using SpringRestApiTest.Resources;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowSample.Steps
{
    [Binding]
    public class UsersTestSteps
    {

        APIClient apiClient;
        private IRestResponse response;
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

        }

        [Then(@"The service should successfully create a user")]
        public void ThenTheServiceShouldSuccessfullyCreateAUser()
        {
            assertResponse();
        }

        [When(@"User requests to delete a user with userId as (.*)")]
        public void WhenUserRequestsToDeleteAUserWithUserNameAs(int userId)
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
