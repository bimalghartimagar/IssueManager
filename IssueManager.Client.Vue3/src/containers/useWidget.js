import { computed, ref } from "@vue/reactivity";
import { defineAsyncComponent } from '@vue/runtime-core'

export default function useWidget() {
    let data = ref({
        open: {
            count: 0,
            selected: false
        },
        assigned: {
            count: 0,
            selected: false
        },
        closed: {
            count: 0,
            selected: false
        }
    })

    function updateData(dataName, dataObj) {
        data.value[dataName] = dataObj
    }

    let selectedData = computed(() => {
        return Object.keys(data.value).filter(x => {
            return data.value[x]['selected']
        })
    })

    return {
        data,
        updateData,
        selectedData
    }
}