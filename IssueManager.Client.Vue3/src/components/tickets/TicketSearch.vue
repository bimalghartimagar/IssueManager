<template>
    <div v-click-outside>
        <input
            @keyup.stop.prevent.enter="search"
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
    </div>
</template>

<script setup>
import { ref } from "@vue/reactivity";
import TicketSearchListWrapper from "./TicketSearchListWrapper.vue";
import useSearchTickets from "../../containers/useSearchTickets.js"

let searchText = ref("")

let {
    searchResult,
    showSearchResult,
    searchingText,
    search,
    hideSearchResult
} = useSearchTickets(searchText)

</script>