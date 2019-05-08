const path = require('path');
const webpack = require('webpack');
const Uglifyjsplugin = require('uglifyjs-webpack-plugin');

module.exports = {
    entry: {app: './wwwroot/src/index.js'},
    output: {
        path: path.resolve(__dirname, 'wwwroot/dist'),
        filename: 'bundle.js',
        publicPath: 'dist/'
    },
    plugins: [
        new webpack.ProvidePlugin({
            Popper: [
                'popper.js',
                'default'
            ]
        })
    ],
    optimization: {
        minimize: true,
        minimizer: [
            new Uglifyjsplugin()
        ]
    },
    module: {
        rules: [
            {
                test: /\.js?$/,
                use: {
                    loader: 'babel-loader',
                    options: {
                        presets: [
                            '@babel/preset-react',
                            '@babel/preset-env'
                        ]
                    }
                }

            }
        ]
    },
    mode: 'development'
};
