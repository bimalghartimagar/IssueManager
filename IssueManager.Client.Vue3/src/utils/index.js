export default {
    getStatusColor: (status) => {
        if (status === "open") {
            return "bg-yellow-500"
        } else if (status === "assigned") {
            return "bg-green-500"
        } else if (status === "closed") {
            return "bg-red-500"
        }
    }
}