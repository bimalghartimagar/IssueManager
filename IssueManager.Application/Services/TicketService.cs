using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IssueManager.Application.Dtos;
using IssueManager.Application.Extensions;
using IssueManager.Application.Interfaces;
using IssueManager.Domain.Interfaces;
using IssueManager.Domain.Model;
namespace IssueManager.Application.Services
{
    public class TicketService : ITicketService
    {
        public IBaseRepository<Ticket> _ticketRepository;
        public TicketService(IBaseRepository<Ticket> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        public async Task<IEnumerable<TicketDto>> GetTicketsAsync()
        {
            var tickets = await _ticketRepository.GetItemsAsync();

            return tickets.Select(ticket => ticket.AsDto()).ToList();
        }

        public async Task<TicketDto> GetTicketAsync(int id){
            Ticket ticket = await _ticketRepository.GetItemAsync(id);

            if(ticket is null){
                return null;
            }

            return ticket.AsDto();
        }

        public async Task<TicketDto> CreateTicketAsync(CreateTicketDto createTicketDto)
        {
            Ticket ticket = new()
            {
                Title = createTicketDto.Title,
                Description = createTicketDto.Description,
            };
            return (await _ticketRepository.CreateItemAsync(ticket)).AsDto();
        }

        public async Task<TicketDto> UpdateTicketAsync(int id, UpdateTicketDto updateTicketDto)
        {
            Ticket existingTicket = await _ticketRepository.GetItemAsync(id);

            if(existingTicket is null){
                return null;
            }

            existingTicket.Title = updateTicketDto.Title;
            existingTicket.Description = updateTicketDto.Description;
            existingTicket.IsDeleted = updateTicketDto.IsDeleted;
            existingTicket.UpdatedAt = DateTime.Now;

            return (await _ticketRepository.UpdateItemAsync(existingTicket)).AsDto();
        }

        public async Task DeleteTicketAsync(int id) {
            await _ticketRepository.DeleteItemAsync(id);
        }
    }
}