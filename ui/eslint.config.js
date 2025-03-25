import js from '@eslint/js';
import globals from 'globals';
import reactHooks from 'eslint-plugin-react-hooks';
import reactRefresh from 'eslint-plugin-react-refresh';
import tseslint from 'typescript-eslint';
import stylisticTs from '@stylistic/eslint-plugin-ts';

export default tseslint.config(
    {
        ignores: [
            'dist',
            'vite.config.ts',
            'src/schema.d.ts'
        ]
    },
    {
        extends: [js.configs.recommended, ...tseslint.configs.recommended],
        files: ['**/*.{ts,tsx}'],
        languageOptions: {
            ecmaVersion: 2020,
            globals: globals.browser,
        },
        plugins: {
            'react-hooks': reactHooks,
            'react-refresh': reactRefresh,
            '@stylistic/ts': stylisticTs,
        },
        rules: {
            ...reactHooks.configs.recommended.rules,
            'react-refresh/only-export-components': [
                'warn',
                {allowConstantExport: true},
            ],
            semi: ['error', 'always'],
            'no-restricted-exports': ['warn', {
                restrictDefaultExports: {
                    direct: true,
                },
            }],
            // Always use arrow functions
            'prefer-arrow-callback': ['error'],
            'func-style': ['error', 'expression'],
            '@stylistic/ts/quotes': ['error', 'single'],
        },
    },
);
