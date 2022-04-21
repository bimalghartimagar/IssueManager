export default {
    getStatusColor: (status) => {
        if (status == null || status == undefined || !Object.keys(status).includes('name') || status.name === "open") {
            return "bg-yellow-500 font-semibold"
        } else if (status.name === "assigned") {
            return "bg-green-500 font-semibold"
        } else if (status.name === "closed") {
            return "bg-red-500 font-semibold"
        }
    },
    debounce: (func, timeInMilliSeconds) => {
        let timer;
        return (...args) => {
            clearTimeout(timer)
            timer = setTimeout(() => {
                func.apply(this, args)
            }, timeInMilliSeconds)
        }

    }
}