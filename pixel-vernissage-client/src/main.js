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
    },{
        name: 'Profile',
        path: '/profile',
        component: () => import('./views/ProfileViews.vue')
    },{
        name: 'PicturePage',
        path: '/picture',
        component: () => import('./views/PictureViews.vue')
    }]
});

createApp(App)
    .use(router)
    .mount('#app')
