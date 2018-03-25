<template>
  <div class="container-full" :style="{ backgroundImage: `url('${backgroundImage}')` }">
    <div id="top-container" class="d-flex flex-column justify-content-start align-items-stretch">
      <div class="dark">
        <nav-menu hidebuttons="true"/>
      </div>

      <div class="dark" id="buttons-container">
        <div class="col-md-6 col-sm-12 col-lg-6 col-md-offset-3">
          <div class="panel panel-primary">
            <div class="panel-body">
              <b-form @submit="onSubmit">
                <b-form-group class="text-danger" label="Shop Name" label-for="shopName">
                  <b-form-input id="shopName" type="text"
                    v-model="shopName"
                    :state="!$v.shopName.$invalid"
                    aria-describedby="shopName-input-feedback"
                    placeholder="Enter shop name" />
                </b-form-group>

                <b-form-group class="text-danger" label="Password" label-for="password">
                  <b-form-input id="password" type="password"
                    v-model="password"
                    :state="!$v.password.$invalid"
                    aria-describedby="password-input-feedback"
                    placeholder="Enter password" />
                </b-form-group>

                <div class="container">
                  <div class="row">
                    <b-button type="submit" variant="danger" class="col-md-3" :disabled="$v.$invalid">Submit</b-button><br>
                    <router-link to="/register" class="btn btn-link text-danger">I don't have account</router-link>
                  </div>
                </div>
              </b-form>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import NavMenu from "./NavMenu";
import backgroundImage from "@/assets/background.jpg";

import { validationMixin } from "vuelidate";
import { required, minLength, email } from "vuelidate/lib/validators";

export default {
  data() {
    return {
      backgroundImage,
      shopName: this.shopName,
      password: this.password
    };
  },
  mixins: [validationMixin],
  validations: {
    shopName: {
      required,
      minLength: minLength(1)
    },
    password: {
      required,
      minLength: minLength(8)
    }
  },
  methods: {
    onSubmit() {
      this.$session.set('shopName', this.shopName);
      this.$router.replace('/shop');
    }
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

#buttons-container {
  width: 100%;
  height: 100%;

  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}
</style>
