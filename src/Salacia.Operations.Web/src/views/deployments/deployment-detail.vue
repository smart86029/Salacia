<template>
  <div>
    <h2></h2>
    <form autocomplete="off" v-on:submit.prevent="submit()">
      <div v-if="isEdit" class="form-group">
        <label class="form-label">專案名稱</label>
        {{ projectName }}
      </div>
      <div v-else class="form-group">
        <label for="web-project-id" class="form-label">專案名稱</label>
        <select class="form-select" id="web-project-id" name="projectId" v-model="web.projectId">
          <option
            v-for="project in projects"
            v-bind:key="project.id"
            v-bind:value="project.id"
          >{{ project.name }}</option>
        </select>
      </div>
      <div class="form-group">
        <label for="web-name" class="form-label">名稱</label>
        <input
          type="text"
          class="form-input"
          id="web-name"
          name="name"
          placeholder="forestage_1"
          v-model="web.name"
        />
      </div>
      <div class="form-group">
        <label for="web-description" class="form-label">描述</label>
        <textarea
          class="form-input"
          id="web-description"
          name="description"
          v-model="web.description"
        ></textarea>
      </div>
      <div class="form-group">
        <label for="web-root-path" class="form-label">根目錄路徑</label>
        <input
          type="text"
          class="form-input"
          id="web-root-path"
          name="rootPath"
          placeholder="D:\webs\forestage_1"
          v-model="web.rootPath"
        />
      </div>
      <div class="form-group">
        <label for="web-port" class="form-label">通訊埠</label>
        <input type="text" class="form-input" id="web-path" name="port" v-model.number="web.port" />
      </div>
      <div class="form-group">
        <label class="form-label">伺服器</label>
        <label v-for="server in servers" v-bind:key="server.id" class="form-checkbox">
          <input
            type="checkbox"
            v-bind:name="server.id"
            v-bind:value="server.id"
            v-model="web.serverIds"
          />
          <i class="form-icon"></i>
          {{ server.name }}
        </label>
      </div>
      <button type="submit">保存</button>
    </form>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'WebDetail',
  data() {
    return {
      isEdit: false,
      web: {
        name: '',
        description: '',
        rootPath: '',
        port: 0,
        projectId: '',
        serverIds: [],
      },
      projects: [],
      servers: [],
      projectName: '',
    };
  },
  created() {
    axios.get('/api/projects').then((response) => {
      this.$data.projects = response.data.items;
    });
    axios.get('/api/servers').then((response) => {
      this.$data.servers = response.data.items;
    });
    const id = this.$route.params?.id;
    if (id) {
      this.$data.isEdit = true;
      axios.get(`/api/webs/${id}`).then((response) => {
        this.$data.web = response.data;
        this.$data.projectName = this.$data.projects.find(
          (x) => x.id === this.$data.web.projectId,
        ).name;
      });
    }
  },
  methods: {
    submit() {
      if (this.$data.isEdit) {
        axios
          .put(`/api/webs/${this.$data.web.id}`, this.$data.web)
          .then((response) => {
            if (response.status === 204) {
              this.$router.push('./');
            }
          });
      } else {
        axios.post('/api/webs', this.$data.web).then((response) => {
          if (response.status === 201) {
            this.$router.push('./');
          }
        });
      }
    },
  },
};
</script>

<style></style>
