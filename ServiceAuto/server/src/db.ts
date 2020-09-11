import * as sql from 'mssql';
import * as moment from 'moment-timezone';
import config from './config';

const pool = new sql.ConnectionPool(config.db);
console.time('db connection');
pool
    .connect()
    .then(() => console.timeEnd('db connection'))
    .catch(dbConnError => console.error({ dbConnError, dbConnConfig: config.db }))

export async function query(sql: string, params?: { [key: string]: any }) {
    try {
        let request = await (await pool.connect()).request();
        for (let param in params) {
            let val = params[param];
            if (typeof val === 'string' && val.length <= 25 && val.match(/\d\d\d\d-\d\d-\d\dT\d\d:\d\d:\d\d.\d\d\dZ/)) {
                val = moment(val).tz('Europe/Bucharest').format('YYYY-MM-DDTHH:mm:ss');
            }
            request.input(param, val);
        }
        return await request.query(sql);
    } catch (err) {
        console.error({ sqlError: err.message || err, sql, params });
        throw err;
    }
}


//query('SELECT TOP 1 Id FROM dbo.XmlFile')
//  .then(result => console.log(result.recordset))
//  .catch(err => console.error('query error: ', err));
//query('SELECT TOP 1 Id FROM dbo.XmlFile')
//  .then(result => console.log(result.recordset))
//  .catch(err => console.error('query error: ', err));
//query('SELECT TOP 1 Id FROM dbo.XmlFile')
//  .then(result => console.log(result.recordset))
//  .catch(err => console.error('query error: ', err));
//query('SELECT TOP 1 Id FROM dbo.XmlFile')
//  .then(result => console.log(result.recordset))
//  .catch(err => console.error('query error: ', err));

//setInterval(async function () {
//  try {
//    let result = await query('SELECT TOP 1 Id FROM dbo.XmlFile');
//    console.log(result.recordset);
//  } catch (ex) {
//    //console.error('query error', ex);
//  }
//}, 3000);

//let data = new Date();
//query('SELECT GetDate() as DataServer, @data as DataNode, cast(@data as nvarchar) as DataNodeInSql', { data })
//  .then(result => console.log(result.recordset));

//query('UPDATE XmlFile SET ImportStart = @data', { data })
//  .then(result => console.log(result.recordset))
//  .catch(err => console.error('query error: ', err));
