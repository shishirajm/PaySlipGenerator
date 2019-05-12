# PaySlipGenerator
Generates the pay slips for employees based on inputs and tax slabs.
Changes made by manasa
Assumptions: number 1

Assumptions of this repo:

	Requirements

	* First phase is building a micro service, which exposes a api. This consumes the PaySlip request model and provides the calcualted fields for the pay slip.
	* This would be helpful to consume later by any client. Second phase will be extending this to build UI to consume this api.
	* Single currency type considered.
	* Currently the calculation is for complete month, partial working month is not considered.
	* Pay slip start date is expected to be whole date, in the format MM-DD-YYYY. Since the same can be used to determin the payment period, the request in the requirement is slightly modified.

	Field Validation 
	
	* Salary and interest can have max of 2 decimal places. 
	* Numbers are always non negative.
	* Names can be alpha numeric with ' allowed.
	* Super interest acccepts number between 0 and 12.
	* Data binding would take care of the date mapping.
	
Design decision:
 
 * Built this as a language agnosticc micro service so it can be consumed by any web client.
 * The tool can be extended later to pass in the year. Based on different tax slab for the year, payslip can be generated.
 * Haven't added the error handling, in case it fails 500 status code will be returned.
 * Since the asp.net web api can be hosted on all the cloud platform choose asp.net
 * HttpGet is being used and the parameters are passed using the URL. Would have liked to pass the parameter in a body but since I was using post man it wont allow to pass get parameters in body.
 * UI/Client is currently not built.
 * Added ms unit tests for all the core logic.
 * Test harness is just throw away code.
 
Deployment

 * Currently the app is hosted in the azure on http://payslipgen.azurewebsites.net
 * It is deployed using https://portal.azure.com pointing to git source
 * If needed to run on local system would need iis or iis express.
 * IIS deployment. Need to follow normal deployment process to deploy the app to IIS. Use msbuild or visual studio to build the solution. Add virtual directory and then access.
 * IIS express deplyment. Click F5 on visual studio.

Source code path:
 * https://github.com/shishirajm/PaySlipGenerator 
 
Running the application:
 * Import postman collection to Postman client from PaySlipGenerator\tools\Postman on https://github.com/shishirajm/PaySlipGenerator
 * Execute changing the input.
 
Test harness
 * Download 
	* https://github.com/shishirajm/PaySlipGenerator/blob/master/tools/TestHarness/jquery2.js and 
	* https://github.com/shishirajm/PaySlipGenerator/blob/master/tools/TestHarness/textbox.html into same folder.
 * Run the html in browser.
 

Request Format:

Http request:

	http://localhost:14431/api/payslip?firstName=Shishira&LastName=Mallasandra&annualSalary=100000&SuperInterestRate=9.5&PaymentStartDate=2-22-2018
	
Response body:

	When status valid reponse:
	
	Response code 200
	
	{
		"Name": "Shishira Mallasandra",
		"GrossIncome": 8333,
		"IncomeTax": 2053,
		"NetIncome": 6280,
		"SuperAmount": 792,
		"PaymentPeriod": "01 February - 28 February"
	}
	
	When model validation fails: 
	
	Response code 400 Bad Request
	
	{
		"Message": "The request is invalid.",
		"ModelState": {
			"LastName": [
				"The LastName field is required."
			],
			"AnnualSalary": [
				"The AnnualSalary field is required."
			],
			"SuperInterestRate": [
				"The SuperInterestRate field is required."
			],
			"PaymentStartDate": [
				"The PaymentStartDate field is required."
			]
		}
	}
