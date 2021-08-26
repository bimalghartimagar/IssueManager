<template>
    <div
        class="p-2 m-2 border border-indigo-500 rounded-md flex flex-row justify-between items-center cursor-pointer hover:bg-indigo-400 hover:text-white"
    >
        <div class="flex-grow">{{ title }}</div>
        <div class="text-xs flex-grow-0 mr-2">Created 10 minutes ago</div>
        <div class="bg-green-500 rounded-lg text-white px-4 py-1 text-sm flex-grow-0">Opened</div>
    </div>
</template>

<script setup>
defineProps({
    title: {
        type: String,
        required: true
    }
})
</script>