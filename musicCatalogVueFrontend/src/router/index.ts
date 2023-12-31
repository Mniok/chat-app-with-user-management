import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import HomeView from '../views/HomeView.vue'
//import RegisterView from '../views/RegisterView.vue'

Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/login',
    name: 'login',
    component: HomeView
  },
  {
    path: '/about',
    name: 'about',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/AboutView.vue')
  },
  {
    path: '/register',
    name: 'register',
    component: () => import('../views/RegisterView.vue')
  },
  {
    path: '/app',
    name: 'appview',
    component: () => import('../views/AppView.vue')
  },
  {
    path: '/settings',
    name: 'settings',
    component: () => import('../views/SettingsView.vue') // not used at all
  },
  {
    path: '/song/:id',  //$route.params.id
    name: 'song',
    component: () => import('../views/SongView.vue') // ! not used in this project
  },
  {
    path: '/upload',
    name: 'upload',
    component: () => import('../views/UploadSongView.vue') /// ! not used in this project
  },
  {
    path: '/manage',
    name: 'manage',
    component: () => import('../views/ManageUsersView.vue')
  },
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
