USE [Diplomna5]
GO
/****** Object:  StoredProcedure [dbo].[InsertDisciplineSkills]    Script Date: 08/28/2018 16:00:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER  PROCEDURE [dbo].[InsertDisciplineSkills]
	@pskillID int,
	@pdisciplineId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	

INSERT INTO Discipline_Skills VALUES(@pskillID,@pdisciplineId)

END

