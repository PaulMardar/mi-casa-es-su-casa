import * as Router from 'koa-router';
import { getCereriFromDb, insertCerereNouaDb } from './cereri';

export const router = new Router({
   prefix: '/api'
});


// set routes
// router.post('/uploadXml', multipartBody, uploadXml);
// router.get('/checkStatus', checkStatus);

router
.get('/get-cereri', getCereriFromDb)
<<<<<<< HEAD
<<<<<<< HEAD
.post('/cerere-noua', insertCerereNouaDb);

=======
.post('/cerere-noua', insertCerereNouaDb);
>>>>>>> VerbaRobert
=======
.post('/cerere-noua', insertCerereNouaDb);
>>>>>>> RoscaMaria
