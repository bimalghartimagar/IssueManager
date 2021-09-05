using System;
using System.Net.Http;
using System.Collections.Generic;
using IssueManager.Domain.Model;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace IssueManager.ThirdParty.Api.Interface
{
    public class TicketService : ITicketService
    {
        static readonly string API_ENDPOINT = "https://605a5f9327f0050017c04d9c.mockapi.io/api/v1";

        readonly HttpClient client = new HttpClient { BaseAddress = new Uri(API_ENDPOINT) };

        public async Task<List<Ticket>> GetTickets()
        {
            return await client.GetFromJsonAsync<List<Ticket>>("/ticket");
        }

        public async Task<Ticket> GetTicket(int id)
        {
            return await client.GetFromJsonAsync<Ticket>($"/ticket/{id}");
        }

        public async Task<List<Ticket>> SearchTickets(string searchText)
        {
            return await client.GetFromJsonAsync<List<Ticket>>($"/ticket?search={searchText}");
        }

        public async Task<Ticket> UpdateTicket(Ticket ticket)
        {
            var response = await client.PutAsJsonAsync<Ticket>($"/ticket/{ticket.Id}", ticket);
            return await response.Content.ReadFromJsonAsync<Ticket>();
        }
        public async Task<Ticket> CreateTicket(Ticket ticket)
        {
            var response = await client.PostAsJsonAsync<Ticket>($"/ticket", ticket);
            return await response.Content.ReadFromJsonAsync<Ticket>();
        }

        public async Task<Ticket> RestoreTicket(Ticket ticket)
        {
            ticket.IsDeleted = false;
            var response = await client.PutAsJsonAsync<Ticket>($"/ticket/{ticket.Id}", ticket);
            return await response.Content.ReadFromJsonAsync<Ticket>();
        }
    }
}
