import DeploymentIndex from '../views/deployments/deployment-index.vue';
import DeploymentList from '../views/deployments/deployment-list.vue';
import DeploymentDetail from '../views/deployments/deployment-detail.vue';

export default {
  path: '/deployments',
  component: DeploymentIndex,
  children: [
    { path: '', component: DeploymentList },
    { path: 'new', component: DeploymentDetail },
    { path: ':id', component: DeploymentDetail },
  ],
};
