
IF  EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'User_GetByUserName') ) 
BEGIN
    DROP PROCEDURE User_GetByUserName
END

GO

CREATE procedure User_GetByUserName(@userName as nvarchar(250))
AS
BEGIN
    SELECT GOT_USER_USERNAME
    , GOT_USER_PASSWORD
    , GOT_USER_SALT
    FROM GOT_USER
    WHERE GOT_USER_USERNAME = @userName;
    
END

GO