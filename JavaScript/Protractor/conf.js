exports.config = {
    //seleniumAddress: 'http://localhost:4444/wd/hub',
    specs: ['web_calculator_test.js'],
    capabilities: {
        'browserName': 'firefox'
    }
};