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
    },{
        name: 'Error',
        path: '/error',
        component: () => import('./views/ErrorViews.vue')
    },{
        name: 'CreateProfile',
        path: '/create',
        component: () => import('./views/CreateProfileViews.vue')
    },{
        name: 'Settings',
        path: '/settings',
        component: () => import('./views/SettingsViews.vue')
    },{
        name: 'CreatePost',
        path: '/createPost',
        component: () => import('./views/CreatePostViews.vue')
    },{
        name: 'Complaint',
        path: '/complaint',
        component: () => import('./views/ComplaintViews.vue')
    },
    {
        name: 'Search',
        path: '/search',
        component: () => import('./views/SearchViews.vue')
    }]
});

createApp(App)
    .use(router)
    .mount('#app')
