<template>
    <router-link :to="`/ticket/${ticket.id}`">
        <div
            class="px-2 py-4 m-2 border border-indigo-500 rounded-md flex flex-row justify-between items-center cursor-pointer hover:bg-indigo-400 hover:text-white"
        >
            <div class="flex-grow text-left">{{ ticket.title }}</div>
            <div class="text-xs flex-grow-0 mr-2">Created 10 minutes ago</div>
            <div
                class="rounded-lg text-white px-4 py-1 text-sm flex-grow-0 capitalize"
                :class="util.getStatusColor(ticket.status)"
            >{{ ticket.status }}</div>
        </div>
    </router-link>
</template>

<script setup>
import util from "../../utils/index.js"
defineProps({
    ticket: {
        type: Object,
        required: true
    }
})

</script>