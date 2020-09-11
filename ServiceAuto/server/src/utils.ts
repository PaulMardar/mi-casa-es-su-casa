import * as fs from 'fs';
import { query } from './db';
import config from './config';



export async function setClientFolder(folderPath): Promise<any> {
    return createFolderIfNotExists(folderPath).then((result) => {
        return folderPath;
    });
}

export async function createFolderIfNotExists(folderPath): Promise<any> {
    return new Promise((resolve, reject) => {
        fs.stat(folderPath, (err, stats) => {
            if (err) {
                fs.mkdir(folderPath, (err) => {
                    if (err) return reject(err);
                    return resolve(stats);
                });
            }
            else {
                return resolve(stats);
            }
        });
    });
}
