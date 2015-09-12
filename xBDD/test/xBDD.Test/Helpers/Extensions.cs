using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace xBDD.Test.Helpers
{
    public static class Extensions
    {
        public static void ValidateToTemplate(this string target, string template)
        {
            List<MissMatch> misses = new List<MissMatch>();
            string[] targetLines = Regex.Split(target, "\r\n|\r|\n");
            string[] templateLines = Regex.Split(template, "\r\n|\r|\n");

            var maxLines = (targetLines.Length > templateLines.Length ? targetLines.Length : templateLines.Length);

            int templateIndex = 0;
            bool searchingForNextLine = false;
            for(int i = 0; i < maxLines; i++)
            {
                var isTemplateFinished = templateIndex == -1;

                if (isTemplateFinished)
                {
                    AddExtraTargetLineMiss(misses, targetLines, i);
                }
                else
                {
                    var pattern = templateLines[templateIndex];
                    pattern = AddPatternStartAndEnd(pattern);

                    if (IsLineWildCard(templateLines, templateIndex))
                    {
                        searchingForNextLine = true;

                        if (IsNotLastTemplateLine(templateLines, templateIndex))
                        {
                            pattern = IncrementTemplateIndexAndGetNextLineFromTemplate(templateLines, ref templateIndex);
                        }
                    }
                    if (IsExtraTemplateLine(targetLines, i))
                    {
                        AddExtraTemplateLineMiss(misses, templateIndex, pattern);
                    }
                    else
                    {
                        bool isMatch = IsMatch(targetLines, i, pattern);

                        if (IsMissAndNotWithinLineWildcard(searchingForNextLine, isMatch))
                        {
                            AddMissBetweenTwoLines(misses, targetLines, templateIndex, i, pattern);
                        }

                        searchingForNextLine = TurnOffSearchingForNextLineIfNecessary(searchingForNextLine, isMatch);

                        bool isLastTargetLine = i == targetLines.Length - 1;
                        bool isNotLastMatchLine = templateIndex != templateLines.Length - 1;

                        if (isLastTargetLine && isNotLastMatchLine)
                        {
                            misses.Add(new MissMatch()
                            {
                                TargetLineNumber = -1,
                                TargetLine = null,
                                TemplateLineNumber = templateIndex,
                                TemplateLine = RemovePatternStartAndEnd(pattern)
                            });
                        }

                        if (!searchingForNextLine && templateIndex < templateLines.Length - 1)
                        {
                            templateIndex++;
                        }
                        else if (templateIndex == templateLines.Length - 1)
                        {
                            templateIndex = -1;
                        }
                    }
                }
            }

            if (misses.Count > 0)
            {
                throw new TemplateValidationException(misses);
            }
        }

        private static bool IsMatch(string[] targetLines, int i, string pattern)
        {
            return Regex.Match(targetLines[i], pattern).Success;
        }

        private static bool IsMissAndNotWithinLineWildcard(bool searchingForNextLine, bool isMatch)
        {
            return !isMatch && !searchingForNextLine;
        }

        private static bool IsExtraTemplateLine(string[] targetLines, int i)
        {
            return i > targetLines.Length - 1;
        }

        private static bool IsNotLastTemplateLine(string[] templateLines, int templateIndex)
        {
            return (templateIndex + 1) != templateLines.Length;
        }

        private static bool IsLineWildCard(string[] templateLines, int templateIndex)
        {
            return templateLines[templateIndex] == "[.*]";
        }

        private static bool TurnOffSearchingForNextLineIfNecessary(bool searchingForNextLine, bool isMatch)
        {
            if (isMatch && searchingForNextLine)
                searchingForNextLine = false;
            return searchingForNextLine;
        }

        private static void AddMissBetweenTwoLines(List<MissMatch> misses, string[] targetLines, int templateIndex, int i, string pattern)
        {
            misses.Add(new MissMatch()
            {
                TargetLineNumber = i,
                TargetLine = targetLines[i],
                TemplateLineNumber = templateIndex,
                TemplateLine = RemovePatternStartAndEnd(pattern)
            });
        }

        private static void AddExtraTemplateLineMiss(List<MissMatch> misses, int templateIndex, string pattern)
        {
            misses.Add(new MissMatch()
            {
                TargetLineNumber = -1,
                TargetLine = null,
                TemplateLineNumber = templateIndex,
                TemplateLine = RemovePatternStartAndEnd(pattern)
            });
        }

        private static string IncrementTemplateIndexAndGetNextLineFromTemplate(string[] templateLines, ref int templateIndex)
        {
            string pattern;
            templateIndex++;
            pattern = templateLines[templateIndex];
            pattern = AddPatternStartAndEnd(pattern);
            return pattern;
        }

        private static void AddExtraTargetLineMiss(List<MissMatch> misses, string[] targetLines, int i)
        {
            misses.Add(new MissMatch()
            {
                TargetLineNumber = i,
                TargetLine = targetLines[i],
                TemplateLineNumber = -1,
                TemplateLine = null
            });
        }

        private static string AddPatternStartAndEnd(string pattern)
        {
            if (!pattern.StartsWith("^"))
                pattern = "^" + pattern;
            if (!pattern.EndsWith("$"))
                pattern = pattern + "$";
            return pattern;
        }
        private static string RemovePatternStartAndEnd(string pattern)
        {
            pattern = pattern.Substring(1, pattern.Length - 2);
            return pattern;
        }
    }
}
