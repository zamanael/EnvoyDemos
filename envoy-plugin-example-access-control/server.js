'use strict';

//const { middleware, errorMiddleware, asyncHandler } = require('@envoy/envoy-integrations-sdk');
//const express = require('express');

//const app = express();
//app.use(middleware());

//// Setup Steps
//app.post('/setup-step-authenticate', asyncHandler(require('./lib/handlers/setupStep/setupStepAuthenticate')));

//// Field Populators
//app.post('/field-populator-durations', require('./lib/handlers/fieldPopulator/fieldPopulatorDurations'));
//app.post('/field-populator-protect-durations', require('./lib/handlers/fieldPopulator/fieldPopulatorProtectDuration'));
//app.post('/field-populator-orgs', asyncHandler(require('./lib/handlers/fieldPopulator/fieldPopulatorOrgs')));
//app.post('/field-populator-sites', asyncHandler(require('./lib/handlers/fieldPopulator/fieldPopulatorSites')));
//app.post('/field-populator-groups', asyncHandler(require('./lib/handlers/fieldPopulator/fieldPopulatorGroups')));
//app.post('/field-populator-flows', asyncHandler(require('./lib/handlers/fieldPopulator/fieldPopulatorFlows')));
//app.post('/field-populator-employees', asyncHandler(require('./lib/handlers/fieldPopulator/fieldPopulatorEmployees')));

//// Events
//app.post('/webhook-invite', asyncHandler(require('./lib/handlers/events/webhookInvite')));
//app.post('/webhook-sign-in', asyncHandler(require('./lib/handlers/events/webhookSignIn')));
//app.post('/webhook-sign-out', asyncHandler(require('./lib/handlers/events/webhookSignOut')));
//app.post('/webhook-employee-sign-in', asyncHandler(require('./lib/handlers/events/webhookEmployeeSignIn')));
//app.post('/webhook-employee-sign-out', asyncHandler(require('./lib/handlers/events/webhookEmployeeSignOut')));

//app.use(errorMiddleware(console.log));
//app.listen(process.env.PORT || 0, () => {});



const express = require('express');
const { middleware, errorMiddleware } = require('@envoy/envoy-integrations-sdk');
const baseUrl = 'https://api.envoy.com';

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
        'url': `${baseUrl}/v1/locations`,
        'headers': {
            'Content-Type': 'application/json',
            'x-api-key': `${process.env.ENVOY_CLIENT_ID}`
        }
    };

    request(options, function (error, response) {
        if (error) throw new Error(error);
        res.send(response.body);
    });
});

app.get('/token', async (req, res) => {
    var request = require('request');
    const base64Encoding = Buffer.from(`${process.env.ENVOY_CLIENT_ID}:${process.env.ENVOY_CLIENT_SECRET}`).toString('base64');

    var options = {
        'method': 'POST',
        'url': `${baseUrl}/oauth2/token`,
        'headers': {
            'Content-Type': 'application/x-www-form-urlencoded',
            'Authorization': `Basic ${base64Encoding}`,
        },
        form: {
            'username': `${process.env.USER_NAME}`,
            'password': `${process.env.PASSWORD}`,
            'scope': 'token.refresh,locations.read',
            'grant_type': 'password'
        }
    };
    request(options, function (error, response) {
        if (error) throw new Error(error);
        res.send(response.body);
    });
});

app.post('/envoy/hello-options', (req, res) => {
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

app.post('/envoy/goodbye-options', (req, res) => {
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
    try {
        const envoy = req.envoy; // our middleware adds an "envoy" object to req.
        const job = envoy.job;
        const hello = envoy.meta.config.HELLO;
        const visitor = envoy.payload;
        const visitorName = visitor.attributes['full-name'];

        const message = `${hello} ${visitorName}!`; // our custom greeting
        await job.attach({ label: 'Hello', value: message }); // show in the Envoy dashboard.

        res.send({ hello });
    } catch (e) {
        res.send(e.message);
    }
});

app.post('/visitor-sign-out', async (req, res) => {
    try {
        const envoy = req.envoy; // our middleware adds an "envoy" object to req.
        const job = envoy.job;
        const goodbye = envoy.meta.config.GOODBYE;
        const visitor = envoy.payload;
        const visitorName = visitor.attributes['full-name'];

        const message = `${goodbye} ${visitorName}!`;
        await job.attach({ label: 'Goodbye', value: message });

        res.send({ goodbye });
    } catch (e) {
        res.send(e.message);
    }
});

app.use(function (req, res, next) {
    console.log('Time:', Date.now())
    next()
});

const listener = app.listen(process.env.PORT || 0, () => {
    console.log(`Listening on port ${listener.address().port}`);
});

