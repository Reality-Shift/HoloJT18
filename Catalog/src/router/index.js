import Vue from 'vue';
import Router from 'vue-router';

import MainPage from '@/components/MainPage';
import InfoPage from '@/components/InfoPage';
import ShopPage from '@/components/ShopPage';
import LoginPage from '@/components/LoginPage';

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: '/',
      component: MainPage,
    },
    {
      path: '/info',
      component: InfoPage,
    },
    {
      path: '/shop',
      component: ShopPage,
    },
    {
      path: '/login',
      component: LoginPage,
    },
  ],
});
