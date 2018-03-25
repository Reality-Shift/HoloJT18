<template>
  <tr class="goods-list-item">
    <td>
      <div :id="`preview-${itemid}`" style="width: 200px; height: 100px;"></div>
    </td>
    <td>
      {{this.name}}
    </td>
    <td>
      <div class="btn btn-outline-danger pull-right" v-on:click="deleteItem">Remove</div>
      <button class="btn btn-outline-primary pull-right" v-on:click="requestItem">Request</button>
    </td>
  </tr>
</template>

<script>
import * as THREE from "three";
import OBJLoader from "@/assets/OBJLoader";
import meshUrl from "@/assets/OBJLoader.js";

export default {
  name: "GoodsListItem",
  data() {
    return {};
  },
  props: ["name", "itemid"],
  methods: {
    init() {
      var container = document.getElementById("preview-" + this.itemid);

      this.camera = new THREE.PerspectiveCamera(
        60,
        container.clientWidth / container.clientHeight,
        0.01,
        1000
      );

      var scene = new THREE.Scene();
      this.scene = scene;

      const modelurl = this.$apihost + "api/models/obj/" + this.itemid;
      const textureurl = this.$apihost + "api/models/texture/" + this.itemid;

      const self = this;

      this.$http
        .get(modelurl)
        .then(modelData => {
          var loader = new THREE.TextureLoader();

          loader.load(textureurl, function(texture) {
            const objLoader = new OBJLoader();
            objLoader.load(
              modelData.body,
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
                distance.x = Math.max(
                  Math.abs(bbox.min.x),
                  Math.abs(bbox.max.x)
                );
                distance.y = Math.max(
                  Math.abs(bbox.min.y),
                  Math.abs(bbox.max.y)
                );
                distance.z = Math.max(
                  Math.abs(bbox.min.z),
                  Math.abs(bbox.max.z)
                );
                self.camera.position.x = (bbox.min.x + bbox.max.x) * 0.5 + distance.length() * 0.9;
                self.camera.position.y = (bbox.min.y + bbox.max.y) * 0.5 + distance.length() * 0.9;
                self.camera.position.z = (bbox.min.z + bbox.max.z) * 0.5 + distance.length() * 0.9;
                self.camera.lookAt(
                  new THREE.Vector3(
                    (bbox.min.x + bbox.max.x) * 0.5,
                    (bbox.min.y + bbox.max.y) * 0.5,
                    (bbox.min.z + bbox.max.z) * 0.5
                  )
                );

                scene.add(self.object);
              },
              undefined,
              function(err) {
                console.error("An error happened.");
              }
            );
          });
        })
        .catch(error => {});

      this.renderer = new THREE.WebGLRenderer({ antialias: true, alpha: true });
      this.renderer.setSize(container.clientWidth, container.clientHeight);
      container.appendChild(this.renderer.domElement);
    },
    animate() {
      requestAnimationFrame(this.animate);
      if (this.object) {
        this.object.rotateY(0.005);
      }
      this.renderer.render(this.scene, this.camera);
    },
    deleteItem() {
      this.$emit("on-delete", this.itemid);
      this.$http
        .delete(this.$apihost + "api/work?common02=" + escape(this.$session.get('shopName')) + '&common03=' + this.name)
        .then(response => {})
        .catch(err => {});
    },
    requestItem() {
      this.$http.post(this.$apihost + 'api/want/' + this.itemid).then(response => {
        console.log(response);
      }).catch(error => {
      });
    }
  },
  mounted() {
    this.init();
    this.animate();
  }
};
</script>

<style scoped>
.goods-list-item {
  min-height: 100px;
}

#preview {
  display: inline-block;
}
</style>
