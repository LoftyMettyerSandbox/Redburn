'use strict';

var readline = require('readline-sync');
var https = require('https');

var rawData = {
    "identifier": "MKS",
    "orderType": 0,
    "orderSize": 123,
    "orderSubType": 0,
    "instruction": "fill",
    "orderTransmissionType": 1
};

var jsonObject = JSON.stringify(rawData);

//var postheaders = {
//    'Content-Type': 'application/json',
//    'Content-Length': Buffer.byteLength(jsonObject, 'utf8')
//};

//var optionspost = {
//    host: 'localhost',
//    port: 44365,
//    path: '/api/trades',
//    method: 'POST',
//    headers: postheaders
//};

//var reqPost = https.request(optionspost, function (res) {
//    console.log("statusCode: ", res.statusCode);
//    // uncomment it for header details
//    //  console.log("headers: ", res.headers);

//    res.on('data', function (d) {
//        console.info('POST result:\n');
//        process.stdout.write(d);
//        console.info('\n\nPOST completed');
//    });

//    // write the json data
//    reqPost.write(jsonObject);
//    reqPost.end();
//    reqPost.on('error', function (e) {
//        console.error(e);
//    });

//});


//const request = require('request')

//request.post('http://localhost:44365/api/trades/', {
//    json: jsonObject
//}, (error, res, body) => {
//    if (error) {
//        console.error(error)
//        return
//    }
//    console.log(`statusCode: ${res.statusCode}`)
//    console.log(body)
//})


// manual
//const data = JSON.stringify({
//    todo: 'Buy the milk'
//})

//const options = {
//    hostname: 'https://localhost/',
//    port: 44365,
//    path: '/api/trades',
//    method: 'POST',
//    headers: {
//        'Content-Type': 'application/json',
//        'Content-Length': jsonObject.length
//    }
//}
//const req = https.request(options, (res) => {
//    console.log(`statusCode: ${res.statusCode}`)

//    res.on('data', (d) => {
//        process.stdout.write(d)
//    })
//})

//req.on('error', (error) => {
//    console.error(error)
//})

//req.write(jsonObject)
//req.end()


var rp = require('request-promise');



var options = {
    method: 'POST',
    uri: 'https://localhost:44365/api/trades/',
    body: rawData,
    json: true // Automatically stringifies the body to JSON
};

rp(options)
    .then(function (parsedBody) {
        console.log(parsedBody);
        // POST succeeded...
    })
    .catch(function (err) {
        console.log(parsedBody);
        // POST failed...
    });


//request({
//    url: https://localhost:44365/api/trades,
//    method: "POST",
//    headers: {
//        "content-type": "application/json"
//    },
//    json: jsonObject
//},
//    function (error, resp, body) {
//        console.write("hello ducky2");
//    };
//});






console.log('Hello world');
readline.question("Press any key to continue");

