using System;
using System.Collections.Generic;
using System.Text;

namespace Saaspose.Pdf
{
    /// <summary>
    /// represents the Represents the link action types
    /// </summary>
    public enum  LinkActionType
    {
        GoToAction,
        GoToURIAction,
        JavascriptAction,
        LaunchAction,
        NamedAction,
        SubmitFormAction
    }
}