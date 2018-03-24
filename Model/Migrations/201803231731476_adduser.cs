namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adduser : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.VisitorStatistics");
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        MaTV = c.Int(nullable: false, identity: true),
                        TaiKhoan = c.String(),
                        MatKhau = c.String(),
                        HoTen = c.String(),
                        DiaChi = c.String(),
                        Email = c.String(),
                        SoDienThoai = c.String(),
                        CauHoi = c.String(),
                        CauTraLoi = c.String(),
                        MaLoaiTV = c.Int(),
                    })
                .PrimaryKey(t => t.MaTV);
            
            AlterColumn("dbo.VisitorStatistics", "ID", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.VisitorStatistics", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.VisitorStatistics");
            AlterColumn("dbo.VisitorStatistics", "ID", c => c.Guid(nullable: false));
            DropTable("dbo.Users");
            AddPrimaryKey("dbo.VisitorStatistics", "ID");
        }
    }
}
