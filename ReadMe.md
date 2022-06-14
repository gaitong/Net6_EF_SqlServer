# NET6 + EF + SQLSERVER
## Installation
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.SqlServer
## Installation .NET Core CLI
dotnet tool install --global dotnet-ef

1.สร้าง class DataContext
```sh
public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
        }

        public DbSet<Crypto> Crypto { get; set; }
    }
```

	
2.เพิ่ม appsetting
```sh
"ConnectionStrings": {
    "ConnectionString": "Server=(localdb)\\MSSQLLocalDB;Database=Crypto;User Id=sa;Password=P@ssw0rd;"
  }
```


3.เพิ่มไฟล์ใน program.cs
```sh
builder.Services.AddDbContext<MyWorldDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
});
```

4. Generate folder Migrations
```sh
dotnet ef migrations add Initial
```
**ถ้าติดปัญหา no project ให้พิมพ์ dir แล้ว cd path ถ้ารันสำเร็จจะได้โฟลเดอร์ชื่อ Migrations

5. Generate database
```sh
dotnet ef database update
```
**สามารถ เรียกใช้ DataContext โดยการ dependency injection เข้าไปใน controller