<template>
  <table class="table">
    <thead>
      <tr>
        <th>專案名稱</th>
        <th>檔案名稱</th>
        <th>已部署數量</th>
        <th>總部署數量</th>
        <th>新建時間</th>
        <th>操作</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="deployment in deployments" v-bind:key="deployment.id">
        <td>{{ deployment.projectName }}</td>
        <td>{{ deployment.fileName }}</td>
        <td>{{ deployment.deployedCount }}</td>
        <td>{{ deployment.deploymentItemCount }}</td>
        <td>{{ deployment.createdOn }}</td>
        <td class="actions">
          <router-link v-bind:to="`/deployments/${deployment.id}`">編輯</router-link>
          <a href="#" class="text-error" v-on:click.prevent="deleteDeployment(deployment.id)">刪除</a>
        </td>
      </tr>
    </tbody>
  </table>
</template>

<script>
import axios from 'axios';

export default {
  name: 'DeploymentList',
  components: {},
  data() {
    return {
      deployments: [],
    };
  },
  created() {
    axios.get('/api/deployments').then((response) => {
      this.$data.deployments = response.data.items;
    });
  },
  methods: {
    deleteDeployment(deploymentId) {
      axios.delete(`/api/deployments/${deploymentId}`).then((response) => {
        if (response.status === 204) {
          this.$router.go(0);
        }
      });
    },
  },
};
</script>

<style>
</style>
