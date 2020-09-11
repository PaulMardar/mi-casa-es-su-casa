export default {
  PORT: 8080,
  publicFolder: 'public',
  uploadsFolder: 'uploads',
  msg: {
    uploadFail: 'Eroare la încărcare fișiere @errors',
    uploadSuccess: 'Fisierele XML s-au încărcat cu success',
  },
  db: {
    user: 'PdfAutomation',
    password: 'Indeco@2020',
    server: 'devsrv.indeco.local\\dev2012',
    database: 'PdfAutomation',
    options: { enableArithAbort: true, useUTC: false }
  },
  intervalForNextRequest: 0
}