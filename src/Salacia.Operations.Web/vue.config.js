module.exports = {
  devServer: {
    proxy: {
      '/api': {
        target: 'https://localhost:10000/',
      },
    },
  },
};
