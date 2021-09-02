<template>
    <component :is="view" v-bind="{ ...props }"></component>
</template>

<script setup>
import { computed, defineAsyncComponent } from "@vue/runtime-core";

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

const view = computed(() => {
    return props.edit ? defineAsyncComponent(() =>
        import('../components/tickets/TicketDetailsEdit.vue')
    ) : defineAsyncComponent(() =>
        import('../components/tickets/TicketDetails.vue')
    )
})
</script>