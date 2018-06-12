SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS OFF
GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SampleTable]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
CREATE TABLE [dbo].[SampleTable]
(
	[PartitionId] [uniqueidentifier] NOT NULL ,
	[ItemKey] [uniqueidentifier] NOT NULL ,
	[ItemValue] [int] NULL ,

	CONSTRAINT [PK_SampleTable] PRIMARY KEY CLUSTERED ( [PartitionId], [ItemKey] )
)
GO

INSERT INTO dbo.SampleTable
(
	PartitionId,
	ItemKey,
	ItemValue
)
VALUES
(
	'00000000-0000-0000-0000-000000000000',
	'00000000-0000-0000-0000-000000000000',
	0
)
GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
