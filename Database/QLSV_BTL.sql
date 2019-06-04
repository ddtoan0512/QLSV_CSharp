CREATE DATABASE QLSV_BTL

USE QLSV_BTL
/* Quan Ly Sinh Vien */
CREATE TABLE tblSVIEN(
MaSV varchar(8) PRIMARY KEY Not Null,
TenSV nvarchar(30) not null,
GioiTinh nvarchar(5),
NgaySinh varchar(20),
Lop varchar(10),
Diem decimal(10,1),
DiaChi nvarchar(30),
)
DROP TABLE tblSVIEN

/*Quan Ly Tai Khoan*/
CREATE TABLE TaiKhoan(
id varchar(10) PRIMARY KEY NOT NULL,
pass varchar(30) NOT NULL,
)
DROP TABLE TaiKhoan

SELECT * FROM tblSVIEN

/*Quan Ly Lop*/
CREATE TABLE tblLop
(
	MaLop varchar(10) PRIMARY KEY not null,
	TenLop Nvarchar(30),
	Khoa Nvarchar(50)
)
DROP TABLE tblLop

ALTER TABLE tblLop
 ADD Khoa VARCHAR(50);


SELECT * FROM tblTaiKhoan
