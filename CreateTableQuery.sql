CREATE TABLE FormsData(
	ID int identity(1,1) primary key,
	IrmFromDate varchar(30),
	IrmToDate varchar(30),
	IrmNumber bigint,
	IecCode bigint not null,
	timestamp DATETIME NULL DEFAULT GETDATE()
);
