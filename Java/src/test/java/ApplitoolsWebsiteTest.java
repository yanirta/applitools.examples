
import com.applitools.eyes.RectangleSize;
import com.applitools.eyes.selenium.Eyes;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.firefox.FirefoxDriver;

public class ApplitoolsWebsiteTest {
    private WebDriver driver_;
    private Eyes eyes_;

    @Before
    public void setup() {
        driver_ = new FirefoxDriver();
        eyes_ = new Eyes();
    }

    @Test
    public void test() {
        driver_.get("http://applitools.com/helloworld");

        // Start visual testing with browser viewport set to 1024x768.
        // Make sure to use the returned driver from this point on.
        driver_ = eyes_.open(driver_, "Applitools website", "Test Applitools homepage", new RectangleSize(900, 700));

        // Visual validation point #1
        eyes_.checkWindow("Home Page");

        driver_.findElement(By.cssSelector("button")).click();

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
