var Eyes = require('eyes.protractor').Eyes;
var eyes = new Eyes();
eyes.setApiKey(APPLITOOLS_APIKEY);
eyes.setBatch("MyBatch");

describe('angularjs homepage', function() {
    it('should add one and two', function() {
        eyes.open(browser.driver, "JavaScript SDK", "Simple Protractor Test", {width: 1000, height: 600});
        browser.get('http://juliemr.github.io/protractor-demo/');
        eyes.checkWindow("Demo start");
        element(by.model('first')).sendKeys(1);
        element(by.model('second')).sendKeys(2);
        eyes.checkWindow("Input Ready");
        element(by.id('gobutton')).click();
        eyes.checkWindow("Result");
        expect(element(by.binding('latest')).getText()).
            toEqual('3');

        eyes.close(false).then(function(res){
            console.log(res);
        });
    });
});