using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AutenticacionBasicaApi.Models
{
    public partial class GestionContext : DbContext
    {
        public GestionContext()
        {
        }

        public GestionContext(DbContextOptions<GestionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Auditoria> Auditoria { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Codigos> Codigos { get; set; }
        public virtual DbSet<ConFotoCopias> ConFotoCopias { get; set; }
        public virtual DbSet<ControlIpm> ControlIpm { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<EquiDeche> EquiDeche { get; set; }
        public virtual DbSet<FactEntrante> FactEntrante { get; set; }
        public virtual DbSet<Imagenes> Imagenes { get; set; }
        public virtual DbSet<InvCat> InvCat { get; set; }
        public virtual DbSet<InvTime> InvTime { get; set; }
        public virtual DbSet<InvenSaEn> InvenSaEn { get; set; }
        public virtual DbSet<Inventario> Inventario { get; set; }
        public virtual DbSet<Mantenimiento> Mantenimiento { get; set; }
        public virtual DbSet<Prestamos> Prestamos { get; set; }
        public virtual DbSet<PrestamosComputo> PrestamosComputo { get; set; }
        public virtual DbSet<PrestamosEmultimedia> PrestamosEmultimedia { get; set; }
        public virtual DbSet<Sanciones> Sanciones { get; set; }
        public virtual DbSet<UsuCat> UsuCat { get; set; }
        public virtual DbSet<UsuCatIma> UsuCatIma { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-V78E4N6\\SQL;Initial Catalog=Gestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auditoria>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CantidadDatabase).HasColumnName("Cantidad_DATABASE");

                entity.Property(e => e.CantidadManual).HasColumnName("Cantidad_Manual");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.IdInv).HasColumnName("ID_Inv");

                entity.HasOne(d => d.IdInvNavigation)
                    .WithMany(p => p.Auditoria)
                    .HasForeignKey(d => d.IdInv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Inventario_Auditoria");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCat)
                    .HasName("PK__Categori__2BF9F61448D363F0");

                entity.Property(e => e.IdCat).HasColumnName("ID_Cat");

                entity.Property(e => e.CatNombre)
                    .IsRequired()
                    .HasColumnName("Cat_Nombre")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Codigos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdInv).HasColumnName("ID_Inv");

                entity.HasOne(d => d.IdInvNavigation)
                    .WithMany(p => p.Codigos)
                    .HasForeignKey(d => d.IdInv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Inventario_Codigos");
            });

            modelBuilder.Entity<ConFotoCopias>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descrip)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.MontoTotal)
                    .HasColumnName("Monto_Total")
                    .HasColumnType("money");

                entity.Property(e => e.MontoXunidad)
                    .HasColumnName("MontoXUnidad")
                    .HasColumnType("money");

                entity.HasOne(d => d.EncargadoNavigation)
                    .WithMany(p => p.ConFotoCopias)
                    .HasForeignKey(d => d.Encargado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Usuario_ControFoto");

                entity.HasOne(d => d.Inv1Navigation)
                    .WithMany(p => p.ConFotoCopiasInv1Navigation)
                    .HasForeignKey(d => d.Inv1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Inventario_Inv1");

                entity.HasOne(d => d.Inv2Navigation)
                    .WithMany(p => p.ConFotoCopiasInv2Navigation)
                    .HasForeignKey(d => d.Inv2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Inventario_Inv2");
            });

            modelBuilder.Entity<ControlIpm>(entity =>
            {
                entity.HasKey(e => e.IdCp)
                    .HasName("PK__Control___8B622F9BDBA8C636");

                entity.ToTable("Control_IPM");

                entity.Property(e => e.IdCp).HasColumnName("ID_CP");

                entity.Property(e => e.Descripcion).HasMaxLength(200);

                entity.Property(e => e.FechayHora).HasColumnType("date");

                entity.Property(e => e.IdAutoPres).HasColumnName("ID_Auto_Pres");

                entity.Property(e => e.IdDepa).HasColumnName("ID_Depa");

                entity.Property(e => e.IdPres).HasColumnName("ID_Pres");

                entity.HasOne(d => d.IdAutoPresNavigation)
                    .WithMany(p => p.ControlIpm)
                    .HasForeignKey(d => d.IdAutoPres)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Usuario_Control");

                entity.HasOne(d => d.IdDepaNavigation)
                    .WithMany(p => p.ControlIpm)
                    .HasForeignKey(d => d.IdDepa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Departamento_Control");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.IdDepa)
                    .HasName("PK__Departam__AAD696106C949BCE");

                entity.Property(e => e.IdDepa).HasColumnName("ID_Depa");

                entity.Property(e => e.NomDep)
                    .IsRequired()
                    .HasColumnName("Nom_Dep")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<EquiDeche>(entity =>
            {
                entity.HasKey(e => e.IdEqui)
                    .HasName("PK__Equi_Dec__BA53A958989A81F9");

                entity.ToTable("Equi_Deche");

                entity.Property(e => e.IdEqui).HasColumnName("Id_Equi");

                entity.Property(e => e.Desccripcion)
                    .IsRequired()
                    .HasColumnName("desccripcion")
                    .HasMaxLength(300);

                entity.Property(e => e.IdAutoPres).HasColumnName("ID_Auto_Pres");

                entity.Property(e => e.IdInv).HasColumnName("ID_Inv");

                entity.HasOne(d => d.IdAutoPresNavigation)
                    .WithMany(p => p.EquiDeche)
                    .HasForeignKey(d => d.IdAutoPres)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Usuario_equipodesechado");

                entity.HasOne(d => d.IdInvNavigation)
                    .WithMany(p => p.EquiDeche)
                    .HasForeignKey(d => d.IdInv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Inventario_equipodesechado");
            });

            modelBuilder.Entity<FactEntrante>(entity =>
            {
                entity.HasKey(e => e.IdFe)
                    .HasName("PK__Fact_Ent__8B622760134BC529");

                entity.ToTable("Fact_Entrante");

                entity.Property(e => e.IdFe).HasColumnName("ID_FE");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Empresa)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FechaFactura)
                    .HasColumnName("Fecha_Factura")
                    .HasColumnType("date");

                entity.Property(e => e.IdInv).HasColumnName("ID_Inv");

                entity.Property(e => e.NumFact)
                    .IsRequired()
                    .HasColumnName("Num_Fact")
                    .HasMaxLength(20);

                entity.Property(e => e.PrecioUnit)
                    .HasColumnName("Precio_Unit")
                    .HasColumnType("money");

                entity.HasOne(d => d.IdInvNavigation)
                    .WithMany(p => p.FactEntrante)
                    .HasForeignKey(d => d.IdInv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Factura_Inventario");
            });

            modelBuilder.Entity<Imagenes>(entity =>
            {
                entity.HasKey(e => e.IdImagen)
                    .HasName("PK__Imagenes__5A31EE72832C1CDB");

                entity.Property(e => e.IdImagen).HasColumnName("ID_Imagen");

                entity.Property(e => e.IdUsu).HasColumnName("ID_usu");

                entity.Property(e => e.Imagen).HasColumnType("image");

                entity.HasOne(d => d.IdUsuNavigation)
                    .WithMany(p => p.Imagenes)
                    .HasForeignKey(d => d.IdUsu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Usu_Imagen");
            });

            modelBuilder.Entity<InvCat>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Inv_Cat");

                entity.Property(e => e.Categoria).HasMaxLength(100);

                entity.Property(e => e.Descripcion).HasMaxLength(200);

                entity.Property(e => e.IdInv).HasColumnName("ID_Inv");

                entity.Property(e => e.InvNombre)
                    .IsRequired()
                    .HasColumnName("Inv_Nombre")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<InvTime>(entity =>
            {
                entity.ToTable("Inv_Time");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.HorasLlegada)
                    .HasColumnName("Horas_Llegada")
                    .HasMaxLength(20);

                entity.Property(e => e.HorasSalida)
                    .HasColumnName("Horas_Salida")
                    .HasMaxLength(20);

                entity.Property(e => e.IdIse).HasColumnName("ID_ISE");

                entity.HasOne(d => d.IdIseNavigation)
                    .WithMany(p => p.InvTime)
                    .HasForeignKey(d => d.IdIse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prestamo_Time");
            });

            modelBuilder.Entity<InvenSaEn>(entity =>
            {
                entity.HasKey(e => e.IdIse)
                    .HasName("PK__Inven_Sa__2C7C1D494FEF3145");

                entity.ToTable("Inven_Sa_En");

                entity.Property(e => e.IdIse).HasColumnName("ID_ISE");

                entity.Property(e => e.CantDevolucion).HasColumnName("Cant_Devolucion");

                entity.Property(e => e.CantEntre).HasColumnName("Cant_Entre");

                entity.Property(e => e.Descripcion).HasMaxLength(500);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.IdInv).HasColumnName("id_Inv");

                entity.Property(e => e.IdUsu).HasColumnName("ID_Usu");

                entity.HasOne(d => d.IdInvNavigation)
                    .WithMany(p => p.InvenSaEn)
                    .HasForeignKey(d => d.IdInv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Inventario_Inve_Sa_EN");

                entity.HasOne(d => d.IdUsuNavigation)
                    .WithMany(p => p.InvenSaEn)
                    .HasForeignKey(d => d.IdUsu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Usuario_Invetario");
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.HasKey(e => e.IdInv)
                    .HasName("PK__Inventar__2C7D41DC171409B0");

                entity.Property(e => e.IdInv).HasColumnName("ID_Inv");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Descripcion).HasMaxLength(200);

                entity.Property(e => e.IdCat).HasColumnName("ID_Cat");

                entity.Property(e => e.InvNombre)
                    .IsRequired()
                    .HasColumnName("Inv_Nombre")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdCatNavigation)
                    .WithMany(p => p.Inventario)
                    .HasForeignKey(d => d.IdCat)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Categoria_Inventario");
            });

            modelBuilder.Entity<Mantenimiento>(entity =>
            {
                entity.HasKey(e => e.IdMate)
                    .HasName("PK__Mantenim__7E27D1A8A9BDE404");

                entity.Property(e => e.IdMate).HasColumnName("ID_Mate");

                entity.Property(e => e.Cant).HasColumnName("cant");

                entity.Property(e => e.DescripProblema)
                    .HasColumnName("Descrip_Problema")
                    .HasMaxLength(500);

                entity.Property(e => e.DescripSolicitud)
                    .HasColumnName("Descrip_Solicitud")
                    .HasMaxLength(500);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.IdAuto).HasColumnName("ID_Auto");

                entity.Property(e => e.IdInv).HasColumnName("ID_Inv");

                entity.HasOne(d => d.IdAutoNavigation)
                    .WithMany(p => p.Mantenimiento)
                    .HasForeignKey(d => d.IdAuto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Usuario_Mantenimiento");

                entity.HasOne(d => d.IdInvNavigation)
                    .WithMany(p => p.Mantenimiento)
                    .HasForeignKey(d => d.IdInv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Inventario_MAntenimiento");
            });

            modelBuilder.Entity<Prestamos>(entity =>
            {
                entity.HasKey(e => e.IdPres)
                    .HasName("PK__Prestamo__B24A516C7542B04D");

                entity.Property(e => e.IdPres).HasColumnName("ID_Pres");

                entity.Property(e => e.Cant).HasColumnName("cant");

                entity.Property(e => e.FechaRegreso)
                    .HasColumnName("Fecha_Regreso")
                    .HasColumnType("date");

                entity.Property(e => e.FechaSale)
                    .HasColumnName("Fecha_sale")
                    .HasColumnType("date");

                entity.Property(e => e.FechaSoli)
                    .HasColumnName("Fecha_Soli")
                    .HasColumnType("date");

                entity.Property(e => e.IdInv).HasColumnName("ID_Inv");

                entity.Property(e => e.IdUsu).HasColumnName("ID_Usu");

                entity.Property(e => e.PresDescrip)
                    .HasColumnName("Pres_Descrip")
                    .HasMaxLength(500);

                entity.HasOne(d => d.IdInvNavigation)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.IdInv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Inventario_Prestamo");

                entity.HasOne(d => d.IdUsuNavigation)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.IdUsu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Usuario_Prestamos");
            });

            modelBuilder.Entity<PrestamosComputo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PrestamosComputo");

                entity.Property(e => e.Apellidos).HasMaxLength(200);

                entity.Property(e => e.Fecha)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IdPres).HasColumnName("ID_Pres");

                entity.Property(e => e.InvNombre)
                    .HasColumnName("Inv_Nombre")
                    .HasMaxLength(100);

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<PrestamosEmultimedia>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PrestamosEMultimedia");

                entity.Property(e => e.Apellidos).HasMaxLength(200);

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IdPres).HasColumnName("ID_Pres");

                entity.Property(e => e.InvNombre)
                    .HasColumnName("Inv_Nombre")
                    .HasMaxLength(100);

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<Sanciones>(entity =>
            {
                entity.HasKey(e => e.IdSanciones)
                    .HasName("PK__Sancione__27C01BE690BB9265");

                entity.Property(e => e.IdSanciones).HasColumnName("Id_Sanciones");

                entity.Property(e => e.Desccripcion)
                    .IsRequired()
                    .HasColumnName("desccripcion")
                    .HasMaxLength(100);

                entity.Property(e => e.IdAutoPres).HasColumnName("ID_Auto_Pres");

                entity.Property(e => e.IdPres).HasColumnName("ID_Pres");

                entity.HasOne(d => d.IdAutoPresNavigation)
                    .WithMany(p => p.Sanciones)
                    .HasForeignKey(d => d.IdAutoPres)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Usuario_Sanciones");

                entity.HasOne(d => d.IdPresNavigation)
                    .WithMany(p => p.Sanciones)
                    .HasForeignKey(d => d.IdPres)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prestamos_Sanciones");
            });

            modelBuilder.Entity<UsuCat>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Usu_Cat");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Dirrecion).HasMaxLength(300);

                entity.Property(e => e.IdUsu).HasColumnName("ID_usu");

                entity.Property(e => e.NivelSegurity).HasColumnName("Nivel_Segurity");

                entity.Property(e => e.NomDep)
                    .HasColumnName("Nom_Dep")
                    .HasMaxLength(100);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<UsuCatIma>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Usu_Cat_Ima");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Dirrecion).HasMaxLength(300);

                entity.Property(e => e.IdUsu).HasColumnName("ID_usu");

                entity.Property(e => e.Imagen).HasColumnType("image");

                entity.Property(e => e.NivelSegurity).HasColumnName("Nivel_Segurity");

                entity.Property(e => e.NomDep)
                    .HasColumnName("Nom_Dep")
                    .HasMaxLength(100);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsu)
                    .HasName("PK__Usuario__1F7A35155CA780E9");

                entity.Property(e => e.IdUsu).HasColumnName("ID_usu");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Dirrecion).HasMaxLength(300);

                entity.Property(e => e.IdDepa).HasColumnName("ID_Depa");

                entity.Property(e => e.NivelSegurity).HasColumnName("Nivel_Segurity");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdDepaNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdDepa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Departamento_Usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
