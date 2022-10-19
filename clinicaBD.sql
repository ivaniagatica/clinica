



create database AGREGAR_CITAS

use AGREGAR_CITAS


CREATE TABLE citas(
Idcitas int identity primary key,
nombre varchar(100),
telefono varchar(100),
correo varchar(100),
comentario varchar(100)
)

create procedure sp_listar
as
begin
     select * from citas
end


create procedure sp_obtener(
@Idcitas int
)
as
begin 
    select * from citas where Idcitas = @Idcitas
end

create procedure sp_guardar(
@nombre varchar(100),
@telefono varchar(100),
@correo varchar(100),
@comentario varchar(100)
)
as 
 begin 
     insert into citas (nombre,telefono,correo,comentario) values (@nombre,@telefono,@correo,@comentario)
	 end


create procedure sp_editar(
@Idcitas int,
@nombre varchar(100),
@telefono varchar(100),
@correo varchar(100),
@comentario varchar(100)
)
as
  begin 
      update citas set nombre = @nombre, telefono = @telefono, correo = @correo, comentario = @comentario where Idcitas = @Idcitas
end


create procedure sp_eliminar(
@Idcitas int
)
as
begin
    delete from citas where Idcitas = @Idcitas
end

