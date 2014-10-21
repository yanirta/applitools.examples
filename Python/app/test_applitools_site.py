__author__ = 'Yanir Taflev'
from selenium import webdriver
from applitools.eyes import Eyes

eyes = Eyes()
# This is your api key, make sure you use it in all your tests.
eyes.api_key = APPLITOOLS_APIKEY

# Get a selenium web driver object.
driver = webdriver.Firefox()

try:
    # Start visual testing with browser viewport set to 1024x768.
    # Make sure to use the returned driver from this point on.
    driver = eyes.open(driver=driver, app_name='Applitools website', test_name='Example test',
                       viewport_size={'width': 900, 'height': 600})
    driver.get('http://www.applitools.com')

    # Visual validation point #1
    eyes.check_window('Main Page')

    driver.find_element_by_css_selector('.read_more').click()

    # Visual validation point #2
    eyes.check_window('Features Page')

    # End visual testing. Validate visual correctness.
    eyes.close()
finally:
    driver.quit()
    eyes.abort_if_not_closed()