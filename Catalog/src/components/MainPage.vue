<template>
  <div class="container-full" :style="{ backgroundImage: `url('${backgroundImage}')` }">
    <div id="top-container" class="d-flex flex-column justify-content-start align-items-stretch">
      <div class="dark">
        <nav-menu/>
      </div>
      <div class="dark" id="buttons-container">
        <div class="btn btn-danger btn-lg"><router-link to="/info" class="text-white">I'm a customer</router-link></div>
        <div class="btn btn-link"><router-link to="/shop" class="text-white"><u>I'm a shop</u></router-link></div>
      </div>
    </div>
  </div>
</template>

<script>
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import backgroundImage from "@/assets/background.jpg";
import NavMenu from "./NavMenu";

export default {
  name: 'Main',
  data() {
    return {
      backgroundImage
    };
  },
  components: {
    NavMenu,
  },
};
</script>

<style scoped>
#top-container {
  width: 100%;
  height: 100vh;

  background-repeat: no-repeat;
  background-attachment: fixed;
  background-position: center;
}

#buttons-container {
  width: 100%;
  height: 100%;

  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}

#buttons-container div {
  margin: 10px;
}

#buttons-container router-link {
  color: #2c3e50;
  font-size: 20px;
  text-decoration: none;
  display: inline;
}

#customer-button {
  padding: 10px;
}
</style>
