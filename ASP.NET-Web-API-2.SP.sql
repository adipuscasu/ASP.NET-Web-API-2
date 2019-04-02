
IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'User_GetByUserName') ) 
BEGIN
    DROP PROCEDURE User_GetByUserName
END

GO

CREATE PROCEDURE User_GetByUserName(@userName as nvarchar(250))
AS
BEGIN
    SELECT GOT_USER_USERNAME
    , GOT_USER_PASSWORD
    FROM GOT_USER
    WHERE GOT_USER_USERNAME = @userName;
    
END

GO


IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'User_Save') ) 
BEGIN
    DROP PROCEDURE User_Save
END

GO

CREATE PROCEDURE User_Save(
@userId as int
	, @userName as nvarchar(100)
	, @password as nvarchar(250)
	, @active as bit
	, @guid as uniqueidentifier
	, @createdDate as datetime
	, @loginFail as int
	, @passwordChanged as datetime
	, @emailConfirmed as bit
	, @phoneNumberConfirmed as bit
	, @twoFactorEnabled as bit
	, @lockOutEndDate as datetime
	, @lockOutEnabled as bit
	, @securityStamp as nvarchar(max)
)
AS
BEGIN
	IF(@userId is null)
	BEGIN
		INSERT INTO GOT_USER
			   (GOT_USER_USERNAME
			   ,GOT_USER_PASSWORD
			   ,GOT_USER_ACTIVE
			   ,GOT_USER_GUID
			   ,GOT_USER_CREATED_DATE
			   ,GOT_USER_LOGINFAIL
			   ,GOT_USER_PASSWORD_CHANGED
			   ,GOT_USER_EMAIL_CONFIRMED
			   ,GOT_USER_PHONE_NUMBER_CONFIRMED
			   ,GOT_USER_TWO_FACTOR_ENABLED
			   ,GOT_USER_LOCKOUT_END_DATE
			   ,GOT_USER_LOCKOUT_ENABLED
			   ,GOT_USER_SECURITY_STAMP)
		 VALUES
			   (
			   @userName
			   , @password
			   , @active
			   , @guid
			   , @createdDate
			   , @loginFail
			   , @passwordChanged
			   , @emailConfirmed
			   , @phoneNumberConfirmed
			   , @twoFactorEnabled
			   , @lockOutEndDate
			   , @lockOutEnabled
			   , @securityStamp
			   );

			   SELECT SCOPE_IDENTITY() AS GOT_USER_ID;
	END
	ELSE
	BEGIN
		UPDATE GO_USER
		SET GO_USER_ID = @userId
		, GOT_USER_USERNAME = @userName
		, GO_USER_PASSWORD = @password
		, GOT_USER_ACTIVE = @active
		, GOT_USER_GUID = @guid
		, GOT_USER_CREATED_DATE = @createdDate
		, GOT_USER_LOGINFAIL = @loginFail
		, GOT_USER_PASSWORD_CHANGED = @passwordChanged
		, GOT_USER_EMAIL_CONFIRMED = @emailConfirmed
		, GOT_USER_PHONE_NUMBER_CONFIRMED = @phoneNumberConfirmed
		, GOT_USER_TWO_FACTOR_ENABLED = @twoFactorEnabled
		, GOT_USER_LOCKOUT_END_DATE = @lockOutEndDate
		, GOT_USE_LOCKOUT_ENABLED = @lockOutEnabled
		, GOT_USER_SECURITY_STAMP = @securityStamp;

		SELECT @userId AS GOT_USER_ID;

	END
END

GO