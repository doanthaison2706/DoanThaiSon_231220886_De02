create database DoanThaiSon_231220886_de02;


use  DoanThaiSon_231220886_de02;

create table DtsCatalog (
	dtsId nvarchar(20) primary key,
    dtsCateName nvarchar(50),
    dtsCatePrice int,
    dtsCateQty int, 
    dtsCatePicture nvarchar(100),
    dtsCateActive bit
);

create database DoanThaiSon_231220886_de02;


insert into DtsCatalog values
('DTS001', 'Iphone 14 Pro Max', 30000000, 50, 'iphone14promax.jpg', 1),
('DTS002', 'Samsung Galaxy S23 Ultra', 28000000, 40, 'samsungs23ultra.jpg', 1),
('DTS003', 'Xiaomi Mi 13 Pro', 20000000, 30, 'xiaomimi13pro.jpg', 1),
('DTS004', 'Oppo Find X5 Pro', 22000000, 20, 'oppofindx5pro.jpg', 1),
('DTS005', 'Vivo X80 Pro', 21000000, 25, 'vivox80pro.jpg', 1);

-- Nhập thông tin sinh viên 
insert into DtsCatalog values
('DTS000', N'Đoàn Thái Sơn', 25000000, 1, 'doanthaison.jpg', 1)