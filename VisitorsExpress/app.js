'use strict';

//try {
//    const https = require("https");
//    const fs = require("fs");
//    var debug = require('debug')('my express app');
//    var express = require('express');
//    const { middleware, errorMiddleware } = require('@envoy/envoy-integrations-sdk');
//    var path = require('path');
//    var favicon = require('serve-favicon');
//    var logger = require('morgan');
//    var cookieParser = require('cookie-parser');
//    var bodyParser = require('body-parser');

//    var routes = require('./routes/index');
//    var users = require('./routes/users');

//    var app = express();

//    // view engine setup
//    app.set('views', path.join(__dirname, 'views'));
//    app.set('view engine', 'pug');

//    // uncomment after placing your favicon in /public
//    //app.use(favicon(__dirname + '/public/favicon.ico'));
//    app.use(logger('dev'));
//    app.use(bodyParser.json());
//    app.use(bodyParser.urlencoded({ extended: false }));
//    app.use(cookieParser());
//    app.use(express.static(path.join(__dirname, 'public')));
//    try {
//        app.use(middleware());
//    } catch (e) {
//        console.log(e);
//    }

//    app.use('/', routes);
//    app.use('/users', users);

//    // catch 404 and forward to error handler
//    app.use(function (req, res, next) {
//        var err = new Error('Not Found');
//        err.status = 404;
//        next(err);
//    });

//    // error handlers

//    // development error handler
//    // will print stacktrace
//    if (app.get('env') === 'development') {
//        app.use(function (err, req, res, next) {
//            res.status(err.status || 500);
//            res.render('error', {
//                message: err.message,
//                error: err
//            });
//        });
//    }

//    // production error handler
//    // no stacktraces leaked to user
//    app.use(function (err, req, res, next) {
//        res.status(err.status || 500);
//        res.render('error', {
//            message: err.message,
//            error: {}
//        });
//    });

//    app.set('port', process.env.PORT || 3000);

//    var server = app.listen(app.get('port'), function () {
//        debug('Express server listening on port ' + server.address().port);
//    });


//} catch (e) {
//    console.log(e);
//}




//try {
//    const https = require('https')
//    const express = require('express')
//    const forge = require('node-forge')


//        ; (function main() {
//            const server = https.createServer(
//                generateX509Certificate([
//                    { type: 6, value: 'http://localhost' },
//                    { type: 7, ip: '127.0.0.1' }
//                ]),
//                makeExpressApp()
//            )
//            server.listen(8443, () => {
//                console.log('Listening on https://localhost:8443/')
//            })
//        })()


//    function generateX509Certificate(altNames) {
//        const issuer = [
//            { name: 'commonName', value: 'example.com' },
//            { name: 'organizationName', value: 'E Corp' },
//            { name: 'organizationalUnitName', value: 'Washington Township Plant' }
//        ]
//        const certificateExtensions = [
//            { name: 'basicConstraints', cA: true },
//            { name: 'keyUsage', keyCertSign: true, digitalSignature: true, nonRepudiation: true, keyEncipherment: true, dataEncipherment: true },
//            { name: 'extKeyUsage', serverAuth: true, clientAuth: true, codeSigning: true, emailProtection: true, timeStamping: true },
//            { name: 'nsCertType', client: true, server: true, email: true, objsign: true, sslCA: true, emailCA: true, objCA: true },
//            { name: 'subjectAltName', altNames },
//            { name: 'subjectKeyIdentifier' }
//        ]
//        const keys = forge.pki.rsa.generateKeyPair(2048)
//        const cert = forge.pki.createCertificate()
//        cert.validity.notBefore = new Date()
//        cert.validity.notAfter = new Date()
//        cert.validity.notAfter.setFullYear(cert.validity.notBefore.getFullYear() + 1)
//        cert.publicKey = keys.publicKey
//        cert.setSubject(issuer)
//        cert.setIssuer(issuer)
//        cert.setExtensions(certificateExtensions)
//        cert.sign(keys.privateKey)
//        return {
//            key: forge.pki.privateKeyToPem(keys.privateKey),
//            cert: forge.pki.certificateToPem(cert)
//        }
//    }


