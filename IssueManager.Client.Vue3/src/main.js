import { createApp } from 'vue'
import App from './App.vue'
import router from "./routes/index.js"
import './index.css'
import clickOutside from "./directives/v-click-outside.js"
const app = createApp(App)

// register directives

app.directive('click-outside', clickOutside)

app.use(router)
app.mount('#app')
