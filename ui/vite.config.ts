import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';
import { vanillaExtractPlugin } from '@vanilla-extract/vite-plugin';

// https://vite.dev/config/
export default defineConfig({
    plugins: [
        react(),
        vanillaExtractPlugin({
            identifiers: 'debug',
        }),
    ],
    server: {
        port: 3000,
        proxy: {
            '/api': {
                target: 'http://localhost:5000',
                changeOrigin: true,
                secure: false,
            }
        }
    },
    resolve: {
        alias: {
            api: '/src/api',
            components: '/src/components',
            pages: '/src/pages',
            entry: '/src/entry',
            utilities: '/src/utilities',
        },
    },
});
