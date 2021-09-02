import { createRouter, createWebHistory } from "vue-router"
import Home from "../views/Home.vue"
import Tickets from "../views/Tickets.vue"
import TicketDetailsView from "../views/TicketDetailsView.vue"

const routes = [
    {
        path: "/",
        component: Home
    },
    {
        path: "/tickets",
        component: Tickets
    },
    {
        path: "/ticket/:id",
        component: TicketDetailsView,
        props: route =>  ({
            id: route.params.id,
            edit: false
        })
    },
    {
        path: "/ticket/:id/edit",
        component: TicketDetailsView,
        props: route =>  ({
            id: route.params.id,
            edit: true
        })
    }
]

export default createRouter({
    history: createWebHistory(),
    routes
})