const path = require('path');
const webpack = require('webpack');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');

module.exports = (env) => {
  let lastMessage = '';
  
  return {
    mode: 'production',
    entry: {
      styles: `./${env.style}/styles/${env.style}.scss`,      
      scripts: './src/ts/index.ts',
    },
    output: {
      path: path.resolve(__dirname, `${env.style}/dist`),
      filename: '[name].min.js',
    },
    devtool: 'source-map',
    watch: true,
    cache: {
      type: 'filesystem',
      cacheDirectory: path.resolve(__dirname, '.temp_cache'),
      compression: 'gzip',
    },
    resolve: {
      extensions: ['.ts', '.js', '.scss', '.css']
    },
    plugins: [
      new MiniCssExtractPlugin({
        filename: 'styles.min.css',
      }),
      new webpack.ProgressPlugin((percentage, message) => {
        const progress = Math.round(percentage * 100);
        const progressBar = `[${'='.repeat(progress / 2)}${' '.repeat(50 - progress / 2)}]`;
        if (message !== lastMessage) {
          console.log(`${progress}% ${progressBar} ${message}`);
          lastMessage = message;
        }
      }),      
    ],
    module: {
      rules: [{
          test: /\.scss$/,
          exclude: /node_modules/,
          sideEffects: true,
          use: [
            MiniCssExtractPlugin.loader,
            {
              loader: 'css-loader',
              options: {
                sourceMap: true
              }
            }, {
              loader: 'postcss-loader',
              options: {
                sourceMap: true,
                postcssOptions: {
                  plugins: [
                    require('autoprefixer')
                  ]
                }
              }
            }, {
              loader: 'sass-loader',
              options: {
                sourceMap: true,
                sassOptions: {
                  silenceDeprecations: ['mixed-decls', 'color-functions', 'global-builtin', 'import'],
                }
              }
            }
          ],
        },
        {
          test: /\.ts$/,
          exclude: /node_modules/,
          use: {
            loader: 'ts-loader'
          }
        }
      ],
    },
  }
};