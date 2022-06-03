using System;
using System.Collections.Generic;
using FluentAssertions;
using IssueManager.Application.Dtos;
using IssueManager.Application.Interfaces;
using IssueManager.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace IssueManager.Tests
{
    public class TicketControllerTests
    {
        private readonly Mock<ITicketService> serviceStub = new();
        private readonly Random rand = new();
        private readonly string[] StatusArray = new string[]
        {
            "Openend",
            "Assigned",
            "Closed"
        };

        [Fact]
        public void GetTicket_WithNonExistingTicket_ReturnsNotFound()
        {
            // Arrrange
            serviceStub.Setup(service => service.GetTicketAsync(It.IsAny<int>()))
                .ReturnsAsync((TicketDto)null);

            var controller = new TicketController(serviceStub.Object);

            // Act
            var result = controller.GetTicketAsync(int.MaxValue);

            // Assert
            result.Result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public void GetTicket_WithExistingTicket_ReturnsExpectedTicket()
        {
            // Arrange
            var expectedTicket = CreateRandomTicket();
            serviceStub.Setup(service => service.GetTicketAsync(It.IsAny<int>()))
                .ReturnsAsync(expectedTicket);
            var controller = new TicketController(serviceStub.Object);

            // Act
            var result = controller.GetTicketAsync(int.MaxValue);

            // Assert
            result.Result.Value.Should().BeEquivalentTo(expectedTicket,
                options => options.ComparingByMembers<TicketDto>());
        }

        [Fact]
        public void GetTickets_WithExistingTickets_RetunsAllTickets()
        {
            //Arrange
            var expectedTickets = new List<TicketDto>()
            {
                CreateRandomTicket(),
                CreateRandomTicket(),
                CreateRandomTicket(),
                CreateRandomTicket()
            };

            serviceStub.Setup(service => service.GetTicketsAsync())
                .ReturnsAsync(expectedTickets);

            var controller = new TicketController(serviceStub.Object);

            // Act
            var actualResult = controller.GetTicketsAsync();

            // Assert
            actualResult.Result.Should().BeEquivalentTo(expectedTickets, options => options.ComparingByMembers<TicketDto>());

        }

        [Fact]
        public void CreateTicket_WithValidData_ReturnsNewTicket(){
            // Arrange
            var NewTicket = new CreateTicketDto()
            {
                Title = "TDD Ticket Creation Test 1",
                Description = "TDD Ticket 1 Description"
            };
            TicketDto expecteCreatedTicket = new() {
                Title = NewTicket.Title,
                Description = NewTicket.Description,
            };
            serviceStub.Setup(service => service.CreateTicketAsync(It.IsAny<CreateTicketDto>()))
                .ReturnsAsync(expecteCreatedTicket);
            var controller = new TicketController(serviceStub.Object);

            //Act
            var result = controller.CreateTicketAsync(NewTicket);

            //Assert
            var createdItem = (result.Result.Result as CreatedAtActionResult).Value as TicketDto;
            NewTicket.Should().BeEquivalentTo(
                createdItem,
                option => option.ComparingByMembers<TicketDto>().ExcludingMissingMembers()
            );
            createdItem.Id.Should().NotBe(null);
            // createdItem.CreatedAt.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(1));
        }

        [Fact]
        public void UpdateTicket_WithNewDetails_ReturnsTicketWithUpdatedDetails(){
            // Arrange
            var existingItem = CreateRandomTicket();
            serviceStub.Setup(service => service.GetTicketAsync(It.IsAny<int>()))
                .ReturnsAsync(existingItem);

            var ticketId = existingItem.Id;
            var ticketToUpdate = new UpdateTicketDto()
            {
                Title = "Updated Title",
                Description = "Updated Description"
            };

            var expectedItem = new TicketDto()
            {
                Id = existingItem.Id,
                Title = ticketToUpdate.Title,
                Description = ticketToUpdate.Description,
                CreatedAt = existingItem.CreatedAt,
                Status = existingItem.Status,
                Attachments = existingItem.Attachments,
                IsDeleted = existingItem.IsDeleted,
                UpdatedAt = existingItem.UpdatedAt
            };

            serviceStub.Setup(service => service.UpdateTicketAsync(It.IsAny<int>(),It.IsAny<UpdateTicketDto>()))
                .ReturnsAsync(expectedItem);

            var controller = new TicketController(serviceStub.Object);

            // Act
            var result = controller.UpdateTicketAsync(ticketId, ticketToUpdate);

            // Assert
            result.Result.Should().BeEquivalentTo(
                expectedItem,
                option => option.ComparingByMembers<TicketDto>()
                    .ExcludingMissingMembers()
            );
        }

        [Fact]
        public void DeleteTicket_IfExists_ReturnsNoContent(){
            // Arrange
            var existingItem = CreateRandomTicket();
            serviceStub.Setup(service => service.GetTicketAsync(It.IsAny<int>()))
                .ReturnsAsync(existingItem);

            var ticketId = existingItem.Id;
            var ticketToUpdate = new UpdateTicketDto()
            {
                Title = "Updated Title",
                Description = "Updated Description"
            };

            var expectedItem = new TicketDto()
            {
                Id = existingItem.Id,
                Title = ticketToUpdate.Title,
                Description = ticketToUpdate.Description,
                CreatedAt = existingItem.CreatedAt,
                Status = existingItem.Status,
                Attachments = existingItem.Attachments,
                IsDeleted = existingItem.IsDeleted,
                UpdatedAt = existingItem.UpdatedAt
            };

            serviceStub.Setup(service => service.UpdateTicketAsync(It.IsAny<int>(),It.IsAny<UpdateTicketDto>()))
                .ReturnsAsync(expectedItem);

            var controller = new TicketController(serviceStub.Object);

            // Act
            var result = controller.UpdateTicketAsync(ticketId, ticketToUpdate);

            // Assert
            result.Result.Should().BeEquivalentTo(
                expectedItem,
                option => option.ComparingByMembers<TicketDto>()
                    .ExcludingMissingMembers()
            );
        }

        #region Helper Methods
        private TicketDto CreateRandomTicket()
        {
            return new TicketDto()
            {
                Id = rand.Next(),
                Title = $"Ticket {rand.Next()}",
                Status = StatusArray[rand.Next(0, 3)],
                Description = $"Test Description {rand.Next()}"
            };
        }
        #endregion
    }
}
