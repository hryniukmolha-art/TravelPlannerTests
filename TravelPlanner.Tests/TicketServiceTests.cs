
using System;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace TravelPlanner.Tests;

public class TicketServiceTests
{
    [Fact]
    public async Task AssignAsync_ValidAssignee_SavesTicketOnce()
    {
        // Arrange
        var repository = new Mock<ITicketRepository>();
        var service = new TicketService(repository.Object);

        var ticket = new Ticket
        {
            Id = 1,
            Title = "Спланувати маршрут"
        };

        string assignee = "Іван";

        // Act
        await service.AssignAsync(ticket, assignee);

        // Assert
        Assert.Equal("Іван", ticket.Assignee);

        repository.Verify(
            r => r.SaveAsync(ticket),
            Times.Once);
    }

    [Fact]
    public void IsDeadlineValid_TicketDeadlineAfterStage_ReturnsFalse()
    {
        // Arrange
        var ticketDeadline = new DateTime(2026, 12, 20);
        var stageDeadline = new DateTime(2026, 12, 15);

        // Act
        bool result = DeadlineValidator.IsDeadlineValid(
            ticketDeadline, stageDeadline);

        // Assert
        Assert.False(result);
    }
}
