<!-- This will be replaced by router view component -->
<template>
    <div class="z-10 shadow-2xl bg-white absolute rounded p-3 border-indigo-500 border" >
        <div class="text-xl font-bold text-left p-2">Ticket search list for <span class="text-indigo-500">{{searchText}}</span></div>
        
        <div v-if="list.length > 0" class="overflow-y-auto h-96">
            <TicketList :list="list" />
        </div>
        <span class="text-xl"><slot></slot></span>
    </div>
</template>

<script setup>
import TicketList from "./TicketList.vue"
defineProps({
    list: {
        type: Array,
        default: () => ([])
    },
    searchText: {
        type: String,
        required: true
    }
})
</script>