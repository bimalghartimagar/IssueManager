using System.Collections.Generic;
using System.Threading.Tasks;
using IssueManager.Application.Dtos;
using IssueManager.Domain.Model;

namespace IssueManager.Application.Interfaces{
    public interface ITicketService{
        Task<IEnumerable<TicketDto>> GetTicketsAsync();
        Task<TicketDto> GetTicketAsync(int id);
        Task<TicketDto> CreateTicketAsync(CreateTicketDto createTicketDto);
        Task<TicketDto> UpdateTicketAsync(int id, UpdateTicketDto updateTicketDto);
        Task DeleteTicketAsync(int id);
    }
}