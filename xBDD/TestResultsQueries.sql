SELECT 
	tr.Id as TestRunId, 
	s.Id AS ScenarioId, 
	s.AreaPath, 
	s.FeatureName, 
	s.Name as ScenarioName, 
	s.Outcome as ScenarioOutcome,
	s.Reason as ScenarioReason,
	st.Id as StepId,
	st.Name as StepName,
	st.MultilineParameter as StepMultilineParameter,
	st.Outcome as StepOutcome,
	st.Reason as StepReason,
	s.StartTime as ScenarioStartTime, 
	s.EndTime as ScenarioEndTime,
	st.StartTime as StepStartTime,
	st.EndTime as StepEndTime
FROM TestRun tr
LEFT JOIN Scenario s
	ON tr.Id = s.TestRunId
LEFT JOIN Step st
	ON s.Id = st.ScenarioId
WHERE tr.Id > 21
  AND s.Outcome = 1
ORDER BY tr.Id ASC, s.EndTime ASC, st.EndTime ASC

SELECT 
	COUNT(Distinct(s.Id))
FROM TestRun tr
LEFT JOIN Scenario s
	ON tr.Id = s.TestRunId
LEFT JOIN Step st
	ON s.Id = st.ScenarioId
WHERE tr.Id > 21

SELECT 
	s.Outcome,
	COUNT(Distinct(s.Id))
FROM TestRun tr
LEFT JOIN Scenario s
	ON tr.Id = s.TestRunId
LEFT JOIN Step st
	ON s.Id = st.ScenarioId
WHERE tr.Id > 25
GROUP BY s.Outcome

SELECT TOP 4 Id
FROM TestRun
ORDER bY Id DESC

SELECT @@Version


SELECT * FROM TestRuns

SELECT * FROM Scenarios
