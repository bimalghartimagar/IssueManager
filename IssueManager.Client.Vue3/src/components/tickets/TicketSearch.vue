<template>
    <input
        @keyup.stop.prevent.enter="delaySearch"
        v-model="searchText"
        class="p-3 w-full border border-gray-500 rounded-lg"
        type="text"
        placeholder="Search"
        @keyup.stop.prevent.delete="hideSearchResult"
    />
    <TicketSearchListWrapper
        v-show="showSearchResult"
        :list="searchResult"
        :search-text="searchText"
    >
        <span class="text-xl">{{ searchingText }}</span>
    </TicketSearchListWrapper>
</template>

<script setup>
import { ref } from "@vue/reactivity";
import utils from "../../utils/index.js"
import service from "../../service/TicketService.js"
import TicketSearchListWrapper from "./TicketSearchListWrapper.vue";

let searchText = ref("")
let searchResult = ref([])
let showSearchResult = ref(false)
let searchingText = ref("Searching...")

const delaySearch = utils.debounce(() => processSearch(), 500)

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
</script>