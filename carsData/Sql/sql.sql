-- Adding User Data on the Sql server via query --

-- Create Table auth_user (
--     Id int Not Null IDENTITY(1,1) Primary Key, 
--     UserName varchar(15) Not Null, 
--     UserEmail varchar(20) Not Null, 
--     UserPassword varchar(255) Not Null
--     );
-- Insert Into auth_user (
--     UserName,
--     UserEmail,
--     UserPassword
-- )
-- Values (
--     'Johnny',
--     'Jaohhnysomething.tech',
--     '34h23jksdfsdf4hlj42'
-- );
--============================================

--========{{ TEST }} ===============
-- Select * From auth_user;

-- ================================
-- Creating Procedures --
-- Create Proc auth_GetAll
-- AS
-- Select Id, UserName, UserEmail, UserPassword
-- From auth_user;
-- Create Proc auth_Update
-- AS
-- Select Id, UserName, UserEmail, UserPassword
-- From auth_user;
--=================================