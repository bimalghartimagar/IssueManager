<template>
    <router-link :to="`/ticket/${ticket.id}`">
        <div
            class="ticket-item px-2 py-4 m-2 border border-indigo-500 rounded-md flex flex-row justify-between items-center cursor-pointer hover:bg-indigo-400 hover:text-white"
        >
            <div class="ticket-title flex-grow text-left">{{ ticket.title }}</div>
            <div class="ticket-date text-xs flex-grow-0 mr-2">Created 10 minutes ago</div>
            <div
                class="ticket-status rounded-lg text-white px-4 py-1 text-sm flex-grow-0 capitalize"
                :class="util.getStatusColor(ticket.status)"
            >{{ ticket.status }}</div>
            <div class="ticket-link ml-2">
                <router-link :to="`/ticket/${ticket.id}/edit`">
                    <button
                        class="ticket-link flex flex-row items-center float-right rounded px-2 pt-1 bg-indigo-500 shadow-xl hover:shadow-none hover:bg-white hover:text-black text-white"
                    >
                        <PencilAltIcon class="ticket-link mr-1 w-5 h-5" />
                        <span class="ticket-link ">Edit</span>
                    </button>
                </router-link>
            </div>
        </div>
    </router-link>
</template>

<script setup>
import util from "../../utils/index.js"
import { PencilAltIcon } from "@heroicons/vue/outline"

defineProps({
    ticket: {
        type: Object,
        required: true
    }
})

</script>