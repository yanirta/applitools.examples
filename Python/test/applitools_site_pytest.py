from applitools.eyes import Eyes
from selenium import webdriver
import pytest

__author__ = 'Yanir Taflev'


class Test:
    driver = 0
    eyes = 0

    @pytest.fixture(autouse=True)
    def setup(self, request):
        self.driver = webdriver.Firefox()
        self.eyes = Eyes()
        self.eyes.api_key = APPLITOOLS_APIKEY
        request.addfinalizer(self.teardown)

    def teardown(self):
        self.eyes.abort_if_not_closed()
        self.driver.close()

    def test(self):
        # Start visual testing with browser viewport set to 1024x768.
        # Make sure to use the returned driver from this point on.
        self.driver = self.eyes.open(driver=self.driver, app_name='Applitools website', test_name='Example test',
                                     viewport_size={'width': 900, 'height': 600})
        self.driver.get('http://www.applitools.com')

        # Visual validation point #1
        self.eyes.check_window('Main Page')

        self.driver.find_element_by_css_selector('.read_more').click()

        # Visual validation point #2
        self.eyes.check_window('Features Page')

        # End visual testing. Validate visual correctness.
        self.eyes.close()