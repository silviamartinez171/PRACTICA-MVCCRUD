Create database MVCCRUD
use MVCCRUD

CREATE TABLE USUARIOS(
Id int identity (1,1) primary key,
Nombre varchar(50),
Fecha date,
clave varchar(50)
)

CREATE TABLE NOTAEST(
Id int identity (1,1) primary key,
Carnet nvarchar(12),
Apellidos nvarchar(30),
Nombres nvarchar(30),
IPN smallint,
IIPN smallint,
SIST smallint,
PROYEC smallint,
NF smallint,
EXCI smallint,
NFCI smallint,
IIC smallint
)