const { createProxyMiddleware } = require('http-proxy-middleware');

module.exports = function (app) {
  app.use(
    '/api',
    createProxyMiddleware({
      target: 'https://localhost:7183',
      changeOrigin: true,
      secure: false,
    })
  );
};
