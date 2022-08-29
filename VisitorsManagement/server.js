'use strict';

const express = require('express');
const { middleware, errorMiddleware } = require('@envoy/envoy-integrations-sdk');

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
        'url': 'https://api.envoy.com/v1/locations',
        'headers': {
            'Content-Type': 'application/json',
            'x-api-key': 'ODMzMjAzZjItMjUxMy0xMWVkLWFhZGUtYzdhOGUzYjc4NDk5OmJjMjgwZjExNWMwYzA2OTY5ZjY4MWQ5YmJkM2UyOTkzMjAxZGVmZWRhZjBhZmVmOTdiMDc2MTAyODNhNWEwYzc3N2EwMTkyZjg4NmQ3YWFkMGY4OTQ4OTU1ZDk3Yjc5MzUzOTM0ZDZjNjU4YzQ3ZTBhNDhlODRlMDVlNzgwMDA3'
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
            'x-api-key': 'ODMzMjAzZjItMjUxMy0xMWVkLWFhZGUtYzdhOGUzYjc4NDk5OmJjMjgwZjExNWMwYzA2OTY5ZjY4MWQ5YmJkM2UyOTkzMjAxZGVmZWRhZjBhZmVmOTdiMDc2MTAyODNhNWEwYzc3N2EwMTkyZjg4NmQ3YWFkMGY4OTQ4OTU1ZDk3Yjc5MzUzOTM0ZDZjNjU4YzQ3ZTBhNDhlODRlMDVlNzgwMDA3',
            'Authorization': 'Basic ODMzMjAzZjItMjUxMy0xMWVkLWFhZGUtYzdhOGUzYjc4NDk5OmJjMjgwZjExNWMwYzA2OTY5ZjY4MWQ5YmJkM2UyOTkzMjAxZGVmZWRhZjBhZmVmOTdiMDc2MTAyODNhNWEwYzc3N2EwMTkyZjg4NmQ3YWFkMGY4OTQ4OTU1ZDk3Yjc5MzUzOTM0ZDZjNjU4YzQ3ZTBhNDhlODRlMDVlNzgwMDA3',
            'Cookie': '_EnvoyWeb_session=TkxNMkZlMXdUKzRkeTNVaTZDRE5kS3dJYnNnV3FZcXVyZDQ1b3pIajNSNHorNnovempNeTNYcytWejlMdHVSTjMvdlZ3dXd5UUdvU0dCcTMwU2tEbTFPcmFBUW8zQmYycHdzWWFGRDdESkdmWlRWNTAybDVaOW9admlXanVZRHJFWW81UDM0LzI4dXFoUU9EY0ZxaE1BTW5VZVRaaUF6Sm15YVlaMUFwVkJkV0YzZTBEcTZIeUZGUVN6QzMwVktzLS1VYVFVNWltTVR6YjdkOE1EVUZOOUZRPT0%3D--7d0a551e06a3bd4e301352c3122542caff3469be; access_token=eyJhbGciOiJFUzM4NCJ9.eyJpYXQiOjE2NjE3NzM2NjAsImlzcyI6ImlkLmVudm95LmNvbSIsImp0aSI6Ijk1YzMyYjMwLTgyOTQtNDc5Mi05ODQ4LTNmYzJjMzQ5NjNkZSIsImV4cCI6MTY2MTg2MDA2MCwic3ViIjoiVXNlcjoyNDcyMTMxIiwiYXVkIjoiODMzMjAzZjItMjUxMy0xMWVkLWFhZGUtYzdhOGUzYjc4NDk5IiwidHlwIjoiYWNjZXNzIiwic2NvcGVzIjpbInRva2VuLnJlZnJlc2giLCJsb2NhdGlvbnMucmVhZCJdLCJtZXRhIjp7ImNvbXBhbnlfaWQiOiIxMzU0MzAiLCJ0aHJvd19hd2F5X3Jvb21zX2FkbWluX3VzZXJfZmxhZyI6dHJ1ZSwiZXh0ZXJuYWxfZGV2IjoidHJ1ZSJ9fQ.S44diM1hk0T2qJyjyT6Nl6NVkwxG4-uJ9wmDkQzZ_XhjEDyPHDu1LNlukbh4vDX-ZWbltV-P9IL04d6jTHpsADs3t1a59v2FpOWuGitCGXQ7-1x6VWb5EyNVWtmWM-Dz; company_id=135430; csrf_token=a8b3afe5b68c023ff2af488775e2d350bff9c0f1aa34393d0e3d6d00449ad5bd; expires_at=1661860060; expires_in=86400; refresh_token=t8hn4EZbzCGk5NAsDCvUjDH1; ajs_anonymous_id=%2249e8e16c-200d-4e31-bd27-42e0427b6b1e%22; landing_url=https%3A%2F%2Fapi.envoy.com%2Fa%2Fauth%2Fv0%2Ftoken; referring_url='
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
