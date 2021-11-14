::Paso 1 crear DB
::sqllocaldb.exe c "SmApiDB"
::sqllocaldb.exe share "SmApiDB" "SharedSmApiDB"
::sqllocaldb.exe start "SmApiDB"
::sqllocaldb.exe info "SmApiDB"
::pause

::Crear Login
sqlcmd -S np:\\.\pipe\LOCALDB#D7611B11\tsql\query
CREATE LOGIN UserSm WITH PASSWORD = 'sM5JSD*7@#';
GO
CREATE USER UserSm;
GO
EXIT

PAUSE





Cambiar la contrasena del sa
GO
ALTER LOGIN [sa] WITH PASSWORD = 'tRE2425188*';
GO
ALTER LOGIN [sa] ENABLE; 




