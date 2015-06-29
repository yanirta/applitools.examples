/**
 * Created by Yanir Taflev.
 */
var webdriver = require('selenium-webdriver');
var driver = new webdriver.Builder().
    withCapabilities(webdriver.Capabilities.chrome()).
    build();

var Eyes = require('eyes.selenium').Eyes;
var eyes = new Eyes();
eyes.setApiKey(YOUR_API_KEY);


try {
    eyes.open(driver, 'Applitools', 'Test Web Page', {width: 800, height: 600}).then(function (driver) {
        driver.get('http://www.applitools.com');

        // Visual validation point #1
        eyes.checkWindow('Test Web Page');

        driver.findElement(webdriver.By.css('.features>a')).click();

        // Visual validation point #2
        eyes.checkWindow('Features Page');

        eyes.close();
    });
} finally {
    eyes.abortIfNotClosed();
    driver.quit();
}

