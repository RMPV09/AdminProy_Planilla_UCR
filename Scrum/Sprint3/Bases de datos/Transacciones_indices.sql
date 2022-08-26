--Índices
CREATE INDEX idx_AgreementEmployerEmail_ProjectName
ON Agreement(EmployerEmail, ProjectName)

CREATE INDEX idx_AgreementEmployeeEmail_IsEnabled
ON Agreement(EmployeeEmail,IsEnabled)

CREATE NONCLUSTERED INDEX idx_subscriptionsIsEnabled
ON Subscription (IsEnabled,TypeSubscription)
INCLUDE (SubscriptionName, SubscriptionDescription, Cost)

--Transacción
CREATE OR ALTER PROCEDURE DeleteSubscription(
	@EmployerEmail varchar(255),
	@ProjectName varchar(255),
	@SubscriptionName varchar(255)
) AS
BEGIN
	set implicit_transactions off;

	set transaction isolation level
	serializable;

	BEGIN TRANSACTION DeleteTransaction
		BEGIN TRY
			UPDATE Subscription
			SET IsEnabled = 0
			WHERE EmployerEmail= @EmployerEmail AND ProjectName = @ProjectName AND SubscriptionName = @SubscriptionName;

			DECLARE @EmployeeEmail varchar(255)
			DECLARE @StartDate datetime
			DECLARE cursor_Subscribes CURSOR FOR
			SELECT EmployeeEmail, StartDate
			FROM Subscribes WHERE EmployerEmail = @EmployerEmail AND ProjectName = @ProjectName AND SubscriptionName = @SubscriptionName
			OPEN cursor_Subscribes
				FETCH NEXT FROM cursor_Subscribes INTO @EmployeeEmail, @StartDate
				WHILE @@FETCH_STATUS = 0 BEGIN
					DELETE FROM Subscribes WHERE  EmployeeEmail = @EmployeeEmail AND EmployerEmail = @EmployerEmail AND ProjectName = @ProjectName AND SubscriptionName = @SubscriptionName AND StartDate = @StartDate
					FETCH NEXT FROM cursor_Subscribes INTO @EmployeeEmail, @StartDate
				END
			CLOSE cursor_Subscribes
			DEALLOCATE cursor_Subscribes
			COMMIT TRANSACTION DeleteTransaction;
		END TRY
       BEGIN CATCH
			ROLLBACK TRANSACTION DeleteTransaction;
       END CATCH
END