USE [Diplomna5]
GO
/****** Object:  StoredProcedure [dbo].[GetSkill]    Script Date: 08/28/2018 15:59:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER  PROCEDURE [dbo].[GetSkill]
@pId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT 
Skills_ID,
Skills_Name	
FROM Skills
WHERE 
	Skills_ID = @pId
END

