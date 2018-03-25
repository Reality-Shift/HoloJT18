import Vue from 'vue';
import Router from 'vue-router';

import MainPage from '@/components/MainPage';
import InfoPage from '@/components/InfoPage';
import ShopPage from '@/components/ShopPage';
import LoginPage from '@/components/LoginPage';
import RegisterPage from '@/components/RegisterPage';
import ItemEditorPage from '@/components/ItemEditorPage';

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
      secure: true,
      component: ShopPage,
    },
    {
      path: '/editor',
      secure: true,
      component: ItemEditorPage,
    },
    {
      path: '/login',
      component: LoginPage,
    },
    {
      path: '/register',
      component: RegisterPage,
    },
  ],
});
