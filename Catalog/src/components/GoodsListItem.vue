<template>
  <div class="goods-list-item">
    <div class="container">
      <div class="row">
        <div class="col-md-3" id="preview">

        </div>
        <div class="col-md-9">
          {{description}}
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import * as THREE from "three";
import OBJLoader from '@/assets/OBJLoader';
import meshUrl from "@/assets/OBJLoader.js";

export default {
  name: "GoodsListItem",
  data() {
    return {
      description: "asd"
    };
  },
  //props: ["modelUrl"],
  methods: {
    init() {
      var container = document.getElementById("preview");

      this.camera = new THREE.PerspectiveCamera(
        70,
        container.clientWidth / container.clientHeight,
        0.01,
        10
      );
      this.camera.position.z = 5;

      var scene = new THREE.Scene();
      this.scene = scene;

      const objLoader = new OBJLoader();

      const materials = [ new THREE.MeshStandardMaterial() ];
      objLoader.setMaterials( materials );
      objLoader.setPath( '' );
      objLoader.load('bunny.obj', object => {
        scene.add(object);
      });

      this.renderer = new THREE.WebGLRenderer({ antialias: true, alpha: true });
      this.renderer.setSize(container.clientWidth, container.clientHeight);
      container.appendChild(this.renderer.domElement);
    },
    animate() {
      requestAnimationFrame(this.animate);
      if (this.mesh) {
        this.mesh.rotation.y += 0.005;
      }
      this.renderer.render(this.scene, this.camera);
    },
  },
  mounted() {
    this.init();
    this.animate();
  }
};
</script>

<style scoped>
.goods-list-item {
  margin: 10px;
  border-bottom: 1px solid #6c757d;
}

.goods-list-item #preview {
  height: 100px;
  width: 100px;
}
</style>
