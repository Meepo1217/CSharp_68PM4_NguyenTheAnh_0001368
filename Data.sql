USE qlsv;
GO

IF OBJECT_ID('tbl_sinhviens', 'U') IS NOT NULL
BEGIN
    DROP TABLE tbl_sinhviens;
END
GO

IF OBJECT_ID('tbl_lophocs', 'U') IS NOT NULL
BEGIN
    DROP TABLE tbl_lophocs;
END
GO

CREATE TABLE tbl_lophocs (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    malop NVARCHAR(20) NOT NULL UNIQUE,
    tenlop NVARCHAR(100) NOT NULL,
    ghichu NVARCHAR(255) NULL
);
GO

CREATE TABLE tbl_sinhviens (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    masv VARCHAR(10) NOT NULL,
    hoten NVARCHAR(100) NOT NULL,
    gioitinh NVARCHAR(20) NULL,
    ngaysinh DATE NOT NULL,
    malop NVARCHAR(20) NOT NULL,
    CONSTRAINT FK_tbl_sinhviens_tbl_lophocs FOREIGN KEY (malop) REFERENCES tbl_lophocs(malop)
);
GO

INSERT INTO tbl_lophocs (malop, tenlop, ghichu) VALUES 
('68PM1', N'Phần mềm 1 - Khóa 68', N'Lớp Demo 1'),
('68PM2', N'Phần mềm 2 - Khóa 68', N'Lớp Demo 2'),
('68PM3', N'Phần mềm 3 - Khóa 68', N'Lớp Demo 3'),
('68PM4', N'Phần mềm 4 - Khóa 68', N'Lớp của Nguyễn Thế Anh'),
('68PM5', N'Phần mềm 5 - Khóa 68', N'Lớp Demo 5'),
('68PM6', N'Phần mềm 6 - Khóa 68', N'Lớp Demo 6'),
('68PM7', N'Phần mềm 7 - Khóa 68', N'Lớp Demo 7'),
('68PM8', N'Phần mềm 8 - Khóa 68', N'Lớp Demo 8'),
('68PM9', N'Phần mềm 9 - Khóa 68', N'Lớp Demo 9'),
('68PM10', N'Phần mềm 10 - Khóa 68', N'Lớp Demo 10'),
('68PM11', N'Phần mềm 11 - Khóa 68', N'Lớp Demo 11'),
('68PM12', N'Phần mềm 12 - Khóa 68', N'Lớp Demo 12'),
('68PM13', N'Phần mềm 13 - Khóa 68', N'Lớp Demo 13'),
('68PM14', N'Phần mềm 14 - Khóa 68', N'Lớp Demo 14'),
('68PM15', N'Phần mềm 15 - Khóa 68', N'Lớp Demo 15');
GO

