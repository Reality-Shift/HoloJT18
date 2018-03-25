<template>
  <header class="catalog-header py-3">
    <div class="row nomargin flex-nowrap justify-content-between align-items-center">
      <div class="col-4 pt-1">
        <a class="text-muted" href="/"><h4>@placeit</h4></a>
      </div>
      <div class="col-4 d-flex justify-content-end align-items-center" v-if="!hide_buttons && !authorized">
        <router-link class="btn btn-sm btn-link text-danger" to="/login" id="signin">Sign in</router-link>
        <router-link class="btn btn-sm btn-outline-danger" to="/register">Get started</router-link>
      </div>
      <div class="col-4 d-flex justify-content-end align-items-center" v-if="!hide_buttons && authorized">
        <button class="btn btn-sm btn-outline-danger" v-on:click="exitShop()">Exit from <b>{{shopName}}</b></button>
      </div>
    </div>
  </header>
</template>

<script>
export default {
  data() {
    return {
      projectName: this.projectName,
      hide_buttons: this.hidebuttons == "true",
      authorized: this.$session.has('shopName'),
      shopName: this.$session.get('shopName')
    }
  },
  methods: {
    exitShop() {
      this.$session.destroy();
      this.$router.replace('/');
    }
  },
  props: ["hidebuttons"],
};
</script>

<style>
.catalog-header {
  width: 100%;
}

.catalog-header > row {
  padding-left: 10px;
  padding-right: 10px;
}
</style>