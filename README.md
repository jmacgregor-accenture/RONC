# Spinning Up React</span>.NET Project From Scratch

## Environment Setup
- Spin up EMPTY ASP</span>.NET Core project (no template)
- Add `services.AddMVC()` to `ConfigureServices` in Startup.cs 
- Add this to define the default route:
    ```
    app.UseMvc((routes =>
           {
               routes.MapRoute(
                   name: "default",
                   template: "{controller=Home}/{action=Index}/{id?}");
           }));
    ```
- Create the following Controller file structure:
    - rootdir/Controllers/Home/HomeController.cs
- Create the following Views file structure:
    - rootdir/Views/Home/Index.cshtml
- Create the following wwwroot file structure:
    - rootdir/wwwroot/src/index.js

## Dependency Setup
- Run `npm init -y` at the rootdir. This will create a package.json file with all default settings
- Install the following packages:
    ```
    "dependencies": {
        "@babel/core": "7.4.3",
        "@babel/preset-env": "7.4.3",
        "@babel/preset-react": "7.0.0",
        "babel-jest": "24.7.1",
        "babel-loader": "8.0.5",
        "enzyme": "3.9.0",
        "enzyme-adapter-react-16": "1.12.1",
        "isomorphic-fetch": "2.2.1",
        "jest": "24.7.1",
        "popper.js": "1.15.0",
        "react": "16.8.6",
        "react-dom": "16.8.6",
        "uglifyjs-webpack-plugin": "2.1.2",
        "webpack": "4.30.0",
        "webpack-cli": "3.3.0"
    }
    ```

## Webpack Setup
- Create webpack.config.js file at rootdir
    ```
    const path = require('path');
    const webpack = require('webpack');
    const uglifyJSPlugin = require('uglifyjs-webpack-plugin');

    module.exports = {

        entry: {
            app: 'wwwroot/src/index.js'
        },
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
                new uglifyJSPlugin()
            ]
        },
        module: {
            rules: [{
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
            }]
        },
        mode: 'development'
    };
    ```
- `entry` is where the webpack bundle looks for all .js files
- `output` is where the new webpack bundle is created and put
- `plugins` is where you make imports globally available
    - Webpack uses its own plugin called ProvidePlugin
    - ProvidePlugin is the master plugin that encompasses all imports you want to be globally available
- `optimization` is where you can put the Uglifyjs plugin which reduces the memory used by javascript
- `module` contains `rules` which looks at each file, searching for a regex match
    - If the file type matches, the `use` determines what loaders and options to apply to that file
- Under the `scripts` in package.json, define `"wbp" : "webpack"`
    - This allows us to run webpack commands in the console
- Run `npm run wbp` this creates you dist directory and the webpack bundle.js file

## React Test Setup
- Create setupTests.js file at rootdir and include the `Adapter` import, the `configure` import, and the `Adapter` configuration
    ```
    import Adapter from 'enzyme-adapter-react-16';
    import {configure} from 'enzyme';

    configure({
        adapter: new Adapter()
    });
    ```
- In `scripts` in package.json, include `"test" : "jest"`
    - When the `jest` command runs, the enzyme Adapter looks for the command and runs any applicable enzyme tests
- In package.json, define `setupFilesAfterEnv` in the `"jest"` level, which overrides the default setup file for jest to the one we created
    ```
    "jest": {
        "setupFilesAfterEnv": [
            "./setupTests.js"
        ]
    }
    ```
- Create `.babelrc` file at rootdir and include the config options in the skeleton
    - This sets the babel presets which allow babel to read react without breaking
    ```
    {
        "env": {
            "test": {
                "presets": [
                    "@babel/env", 
                    "@babel/react"
                ]
            }
        }
    }
    ```
