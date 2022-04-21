<template>
    <WidgetList :data="data" @select="updateData" />
    <Spinner class="w-6 mx-auto mt-8" v-if="loading" />
    <TicketListWrapper v-else :list="filterList" />
</template>

<script setup>
import { computed, ref } from "@vue/reactivity";
import { onMounted } from "@vue/runtime-core";

import service from "../service/TicketService.js"

import TicketListWrapper from '../components/tickets/TicketListWrapper.vue';
import WidgetList from '../components/widgets/WidgetList.vue';
import Spinner from "../components/Spinner.vue";
import useWidget from "../containers/useWidget.js"

let ticketList = ref([]);

let loading = ref(true);

let {
    data,
    updateData,
    selectedData
} = useWidget()

let filterList = computed(() => {
    if (selectedData.value.length === 0) {
        return ticketList.value
    }
    return ticketList.value.filter(x => selectedData.value.includes(x.status.name))
})

onMounted(async () => {
    ticketList.value = await service.getTickets().then(response => response.json())
    ticketList.value.reduce((acc, item) => {
        if (item.status.name === "open") {
            data.value.open.count++
        } else if (item.status.name === "assigned") {
            data.value.assigned.count++
        } else if (item.status.name === "closed") {
            data.value.closed.count++
        }
    }, data)
    loading.value = false
})
</script>