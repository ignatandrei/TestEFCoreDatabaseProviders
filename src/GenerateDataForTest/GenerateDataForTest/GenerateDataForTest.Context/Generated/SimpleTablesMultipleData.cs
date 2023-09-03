using Microsoft.EntityFrameworkCore;

namespace Generated;
    partial class SimpleTablesMultipleData
{
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
        //for Npgsql_EntityFrameworkCore_PostgreSQL
        modelBuilder.Entity<Tbl_DATETIME>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Tbl_DATE__3214EC27B76F5021");

            entity.Property(e => e.DataColumn).HasColumnType(null);
        });
        //for Npgsql_EntityFrameworkCore_PostgreSQL
        modelBuilder.Entity<Tbl_IMAGE>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Tbl_IMAG__3214EC272ABBD18A");

            entity.Property(e => e.DataColumn).HasColumnType(null);
        });
        //for Npgsql_EntityFrameworkCore_PostgreSQL
        modelBuilder.Entity<Tbl_NTEXT>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Tbl_NTEX__3214EC270A3DAF05");

            entity.Property(e => e.DataColumn).HasColumnType(null);
        });
        //for Npgsql_EntityFrameworkCore_PostgreSQL
        modelBuilder.Entity<Tbl_SMALLDATETIME>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Tbl_SMAL__3214EC2728B69889");

            entity.Property(e => e.DataColumn).HasColumnType(null);
        });
        //for Pomelo_EntityFrameworkCore_MySql 
        //for MySql_EntityFrameworkCore
        modelBuilder.Entity<Tbl_MONEY>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Tbl_MONE__3214EC27A2778933");

            entity.Property(e => e.DataColumn).HasColumnType(null);
        });
        //for Pomelo_EntityFrameworkCore_MySql 
        //for MySql_EntityFrameworkCore
        modelBuilder.Entity<Tbl_XML>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Tbl_XML__3214EC27752328E4");

            entity.Property(e => e.DataColumn).HasColumnType(null);
        });
    }
}
