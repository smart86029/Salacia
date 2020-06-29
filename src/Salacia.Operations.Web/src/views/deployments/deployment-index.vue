<template>
  <div>
    <nav>
      <router-link to="/deployments/new">新建部署</router-link>
    </nav>
    <router-view />
  </div>
</template>

<script>
export default {
  name: 'DeploymentIndex',
};
</script>

<style>
</style>