//    function makeExpressApp() {
//        const app = express()
//        app.get('/', (req, res) => {
//            res.json({ message: 'Hello, friend' })
//        })
//        return app
//    }
//} catch (e) {
//    console.log(e);
//}



try {
    const forge = require('node-forge');
    const https = require("https");
    const fs = require("fs");
    var debug = require('debug')('my express app');
    var express = require('express');
    const { middleware, errorMiddleware } = require('@envoy/envoy-integrations-sdk');
    var path = require('path');
    var favicon = require('serve-favicon');
    var logger = require('morgan');
    var cookieParser = require('cookie-parser');
    var bodyParser = require('body-parser');

    var routes = require('./routes/index');
    var users = require('./routes/users');

    // https://flaviocopes.com/express-https-self-signed-certificate/

    (function main() {
        const server = https.createServer(
            generateX509Certificate([
                { type: 6, value: 'http://localhost' },
                { type: 7, ip: '127.0.0.1' }
            ]),
            makeExpressApp()
        )
        server.listen(process.env.PORT || 3000, () => {
            console.log(`Listening on https://localhost:${process.env.PORT}/`)
        })
    })();

    function generateX509Certificate(altNames) {
        const issuer = [
            { name: 'commonName', value: 'example.com' },
            { name: 'organizationName', value: 'E Corp' },
            { name: 'organizationalUnitName', value: 'Washington Township Plant' }
        ]
        const certificateExtensions = [
            { name: 'basicConstraints', cA: true },
            { name: 'keyUsage', keyCertSign: true, digitalSignature: true, nonRepudiation: true, keyEncipherment: true, dataEncipherment: true },
            { name: 'extKeyUsage', serverAuth: true, clientAuth: true, codeSigning: true, emailProtection: true, timeStamping: true },
            { name: 'nsCertType', client: true, server: true, email: true, objsign: true, sslCA: true, emailCA: true, objCA: true },
            { name: 'subjectAltName', altNames },
            { name: 'subjectKeyIdentifier' }
        ]
        const keys = forge.pki.rsa.generateKeyPair(2048)
        const cert = forge.pki.createCertificate()
        cert.validity.notBefore = new Date()
        cert.validity.notAfter = new Date()
        cert.validity.notAfter.setFullYear(cert.validity.notBefore.getFullYear() + 1)
        cert.publicKey = keys.publicKey
        cert.setSubject(issuer)
        cert.setIssuer(issuer)
        cert.setExtensions(certificateExtensions)
        cert.sign(keys.privateKey)
        return {
            key: forge.pki.privateKeyToPem(keys.privateKey),
            cert: forge.pki.certificateToPem(cert)
        }
    }


    function makeExpressApp() {
        const app = express();

        // view engine setup
        app.set('views', path.join(__dirname, 'views'));
        app.set('view engine', 'pug');

        // uncomment after placing your favicon in /public
        //app.use(favicon(__dirname + '/public/favicon.ico'));
        app.use(logger('dev'));
        app.use(bodyParser.json());
        app.use(bodyParser.urlencoded({ extended: false }));
        app.use(cookieParser());
        app.use(express.static(path.join(__dirname, 'public')));
        try {
            app.use(middleware());
        } catch (e) {
            console.log(e);
        }

        app.use('/', routes);
        app.use('/users', users);

        // catch 404 and forward to error handler
        app.use(function (req, res, next) {
            var err = new Error('Not Found');
            err.status = 404;
            next(err);
        });

        // error handlers

        // development error handler
        // will print stacktrace
        if (app.get('env') === 'development') {
            app.use(function (err, req, res, next) {
                res.status(err.status || 500);
                res.render('error', {
                    message: err.message,
                    error: err
                });
            });
        }

        // production error handler
        // no stacktraces leaked to user
        app.use(function (err, req, res, next) {
            res.status(err.status || 500);
            res.render('error', {
                message: err.message,
                error: {}
            });
        });

        return app;
    }
} catch (e) {
    console.log(e);
}
