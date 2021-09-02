<template>
    <div v-if="ticket" class="rounded shadow mt-8 pb-1 border border-indigo-400">
        <div class="w-full text-left p-4 text-xl bg-indigo-400 shadow">Create a new ticket</div>
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
            <div class="flex flex-row p-4 m-4">
                <div class="mr-1">Status:</div>
                <select v-model="ticket.status" class="p-1 rounded border border-black">
                    <option
                        v-for="data in StatusData"
                        :value="data.value"
                        :class="util.getStatusColor(data.value)"
                    >{{ data.name }}</option>
                </select>
            </div>
            <div class="text-left p-4 m-4">
                <button
                    @click.capture.prevent="createTicket"
                    class="flex flex-row items-center rounded px-2 py-1 hover:bg-white shadow-none bg-indigo-500 text-white hover:text-indigo-500"
                    :class="isAdding ? 'disabled:opacity-50 cursor-not-allowed' : ''"
                    :disabled="isAdding"
                >
                    <svg
                        v-show="isAdding"
                        class="animate-spin mr-1 h-5 w-5 hover:text-white"
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
                    <PlusCircleIcon v-show="!isAdding" class="mr-1 w-5 h-5" />
                    <span>Create</span>
                </button>
                <span class="text-white mr-2 text-lg" :class="responseMsgClasses">{{ responseMsg }}</span>
                <span v-show="isAdded">
                    <span
                        @click="GotoTicket"
                        class="underline text-indigo-500 cursor-pointer text-lg"
                    >Click here</span> to open the ticket
                </span>
            </div>
        </div>
    </div>
</template>

<script setup>
import { useRouter } from "vue-router"
import { ref } from "@vue/runtime-core"
import TicketService from "../service/TicketService.js"
import util from "../utils/index.js"
import { PlusCircleIcon } from "@heroicons/vue/outline"
const StatusData = [
    { value: "open", name: "Open" },
    { value: "assigned", name: "Assigned" },
    { value: "closed", name: "Closed" }
]
let router = useRouter()

let ticket = ref({
    title: "",
    description: "",
    status: "open"
})

let responseMsg = ref("")
let responseMsgClasses = ref("")
let isAdding = ref(false)
let isAdded = ref(false)
let id = ref(0)
function isFormValid() {
    return ticket.value.title.trim().length !== 0 && ticket.value.description.trim().length !== 0
}

async function createTicket() {
    if (!isFormValid()) {
        responseMsg.value = "Please fill all the details";
        responseMsgClasses.value = "text-red-500"
        return
    }
    isAdding.value = true
    isAdded.value = false
    let response = await TicketService.createTicket({ ...ticket.value, createdAt: (new Date).toISOString() })
        .then(res => {
            if (res.status === 201) {
                return res.json()
            } else {
                throw new Error("Error while adding ticket")
            }
        })
        .then(data => {
            id.value = data.id
            isAdded.value = true
            responseMsg.value = "New ticket created"
            responseMsgClasses.value = "text-green-500"
            ticket.value = {
                ...{
                    title: "",
                    description: "",
                    status: "open"
                }
            }
        })
        .catch(err => {
            responseMsg.value = err
            responseMsgClasses.value = "text-red-500"
        })
        .finally(() => isAdding.value = false)
}

function GotoTicket() {
    router.push(`/ticket/${id.value}`)
}

</script>