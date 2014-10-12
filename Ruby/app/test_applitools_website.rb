require 'eyes_selenium'

eyes = Applitools::Eyes.new
# This is your api key, make sure you use it in all your tests.
eyes.api_key = APPLITOOLS_APIKEY

# Get a selenium web driver object.
my_webdriver = Selenium::WebDriver.for :firefox

#baseline = os + browser + viewport-size + app_name + test
begin
  # Start visual testing using my_webdriver and setting the viewport to 1024x768.
  eyes.test(app_name: 'Applitools website', test_name: 'Example test',
            viewport_size: {width: 900, height: 600}, driver: my_webdriver) do |driver|

    driver.get 'http://www.applitools.com'
    # Visual validation point #1
    eyes.check_window('Main Page')
    driver.find_element(:css, ".read_more").click
    # Visual validation point #2
    eyes.check_window('Features Page')
  end
ensure
  eyes.abort_if_not_closed
  my_webdriver.quit
end
