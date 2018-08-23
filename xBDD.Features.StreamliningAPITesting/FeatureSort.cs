namespace xBDD.Features.StreamliningAPITesting
{
    using System;
    using System.Collections.Generic;
    public class FeatureSort
    {
        public string[] SortedFeatureNames { get; private set; }

        public FeatureSort()
        {
            List<string> SortedFeatureNames = new List<string>() {
                typeof(xBDD.Features.StreamliningAPITesting.StreamliningAPITesting.IssuingRequests.IssueAGet).FullName,
                typeof(xBDD.Features.StreamliningAPITesting.StreamliningAPITesting.IssuingRequests.IssueAPost).FullName,
                typeof(xBDD.Features.StreamliningAPITesting.StreamliningAPITesting.IssuingRequests.IssueAPut).FullName,
                typeof(xBDD.Features.StreamliningAPITesting.StreamliningAPITesting.IssuingRequests.IssueADelete).FullName,
                typeof(xBDD.Features.StreamliningAPITesting.StreamliningAPITesting.IssuingRequests.ModifyTheHeaders).FullName,
                typeof(xBDD.Features.StreamliningAPITesting.StreamliningAPITesting.IssuingRequests.ModifyTheBody).FullName,
                typeof(xBDD.Features.StreamliningAPITesting.StreamliningAPITesting.IssuingRequests.ModifyTheCookies).FullName,
                typeof(xBDD.Features.StreamliningAPITesting.StreamliningAPITesting.ValidatingResponses.ValidateAResponseCode).FullName,
                typeof(xBDD.Features.StreamliningAPITesting.StreamliningAPITesting.ValidatingResponses.FollowA300Response).FullName,
                typeof(xBDD.Features.StreamliningAPITesting.StreamliningAPITesting.ValidatingResponses.ProcessA500Response).FullName,
                typeof(xBDD.Features.StreamliningAPITesting.StreamliningAPITesting.ValidatingResponses.ProcessA400Response).FullName,
                typeof(xBDD.Features.StreamliningAPITesting.StreamliningAPITesting.ValidatingResponses.ProcessA200Response).FullName,
                typeof(xBDD.Features.StreamliningAPITesting.StreamliningAPITesting.ValidatingResponses.AccessHeaders).FullName,
                typeof(xBDD.Features.StreamliningAPITesting.StreamliningAPITesting.ValidatingResponses.AccessCookies).FullName,
                typeof(xBDD.Features.StreamliningAPITesting.StreamliningAPITesting.ValidatingResponses.ValidateAResponseAgainstATemplate).FullName,
                typeof(xBDD.Features.StreamliningAPITesting.StreamliningAPITesting.ValidatingResponses.CaptureATemplateFromAResponse).FullName,
            };

            this.SortedFeatureNames = SortedFeatureNames.ToArray();

        }
    }
}
