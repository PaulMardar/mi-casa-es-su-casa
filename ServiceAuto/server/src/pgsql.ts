const Pool = require('pg-pool');
const url = require('url')
const pgUri = `postgres://impjgqibbkhpqu:c88191a2e95c792ed9effe8c6829eb4a7ff86c23826287639b496191bff9741b@ec2-3-215-83-17.compute-1.amazonaws.com:5432/dfup0ifrer09ho`;
const params = url.parse(process.env.DATABASE_URL || pgUri);
const [user, pass] = params.auth.split(':');

const config = {
    user: user,
    password: pass,
    host: params.hostname,
    port: params.port,
    database: params.pathname.split('/')[1],
    ssl: true
};

//console.log({ config });
let client;
const pool = new Pool(config);
<<<<<<< HEAD
<<<<<<< HEAD
pool.connect()
.then(conn => {
=======
pool.connect().then(conn => {
>>>>>>> VerbaRobert
=======
pool.connect()
.then(conn => {
>>>>>>> RoscaMaria
    client = conn;
}).catch(console.error);
// setTimeout(() => {
//     test()
//         .then(test)
//         .then(test)
//         .catch(console.error);

// }, 2000);

// async function test() {
//     let sqlcmd = `
//     DO
//     $do$
//     BEGIN
//         insert into cerere(phone)
//         values ('0723.433.212');
//         select * from cerere;
//     END
//     $do$
// `;

//     console.time('query')
//     var result = await client.query(sqlcmd);
//     console.timeEnd('query');
//     console.log(result.rows);
// }

export async function query(query: { text: string, values?: Array<any> }) {
    return await client.query(query.text, query.values || []);
}