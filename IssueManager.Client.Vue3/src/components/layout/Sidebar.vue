<template>
    <div class="felx flex-col font-sans">
        <div class="head-title p-10 text-3xl font-bold">Ticket Manager</div>
        <router-link to="/"  custom v-slot="{isActive, navigate}">
            <div :class="isActive?'border-white bg-indigo-600':'border-indigo-500'" @click="navigate" class="p-3 m-0 text-xl cursor-pointer border-l-8 hover:bg-indigo-400">Home</div>
        </router-link>
        <router-link to="/tickets" custom v-slot="{isActive, navigate}">
            <div :class="isActive?'border-white bg-indigo-600':'border-indigo-500'" @click="navigate"
                class="p-3 m-0 text-xl cursor-pointer border-l-8 hover:bg-indigo-400"
            >Tickets</div>
        </router-link>
    </div>
</template>