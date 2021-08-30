export default {
    created(el, binding, vnode, prevNode) {
        document.getElementById("app").addEventListener('click', event => {

            function isOutside() {
                return (el.lastElementChild.style.hasOwnProperty("display")
                    && el.lastElementChild.style.display !== "none") && !el.contains(event.target)
            }

            function isInsideAndTicketItem() {
                let isTicket = false
                let itr = event.target.classList.values()
                let classNameResult = itr.next()
                while (!classNameResult.done) {
                    if ((/^ticket/).test(classNameResult.value)) {
                        isTicket = true
                        break
                    }
                    classNameResult = itr.next()
                }
                return isTicket
            }

            if (isOutside() || isInsideAndTicketItem()) {
                binding.instance.showSearchResult = false
            }
        })
    },
}