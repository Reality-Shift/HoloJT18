<template>
  <div class="container-full" :style="{ backgroundImage: `url('${backgroundImage}')` }">
    <div id="top-container" class="d-flex flex-column justify-content-start align-items-stretch">
      <div class="dark">
        <nav-menu/>
      </div>
      <div id="body-container">
          <div class="container">
              <div class="row" style="width: 100%">
                <link rel="stylesheet" href="//maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css">
                <div class="col-md-7" id="empty-space" :style="{ backgroundImage: `url('${chairImage}')` }">
                </div>
                <div class="col-md-5 d-flex flex-column justify-content-center align-items-start">
                    <h2>@placeit <small class="text-muted">is</small></h2>
                    <ul>
                      <li>Ability for customers to try on goods in AR before buying</li>
                      <li>A service which helps online stores to simplify logistics</li>
                      <li>Add-on API interface for Minikura</li>
                    </ul>
                    <hr>
                    <a href="#" class="btn btn-app-store pull-right"><i class="fa fa-apple"></i> <span class="small pull-left">Download soon on</span><br><span class="big">App Store</span></a>
                    <a href="#" class="btn btn-app-store"><i class="fa fa-windows"></i> <span class="small pull-left">Get it soon from</span><br><span class="big">Windows Store</span></a>
                  </div>
              </div>
          </div>
      </div>
    </div>
  </div>
</template>

<script>
import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";
import backgroundImage from "@/assets/background.jpg";
import chairImage from "@/assets/chair.png";
import NavMenu from "./NavMenu";

export default {
  name: "Main",
  data() {
    return {
      backgroundImage,
      chairImage
    };
  },
  components: {
    NavMenu
  }
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

#body-container {
  width: 100%;
  height: 100%;

  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;

  background-color: white;
}

#body-container a {
  margin: 10px;
}

#body-container router-link {
  color: #2c3e50;
  font-size: 20px;
  text-decoration: none;
  display: inline;
}

#customer-button {
  padding: 10px;
}

#empty-space {
  background-repeat: no-repeat;
  
  background-position: left bottom;
}

.btn-app-store {
  background: black;
  color: white;
  position: relative;
  height: 60px;
  padding-left: 55px;
  padding-right: 20px;
}
.btn-app-store i {
  font-size: 40px;
  position: absolute;
  left: 10px;
}
.btn-app-store .small {
  display: block;
  font-size: 12px;
  line-height: 12px;
  margin-bottom: 2px;
  margin-top: 5px;
}
.btn-app-store .big {
  display: block;
  text-align: left;
  font-size: 21px;
  line-height: 21px;
}
</style>
