<template>
  <div class="container-full">
    <div class="dark">
      <nav-menu/>
    </div>

    <div class="container" style="margin-top: 20px;">
      <div class="row">
        <div class="col-md-8">
            <div id="preview"></div>
        </div>
        <div class="col-md-4">
          <div class="row mt-3">Create Item</div>
          <div class="row mt-3 text-danger">
            <b-form-input v-model="itemName" :state="!$v.itemName.$invalid" placeholder="Item name"></b-form-input>
          </div>
          <div class="row mt-3">
            <b-form-file v-model="modelFile" :state="Boolean(modelFile)" accept=".obj" placeholder="Select model..." v-on:change="modelFileChanged"></b-form-file>
          </div>
          <div class="row mt-3">
            <b-form-file v-model="textureFile" :state="Boolean(textureFile)" accept=".jpg, .png" placeholder="Select texture..." v-on:change="textureFileChanged"></b-form-file>
          </div>
          <div class="row mt-3 row justify-content-between">
            <b-button variant="danger" :disabled="$v.$invalid && !this.saved" v-on:click="submitForm()" class="col-5">Submit</b-button>
            <router-link to="/shop" class="btn btn-outline-secondary col-5">Cancel</router-link>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import NavMenu from "./NavMenu";

import * as THREE from "three";
import OBJLoader from "@/assets/OBJLoader";
import meshUrl from "@/assets/OBJLoader.js";

import { validationMixin } from "vuelidate";
import { required, minLength } from "vuelidate/lib/validators";

export default {
  data() {
    return {
      itemName: this.itemName,
      modelFile: this.modelFile,
      textureFile: this.textureFile,
      saved: this.saved
    };
  },
  mixins: [validationMixin],
  validations: {
    itemName: {
      required,
      minLength: minLength(1)
    },
    modelFile: {
      required
    },
    textureFile: {
      required
    }
  },
  methods: {
    init() {
      var container = document.getElementById("preview");

      this.camera = new THREE.PerspectiveCamera(
        60,
        container.clientWidth / container.clientHeight,
        0.01,
        1000
      );

      var scene = new THREE.Scene();
      this.scene = scene;

      this.renderer = new THREE.WebGLRenderer({ antialias: true, alpha: true });
      this.renderer.setSize(container.clientWidth, container.clientHeight);
      container.appendChild(this.renderer.domElement);
    },
    initModel() {
      if (this.object) {
        this.scene.remove(this.object);
      }

      const self = this;

      var loader = new THREE.TextureLoader();
      loader.load(self.textureFileData, texture => {
        const objLoader = new OBJLoader();
        objLoader.load(
          this.modelFileData,
          object => {
            self.object = object;
            const meshMaterial = new THREE.MeshBasicMaterial({
              map: texture
            });
            for (var i = 0; i < self.object.children.length; ++i) {
              self.object.children[i].material = meshMaterial;
            }

            const bbox = new THREE.Box3().setFromObject(self.object);

            const distance = new THREE.Vector3(0, 0, 0);
            distance.x = Math.max(Math.abs(bbox.min.x), Math.abs(bbox.max.x));
            distance.y = Math.max(Math.abs(bbox.min.y), Math.abs(bbox.max.y));
            distance.z = Math.max(Math.abs(bbox.min.z), Math.abs(bbox.max.z));

            self.camera.position.y = distance.length() * 1.1;
            self.camera.position.z = distance.length() * 1.1;
            self.camera.lookAt(
              new THREE.Vector3(
                (bbox.min.x + bbox.max.x) * 0.5,
                (bbox.min.y + bbox.max.y) * 0.5,
                (bbox.min.z + bbox.max.z) * 0.5
              )
            );

            self.scene.add(self.object);
          },
          undefined,
          err => {
            console.error("An error happened.");
          }
        );
      });
    },
    animate() {
      requestAnimationFrame(this.animate);
      this.renderer.render(this.scene, this.camera);
    },
    modelFileChanged(e) {
      var files = e.target.files;

      const self = this;

      for (var i = 0, f; (f = files[i]); i++) {
        var reader = new FileReader();

        reader.onload = (function(theFile) {
          return function(e) {
            self.modelFileData = e.target.result;

            if (self.textureFileData != null && self.modelFileData != null) {
              self.initModel();
            }
          };
        })(f);

        reader.readAsText(f);
      }
    },
    textureFileChanged(e) {
      var files = e.target.files;

      const self = this;

      for (var i = 0, f; (f = files[i]); i++) {
        var reader = new FileReader();

        reader.onload = (function(theFile) {
          return function(e) {
            self.textureFileData = e.target.result;

            if (self.textureFileData != null && self.modelFileData != null) {
              self.initModel();
            }
          };
        })(f);

        reader.readAsDataURL(f);
      }
    },
    submitForm() {
      this.saved = true;

      const formData = new FormData();
      formData.append("customer_id", "Ivanov");
      formData.append('common02', escape(this.$session.get('shopName')));
      formData.append("common03", this.itemName);
      formData.append("obj", this.modelFile, this.modelFile.name);
      formData.append("texture", this.textureFile, this.textureFile.name);

      this.$http
        .post(this.$apihost + "api/work", formData)
        .then(response => {
          this.$router.replace("/shop");
          console.log(response);
        })
        .catch(error => {
          this.saved = false;
          console.log(error);
        });
    }
  },
  mounted() {
    this.saved = false;
    this.init();
    this.animate();
  },
  components: {
    NavMenu
  }
};
</script>

<style scoped>
#preview {
  min-height: 400px;
  width: 100%;
  border: 1px solid #6c757d;
  margin-bottom: 75px;
}
</style>