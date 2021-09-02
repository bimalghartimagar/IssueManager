<template>
    <div v-if="ticket" class="rounded shadow mt-8 pb-1 border border-indigo-400">
        <div class="w-full text-left p-4 text-xl bg-indigo-400 shadow">
            Details of ticket #{{ ticket.id }}
            <button
                @click="saveTicket"
                class="flex flex-row items-center float-right rounded px-2 pt-1 bg-white shadow-xl hover:shadow-none hover:bg-indigo-500 hover:text-white"
                :class="isUpdating ? 'disabled:opacity-50' : ''"
            >
                <svg
                    v-show="isUpdating"
                    class="mr-1 h-5 w-5 hover:text-white"
                    xmlns="http://www.w3.org/2000/svg"
                    fill="none"
                    viewBox="0 0 24 24"
                >
                    <circle
                        class="opacity-25"
                        cx="12"
                        cy="12"
                        r="10"
                        stroke="currentColor"
                        stroke-width="4"
                    />
                    <path
                        class="opacity-75"
                        fill="currentColor"
                        d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"
                    />
                </svg>
                <SaveIcon v-show="!isUpdating" class="mr-1 w-5 h-5" />
                <span>Save</span>
            </button>
            <span class="float-right text-white mr-2">{{ updateMsg }}</span>
        </div>
        <div class="grid grid-cols-3 gap-4 shadow p-3">
            <div>Created At: {{ getReadableDateTime(ticket.createdAt) }}</div>
            <div>Updated At: {{ getReadableDateTime(ticket.updatedAt) }}</div>
            <div class="flex flex-row">
                <div class="mr-1">Status:</div>
                <select v-model="ticket.status" class="p-1 rounded border border-black">
                    <option
                        v-for="data in StatusData"
                        :value="data.value"
                        :class="util.getStatusColor(data.value)"
                    >{{ data.name }}</option>
                </select>
            </div>
        </div>
        <div class="m-4 p-2 rounded shadow text-left border border-gray-400">
            <div class="text-xl font-bold">Title:</div>
            <div class="p-4 font-semibold text-xl bg-gray-400">
                <input v-model="ticket.title" class="p-2 w-full rounded border border-black" />
            </div>
            <div class="p-4 m-4">
                <div class="text-xl font-bold">Description:</div>
                <textarea
                    v-model="ticket.description"
                    class="w-full h-60 p-1 rounded border border-black"
                ></textarea>
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
import { SaveIcon } from "@heroicons/vue/outline"
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
let isUpdating = ref(false)

watch(() => props.id, async (val, prevVal) => {
    if (val !== prevVal) {
        await fetchTicketData()
    }
})

async function fetchTicketData() {
    isUpdating.value = true
    ticket.value = await service.getTicket(props.id).then(response => response.json()).finally(() => isUpdating.value = false)
}

onMounted(async () => {
    await fetchTicketData()
})

function getReadableDateTime(dateTimeString) {
    let date = new Date(dateTimeString)
    var options = { year: 'numeric', month: 'long', day: 'numeric', hour: 'numeric', minute: 'numeric' };

    return date.toLocaleDateString("en-US", options)
}

async function saveTicket() {
    isUpdating.value = true
    let response = await TicketService.updateTicket({ ...ticket.value, updatedAt: (new Date).toISOString() }, props.id)
        .then(res => {
            if (res.status === 200) {
                return res.json()
            } else {
                throw new Error("Error while updating ticket details")
            }
        })
        .then(async data => await fetchTicketData())
        .then(() => updateMsg.value = "Updated ticket details")
        .catch(err => updateMsg.value = err)
        .finally(() => isUpdating.value = false)
}

</script>