<template>
  <div id="app">
    <header>
      <nav class="nav-main">
        <router-link to="/" exact>Home</router-link>|
        <router-link to="/deployments">部署</router-link>
      </nav>
    </header>
    <main>
      <router-view class="view" />
    </main>
  </div>
</template>

<style lang="scss">
@import url(//fonts.googleapis.com/earlyaccess/notosanstc.css);

#app {
  font-family: 'Noto Sans TC', Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
}

nav {
  a {
    font-weight: bold;
    color: #2c3e50;
    margin: 5px;

    &:visited {
      color: inherit;
    }

    &.router-link-active {
      color: #42b983;
    }
  }
}

.nav-main {
  padding: 30px;
}

.view {
  margin: 10px;
}

.actions {
  a {
    margin-right: 10px;
  }
}
</style>
