﻿using System.Activities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using Microsoft.Crm.Sdk.Messages;
using UltimateWorkflowToolkit.Common;

namespace UltimateWorkflowToolkit.CoreOperations
{
    public class InvoiceLockPricing : CrmWorkflowBase
    {
        #region Input/Output Parameters

        [Input("Invoice")]
        [ReferenceTarget("invoice")]
        [RequiredArgument]
        public InArgument<EntityReference> Invoice { get; set; }

        #endregion Input/Output Parameters

        protected override void ExecuteWorkflowLogic()
        {
            var lockInvoicePricingRequest = new LockInvoicePricingRequest()
            {
                InvoiceId = Invoice.Get(Context.ExecutionContext).Id
            };

            Context.UserService.Execute(lockInvoicePricingRequest);
        }
    }
}
