# Rabobank.Training
Rabobank Training Exercises
The following exercises are designed to test your Microsoft C#, Angular and SSIS developing skills. We are looking for senior developers that can work independently and quickly solve any issues they may face. 
You will be judged on code clarity, coding principles used, styling, self-documenting code and comments where necessary. 
Don’t forget, Google is your friend; Be creative, don’t make too many assumptions; If you have any questions concerning the exercises please contact me at e-mail barry.carnahan@rabobank.nl. 
In the RabobankExercises.zip file you will find 4 files; This word document, an xml file with schema and a csv file. These files will be used in the following exercises.
In order to complete the exercises you will need the latest version of Visual Studio 2022 with at least options Web & Cloud, Other Toolsets: Data storage and processing, Data science and analytical applications and .Net Core cross-platform development. 
If not already so, configure VS 2022 so that “System” directives come first when sorting. Also ensure that the “using” statements are placed within the namespace and ordered accordingly.
The installations should take about 2 hours to install.
Read through all the exercises before starting.
Exercise 1:
Create an .NET 6 Web application with Angular, name the Solution Rabobank.Training, the web project Rabobank.Training.WebApp. Build the web application and run it. 20 minutes.
Exercise 2: 
Create a .NET 6 MSTest project in the Rabobank.Training solution, name it Rabobank.Training.ClassLibrary.Tests.  15 minutes.
In the team we use FluentAssertions in our test projects, add this nuget package to the project.
Copy the FundsOfMandatesData.xml file provided in the zip file Rabobank.Exercises to a new project folder TestData.  
NOTE:  Add the tests for the functionality you implement in the next 2 exercises to this test project.
Exercise 3:
Create a .NET 6 Class library project in the Rabobank.Training solution, name it Rabobank.Training.ClassLibrary.  1 hour.
In this exercise you will use the schema to create a class object that can be used to read the xml file in. Create classes from the schema and store them in the ClassLibrary project.
Create an additional class that implements a method that receives a filename as a parameter and returns a list of FundOfMandates objects.  NOTE: This class will be used in the web application you created in exercise 1, so ensure you have all components in place for this dependency.
Ensure unit tests are in place to test your method.  Use the xml file from the TestData folder you created in exercise 2 as input for your method in the tests. 
 
Exercise 4:
In Rabobank.Training.ClassLibrary you will introduce three new classes, or View Models, PortfolioVM,  PositionVM and MandateVM. The Mandates read in exercise 3 will be mapped to the MandateVM objects and the value calculated according to the specifications described below. 1.5 hours.
The new objects should have the following definition:
PortfolioVM				PositionVM				MandateVM
Property	Type			Property	Type			Property	Type
Positions	List<PositionVM>	Code		string			Name		string
Name		string			Allocation	decimal
Value		decimal			Value		decimal
Mandates	List<MandateVM>

Add a method to the class you created in Exercise 3, call it GetPortfolio and let it return a static PortfolioVM object with the following Positions:
Code			Name					Value
NL0000009165		Heineken				12345
NL0000287100		Optimix Mix Fund			23456
LU0035601805		DP Global Strategy L High		34567
NL0000292332		Rabobank Core Aandelen Fonds T2	45678
LU0042381250		Morgan Stanley Invest US Gr Fnd	56789

Add another method to calculate the mandates for a given PositionVM object and a fundOfMandates object and returns a PositionVM object. The idea is that the Position Code matches the fundOfMandates instrumentCode, but check it to make sure. If it does match then iterate through the array of mandate objects in the fundOfMandates and for each mandate add a MandateVM to the collection of Mandates in the Position. If it doesn’t match then do nothing.
The value for the Mandate can be calculated by multiplying the Position Value by the mandate allocation percentage (divide it by 100). The mandate allocation should also be divided by 100 before assigning it to MandateVM.Allocation. All Values should be rounded to the euro, so no cents.
After all mandate objects have been processed then check the liquidityAllocation in fundOfMandates. If it’s greater than 0 then create another MandateVM object with the Name “Liquidity”, the corresponding liquidityAllocation, but besides calculating the Value by multiplying the Position Value by the liquidityAllocation, subtract the sum of the calculated Mandate Values from the Position Value.
For example, you have the following Position:
Code			Name					Value
NL0000292332		Rabobank Core Aandelen Fonds T2	45678

And the following fundOfMandates:
instrumentCode	name					liquidityAllocation
NL0000292332		Rabobank Core Aandelen Fonds T2	1
With mandates:
mandate-id		mandateName				allocation
NL0000292332-01	Vanguard MSCI world mandaat		49.6
NL0000292332-02	Blackrock World Stock mandaat	49.4

 
In this case you should end up with the following PositionVM object:

Code			Name					Value
NL0000292332		Rabobank Core Aandelen Fonds T2	45678
Mandates:
Name					Allocation		Value
Vanguard MSCI world mandaat		0.496			22656
Blackrock World Stock mandaat	0.494			22565
Liquidity				0.01			457

Ensure unit tests are in place to test the methods you created in this exercise.

Exercise 5:
Create a new MSTest project named Rabobank.Training.WebApp.Tests.  You will use this test project for testing the functionality you add to the web application in the next exercise. 15 minutes.
At the Rabobank we use mocking library NSubstitute or Moq.  Add NuGet packages FluentAssertions and NSubstitute or Moq (you can choose which mocking library to use).

Exercise 6: 
With the developments up to now it’s time to modify the web application. Add a new angular component called “show-portfolio”. The new component should communicate with the web app through the new (api) PortfolioController. The FundsOfMandatesData.xml file should be placed somewhere accessible, an app setting should be made to provide the location of the xml file. The Rabobank.Training.ClassLibrary Utilities class should be injected into PortfolioController so that the xml file can be read in and the Portfolio can be updated with the Mandate data. 2.5 hours.
Use Bootstrap to format the page. The “Show portfolio” page should be triggered by a navigation link, next to the “Fetch data” link. When you click on the “Show portfolio” link the following page should be displayed (or close to it):
 
Ensure unit tests are in place to test the PortfolioController Get method.
Exercise 7:
Review the code you’ve written so far and refactor it so that the responsibilities and heavy lifting in the code are placed properly. Make sure all unit-tests run successfully after making any changes. 1 hour.

