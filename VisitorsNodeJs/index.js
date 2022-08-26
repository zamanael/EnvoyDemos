'use strict';

//const express = require('express');
//const { middleware, errorMiddleware } = require('@envoy/envoy-integrations-sdk');

//const app = express();
//app.use(middleware());

//app.post('/hello-options', (req, res) => {
//    res.send([
//        {
//            label: 'Hello',
//            value: 'Hello',
//        },
//        {
//            label: 'Hola',
//            value: 'Hola',
//        },
//        {
//            label: 'Aloha',
//            value: 'Aloha',
//        },
//    ]);
//});

//app.post('/goodbye-options', (req, res) => {
//    res.send([
//        {
//            label: 'Goodbye',
//            value: 'Goodbye',
//        },
//        {
//            label: 'Adios',
//            value: 'Adios',
//        },
//        {
//            label: 'Aloha',
//            value: 'Aloha',
//        },
//    ]);
//});


//// Event Handlers

//// "visitor sign-in" endpoint
//// The URL of this endpoint can be anything - 
//// we'll connect the event with the endpoint URL in the Dev Dashboard menu - but here we're naming the endpoint after the event.

//app.post('/visitor-sign-in', async (req, res) => {
//    const envoy = req.envoy; // our middleware adds an "envoy" object to req.
//    const job = envoy.job;
//    const hello = envoy.meta.config.HELLO;
//    const visitor = envoy.payload;
//    const visitorName = visitor.attributes['full-name'];

//    const message = `${hello} ${visitorName}!`; // our custom greeting
//    await job.attach({ label: 'Hello', value: message }); // show in the Envoy dashboard.

//    res.send({ hello });
//});

////"visitor sign-out" endpoint

//app.post('/visitor-sign-out', async (req, res) => {
//    const envoy = req.envoy; // our middleware adds an "envoy" object to req.
//    const job = envoy.job;
//    const goodbye = envoy.meta.config.GOODBYE;
//    const visitor = envoy.payload;
//    const visitorName = visitor.attributes['full-name'];

//    const message = `${goodbye} ${visitorName}!`;
//    await job.attach({ label: 'Goodbye', value: message });

//    res.send({ goodbye });
//});

//app.use(function (req, res, next) {
//    console.log('Time:', Date.now())
//    next()
//});

//app.post('/goodbye-options', (req, res) => {
//    console.log('goodbye-options');
//    //...
//});

// Another option is to set DEBUG in the command line and watch stdout:
// set DEBUG=express:*

//app.use(errorMiddleware());

//const listener = app.listen(process.env.PORT || 0, () => {
//    console.log(`Listening on port ${listener.address().port}`);
//});

//var http = require('http');
//var port = process.env.PORT || 1337;

//http.createServer(function (req, res) {
//    res.writeHead(200, { 'Content-Type': 'text/plain' });
//    res.end('Hello World\n');
//}).listen(port);

