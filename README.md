# PaySlipGenerator
Generates the pay slips for employees based on inputs and tax slabs.

Assumptions:

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