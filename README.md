# ClarivateSimulation
Automation Simulation using Selenium C#

The framework has been developed in Selenium C# using 'MSTest Unit Testing Framework'.

Instructions to install Automation Components:
-- Install Visual Studio
-- Chrome Browser version 110.xxx should be installed in the machine we're running tests on
-- Nuget package manager has multiple needed packages installed (Attached with the Project file)

Instructions to execute Automation tests:
-- When the project is cloned, open that in Visual Studio IDE.
-- Open 'Test Explorer' to see/find the tests.
-- Select the test we want to run and right click on it.
-- Click on 'Run Test' option to run the selected test.

The small framework I have created consists of following folders:
-- Core (Contains classes to handle 'Core' operations needed. This can be further expanded as per the need.)
-- Pages (This folder contains all the pages we're using in our tests. One 'BasePage' class is there with all common functionalities)
-- Tests (This contains all test classes including the 'BaseTest' class where we're getting driver instance and quitting it at the end.)

-- Test Scnnario 1 is for writing into .txt file: The text file will be added in the 'Current Directory' when we run the test.
-- Test Scenario 2 is for capturing the screenshot, the screenshot will be added into 'Screenshots' folder inside current directory. I have called method to take the 'full page screenshot' to capture all the search results, however added method to take normal screenshot as well and can be used if needed.

The Result files are attached with below names:
Captured Screenshot: '0307110019.Png'
.Txt file: 'FileToWrite0307105631.txt'
