namespace xBDD.Features.GeneratingCode.Interfaces
{
	public class FileSystem
	{
		public myGeneratedSample_Features MyGeneratedSample_Features => new myGeneratedSample_Features();
		public class myGeneratedSample_Features {
			public FileMetadata MyGeneratedSample_Features_csproj => new FileMetadata() {
				FilePath = "./MyGeneratedSample.Features/MyGeneratedSample.Features.csproj",
				TemplatePath = "./../../../Features/GeneratingProjectFiles/MyGeneratedSample.Features.csproj.tmpl",
				ModifiedComment = $"<!-- Modified -->{System.Environment.NewLine}"
			};
			public FileMetadata MyGeneratedSample_Features_csproj_xbdd => new FileMetadata() {
				FilePath = "./MyGeneratedSample.Features/MyGeneratedSample.Features.csproj.xbdd",
				TemplatePath = "./../../../Features/GeneratingProjectFiles/MyGeneratedSample.Features.csproj.xbdd.tmpl",
				ModifiedComment = $"<!-- Modified -->{System.Environment.NewLine}"
			};
			public FileMetadata xBDDInitializeAndComplete_cs => new FileMetadata() {
				FilePath = "./MyGeneratedSample.Features/xBDDInitializeAndComplete.cs",
				TemplatePath = "./../../../Features/GeneratingProjectFiles/xBDDInitializeAndComplete.cs.tmpl",
				ModifiedComment = $"// Modified{System.Environment.NewLine}"
			};
			public FileMetadata xBddConfig_json => new FileMetadata() {
				FilePath = "./MyGeneratedSample.Features/xBddConfig.json",
				TemplatePath = "./../../../Features/GeneratingProjectFiles/xBddConfig.json.tmpl",
				ModifiedComment = $"{System.Environment.NewLine}"
			};
			public FileMetadata xBddConfigWithTestRunName_json => new FileMetadata() {
				FilePath = "./MyGeneratedSample.Features/xBddConfig.json",
				TemplatePath = "./../../../Features/GeneratingProjectFiles/xBddConfigWithTestRunName.json.tmpl",
				ModifiedComment = $"{System.Environment.NewLine}"
			};
			public FileMetadata xBddConfigWithRemoveAreaName_json => new FileMetadata() {
				FilePath = "./MyGeneratedSample.Features/xBddConfig.json",
				TemplatePath = "./../../../Features/GeneratingProjectFiles/xBddConfigWithRemoveAreaName.json.tmpl",
				ModifiedComment = $"{System.Environment.NewLine}"
			};
			public FileMetadata xBddFeatureBase_xbdd_cs => new FileMetadata() {
				FilePath = "./MyGeneratedSample.Features/xBddFeatureBase.xbdd.cs",
				TemplatePath = "./../../../Features/GeneratingProjectFiles/xBddFeatureBase.xbdd.cs.tmpl",
				ModifiedComment = $"// Modified{System.Environment.NewLine}"
			};
			public FileMetadata xBddSorting_xbdd_cs => new FileMetadata() {
				FilePath = "./MyGeneratedSample.Features/xBddSorting.xbdd.cs",
				TemplatePath = "./../../../Features/GeneratingProjectFiles/xBddSorting.xbdd.cs.tmpl",
				ModifiedComment = $"// Modified{System.Environment.NewLine}"
			};
			public FileMetadata xBddSorting_cs => new FileMetadata() {
				FilePath = "./MyGeneratedSample.Features/xBddSorting.cs",
				TemplatePath = "./../../../Features/GeneratingProjectFiles/xBddSorting.cs.tmpl",
				ModifiedComment = $"// Modified{System.Environment.NewLine}"
			};
			public FileMetadata xBddFeatureImport_txt => new FileMetadata() {
				FilePath = "./MyGeneratedSample.Features/xBddFeatureImport.txt",
				TemplatePath = "./../../../Features/GeneratingProjectFiles/xBddFeatureImport.txt.tmpl",
				ModifiedComment = $"// Modified{System.Environment.NewLine}"
			};
			public FileMetadata Features_MySampleArea_MySampleFeature_cs => new FileMetadata() {
				FilePath = "./MyGeneratedSample.Features/Features/MyArea/MyFeature.cs",
				TemplatePath = "./../../../Features/GeneratingProjectFiles/MyFeature.cs.tmpl",
				ModifiedComment = $"// Modified{System.Environment.NewLine}"
			};
			public FileMetadata Features_MySampleArea_MySampleFeature_xbdd_cs => new FileMetadata() {
				FilePath = "./MyGeneratedSample.Features/Features/MyArea/MyFeature.xbdd.cs",
				TemplatePath = "./../../../Features/GeneratingProjectFiles/MyFeature.xbdd.cs.tmpl",
				ModifiedComment = $"// Modified{System.Environment.NewLine}"
			};
		}
	}
}