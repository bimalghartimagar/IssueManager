<template>
    <WidgetList :data="widgetData" />
    <Spinner  class="w-6 mx-auto mt-8" v-if="loading"/>
    <TicketListWrapper v-else :list="ticketList" />
</template>

<script setup>
import { ref } from "@vue/reactivity";
import { onMounted } from "@vue/runtime-core";

import service from "../service/TicketService.js"

import TicketListWrapper from '../components/tickets/TicketListWrapper.vue';
import WidgetList from '../components/widgets/WidgetList.vue';
import Spinner from "../components/Spinner.vue";

let ticketList = ref([]);
let loading = ref(true);
let widgetData = ref({
    open: 0,
    assigned: 0,
    closed: 0
})

onMounted(async () => {
    ticketList.value = await service.getTickets().then(response => response.json())
    ticketList.value.reduce((acc, item) => {
        if (item.status === "open") {
            widgetData.value.open++
        } else if (item.status === "assigned") {
            widgetData.value.assigned++
        } else if (item.status === "closed") {
            widgetData.value.closed++
        }
    }, widgetData)
    loading.value = false
})
</script>