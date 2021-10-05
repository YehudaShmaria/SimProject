CREATE VIEW [dbo].[OnlyUser]
	AS SELECT S.[SId], s.Unitname, s.Contact, COUNT(s.SId) as NumOfSim
	FROM Sim s
	group by 
	Unitname, Contact