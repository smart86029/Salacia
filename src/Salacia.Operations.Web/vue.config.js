module.exports = {
  devServer: {
    proxy: {
      '/api': {
        target: 'http://192.168.99.100:10000/',
      },
    },
  },
};
