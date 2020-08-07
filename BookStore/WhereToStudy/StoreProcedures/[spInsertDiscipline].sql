USE [Diplomna5]
GO
/****** Object:  StoredProcedure [dbo].[spInsertDiscipline]    Script Date: 08/28/2018 16:01:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER  PROCEDURE [dbo].[spInsertDiscipline]
	@pSpecialty_ID int,
	@pDiscipline_Name nvarchar(50),
	@pDiscipline_Semester int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	

INSERT INTO Disciplines VALUES(@pSpecialty_ID,
@pDiscipline_Name,@pDiscipline_Semester)

END

