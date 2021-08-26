<template>
    <div
        class="px-2 py-4 m-2 border border-indigo-500 rounded-md flex flex-row justify-between items-center cursor-pointer hover:bg-indigo-400 hover:text-white"
    >
        <div class="flex-grow text-left">{{ ticket.title }}</div>
        <div class="text-xs flex-grow-0 mr-2">Created 10 minutes ago</div>
        <div
            class="rounded-lg text-white px-4 py-1 text-sm flex-grow-0 capitalize" :class="getStatusColor(ticket.status)"
        >{{ ticket.status }}</div>
    </div>
</template>

<script setup>
defineProps({
    ticket: {
        type: Object,
        required: true
    }
})
function getStatusColor(status) {
    if (status === "open") {
        return "bg-yellow-500"
    } else if (status === "assigned") {
        return "bg-green-500"
    } else if (status === "closed") {
        return "bg-red-500"
    }
}
</script>