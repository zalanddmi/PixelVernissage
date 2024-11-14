import './assets/main.css'

import { createRouter, createWebHistory } from 'vue-router'
import { createApp } from 'vue'
import App from './App.vue'

const router = createRouter({
    history: createWebHistory(),
    routes: [{
        name: 'Home',
        path: '/',
        component: () => import('./views/HomeViews.vue')
    },{
        name: 'Cart',
        path: '/cart',
        component: () => import('./components/postCard.vue')
    }]
});

createApp(App)
    .use(router)
    .mount('#app')
