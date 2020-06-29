module.exports = {
  devServer: {
    proxy: {
      '/api': {
        target: 'https://192.168.99.100:10000/',
      },
    },
  },
};
