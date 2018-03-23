<template>
  <header class="catalog-header py-3">
    <div class="row nomargin flex-nowrap justify-content-between align-items-center">
      <div class="col-4 pt-1">
        <a class="text-muted" href="/"><h3>@projectName</h3></a>
      </div>
      <div class="col-4 d-flex justify-content-end align-items-center">
        <router-link class="btn btn-sm btn-link text-danger" to="/login" id="signin">Sign in</router-link>
        <router-link class="btn btn-sm btn-outline-danger" to="/login">Get started</router-link>
      </div>
    </div>
  </header>
</template>

<script>
export default {
  data() {
    return {
      projectName: this.projectName,
    }
  }
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