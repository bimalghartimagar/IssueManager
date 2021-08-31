<template>
    <div class="grid grid-cols-3 gap-6 mt-8">
        <div
            @click="selectFilter(data, 'open')"
            class="bg-white shadow rounded py-6 flex justify-center items-center text-4xl font-semibold cursor-pointer"
            :class="data.open.selected ? 'border-2 border-indigo-500' : ''"
        >
            <ChatIcon class="h-20 w-20 text-blue-500" />
            {{ data.open.count }} Opened
        </div>

        <div
            @click="selectFilter(data, 'assigned')"
            class="bg-white shadow rounded py-6 flex justify-center items-center text-4xl font-semibold cursor-pointer"
            :class="data.assigned.selected ? 'border-2 border-indigo-500' : ''"
        >
            <CogIcon class="h-20 w-20 text-green-500" />
            {{ data.assigned.count }} Assigned
        </div>
        <div
            @click="selectFilter(data, 'closed')"
            class="bg-white shadow rounded py-6 flex justify-center items-center text-4xl font-semibold cursor-pointer"
            :class="data.closed.selected ? 'border-2 border-indigo-500' : ''"
        >
            <XCircleIcon class="h-20 w-20 text-red-500" />
            {{ data.closed.count }} Closed
        </div>
    </div>
</template>

<script setup>
import { XCircleIcon, CogIcon, ChatIcon } from '@heroicons/vue/outline'
import { defineAsyncComponent } from '@vue/runtime-core'


const chaticon = defineAsyncComponent(() => import("../Spinner.vue"))
defineProps({
    data: {
        type: Object,
        required: true
    }
})
const emit = defineEmits(['select'])

function selectFilter(data, key) {
    emit('select', key, { ...data[key], selected: !data[key].selected })
}
</script>