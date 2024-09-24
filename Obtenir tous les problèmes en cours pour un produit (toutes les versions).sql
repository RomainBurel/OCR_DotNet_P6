USE [aspnet-53bc9b9d-9d6a-45d4-8429-2a2761773502]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[P_GET_TICKETS]
		@status = 1,
		@product = 1,
		@version = 3,
		@periodStart = N'12/12/2023',
		@periodEnd = N'09/09/2024',
		@keywords = N'Trader en Herbe'

SELECT	@return_value as 'Return Value'

GO
