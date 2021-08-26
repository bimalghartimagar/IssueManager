<template>
    <TicketListItem v-for="(ticket, i) in list" :key="i" :ticket="ticket" />
</template>

<script setup>
import TicketListItem from "./TicketListItem.vue";
defineProps({
    list: {
        type: Array,
        default: () => ([])
    }
})
</script>