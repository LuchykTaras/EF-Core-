CREATE VIEW vw_ActiveWizards AS
SELECT WizardsId, [Name], House, BloodStatus
FROM Wizards
WHERE IsActive = 1;