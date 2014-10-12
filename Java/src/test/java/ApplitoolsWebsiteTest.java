import com.applitools.eyes.Eyes;
import com.applitools.eyes.RectangleSize;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.junit.runners.JUnit4;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.firefox.FirefoxDriver;

@RunWith(JUnit4.class)
public class ApplitoolsWebsiteTest {
    private WebDriver driver_;
    private Eyes eyes_;

    @Before
    public void setup() {
        driver_ = new FirefoxDriver();
        eyes_ = new Eyes();
        // This is your api key, make sure you use it in all your tests.
        eyes_.setApiKey(APPLITOOLS_APIKEY);
    }

    @Test
    public void test() {
        // Start visual testing with browser viewport set to 1024x768.
        // Make sure to use the returned driver from this point on.
        driver_ = eyes_.open(driver_, "Applitools website", "Test toolbar", new RectangleSize(900, 700));

        driver_.get("http://applitools.com");

        // Visual validation point #1
        eyes_.checkWindow("Main Page");

        driver_.findElement(By.cssSelector(".read_more")).click();

        // Visual validation point #2
        eyes_.checkWindow("Features page");

        // End visual testing. Validate visual correctness.
        eyes_.close();
    }

    @After
    public void tearDown() {
        eyes_.abortIfNotClosed();
    }
}
