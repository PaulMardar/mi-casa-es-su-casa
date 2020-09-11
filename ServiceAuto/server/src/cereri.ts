<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> RoscaMaria
import { query } from './pgsql';

export async function getCereriFromDb(ctx) {
    let sql = 'SELECT * FROM cerere';
    ctx.body = (await query({ text: sql })).rows;
}

//insertCerereNouaDb
export async function insertCerereNouaDb(ctx) {
    let params = ctx.request.body;
    console.log(params);
    let sql = {
        text: "INSERT INTO cerere(phone, auto) VALUES ($1, $2)",
        values: [params.phone, params.auto]
    };
    ctx.body = (await query(sql));
<<<<<<< HEAD
}
=======
  import { query } from './pgsql';

export async function getCereriFromDb(ctx) {
    let sql = 'SELECT * FROM cerere';
    ctx.body = (await query({text: sql})).rows;
}

export async function insertCerereNouaDb(ctx) {
  let params = ctx.request.body;
  console.log(params);
  let sql = {
      text: "INSERT INTO cerere(phone, auto) VALUES ($1, $2)",
      values: [params.phone, params.auto]
  };
  ctx.body = (await query(sql));
}
>>>>>>> VerbaRobert
=======
}
>>>>>>> RoscaMaria
