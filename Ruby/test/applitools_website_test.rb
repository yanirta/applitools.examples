require 'test/unit'
require 'eyes_selenium'

class MyTest < Test::Unit::TestCase

  def setup
    @eyes = Applitools::Eyes.new
    # This is your api key, make sure you use it in all your tests.
    @eyes.api_key = APPLITOOLS_APIKEY

    # Get a selenium web driver object.
    @driver = Selenium::WebDriver.for :firefox
  end

  # Called after every test method runs. Can be used to tear
  # down fixture information.

  def teardown
    @eyes.abort_if_not_closed
  end

  # Fake test
  def test
    @eyes.test(app_name: 'Applitools website', test_name: 'Example test',
               viewport_size: {width: 900, height: 600}, driver: @driver) do |wrapped_driver|
      wrapped_driver.get 'http://www.applitools.com'
      # Visual validation point #1
      @eyes.check_window('Main Page')
      wrapped_driver.find_element(:css, ".read_more").click
      # Visual validation point #2
      @eyes.check_window('Features Page')
    end
  end
end