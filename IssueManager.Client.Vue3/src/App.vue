<template>
  <DashboardLayout>
    <TicketListWrapper />
  </DashboardLayout>
</template>

<script setup>
import DashboardLayout from './components/layout/DashboardLayout.vue'
import TicketListWrapper from './components/tickets/TicketListWrapper.vue';
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
