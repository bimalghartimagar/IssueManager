<template>
    <Spinner  class="w-6 mx-auto mt-8" v-if="loading"/>
    <TicketListWrapper v-else :list="ticketList" />
</template>


<script setup>
import { ref } from "@vue/reactivity";
import { onMounted } from "@vue/runtime-core";

import service from "../service/TicketService.js"

import TicketListWrapper from '../components/tickets/TicketListWrapper.vue';
import Spinner from "../components/Spinner.vue";

let ticketList = ref([]);
let loading = ref(true);

onMounted(async () => {
    ticketList.value = await service.getTickets().then(response => response.json())
    loading.value = false
})
</script>