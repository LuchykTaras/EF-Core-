CREATE VIEW vw_ActiveWizard
AS
SELECT w.WizardId, w.[Name], w.House, w.BloodStatus
FROM Wizards w
WHERE IsActive = 1;