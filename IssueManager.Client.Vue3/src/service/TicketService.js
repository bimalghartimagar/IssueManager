const API_ENDPOINT = "https://605a5f9327f0050017c04d9c.mockapi.io/api/v1"
export default {
    getTickets: async function () {
        return await fetch(`${API_ENDPOINT}/ticket`)
    },
    getTicket: async (id) => {
        return await fetch(`${API_ENDPOINT}/ticket/${id}`)
    }
}