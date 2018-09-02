namespace xBDD.Features.GeneratingCode.Interfaces
{
	public class FileSystem
	{
		public myGeneratedSample_Features MyGeneratedSample_Features => new myGeneratedSample_Features();
		public class myGeneratedSample_Features {
			public FileMetadata MyGeneratedSample_Features_csproj => new FileMetadata() {
				FilePath = "./MyGeneratedSample.Features/MyGeneratedSample.Features.csproj",
				TemplatePath = "./../../../Interfaces/Files/ProjectFileTemplates/MyGeneratedSample.Features.csproj.tmpl",
				ModifiedComment = $"<!-- Modified -->{System.Environment.NewLine}"
			};
			public FileMetadata MyGeneratedSample_Features_csproj_xbdd => new FileMetadata() {
				FilePath = "./MyGeneratedSample.Features/MyGeneratedSample.Features.csproj.xbdd",
				TemplatePath = "./../../../Interfaces/Files/ProjectFileTemplates/MyGeneratedSample.Features.csproj.xbdd.tmpl",
				ModifiedComment = $"<!-- Modified -->{System.Environment.NewLine}"
			};
			public FileMetadata xBDDInitializeAndComplete_cs => new FileMetadata() {
				FilePath = "./MyGeneratedSample.Features/xBDDInitializeAndComplete.cs",
				TemplatePath = "./../../../Interfaces/Files/ProjectFileTemplates/xBDDInitializeAndComplete.cs.tmpl",
				ModifiedComment = $"// Modified{System.Environment.NewLine}"
			};
			public FileMetadata xBddConfig_json => new FileMetadata() {
				FilePath = "./MyGeneratedSample.Features/xBddConfig.json",
				TemplatePath = "./../../../Interfaces/Files/ProjectFileTemplates/xBddConfig.json.tmpl",
				ModifiedComment = $"{System.Environment.NewLine}"
			};
			public FileMetadata xBddConfigWithTestRunName_json => new FileMetadata() {
				FilePath = "./MyGeneratedSample.Features/xBddConfig.json",
				TemplatePath = "./../../../Interfaces/Files/ProjectFileTemplates/xBddConfigWithTestRunName.json.tmpl",
				ModifiedComment = $"{System.Environment.NewLine}"
			};
			public FileMetadata xBddConfigWithRemoveAreaName_json => new FileMetadata() {
				FilePath = "./MyGeneratedSample.Features/xBddConfig.json",
				TemplatePath = "./../../../Interfaces/Files/ProjectFileTemplates/xBddConfigWithRemoveAreaName.json.tmpl",
				ModifiedComment = $"{System.Environment.NewLine}"
			};
			public FileMetadata xBddFeatureBase_xbdd_cs => new FileMetadata() {
				FilePath = "./MyGeneratedSample.Features/xBddFeatureBase.xbdd.cs",
				TemplatePath = "./../../../Interfaces/Files/ProjectFileTemplates/xBddFeatureBase.xbdd.cs.tmpl",
				ModifiedComment = $"// Modified{System.Environment.NewLine}"
			};
			public FileMetadata xBddSorting_xbdd_cs => new FileMetadata() {
				FilePath = "./MyGeneratedSample.Features/xBddSorting.xbdd.cs",
				TemplatePath = "./../../../Interfaces/Files/ProjectFileTemplates/xBddSorting.xbdd.cs.tmpl",
				ModifiedComment = $"// Modified{System.Environment.NewLine}"
			};
			public FileMetadata xBddSorting_cs => new FileMetadata() {
				FilePath = "./MyGeneratedSample.Features/xBddSorting.cs",
				TemplatePath = "./../../../Interfaces/Files/ProjectFileTemplates/xBddSorting.cs.tmpl",
				ModifiedComment = $"// Modified{System.Environment.NewLine}"
			};
			public FileMetadata xBddFeatureImport_txt => new FileMetadata() {
				FilePath = "./MyGeneratedSample.Features/xBddFeatureImport.txt",
				TemplatePath = "./../../../Interfaces/Files/ProjectFileTemplates/xBddFeatureImport.txt.tmpl",
				ModifiedComment = $"// Modified{System.Environment.NewLine}"
			};
			public FileMetadata Features_MySampleArea_MySampleFeature_cs => new FileMetadata() {
				FilePath = "./MyGeneratedSample.Features/Features/MyArea/MyFeature.cs",
				TemplatePath = "./../../../Interfaces/Files/ProjectFileTemplates/MyFeature.cs.tmpl",
				ModifiedComment = $"// Modified{System.Environment.NewLine}"
			};
			public FileMetadata Features_MySampleArea_MySampleFeature_xbdd_cs => new FileMetadata() {
				FilePath = "./MyGeneratedSample.Features/Features/MyArea/MyFeature.xbdd.cs",
				TemplatePath = "./../../../Interfaces/Files/ProjectFileTemplates/MyFeature.xbdd.cs.tmpl",
				ModifiedComment = $"// Modified{System.Environment.NewLine}"
			};
		}
		public InvalidOutlines InvalidOutline => new InvalidOutlines();
		public class InvalidOutlines {
			public const string baseUri = "./../../../Interfaces/Files/InvalidFeatureImportFiles";
			public FileMetadata WithADuplicateFeature => new FileMetadata() { 
					FilePath = $"{baseUri}/WithADuplicateFeature.txt",
					StepNameAddition = "with a duplicate feature"
				};
			public FileMetadata WithADuplicateScenario => new FileMetadata() { 
					FilePath = $"{baseUri}/WithADuplicateScenario.txt",
					StepNameAddition = "with a duplicate scenario"
				};
			public FileMetadata WithAFeatureWithAnInvalidChildLine => new FileMetadata() { 
					FilePath = $"{baseUri}/WithAFeatureWithAnInvalidChildLine.txt",
					StepNameAddition = "with a feature with an invalid child line"
				};
			public FileMetadata WithAFeatureWithInvalidCharactersInTheName => new FileMetadata() { 
					FilePath = $"{baseUri}/WithAFeatureWithInvalidCharactersInTheName.txt",
					StepNameAddition = "with a feature with invalid characters in the name"
				};
			public FileMetadata WithAFeatureWithNoName => new FileMetadata() { 
					FilePath = $"{baseUri}/WithAFeatureWithNoName.txt",
					StepNameAddition = "with a feature with no name"
				};
			public FileMetadata WithAnAreaWithAnInvalidChildLine => new FileMetadata() { 
					FilePath = $"{baseUri}/WithAnAreaWithAnInvalidChildLine.txt",
					StepNameAddition = "with an area with an invalid child line"
				};
			public FileMetadata WithAnAreaWithInvalidCharactersInTheName => new FileMetadata() { 
					FilePath = $"{baseUri}/WithAnAreaWithInvalidCharactersInTheName.txt",
					StepNameAddition = "with an area with invalid characters in the name"
				};
			public FileMetadata WithAnAreaWithNoName => new FileMetadata() { 
					FilePath = $"{baseUri}/WithAnAreaWithNoName.txt",
					StepNameAddition = "with an area with no name"
				};
			public FileMetadata WithAScenarioWithAnInvalidChildLine => new FileMetadata() { 
					FilePath = $"{baseUri}/WithAScenarioWithAnInvalidChildLine.txt",
					StepNameAddition = "with a scenario with an invalid child line"
				};
			public FileMetadata WithAScenarioWithInvalidCharactersInTheName => new FileMetadata() { 
					FilePath = $"{baseUri}/WithAScenarioWithInvalidCharactersInTheName.txt",
					StepNameAddition = "with a scenario with invalid characters in the name"
				};
			public FileMetadata WithAScenarioWithNoName => new FileMetadata() { 
					FilePath = $"{baseUri}/WithAScenarioWithNoName.txt",
					StepNameAddition = "with a scenario with no name"
				};
			public FileMetadata WithAStepWithAnInvalidChildLine => new FileMetadata() { 
					FilePath = $"{baseUri}/WithAStepWithAnInvalidChildLine.txt",
					StepNameAddition = "with a step with an invalid child line"
				};
			public FileMetadata WithAStepWithNoName => new FileMetadata() { 
					FilePath = $"{baseUri}/WithAStepWithNoName.txt",
					StepNameAddition = "with a step with no name"
				};
			public FileMetadata WithNoAreasAKAEmpty => new FileMetadata() { 
					FilePath = $"{baseUri}/WithNoAreasAKAEmpty.txt",
					StepNameAddition = "with no areas (aka empty file)"
				};
			public FileMetadata WithNoFeatures => new FileMetadata() { 
					FilePath = $"{baseUri}/WithNoFeatures.txt",
					StepNameAddition = "with no features"
				};
			public FileMetadata WithNoScenarios => new FileMetadata() { 
					FilePath = $"{baseUri}/WithNoScenarios.txt",
					StepNameAddition = "with no scenarios"
				};
		}

		public class ExceptionOutputs {
			public const string baseUri = "./../../../Interfaces/Files/InvalidFeatureImportFiles";
			public const string outputPath = "./MyGeneratedSample.Features/output.txt";
			public FileMetadata NoAreasAKAEmpty => new FileMetadata() {
				FilePath = outputPath,
				TemplatePath = $"{baseUri}/WithNoAreasAKAEmpty.tmpl",
				StepNameAddition = "No Areas (AKA Empty)"
			};
		}
	}
}