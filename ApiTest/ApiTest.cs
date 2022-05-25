using ApiTest.Models;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using Xunit;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ApiTest
{
    public class ApiTest
    {
        const string contentType = "application/json; charset=utf-8";
        [Fact]
        public void StatusCodeTest()
        {
            //Arange
            RestClient client = new RestClient("https://jsonplaceholder.typicode.com");
            RestRequest request = new RestRequest("posts", Method.GET);

            //Act
            IRestResponse response = client.Execute(request);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }
        [Fact]
        public void ContentTypeTest()
        {
            //Arange
            RestClient client = new RestClient("https://jsonplaceholder.typicode.com");
            RestRequest request = new RestRequest("posts", Method.GET);

            //Act
            IRestResponse response = client.Execute(request);
            JToken content = JToken.Parse(response.Content);

            //Assert
            Assert.NotEmpty(response.Content);
            Assert.Equal(contentType, response.ContentType);
        }
        [Theory]
        [InlineData("photos", HttpStatusCode.OK)]
        [InlineData("comments", HttpStatusCode.OK)]
        public void StatusCodeWithSetOfData(string status, HttpStatusCode expectedresult)
        {
            //Arange
            RestClient client = new RestClient("https://jsonplaceholder.typicode.com");
            RestRequest request = new RestRequest($"{status}", Method.GET);

            //Act
            IRestResponse response = client.Execute(request);

            //Assert
            Assert.Equal(expectedresult, response.StatusCode);
        }
       
        [Theory]
        [InlineData("photos", contentType)]
        [InlineData("comments", contentType)]
        public void ContentTypeTestCategory(string category, string contentTypeExpectedResult)
        {
            //Arange
            RestClient client = new RestClient("https://jsonplaceholder.typicode.com");
            RestRequest request = new RestRequest($"{category}", Method.GET);

            //Act
            IRestResponse response = client.Execute(request);
            JToken content = JToken.Parse(response.Content);
            
            //Assert
            Assert.NotEmpty(response.Content);
            Assert.Equal(contentTypeExpectedResult, response.ContentType);
        }
        [Fact]
        public void ContentTypeTest2()
        {
            //Arange
            RestClient client = new RestClient("https://jsonplaceholder.typicode.com");
            RestRequest request = new RestRequest("comments?postId=1", Method.GET);

            //Act
            IRestResponse response = client.Execute(request);
            JToken content = JToken.Parse(response.Content);
           
            //Assert
            Assert.NotEmpty(response.Content);
            Assert.Equal(contentType, response.ContentType);
        }

        [Fact]
        public void Check_number_of_comments()
        {
            //Arange
            RestClient client = new RestClient("https://jsonplaceholder.typicode.com");
            RestRequest request = new RestRequest("comments?postId=1", Method.GET);

            //Act
            IRestResponse response = client.Execute(request);
            JToken content = JToken.Parse(response.Content);
            
            //Assert
            Assert.NotEmpty(response.Content);
            List<CommentModel> comments = JsonConvert.DeserializeObject<List<CommentModel>>(response.Content);
            
            Assert.Equal(5, comments.Count);

        }

    }
}