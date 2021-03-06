﻿using System.Activities;
using System.Collections.Generic;
using Microsoft.Xrm.Sdk.Workflow;
using UltimateWorkflowToolkit.Common;

namespace UltimateWorkflowToolkit.CoreOperations.Base
{
    public abstract class BuildRequestWorkflowBase: CrmWorkflowBase
    {
        #region Inputs

        [Input("Request")]
        [Output("Modified Request")]
        public InOutArgument<string> SerializedObject { get; set; }

        #endregion Inputs

        protected abstract void BuildRequest(ref Dictionary<string, object> request);

        protected override void ExecuteWorkflowLogic()
        {
            var serializedObject = SerializedObject.Get(Context.ExecutionContext);
            var request = DeserializeDictionary(serializedObject);

            BuildRequest(ref request);

            SerializedObject.Set(Context.ExecutionContext, SerializeDictionary(request));
        }
    }
}
