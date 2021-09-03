<template>
    <div
        v-if="Object.keys(ticket).length > 0"
        class="rounded shadow mt-8 pb-1 border border-indigo-400"
    >
        <div
            class="flex items-center justify-between w-full text-left p-4 text-xl shadow text-white"
            :class="ticket.isDeleted ? 'bg-red-500' : 'bg-indigo-400'"
        >
            Details of ticket #{{ ticket.id }}
            <div v-if="ticket.isDeleted" class="bg-red-500 p-2 rounded">This ticket is deleted.</div>
            <Modal v-if="!ticket.isDeleted" @approve="DeleteTicket">
                <template v-slot:button>
                    <button
                        class="flex flex-row items-center float-right rounded px-2 py-1 bg-red-500 shadow-xl hover:shadow-none text-white hover:bg-red-600"
                    >
                        <TrashIcon class="mr-1 w-5 h-5" />
                        <span>Delete</span>
                    </button>
                </template>
                <template v-slot:title>Delete ticket</template>
                <template v-slot:body>Are you sure you want to delete the ticket?</template>
            </Modal>

            <button
                v-if="ticket.isDeleted"
                @click="RestoreTicket"
                class="flex flex-row items-center float-right rounded px-2 py-1 bg-green-500 shadow-xl hover:shadow-none text-white hover:bg-green-600"
            >
                <RefreshIcon class="mr-1 w-5 h-5" />
                <span>Restore</span>
            </button>
        </div>
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
import service from "../../service/TicketService.js"
import util from "../../utils/index.js"
import { TrashIcon, RefreshIcon } from "@heroicons/vue/outline"
import Modal from "../shared/Modal.vue"
import TicketService from "../../service/TicketService.js"
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
        fetchTicketData()
    }
})

async function fetchTicketData() {
    ticket.value = await service.getTicket(props.id).then(response => response.json())
}

onMounted(async () => {
    await fetchTicketData()
})

function getReadableDateTime(dateTimeString) {
    let date = new Date(dateTimeString)
    var options = { year: 'numeric', month: 'long', day: 'numeric', hour: 'numeric', minute: 'numeric' };

    return date.toLocaleDateString("en-US", options)
}

function DeleteTicket() {
    TicketService.deleteTicket(props.id).then(res => res.json()).then(async () => await fetchTicketData())
}

function RestoreTicket() {
    TicketService.restoreTicket(props.id).then(res => res.json()).then(async () => await fetchTicketData())
}

</script>