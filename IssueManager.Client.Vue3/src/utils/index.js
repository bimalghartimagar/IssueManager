export default {
    getStatusColor: (status) => {
        if (status === "open") {
            return "ring ring-yellow-500 text-yellow-500 font-semibold"
        } else if (status === "assigned") {
            return "ring ring-green-500 text-green-500 font-semibold"
        } else if (status === "closed") {
            return "ring ring-red-500 text-red-500 font-semibold"
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