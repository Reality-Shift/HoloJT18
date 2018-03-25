// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue';
import BootstrapVue from 'bootstrap-vue';
import VueResource from 'vue-resource';
import VueSession from 'vue-session';
import Vuelidate from 'vuelidate';
import App from './App';
import router from './router';

Vue.prototype.$apihost = 'http://192.168.137.145/';

Vue.use(BootstrapVue);
Vue.use(VueResource);
Vue.use(VueSession);
Vue.use(Vuelidate);

Vue.http.headers.common['Content-Type'] = 'application/x-www-form-urlencoded';
Vue.http.headers.common['Access-Control-Allow-Origin'] = '*';
Vue.http.headers.common['Accept'] = 'pplication/x-www-form-urlencoded, application/json, text/plain, */*';
Vue.http.headers.common['Access-Control-Allow-Headers'] = 'Origin, Accept, Content-Type, Authorization, Access-Control-Allow-Origin';

Vue.config.productionTip = false;

Vue.mixin({
  data() {
    return {
      get projectName() {
        return 'Gallium';
      },
    };
  },
});

router.beforeEach((to, from, next) => {
  for (var i = 0; i < router.options.routes.length; ++i) {
    const route = router.options.routes[i];

    if (to.matched[0].path === route.path && route.secure) {
      if (!router.app.$session.has('shopName')) {
        router.app.$session.destroy();
        return next('/register');
      }
    }
  }

  next();
});

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  components: {
    App,
  },
  template: '<App/>',
});
