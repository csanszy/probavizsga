import { createRouter, createWebHistory } from 'vue-router'

const routes = [
  { path: '/', component: () => import("../pages/HomePage.vue") },
  { path: '/todolist', component: () => import("../pages/listpages/TodoList.vue") },
  { path: '/userlist', component: () => import("../pages/listpages/UserList.vue") },
  { path: '/todocreate', component: () => import("../pages/createpages/TodoCreate.vue") },
  { path: '/usercreate', component: () => import("../pages/createpages/UserCreate.vue") },
]


const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
})

export default router
