using ApplicationLayer.Dto_s;
using DomainLayer.Enums;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PurchaseRequest.IntegrationTests
{
    public class PurchaseRequestControllerTests
      : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public PurchaseRequestControllerTests(
            WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreatePurchases_ShouldReturnRejected_WhenBudgetIsExceeded()
        {
            // Arrange
            var request = new SavePurchasesDTO
            {
                Amount = 6000,
                Department = Department.Technology,
                EmployeeSeniority = 5,
                PurchaseType = PurchaseType.Software,
                AvailableBudget = 5000
            };

            // Act
            var response = await _client.PostAsJsonAsync(
                "/PurchaseRequest",
                request);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);


            var result = await response.Content.ReadFromJsonAsync<OperationResultDTO>(
               new JsonSerializerOptions
               {
                   PropertyNameCaseInsensitive = true,
                   Converters =
                   {
                     new JsonStringEnumConverter()
                   }
               });

            Assert.NotNull(result);

            Assert.Equal(
                Results.Rejected,
                result.Status);
        }

        [Fact]
        public async Task CreatePurchases_ShouldReturnBadRequest_WhenAmountIsNegative()
        {
            // Arrange
            var request = new SavePurchasesDTO
            {
                Amount = -100,
                Department = Department.Technology,
                EmployeeSeniority = 5,
                PurchaseType = PurchaseType.Software,
                AvailableBudget = 5000
            };

            // Act
            var response = await _client.PostAsJsonAsync(
                "/PurchaseRequest",
                request);

            // Assert
            Assert.Equal(
                HttpStatusCode.BadRequest,
                response.StatusCode);
        }

        [Fact]
        public async Task CreatePurchases_ShouldReturnApproved_WhenAllRullPassed()
        {
            // Arrange
            var request = new SavePurchasesDTO
            {
                Amount = 4100,
                Department = Department.Technology,
                EmployeeSeniority = 3,
                PurchaseType = PurchaseType.Software,
                AvailableBudget = 5000
            };

            // Act
            var response = await _client.PostAsJsonAsync(
                "/PurchaseRequest",
                request);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);


            var result = await response.Content.ReadFromJsonAsync<OperationResultDTO>(
               new JsonSerializerOptions
               {
                   PropertyNameCaseInsensitive = true,
                   Converters =
                   {
                     new JsonStringEnumConverter()
                   }
               });

            Assert.NotNull(result);

            Assert.Equal(
                Results.Approved,
                result.Status);
        }

       
        
    }
}
