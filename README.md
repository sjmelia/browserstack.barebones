Barebones BrowserStack Example
==============================

A minimal website and set of tests that runs Selenium tests in parallel on multiple platforms using Browserstack. A more stripped back example than found in the Browserstack documentation.

Quick start
-----------

### Run the tests locally
* git clone repo
* Assuming Visual Studio, install the [NUnit 3 Test Adapter](https://marketplace.visualstudio.com/items?itemName=NUnitDevelopers.NUnit3TestAdapter). (best done via "Tools" > "Extensions and Updates..." menu)
* Open Visual Studio and `F5` to start the website.
* Ensuring the website is still running; execute the tests to run locally using both Chrome and Firefox.

### Running the tests on BrowserStack
* Install and run the browser stack automate [local testing binary](https://www.browserstack.com/local-testing#getting-started).
* Right click the project, select "Properties" from the context menu and add `BROWSERSTACK` to "Conditional compilation symbols". This causes the tests to run via browserstack.
* Edit the file `/BrowserStack.Barebones.Tests/HomePageTests.cs` to contain your Browserstack Automate username and access key.
* Run the tests again to observe them running in Browserstack Automate.
