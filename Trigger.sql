USE [Order]
GO
/****** Object:  Trigger [dbo].[update_Gia]    Script Date: 6/22/2020 10:42:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER trigger [dbo].[update_Gia]
on [dbo].[ThucAn] for update
as
begin
	set nocount on
	declare @maThucAn nvarchar(50), @gia int
	select @maThucAn = MaThucAn, @gia = Gia
	from inserted
	update ThongTinHoaDon set Gia = @gia
	where MaThucAn = @maThucAn 
end
