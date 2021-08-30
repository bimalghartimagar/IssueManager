import { ref } from "@vue/reactivity"
import utils from "../../utils/index.js"
import service from "../../service/TicketService.js"

export default function useSearchTickets(searchText) {
    let searchResult = ref([])
    let showSearchResult = ref(false)
    let searchingText = ref("Searching...")

    const search = utils.debounce(() => processSearch(), 500)

    function hideSearchResult() {
        if (searchText.value.trim().length == 0) {
            showSearchResult.value = false
        } else {
            showSearchResult.value = true
        }
    }

    async function processSearch() {
        searchResult.value = []
        searchingText.value = "Searching..."
        hideSearchResult()
        searchResult.value = await service.searchTicket(searchText.value.trim()).then(response => response.json())
        if (searchResult.value.length == 0) {
            searchingText.value = "No results found"
        } else {
            searchingText.value = `${searchResult.value.length} results found`
        }
    }
    return {
        searchResult,
        showSearchResult,
        searchingText,
        search,
        hideSearchResult
    }
}