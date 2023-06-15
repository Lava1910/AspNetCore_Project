create table Phong_ban (
	Ma_PB char(10) Primary key,
	Ten_PB nvarchar(255) not null
);

create table Buu_cuc (
	Ma_BC char(10) Primary key,
	Ten_BC nvarchar(255) not null,
	Diachi_BC ntext not null,
	Sdt_BC varchar(255) not null
);

create table Account (
	id int Primary key identity(1,1),
	User_name nvarchar(255),
	User_email varchar(255) unique,
	User_password varchar(255),
	Role nvarchar(255)
);


create table Nhan_vien (
	Ma_NV int Primary key,
	Ten_NV nvarchar(255),
	Sdt_NV varchar(255),
	Email_NV varchar(255),
	Phong_ban char(10) foreign key references Phong_ban(Ma_PB),
	Buu_cuc char(10) foreign key references Buu_cuc(Ma_BC),
	User_id int foreign key references Account(id)
);

create table Khach_Hang (
	Ma_KH char(10) PRIMARY key,
	Ten_KH nvarchar(255),
	Sdt_KH varchar(255),
	Email_KH varchar(255),
	Diachi_KH ntext,
	User_id int foreign key references Account(id)
);

create table Dich_vu (
	Ma_DV char(10) primary key,
	Ten_DV nvarchar(255),
	Trong_luong char(10),
	Tuyen_DV nvarchar(255)
);

create table Bao_gia (
	Ma_BG char(10) primary key,
	Gia_DV decimal(10,2),
	Ma_DV char(10) foreign key references Dich_vu(Ma_DV)
);

create table Phieu_gui (
	Ma_PG char(10) primary key,
	Trong_luong char(10),
	Cuoc_phi float,
	Ngay_gui date,
	Ngay_nhan date
);

create table Don_hang (
	Ma_DH char(10) primary key,
	Trong_luong int,
	Dia_chi_nhan ntext,
	Dia_chi_gui ntext,
	Ngay_gui date,
	Ngay_nhan date,
	Bao_gia char(10) foreign key references Bao_gia(Ma_BG),
	Trang_thai nvarchar(255)
);


-- drop table Phong_ban;
-- drop table Buu_cuc;
-- drop table Account;
-- drop table Nhan_vien;
-- drop table Khach_Hang;
-- drop table Dich_vu;
-- drop table Bao_gia;
-- drop table Phieu_gui;
-- drop table Don_hang;