INSERT INTO tbl_sinhviens (masv, hoten, gioitinh, ngaysinh, malop) VALUES 
('SV001', N'Nguyễn Thế Anh', N'Nam', '2000-12-17', '68PM4'),
('SV002', N'Trần Thị B', N'Nữ', '2001-05-20', '68PM1'),
('SV003', N'Lê Minh C', N'Nam', '2002-01-10', '68PM2'),
('SV004', N'Phạm Thu D', N'Nữ', '2001-08-15', '68PM3'),
('SV005', N'Hoàng Văn E', N'Nam', '2000-11-22', '68PM5'),
('SV006', N'Vũ Thị F', N'Nữ', '2001-03-30', '68PM6'),
('SV007', N'Đặng Minh G', N'Nam', '2002-07-05', '68PM7'),
('SV008', N'Phan Thu H', N'Nữ', '2000-09-12', '68PM8'),
('SV009', N'Huỳnh Văn I', N'Nam', '2001-02-28', '68PM9'),
('SV010', N'Nguyễn Thị K', N'Nữ', '2002-11-18', '68PM10'),
('SV011', N'Trần Minh L', N'Nam', '2000-04-25', '68PM11'),
('SV012', N'Lê Thu M', N'Nữ', '2001-10-08', '68PM12'),
('SV013', N'Phạm Văn N', N'Nam', '2002-06-14', '68PM13'),
('SV014', N'Hoàng Thị O', N'Nữ', '2000-12-03', '68PM14'),
('SV015', N'Vũ Minh P', N'Nam', '2001-05-29', '68PM15'),
('SV016', N'Đặng Thu Q', N'Nữ', '2002-01-07', '68PM1'),
('SV017', N'Phan Văn R', N'Nam', '2000-08-21', '68PM2'),
('SV018', N'Huỳnh Thị S', N'Nữ', '2001-04-16', '68PM3'),
('SV019', N'Nguyễn Minh T', N'Nam', '2002-09-09', '68PM4'),
('SV020', N'Trần Thu U', N'Nữ', '2000-02-14', '68PM5'),
('SV021', N'Lê Văn V', N'Nam', '2001-11-26', '68PM6'),
('SV022', N'Phạm Thị X', N'Nữ', '2002-03-08', '68PM7'),
('SV023', N'Hoàng Minh Y', N'Nam', '2000-07-19', '68PM8'),
('SV024', N'Vũ Thu Z', N'Nữ', '2001-12-31', '68PM9'),
('SV025', N'Đặng Văn A1', N'Nam', '2002-05-04', '68PM10'),
('SV026', N'Phan Thị B1', N'Nữ', '2000-10-27', '68PM11'),
('SV027', N'Huỳnh Minh C1', N'Nam', '2001-06-02', '68PM12'),
('SV028', N'Nguyễn Thu D1', N'Nữ', '2002-02-22', '68PM13'),
('SV029', N'Trần Văn E1', N'Nam', '2000-09-05', '68PM14'),
('SV030', N'Lê Thị F1', N'Nữ', '2001-01-17', '68PM15'),
('SV031', N'Phạm Minh G1', N'Nam', '2002-08-11', '68PM1'),
('SV032', N'Hoàng Thu H1', N'Nữ', '2000-03-24', '68PM2'),
('SV033', N'Vũ Văn I1', N'Nam', '2001-10-09', '68PM3'),
('SV034', N'Đặng Thị K1', N'Nữ', '2002-04-03', '68PM4'),
('SV035', N'Phan Minh L1', N'Nam', '2000-11-13', '68PM5'),
('SV036', N'Huỳnh Thu M1', N'Nữ', '2001-07-28', '68PM6'),
('SV037', N'Nguyễn Văn N1', N'Nam', '2002-12-06', '68PM7'),
('SV038', N'Trần Thị O1', N'Nữ', '2000-05-18', '68PM8'),
('SV039', N'Lê Minh P1', N'Nam', '2001-09-02', '68PM9'),
('SV040', N'Phạm Thu Q1', N'Nữ', '2002-02-10', '68PM10'),
('SV041', N'Hoàng Văn R1', N'Nam', '2000-06-25', '68PM11'),
('SV042', N'Vũ Thị S1', N'Nữ', '2001-11-07', '68PM12'),
('SV043', N'Đặng Minh T1', N'Nam', '2002-03-15', '68PM13'),
('SV044', N'Phan Thu U1', N'Nữ', '2000-08-01', '68PM14'),
('SV045', N'Huỳnh Văn V1', N'Nam', '2001-12-20', '68PM15'),
('SV046', N'Nguyễn Thị X1', N'Nữ', '2002-05-12', '68PM1'),
('SV047', N'Trần Minh Y1', N'Nam', '2000-10-04', '68PM2'),
('SV048', N'Lê Thu Z1', N'Nữ', '2001-01-29', '68PM3'),
('SV049', N'Phạm Văn A2', N'Nam', '2002-07-16', '68PM4'),
('SV050', N'Hoàng Thị B2', N'Nữ', '2000-12-21', '68PM5');
GO
