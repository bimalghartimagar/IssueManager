﻿using System;
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

    }
}