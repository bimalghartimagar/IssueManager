<template>
    <div v-for="i in 10">
        <TicketListItem :key="i" :title="'name'+i"/>
    </div>
</template>

<script setup>
import TicketListItem from "./TicketListItem.vue";
</script>