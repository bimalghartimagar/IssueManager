<template>
    <div v-if="ticket" class="rounded shadow mt-8 pb-1 border border-indigo-400">
        <div
            class="w-full text-left p-4 text-xl bg-indigo-400 shadow"
        >Details of ticket #{{ ticket.id }}</div>
        <div class="grid grid-cols-3 gap-4 shadow p-3">
            <div>Created At: {{ getReadableDateTime(ticket.createdAt) }}</div>
            <div>Updated At: {{ getReadableDateTime(ticket.updatedAt) }}</div>
            <div>
                Status:
                <span
                    class="rounded-lg text-white px-4 py-1 text-sm capitalize"
                    :class="util.getStatusColor(ticket.status)"
                >{{ ticket.status }}</span>
            </div>
        </div>
        <div class="m-4 p-2 rounded shadow text-left border border-gray-400">
            <div class="p-4 font-semibold text-xl bg-gray-400">{{ ticket.title }}</div>
            <div class="p-4 m-4">{{ ticket.description }}</div>
        </div>
        <div class="text-left m-4 p-2">
            <div>Attachments:</div>
            <div class="flex flex-wrap gap-x-2">
                <img
                    v-for="attachment in ticket.attachments"
                    :src="attachment.path"
                    class="h-40 w-40 p-1 rounded shadow-lg border border-gray-400"
                />
            </div>
        </div>
    </div>
</template>

<script setup>
import { defineAsyncComponent, onMounted, ref, watch } from "@vue/runtime-core"
import TicketService from "../../service/TicketService.js"
import service from "../../service/TicketService.js"
import util from "../../utils/index.js"

const detailsComponent = defineAsyncComponent(()=>{
    if(edit){
        return import("./TicketDetails.vue")
    }else{
        return import("./TicketDetails.vue")
        return import("./TicketDetails.vue")
    }
})

const props = defineProps({
    id: {
        type: String,
        required: true
    },
    edit: {
        type: Boolean,
        required: true
    }
})

let ticket = ref({})

watch(() => props.id, async (val, prevVal) => {
    if (val !== prevVal) {
        ticket.value = await service.getTicket(props.id).then(response => response.json())
    }
})

onMounted(async () => {
    ticket.value = await service.getTicket(props.id).then(response => response.json())
})

function getReadableDateTime(dateTimeString) {
    let date = new Date(dateTimeString)
    var options = { year: 'numeric', month: 'long', day: 'numeric', hour: 'numeric', minute: 'numeric' };

    return date.toLocaleDateString("en-US", options)
}

</script>