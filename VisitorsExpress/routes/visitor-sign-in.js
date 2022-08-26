'use strict';

var express = require('express');
var router = express.Router();

router.post('/', async (req, res) => {
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
        return res.status(400).send({
            message: 'An error occured!'
        });
    }
});

module.exports = router;
