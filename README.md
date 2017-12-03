# PaySlipGenerator
Generates the pay slips for employees based on inputs and tax slabs.

Assumptions:
* First phase is building a micro service, which exposes a api. This consumes the PaySlip request model and provides the calcualted fields for the pay slip.
* This would be helpful to consume later by any client. Second phase will be extending this to build UI to consume this api. 
