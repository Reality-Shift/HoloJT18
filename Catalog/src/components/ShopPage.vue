<template>
    <div class="container-full">
      <div class="dark">
        <nav-menu/>
      </div>

      <div class="container">
        <div class="col-md-10">
          <div class="goods-list">
            <goods-list-item meshUrl="./assets/bunny.obj" />
            <goods-list-item />
          </div>
        </div>
        <div class="col-md-2">

        </div>
      </div>
    </div>
</template>

<script>
import NavMenu from "./NavMenu";
import GoodsListItem from "./GoodsListItem";

export default {
  name: "shop",
  data() {
    return {};
  },
  components: {
    NavMenu,
    GoodsListItem,
  }
};
</script>

<style scoped>

</style>