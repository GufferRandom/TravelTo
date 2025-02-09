IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'DemoAspnet')
BEGIN
    CREATE DATABASE [DemoAspnet];
END