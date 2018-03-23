<template>
  <div id="app">
    <router-view/>
  </div>
</template>

<script>
export default {
  name: 'App',
};
</script>

<style>
* {
  box-sizing: border-box;
}

html, body {
  height: 100%;
}

.container-full {
  width: 100%;
  min-height: 100vh;
  padding-right: 0;
  padding-left: 0;
  margin-right: 0;
  margin-left: 0;
}

.row.nomargin {
  margin: 0;
}

.dark {
  background-color: rgba(5, 1, 17, 0.8);
}

#app {
  font-family: medium-content-sans-serif-font, -apple-system, BlinkMacSystemFont,
    "Segoe UI", Roboto, Oxygen, Ubuntu, Cantarell, "Open Sans", "Helvetica Neue",
    sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  height: 100%;
  width: 100%;
  padding: 0;
  margin: 0;
  list-style: none;
  display: flex;
  align-items: center;
  justify-content: center;
}

router-view {
  height: 100%;
  width: 100%;
}
</style>
