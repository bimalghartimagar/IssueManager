<!-- This will be replaced by router view component -->
<template>
    <div class="mt-8 text-xl font-bold text-left p-2">Tickets</div>
    <div class="overflow-y-auto h-96 border border-gray-200 shadow bg-white rounded p-2">
        <TicketList :list="ticketList" />
    </div>
</template>

<script setup>
import TicketList from "./TicketList.vue"
import service from "../../service/TicketService.js"
import { ref } from "@vue/reactivity";
import { onMounted } from "@vue/runtime-core";

const ticketList = ref([]);

onMounted(async () => {
    ticketList.value = await service.getTickets().then(response => response.json())
})
</script>