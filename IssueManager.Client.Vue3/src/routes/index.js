import { createRouter, createWebHistory } from "vue-router"
import Home from "../views/Home.vue"
import Tickets from "../views/Tickets.vue"
import TicketDetails from "../views/TicketDetails.vue"

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
        component: TicketDetails,
        props: true
    }
]

export default createRouter({
    history: createWebHistory(),
    routes
})