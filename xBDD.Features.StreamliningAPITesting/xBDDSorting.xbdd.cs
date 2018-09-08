namespace xBDD.Features.StreamliningAPITesting
{
	using System;
	using System.Collections.Generic;
	using xBDD;

	public partial class xBDDSorting: ISorting
	{
		public List<string> GetGeneratedSortedFeatureNames() {
			return new List<string>() {
				typeof(xBDD.Features.StreamliningAPITesting.IssuingRequests.IssueAGet).FullName,
				typeof(xBDD.Features.StreamliningAPITesting.IssuingRequests.IssueAPost).FullName,
				typeof(xBDD.Features.StreamliningAPITesting.IssuingRequests.IssueAPut).FullName,
				typeof(xBDD.Features.StreamliningAPITesting.IssuingRequests.IssueADelete).FullName,
				typeof(xBDD.Features.StreamliningAPITesting.IssuingRequests.ModifyTheHeaders).FullName,
				typeof(xBDD.Features.StreamliningAPITesting.IssuingRequests.ModifyTheBody).FullName,
				typeof(xBDD.Features.StreamliningAPITesting.IssuingRequests.ModifyTheCookies).FullName,
				typeof(xBDD.Features.StreamliningAPITesting.ValidatingResponses.ValidateAResponseCode).FullName,
				typeof(xBDD.Features.StreamliningAPITesting.ValidatingResponses.FollowA300Response).FullName,
				typeof(xBDD.Features.StreamliningAPITesting.ValidatingResponses.ProcessA500Response).FullName,
				typeof(xBDD.Features.StreamliningAPITesting.ValidatingResponses.ProcessA400Response).FullName,
				typeof(xBDD.Features.StreamliningAPITesting.ValidatingResponses.ProcessA200Response).FullName,
				typeof(xBDD.Features.StreamliningAPITesting.ValidatingResponses.AccessHeaders).FullName,
				typeof(xBDD.Features.StreamliningAPITesting.ValidatingResponses.AccessCookies).FullName,
				typeof(xBDD.Features.StreamliningAPITesting.ValidatingResponses.ValidateAResponseAgainstATemplate).FullName,
				typeof(xBDD.Features.StreamliningAPITesting.ValidatingResponses.CaptureATemplateFromAResponse).FullName,
			};
		}
		public List<string> GetGeneratedReasons() {
			return new List<string>() {
				"Defining",
			};
		}
	}
}