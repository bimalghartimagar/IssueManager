<template>
  <DashboardLayout class="bg-gray-200">
    <WidgetList :data="widgetData"/>
    <TicketListWrapper :list="ticketList"/>
  </DashboardLayout>
</template>

<script setup>
import { ref } from "@vue/reactivity";
import { onMounted } from "@vue/runtime-core";

import service from "./service/TicketService.js"

import DashboardLayout from './components/layout/DashboardLayout.vue'
import TicketListWrapper from './components/tickets/TicketListWrapper.vue';
import WidgetList from './components/widgets/WidgetList.vue';

const ticketList = ref([]);

const widgetData = ref({
  open: 0,
  assigned: 0,
  closed: 0
})

onMounted(async () => {
    ticketList.value = await service.getTickets().then(response => response.json())
    ticketList.value.reduce((acc, item) => {
      if(item.status === "open"){
        widgetData.value.open++
      }else if(item.status === "assigned"){
        widgetData.value.assigned++
      }else if(item.status === "closed"){
        widgetData.value.closed++
      }
    }, widgetData.value)
})

</script>

<style>
/* css debug */
/* * {
  outline: solid 0.25rem red;
} */

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
</style>
