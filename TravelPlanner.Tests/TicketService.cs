
using System;
using System.Threading.Tasks;

namespace TravelPlanner.Tests;

public class Ticket
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string? Assignee { get; set; }
}

public interface ITicketRepository
{
    Task SaveAsync(Ticket ticket);
}

public class TicketService
{
    private readonly ITicketRepository _repository;

    public TicketService(ITicketRepository repository)
    {
        _repository = repository;
    }

    public async Task AssignAsync(Ticket ticket, string assignee)
    {
        if (string.IsNullOrWhiteSpace(assignee))
        {
            throw new ArgumentException(
                "Виконавець не може бути порожнім.");
        }

        ticket.Assignee = assignee;
        await _repository.SaveAsync(ticket);
    }
}
