<template>
    <div v-if="ticket" class="rounded shadow mt-8 pb-1 border border-indigo-400">
        <div class="w-full text-left p-4 text-xl bg-indigo-400 shadow">
            Details of ticket #{{ ticket.id }}
            <button
                @click="saveTicket"
                class="float-right rounded px-2 pt-1 bg-white shadow-xl hover:shadow-none hover:bg-indigo-500 hover:text-white"
            >Save</button>
            <span class="float-right text-white mr-2">{{ updateMsg }}</span>
        </div>
        <div class="grid grid-cols-3 gap-4 shadow p-3">
            <div>Created At: {{ getReadableDateTime(ticket.createdAt) }}</div>
            <div>Updated At: {{ getReadableDateTime(ticket.updatedAt) }}</div>
            <div>
                Status:
                <select v-model="ticket.status" class="p-1 rounded">
                    <option
                        v-for="data in StatusData"
                        :value="data.value"
                        :class="util.getStatusColor(data.value)"
                    >{{ data.name }}</option>
                </select>
            </div>
        </div>
        <div class="m-4 p-2 rounded shadow text-left border border-gray-400">
            <div class="p-4 font-semibold text-xl bg-gray-400">
                <input v-model="ticket.title" class="p-2 w-full border rounded" />
            </div>
            <div class="p-4 m-4">
                <textarea v-model="ticket.description" class="w-full h-60 p-1 rounded"></textarea>
            </div>
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
import { onMounted, ref, watch } from "@vue/runtime-core"
import TicketService from "../../service/TicketService.js"
import service from "../../service/TicketService.js"
import util from "../../utils/index.js"

const StatusData = [
    { value: "open", name: "Open" },
    { value: "assigned", name: "Assigned" },
    { value: "closed", name: "Closed" }
]

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
let updateMsg = ref("")

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

async function saveTicket() {
    let response = await TicketService.updateTicket(ticket.value, props.id)
        .then(res => {
            if (res.status === 200) {
                return res.json()
            } else {
                throw new Error("Error while updating ticket details")
            }
        })
        .then(data => updateMsg.value = "Updated ticket details")
        .catch(err => updateMsg.value = err)
}

</script>