<template>
    <div class="grid grid-cols-6">
        <div class="sidebar bg-indigo-500 text-white">
            <Sidebar />
        </div>
        <div class="main col-span-5 h-screen">
            <div class="heading">
                <SearchBar />
            </div>
            <div class="content">
                <slot></slot>
            </div>
        </div>
    </div>
</template>

<script>
import Sidebar from "./Sidebar.vue"
import SearchBar from "./SearchBar.vue"
export default {
    components: {
        Sidebar,
        SearchBar
    }
}
</script>