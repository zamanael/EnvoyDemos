'use strict';

var express = require('express');
var router = express.Router();

router.post('/', async (req, res) => {
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
        return res.status(400).send({
            message: 'An error occured!'
        });
    }
});

module.exports = router;
