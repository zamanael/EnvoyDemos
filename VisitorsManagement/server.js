'use strict';

const express = require('express');
const { middleware, errorMiddleware } = require('@envoy/envoy-integrations-sdk');
const baseUrl = 'https://api.envoy.com/v1';

const app = express();
app.use(middleware());
app.use(errorMiddleware());

app.get('/', (req, res) => {
    res.send(process.env.ENVOY_CLIENT_API_KEY);
});

app.get('/locations', async (req, res) => {
    var request = require('request');
    var options = {
        'method': 'GET',
        'url': `${baseUrl}/locations`,
        'headers': {
            'Content-Type': 'application/json',
            'x-api-key': `${process.env.ENVOY_CLIENT_API_KEY}`
        }
    };

    request(options, function (error, response) {
        if (error) throw new Error(error);
        res.send(response.body);
    }); 
});

app.get('/token', async (req, res) => {
    var request = require('request');
    var options = {
        'method': 'POST',
        'url': 'https://api.envoy.com/oauth2/token',
        'headers': {
            'Content-Type': 'application/x-www-form-urlencoded',
            'Authorization': 'Basic ODMzMjAzZjItMjUxMy0xMWVkLWFhZGUtYzdhOGUzYjc4NDk5OmJjMjgwZjExNWMwYzA2OTY5ZjY4MWQ5YmJkM2UyOTkzMjAxZGVmZWRhZjBhZmVmOTdiMDc2MTAyODNhNWEwYzc3N2EwMTkyZjg4NmQ3YWFkMGY4OTQ4OTU1ZDk3Yjc5MzUzOTM0ZDZjNjU4YzQ3ZTBhNDhlODRlMDVlNzgwMDA3',
        },
        form: {
            'username': 'titucse700@gmail.com',
            'password': 'Admin#123456',
            'scope': 'token.refresh,locations.read',
            'grant_type': 'password'
        }
    };
    request(options, function (error, response) {
        if (error) throw new Error(error);
        res.send(response.body);
    });
});

app.post('/hello-options', (req, res) => {
    res.send([
        {
            label: 'Hello',
            value: 'Hello',
        },
        {
            label: 'Hola',
            value: 'Hola',
        },
        {
            label: 'Aloha',
            value: 'Aloha',
        },
    ]);
});

app.post('/goodbye-options', (req, res) => {
    res.send([
        {
            label: 'Goodbye',
            value: 'Goodbye',
        },
        {
            label: 'Adios',
            value: 'Adios',
        },
        {
            label: 'Aloha',
            value: 'Aloha',
        },
    ]);
});

app.post('/visitor-sign-in', async (req, res) => {
    const envoy = req.envoy; // our middleware adds an "envoy" object to req.
    const job = envoy.job;
    const hello = envoy.meta.config.HELLO;
    const visitor = envoy.payload;
    const visitorName = visitor.attributes['full-name'];

    const message = `${hello} ${visitorName}!`; // our custom greeting
    await job.attach({ label: 'Hello', value: message }); // show in the Envoy dashboard.

    res.send({ hello });
});

app.post('/visitor-sign-out', async (req, res) => {
    const envoy = req.envoy; // our middleware adds an "envoy" object to req.
    const job = envoy.job;
    const goodbye = envoy.meta.config.GOODBYE;
    const visitor = envoy.payload;
    const visitorName = visitor.attributes['full-name'];

    const message = `${goodbye} ${visitorName}!`;
    await job.attach({ label: 'Goodbye', value: message });

    res.send({ goodbye });
});

app.use(function (req, res, next) {
    console.log('Time:', Date.now())
    next()
});

const listener = app.listen(process.env.PORT || 0, () => {
    console.log(`Listening on port ${listener.address().port}`);
}); 
