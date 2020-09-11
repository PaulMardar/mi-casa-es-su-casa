import * as Koa from 'koa';

const logger = require('koa-logger');
const serve = require('koa-static');
const cors = require('@koa/cors');
const path = require('path');
const bodyParser = require('koa-bodyparser');
<<<<<<< HEAD

=======
>>>>>>> RoscaMaria
import { router } from './src/router';
import config from './src/config';


const app = new Koa();
app.use(logger())
  .use(serve(path.join(__dirname, '/public')))
  .use(cors())
  .use(bodyParser())
  .use(router.routes())
  .use(router.allowedMethods())
<<<<<<< HEAD
  .listen(config.PORT, async () => console.log(`WEB port... ${config.PORT}`));
=======
  .listen(config.PORT, async () => console.log(`WEB port... ${config.PORT}`));
>>>>>>> RoscaMaria
