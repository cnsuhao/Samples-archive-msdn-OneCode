use master
if exists (select [name] from sysdatabases where [name]='db_test')
drop database db_test
go

create database db_test
go

use db_test
go


CREATE TABLE [dbo].[tb_dbo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[number] [bigint] NULL,
	[value] [varchar](max) NULL,
	[isleader] [bit] NULL,
	[datetime]datetime default(getdate()),
	[picture] [image] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

--Test Data
declare @count int
set @count = 1
while(@count<100)
begin

	insert into tb_dbo(number,value,isleader)values(@count*100,'Value:'+CONVERT(varchar(3),@count),@count/50)
	set @count = @count +1
end



