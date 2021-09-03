<template>
    <div @click="modalOpen = true">
        <slot name="button"></slot>
    </div>
    <teleport to="body">
        <div v-if="modalOpen" class="modal absolute top-1/2 left-1/2">
            <div class="modal-title bg-indigo-500 p-2 text-white text-lg">
                <slot name="title">Title</slot>
            </div>
            <div class="modal-body bg-white p-2 text-lg">
                <slot name="body">Body</slot>
            </div>
            <div class="px-2 bg-white flex items-center justify-end">
                <button class="bg-red-600 text-white p-2 px-3 rounded" @click="confirmAction">Yes</button>
                <button
                    class="bg-indigo-500 text-white p-2 m-2 px-3 rounded"
                    @click="modalOpen = false"
                >No</button>
            </div>
        </div>
    </teleport>
</template>

<script setup>import { ref } from "@vue/reactivity";

const emit = defineEmits(["approve"])
let modalOpen = ref(false)
function confirmAction() {
    emit('approve')
    modalOpen.value = false
}
</script>

<style>
.modal {
    transform: translate(-50%, -50%);
}
</style>