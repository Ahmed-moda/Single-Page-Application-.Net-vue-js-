import Vue from 'vue';
import VueRouter from 'vue-router';

Vue.use(VueRouter);

const routes = [
  {
    path: '/',
    name: 'home',
    component: () => import('H:/.Net and Vue/vue js/project/my-project/src/components/HomeForm.vue'),
    meta: { requiresAuth: true },
  },
  {
    path: '/Register',
    name: 'Register',
    component: () => import('H:/.Net and Vue/vue js/project/my-project/src/components/RegisterForm.vue'),
  },{
    path: '/Login',
    name: 'Login',
    component: () => import('H:/.Net and Vue/vue js/project/my-project/src/components/LoginForm.vue'),
  },
  {
    path: '/Create',
    name: 'Create',
    component: () => import('H:/.Net and Vue/vue js/project/my-project/src/components/AddBook.vue'),
  }
];

// router.beforeEach((to, from, next) => {
//   var token=localStorage.getItem("Token");
//   var isAuthenticated=false;
//   if(token!=null&&token!=""){
//      isAuthenticated =true ;
//   }
  

//   if (to.matched.some((record) => record.meta.requiresAuth)) {
//     if (!isAuthenticated) {
//       next({
//         path: "/Login",
//         query: { redirect: to.fullPath },
//       });
//     } else {
//       next();
//     }
//   } else {
//     next();
//   }
// });



const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes,
});
router.beforeEach((to, from, next) => {
  const token = localStorage.getItem('Token')
    // If logged in, or going to the Login page.
    if (token || to.name === 'Login'||to.name=="Register") {
      // Continue to page.
      next()
    } else {
      // Not logged in, redirect to login.
      next({name: 'Login'})
    }
  }
);
export default router;