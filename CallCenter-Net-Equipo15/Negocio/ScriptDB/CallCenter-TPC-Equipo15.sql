/*
Use Master
Go
Create Database CallCenter-TPC-Equipo15
go
Use CallCenter-TPC-Equipo15
go


Create Table Cliente() - Usuario?

Create Table Administrador()

Create Table Telefonista()

Create Table Supervisor()

Create Table Incidencias()

accesos?


Clientes:
ID
Nombre
Correo electrónico


Incidencias:
ID
Cliente
Tipo de incidencia
Prioridad
Problemática
Estado (Abierto, En Análisis, Cerrado, Reabierto, Asignado, Resuelto)
Fecha de creación
Última fecha de modificación
Comentario final de cierre


Usuarios:
ID 
Nombre de usuario
Contraseña
Rol (Administrador, Telefonista, Supervisor)


Asignaciones:
ID 
Usuario
Incidencia


Cambios de estado(para registrar los cambios de estado de las incidencias):
ID
Incidencia
Estado anterior
Nuevo estado
Fecha del cambio


Motivos de cierre (para registrar los motivos de cierre de las incidencias):
ID
Descripción del motivo


Seguimiento de correos electrónicos (para registrar los correos enviados a los clientes):

ID
Incidencia
Tipo de correo (Alta, Cierre, Resolución)
Fecha de envío
Contenido del correo electrónico

*/