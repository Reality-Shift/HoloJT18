<template>
  <div class="container-full">
    <div class="dark">
      <nav-menu/>
    </div>

    <div class="container" style="margin-top: 20px;">
      <div class="row">
        <div class="col-10">
          <table width="100%" class="table">
            <thead>
              <td>Preview</td>
              <td>Name</td>
              <td>Actions</td>
            </thead>
            <tbody>
              <tr is="goods-list-item" v-for="item in items" 
                v-bind:key="item.item_id"
                v-bind:itemid="item.item_id"
                v-bind:shopName="item.common02"
                v-bind:name="item.common03"
                @on-delete="onItemDelete">
                </tr>
            </tbody>
          </table>
        </div>
        <div class="col-2">
          <router-link to="/editor" class="btn btn-danger">Add new</router-link>
        </div>
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
    return {
      items: this.items
    };
  },
  mounted() {
    this.items = [];
    this.$http
      .get(
        this.$apihost +
          "api/work?common02=" +
          escape(this.$session.get("shopName"))
      )
      .then(response => {
        
        if (response.body.results != null) {
          const results = response.body.results.filter(
            (item, index, self) =>
              index === self.findIndex(t => t.common03 === item.common03)
          );
          this.items = results;
        } else {
          this.items = [];
        }
      });
  },
  methods: {
    onItemDelete(itemid) {
      for (var i = 0; i < this.items.length; ++i) {
        if (this.items[i].item_id == itemid) {
          this.items.splice(i, 1);
        }
      }
    }
  },
  components: {
    NavMenu,
    GoodsListItem
  }
};
</script>

<style scoped>

</style>