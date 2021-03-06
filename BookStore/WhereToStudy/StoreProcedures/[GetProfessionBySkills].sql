USE [Diplomna5]
GO
/****** Object:  StoredProcedure [dbo].[GetProfessionBySkills]    Script Date: 08/28/2018 15:59:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[GetProfessionBySkills]
	@pskillID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
SELECT 
	p.Profession_ID,
	p.Profession_Name
FROM 
  Professions p
LEFT JOIN Profession_Skills ps ON p.Profession_ID = ps.Profession_ID
Where ps.Skills_ID = @pskillID

END

