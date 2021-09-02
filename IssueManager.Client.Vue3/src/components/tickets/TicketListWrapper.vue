<!-- This will be replaced by router view component -->
<template>
    <div class="mt-8 text-xl font-bold text-left p-2 mb-1">
        <span>Tickets</span>
        <router-link to="/ticket/create">
            <button class="bg-indigo-500 text-white px-2 py-1 rounded float-right">Create Ticket</button>
        </router-link>
    </div>
    <div class="overflow-y-auto h-96 border border-gray-200 shadow bg-white rounded p-2">
        <TicketList :list="list" />
    </div>
</template>

<script setup>
import TicketList from "./TicketList.vue"
defineProps({
    list: {
        type: Array,
        default: () => ([])
    }
})
</script>