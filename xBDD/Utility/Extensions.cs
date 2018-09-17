using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace xBDD.Utility
{
	using System;
    /// <summary>
    /// Extension methods for core processing.
    /// </summary>
    public static class Extensions
    {
        internal static string FirstCharToUpper(this string input)
        {
            return input.First().ToString().ToUpper() + input.Substring(1);
        }
        /// <summary>
        /// Converts a namespace to an capability name by replacing "." with " - ".
        /// </summary>
        /// <param name="text">The namespace value.</param>
        /// <returns>A matching Capability name.</returns>
        public static string ConvertNamespaceToCapabilityName(this string text)
        {
            return text.AddSpacesToSentence().Replace(".", " - ");
        }

		/// <summary>
		/// Removes a set number of tabs from the beginning of each line of text in the 
		/// string provided.  Also removed first line if it is empty.
		/// </summary>
		/// <param name="text">The multiline string to remove tabs from the beginning of each line.</param>
		/// <param name="indentation">The number of tabs to remove from the beginning of each line.</param>
		/// <param name="removeFirstLine">Instructs the operation to remove the first line from the string.</param>
		/// <returns></returns>
		public static string RemoveIndentation(this string text, int indentation, bool removeFirstLine = false) {
			StringBuilder sb = new StringBuilder();
			if(indentation > 0) {
				string[] lines = text.Split(new[] { System.Environment.NewLine }, StringSplitOptions.None);
				for(int i = 0; i < lines.Length; i++) {
					var lastLine = i == lines.Length - 1;
					if(i==0) {
						if(!removeFirstLine) {
							sb.AppendLine(lines[i]);
						}
					} else {
						if(lines[i].Length == 0) {
							if(!lastLine) {
								sb.AppendLine();
							}
						} else {
							if(lines[i].Length <= indentation) {
								if(!lastLine) {
									sb.AppendLine();
								}
							} else {
								var lineContent = lines[i].Substring(indentation,lines[i].Length-(indentation));
								if(lastLine) {
									sb.Append(lineContent);
								} else {
									sb.AppendLine(lineContent);
								}
							}
						} 
					}
				}
			} else {
				sb.Append(text);
			}
			return sb.ToString();;
		}

		/// <summary>
		/// Adds a set number of tabs in the beginning of each line of text in the 
		/// string provided. Also adds a blank line at the beginning.
		/// </summary>
		/// <param name="text">The multiline string to add tabs to the beginning of each line.</param>
		/// <param name="indentation">The number of tabs to add to the beginning of each line.</param>
		/// <returns></returns>
		public static string AddIndentation(this string text, int indentation) {
			StringBuilder sb = new StringBuilder();
			if(indentation > 0) {
				string[] lines = text.Split(new[] { System.Environment.NewLine }, StringSplitOptions.None);
				var lineCount = lines.Length;
				if(lines[lines.Length-1].Length == 0) {
					lineCount = lineCount-1;
				}
				for(int i = 0; i < lineCount; i++) {
					if(i != 0) {
						for(int n = 0; n < indentation; n++) {
							sb.Append("\t");
						}
					}
					if(i == lineCount-1) {
						sb.Append(lines[i]);
					} else {
						sb.AppendLine(lines[i]);
					}
				}
			} else {
				sb.Append(text);
			}
			return sb.ToString();;
		}

		/// <summary>
		/// Adds a set number of tabs in the beginning of each line of text in the 
		/// string provided. Also adds a blank line at the beginning.
		/// </summary>
		/// <param name="text">The multiline string to add tabs to the beginning of each line.</param>
		/// <param name="prefix">The number of tabs to add to the beginning of each line.</param>
		/// <returns></returns>
		public static string PrependLines(this string text, string prefix) {
			StringBuilder sb = new StringBuilder();
			if(prefix.Length > 0) {
				string[] lines = text.Split(new[] { System.Environment.NewLine }, StringSplitOptions.None);
				var lineCount = lines.Length;
				if(lines[lines.Length-1].Length == 0) {
					lineCount = lineCount-1;
				}
				for(int i = 0; i < lineCount; i++) {
					sb.Append(prefix);
					if(i == lineCount-1) {
						sb.Append(lines[i]);
					} else {
						sb.AppendLine(lines[i]);
					}
				}
			} else {
				sb.Append(text);
			}
			return sb.ToString();;
		}

        /// <summary>
        /// Converts an capability name to a namespace to replacing " - " with ".".
        /// </summary>
        /// <param name="text">The capability name value.</param>
        /// <returns>A matching namespace.</returns>
        internal static string ConvertCapabilityNameToNamespace(this string text)
        {
			var hashTagIndex = text.IndexOf('#');
			var atTagIndex = text.IndexOf('@');
			if(hashTagIndex > -1 || atTagIndex > -1) {
				var least = hashTagIndex > -1 ? hashTagIndex : atTagIndex;
				if(atTagIndex > -1 && atTagIndex < least) {
					least = atTagIndex;
				}
				text = text.Substring(0, least - 1);
			}
            List<string> words = new List<string>(text.Trim().Split(' '));
            StringBuilder sb = new StringBuilder();
            words.ForEach(word => {
                if(word == "-") {
                    sb.Append(".");
                } else {
                    sb.Append(word.FirstCharToUpper()); 
                }
            });
            return sb.ToString();
        }

        internal static string ConvertFeatureNameToClassName(this string text)
        {
			var hashTagIndex = text.IndexOf('#');
			var atTagIndex = text.IndexOf('@');
			if(hashTagIndex > -1 || atTagIndex > -1) {
				var least = hashTagIndex > -1 ? hashTagIndex : atTagIndex;
				if(atTagIndex > -1 && atTagIndex < least) {
					least = atTagIndex;
				}
				text = text.Substring(0, least - 1);
			}
            List<string> words = new List<string>(text.Trim().Split(' '));
            StringBuilder sb = new StringBuilder();
            words.ForEach(word => {
               sb.Append(word.FirstCharToUpper()); 
            });
            return sb.ToString();
        }

        internal static string ConvertScenarioNameToMethodName(this string text)
        {
			List<string> matches = new List<string>();
			foreach (Match match in Regex.Matches(text, @".+?(?= [#@])"))
			{
				matches.Add(match.Value);
			}
			var scenarioName = matches.FirstOrDefault();
			if(String.IsNullOrEmpty(scenarioName)) {
				scenarioName = text;
			}
			return scenarioName.ConvertFeatureNameToClassName();
        }

        internal static string ExtractReason(this string text)
        {
			List<string> tags = new List<string>();
			foreach (Match match in Regex.Matches(text, @"(?<=#R-)\w+"))
			{
				tags.Add(match.Value);
			}
            return tags.FirstOrDefault();
        }

        internal static string[] ExtractAssignments(this string text)
        {
			List<string> owners = new List<string>();
			foreach (Match match in Regex.Matches(text, @"(?<=@)\w+"))
			{
				owners.Add(match.Value);
			}
            return owners.ToArray();
        }

        internal static string[] ExtractTags(this string text)
        {
			List<string> owners = new List<string>();
			foreach (Match match in Regex.Matches(text, @"(?<=#T-)\w+"))
			{
				owners.Add(match.Value);
			}
            return owners.ToArray();
        }

        /// <summary>
        /// Adds spaces to a string of words that have no spaces but use Camel Case.
        /// </summary>
        /// <param name="text">The camel case string to add spaces to.</param>
        /// <returns></returns>
        internal static string AddSpacesToSentence(this string text)
        {
            text = text.Replace('_', ' ');
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;
            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            char? lastChar = null;
            for (int i = 1; i < text.Length; i++)
            {
                char currentChar = text[i];
                char? nextChar = null;
                if ((i+1) < text.Length)
                    nextChar = text[i + 1];
                var charIsUpperLetter = char.IsLetter(currentChar) && char.IsUpper(currentChar);
                //var nextCharIsNotUpperLetter = (nextChar.HasValue ? !(char.IsLetter(nextChar.Value) && char.IsUpper(nextChar.Value)) : false);
                //var lastCharIsNotAnUpperLetter = (lastChar.HasValue? !(char.IsLetter(lastChar.Value) && char.IsUpper(lastChar.Value)) : false);
                //var lastCharIsNotSpace = (lastChar.HasValue ? lastChar.Value != ' ' : true);
                var lastCharIsLowerLetter = (lastChar.HasValue ? char.IsLetter(lastChar.Value) && char.IsLower(lastChar.Value) : false);
                var lastCharIsUpperLetter = (lastChar.HasValue ? char.IsLetter(lastChar.Value) && char.IsUpper(lastChar.Value) : false);
                var nextCharIsLowerLetter = (nextChar.HasValue ? char.IsLetter(nextChar.Value) && char.IsLower(nextChar.Value) : false);
                var charIsLetter = char.IsLetter(currentChar);
                var lastCharIsLetter = (lastChar.HasValue ? char.IsLetter(lastChar.Value) : false);
                var nextCharIsLetter = (nextChar.HasValue ? char.IsLetter(nextChar.Value) : false);
                var charIsNumber = char.IsDigit(currentChar);
                var lastCharIsNumber = (lastChar.HasValue ? char.IsDigit(lastChar.Value) : false);
                var nextCharIsNumber = (nextChar.HasValue ? char.IsDigit(nextChar.Value) : false);

                var shouldAddSpace =
                    (lastCharIsLowerLetter && charIsUpperLetter) || //aB
                    (lastCharIsUpperLetter && charIsUpperLetter && nextCharIsLowerLetter) || //BBa
                    (lastCharIsLetter && charIsNumber) || //a1
                    (lastCharIsNumber && charIsLetter);
                if (shouldAddSpace)
                    newText.Append(' ');

                newText.Append(text[i]);
                lastChar = currentChar;
            }
            return newText.ToString();
        }
    }
}
