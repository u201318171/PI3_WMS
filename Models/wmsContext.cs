using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace wms2_proj.Models
{
    public partial class wmsContext : DbContext
    {

        public wmsContext(DbContextOptions<wmsContext> options):base(options)
        {
        }

        public virtual DbSet<Estacion> Estacion { get; set; }
        public virtual DbSet<TblAnalisisRequerido> TblAnalisisRequerido { get; set; }
        public virtual DbSet<TblBombeo> TblBombeo { get; set; }
        public virtual DbSet<TblCadenaCustodia> TblCadenaCustodia { get; set; }
        public virtual DbSet<TblCadenaCustodiaDetalle> TblCadenaCustodiaDetalle { get; set; }
        public virtual DbSet<TblCliente> TblCliente { get; set; }
        public virtual DbSet<TblEcaParametroLimite> TblEcaParametroLimite { get; set; }
        public virtual DbSet<TblEmpleado> TblEmpleado { get; set; }
        public virtual DbSet<TblEstandarCalidadAgua> TblEstandarCalidadAgua { get; set; }
        public virtual DbSet<TblLaboratorio> TblLaboratorio { get; set; }
        public virtual DbSet<TblMaterial> TblMaterial { get; set; }
        public virtual DbSet<TblMatriz> TblMatriz { get; set; }
        public virtual DbSet<TblMeteorologia> TblMeteorologia { get; set; }
        public virtual DbSet<TblMetodoPerforacion> TblMetodoPerforacion { get; set; }
        public virtual DbSet<TblMuestra> TblMuestra { get; set; }
        public virtual DbSet<TblNivelAgua> TblNivelAgua { get; set; }
        public virtual DbSet<TblParametroAnalisis> TblParametroAnalisis { get; set; }
        public virtual DbSet<TblParametroCateria> TblParametroCateria { get; set; }
        public virtual DbSet<TblParametroGrupo> TblParametroGrupo { get; set; }
        public virtual DbSet<TblParametroGrupoLista> TblParametroGrupoLista { get; set; }
        public virtual DbSet<TblParametroUnidad> TblParametroUnidad { get; set; }
        public virtual DbSet<TblPerfil> TblPerfil { get; set; }
        public virtual DbSet<TblPerforacion> TblPerforacion { get; set; }
        public virtual DbSet<TblPlanDetalle> TblPlanDetalle { get; set; }
        public virtual DbSet<TblPlanMonitoreo> TblPlanMonitoreo { get; set; }
        public virtual DbSet<TblPluviometria> TblPluviometria { get; set; }
        public virtual DbSet<TblProyecto> TblProyecto { get; set; }
        public virtual DbSet<TblQualityControl> TblQualityControl { get; set; }
        public virtual DbSet<TblResultadoAnalisis> TblResultadoAnalisis { get; set; }
        public virtual DbSet<TblTarea> TblTarea { get; set; }
        public virtual DbSet<TblTipoEstacion> TblTipoEstacion { get; set; }
        public virtual DbSet<TblTipoMuestra> TblTipoMuestra { get; set; }
        public virtual DbSet<TblUsuario> TblUsuario { get; set; }
        public virtual DbSet<TblZona> TblZona { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estacion>(entity =>
            {
                entity.ToTable("estacion");

                entity.HasIndex(e => e.IdProyecto)
                    .HasName("id_proyecto");

                entity.HasIndex(e => e.IdTipoEstacion)
                    .HasName("FK_tbl_estacion_tbl_tipo_estacion");

                entity.HasIndex(e => e.IdZona)
                    .HasName("FK_tbl_estacion_tbl_zona");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Comentarios)
                    .HasColumnName("comentarios")
                    .HasColumnType("varchar(1000)");

                entity.Property(e => e.DescripcionEntorno)
                    .HasColumnName("descripcion_entorno")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.Elevation).HasColumnName("elevation");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.IdProyecto)
                    .HasColumnName("id_proyecto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTipoEstacion)
                    .HasColumnName("id_tipo_estacion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdZona)
                    .HasColumnName("id_zona")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.Report).HasColumnType("bit(1)");

                entity.Property(e => e.XPsad56).HasColumnName("X_PSAD56");

                entity.Property(e => e.XWgs84).HasColumnName("X_WGS84");

                entity.Property(e => e.YPsad56).HasColumnName("Y_PSAD56");

                entity.Property(e => e.YWgs84).HasColumnName("Y_WGS84");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.Estacion)
                    .HasForeignKey(d => d.IdProyecto)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tbl_estacion_tbl_proyecto");

                entity.HasOne(d => d.IdTipoEstacionNavigation)
                    .WithMany(p => p.Estacion)
                    .HasForeignKey(d => d.IdTipoEstacion)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tbl_estacion_tbl_tipo_estacion");

                entity.HasOne(d => d.IdZonaNavigation)
                    .WithMany(p => p.Estacion)
                    .HasForeignKey(d => d.IdZona)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tbl_estacion_tbl_zona");
            });

            modelBuilder.Entity<TblAnalisisRequerido>(entity =>
            {
                entity.HasKey(e => e.IdRequerimiento)
                    .HasName("PK_tbl_analisis_requerido");

                entity.ToTable("tbl_analisis_requerido");

                entity.Property(e => e.IdRequerimiento)
                    .HasColumnName("id_requerimiento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombreParametro)
                    .HasColumnName("nombre_parametro")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Preservante)
                    .HasColumnName("preservante")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<TblBombeo>(entity =>
            {
                entity.HasKey(e => e.IdEstacion)
                    .HasName("PK_tbl_bombeo");

                entity.ToTable("tbl_bombeo");

                entity.Property(e => e.IdEstacion)
                    .HasColumnName("id_estacion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CaudalLs).HasColumnName("caudal_ls");

                entity.Property(e => e.Comentario)
                    .HasColumnName("comentario")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.TiempoXhora).HasColumnName("tiempo_xhora");

                entity.Property(e => e.VolumenM3).HasColumnName("volumen_m3");

                entity.HasOne(d => d.IdEstacionNavigation)
                    .WithOne(p => p.TblBombeo)
                    .HasForeignKey<TblBombeo>(d => d.IdEstacion)
                    .HasConstraintName("FK__tbl_bombeo__tbl_estacion");
            });

            modelBuilder.Entity<TblCadenaCustodia>(entity =>
            {
                entity.HasKey(e => e.IdCc)
                    .HasName("PK_tbl_cadena_custodia");

                entity.ToTable("tbl_cadena_custodia");

                entity.HasIndex(e => e.IdLab)
                    .HasName("FK_tbl_cadena_custodia_tbl_laboratorio");

                entity.Property(e => e.IdCc)
                    .HasColumnName("id_cc")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AprobadoPor)
                    .HasColumnName("aprobado_por")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreadoPor)
                    .HasColumnName("creado_por")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EnviadoPor)
                    .HasColumnName("enviado_por")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.FechaEnvio)
                    .HasColumnName("fecha_envio")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaRecepcion)
                    .HasColumnName("fecha_recepcion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdLab)
                    .HasColumnName("id_lab")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Instrucciones)
                    .HasColumnName("instrucciones")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.RecibidoPor)
                    .HasColumnName("recibido_por")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Referencia)
                    .HasColumnName("referencia")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.IdLabNavigation)
                    .WithMany(p => p.TblCadenaCustodia)
                    .HasForeignKey(d => d.IdLab)
                    .HasConstraintName("FK_tbl_cadena_custodia_tbl_laboratorio");
            });

            modelBuilder.Entity<TblCadenaCustodiaDetalle>(entity =>
            {
                entity.HasKey(e => new { e.IdCc, e.IdEstacion, e.IdMuestra, e.IdRequerimiento })
                    .HasName("PK_tbl_cadena_custodia_detalle");

                entity.ToTable("tbl_cadena_custodia_detalle");

                entity.HasIndex(e => e.IdRequerimiento)
                    .HasName("FK_tbl_cadena_custodia_detalle_tbl_analisis_requerido");

                entity.HasIndex(e => new { e.IdEstacion, e.IdMuestra })
                    .HasName("FK_tbl_cadena_custodia_detalle_tbl_muestra");

                entity.Property(e => e.IdCc)
                    .HasColumnName("id_cc")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdEstacion)
                    .HasColumnName("id_estacion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdMuestra)
                    .HasColumnName("id_muestra")
                    .HasColumnType("varchar(70)");

                entity.Property(e => e.IdRequerimiento)
                    .HasColumnName("id_requerimiento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DentroDePeriodo)
                    .HasColumnName("dentro_de_periodo")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Observaciones).HasColumnType("varchar(255)");

                entity.HasOne(d => d.IdCcNavigation)
                    .WithMany(p => p.TblCadenaCustodiaDetalle)
                    .HasForeignKey(d => d.IdCc)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tbl_cadena_custodia_detalle_tbl_cadena_custodia");

                entity.HasOne(d => d.IdRequerimientoNavigation)
                    .WithMany(p => p.TblCadenaCustodiaDetalle)
                    .HasForeignKey(d => d.IdRequerimiento)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tbl_cadena_custodia_detalle_tbl_analisis_requerido");
            });

            modelBuilder.Entity<TblCliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK_tbl_cliente");

                entity.ToTable("tbl_cliente");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("FK_tbl_cliente_tbl_usuario");

                entity.Property(e => e.IdCliente)
                    .HasColumnName("id_cliente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombreContacto)
                    .HasColumnName("nombre_contacto")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.RazonSocial)
                    .HasColumnName("razon_social")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Ruc)
                    .HasColumnName("ruc")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.TelefonoContacto)
                    .HasColumnName("telefono_contacto")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Web)
                    .HasColumnName("web")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.TblCliente)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_tbl_cliente_tbl_usuario");
            });

            modelBuilder.Entity<TblEcaParametroLimite>(entity =>
            {
                entity.HasKey(e => new { e.IdEca, e.IdParametro, e.IdUnidad })
                    .HasName("PK_tbl_eca_parametro_limite");

                entity.ToTable("tbl_eca_parametro_limite");

                entity.HasIndex(e => e.IdParametro)
                    .HasName("FK_tbl_eca_parametro_limite_tbl_parametro_analisis");

                entity.HasIndex(e => e.IdUnidad)
                    .HasName("FK_tbl_eca_parametro_limite_tbl_parametro_unidad");

                entity.Property(e => e.IdEca)
                    .HasColumnName("id_eca")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdParametro)
                    .HasColumnName("id_parametro")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdUnidad)
                    .HasColumnName("id_unidad")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Comentario)
                    .HasColumnName("comentario")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LimiteMaximo).HasColumnName("limite_maximo");

                entity.Property(e => e.LimiteMinimo).HasColumnName("limite_minimo");

                entity.HasOne(d => d.IdEcaNavigation)
                    .WithMany(p => p.TblEcaParametroLimite)
                    .HasForeignKey(d => d.IdEca)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tbl_eca_parametro_limite_tbl_estandar_calidad_agua");

                entity.HasOne(d => d.IdParametroNavigation)
                    .WithMany(p => p.TblEcaParametroLimite)
                    .HasForeignKey(d => d.IdParametro)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tbl_eca_parametro_limite_tbl_parametro_analisis");

                entity.HasOne(d => d.IdUnidadNavigation)
                    .WithMany(p => p.TblEcaParametroLimite)
                    .HasForeignKey(d => d.IdUnidad)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tbl_eca_parametro_limite_tbl_parametro_unidad");
            });

            modelBuilder.Entity<TblEmpleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PK_tbl_empleado");

                entity.ToTable("tbl_empleado");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("FK_tbl_empleado_tbl_usuario");

                entity.Property(e => e.IdEmpleado)
                    .HasColumnName("id_empleado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasColumnName("apellidos")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasColumnName("nombres")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.TblEmpleado)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_tbl_empleado_tbl_usuario");
            });

            modelBuilder.Entity<TblEstandarCalidadAgua>(entity =>
            {
                entity.HasKey(e => e.IdEca)
                    .HasName("PK_tbl_estandar_calidad_agua");

                entity.ToTable("tbl_estandar_calidad_agua");

                entity.Property(e => e.IdEca)
                    .HasColumnName("id_eca")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Comentario)
                    .HasColumnName("comentario")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Fuente)
                    .HasColumnName("fuente")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.NombreEstandar)
                    .HasColumnName("nombre_estandar")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<TblLaboratorio>(entity =>
            {
                entity.HasKey(e => e.IdLab)
                    .HasName("PK_tbl_laboratorio");

                entity.ToTable("tbl_laboratorio");

                entity.Property(e => e.IdLab)
                    .HasColumnName("id_lab")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombreContacto)
                    .HasColumnName("nombre_contacto")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.NombreLaboratorio)
                    .IsRequired()
                    .HasColumnName("nombre_laboratorio")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Ruc)
                    .HasColumnName("ruc")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.TelefonoContacto)
                    .HasColumnName("telefono_contacto")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Web)
                    .HasColumnName("web")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<TblMaterial>(entity =>
            {
                entity.HasKey(e => e.IdMaterial)
                    .HasName("PK_tbl_material");

                entity.ToTable("tbl_material");

                entity.Property(e => e.IdMaterial)
                    .HasColumnName("id_material")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.NombreMaterial)
                    .IsRequired()
                    .HasColumnName("nombre_material")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<TblMatriz>(entity =>
            {
                entity.HasKey(e => e.IdMatriz)
                    .HasName("PK_tbl_matriz");

                entity.ToTable("tbl_matriz");

                entity.Property(e => e.IdMatriz)
                    .HasColumnName("id_matriz")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Codi)
                    .IsRequired()
                    .HasColumnName("codi")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Descripción)
                    .HasColumnName("descripción")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<TblMeteorologia>(entity =>
            {
                entity.HasKey(e => e.IdEstacion)
                    .HasName("PK_tbl_meteorologia");

                entity.ToTable("tbl_meteorologia");

                entity.Property(e => e.IdEstacion)
                    .HasColumnName("id_estacion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Comentario)
                    .HasColumnName("comentario")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Evaporacion).HasColumnName("evaporacion");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.HumedadMm).HasColumnName("humedad_mm");

                entity.Property(e => e.PrecipitacionMm).HasColumnName("precipitacion_mm");

                entity.Property(e => e.PresionBar).HasColumnName("presion_bar");

                entity.Property(e => e.RadiacionSolar).HasColumnName("radiacion_solar");

                entity.Property(e => e.TemperaturaC).HasColumnName("temperatura_C");

                entity.Property(e => e.VelocidadViento).HasColumnName("velocidad_viento");

                entity.HasOne(d => d.IdEstacionNavigation)
                    .WithOne(p => p.TblMeteorologia)
                    .HasForeignKey<TblMeteorologia>(d => d.IdEstacion)
                    .HasConstraintName("FK__tbl_meteorologia__tbl_estacion");
            });

            modelBuilder.Entity<TblMetodoPerforacion>(entity =>
            {
                entity.HasKey(e => e.IdMetodoPerforacion)
                    .HasName("PK_tbl_metodo_perforacion");

                entity.ToTable("tbl_metodo_perforacion");

                entity.Property(e => e.IdMetodoPerforacion)
                    .HasColumnName("id_metodo_perforacion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.NombreMetodo)
                    .HasColumnName("nombre_metodo")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<TblMuestra>(entity =>
            {
                entity.HasKey(e => new { e.IdEstacion, e.IdMuestra })
                    .HasName("PK_tbl_muestra");

                entity.ToTable("tbl_muestra");

                entity.HasIndex(e => e.IdMatriz)
                    .HasName("FK_tbl_muestra_tbl_matriz");

                entity.HasIndex(e => e.IdQualityControl)
                    .HasName("FK_tbl_muestra_tbl_quality_control");

                entity.HasIndex(e => e.IdTecnicoCampo)
                    .HasName("FK_tbl_muestra_tbl_empleado");

                entity.HasIndex(e => e.IdTipoMuestra)
                    .HasName("FK_tbl_muestra_tbl_tipo_muestra");

                entity.Property(e => e.IdEstacion)
                    .HasColumnName("id_estacion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdMuestra)
                    .HasColumnName("id_muestra")
                    .HasColumnType("varchar(70)");

                entity.Property(e => e.Comentario)
                    .HasColumnName("comentario")
                    .HasColumnType("varchar(1000)");

                entity.Property(e => e.FechaMuestreo)
                    .HasColumnName("fecha_muestreo")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdMatriz)
                    .HasColumnName("id_matriz")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdQualityControl)
                    .HasColumnName("id_quality_control")
                    .HasColumnType("varchar(70)");

                entity.Property(e => e.IdTecnicoCampo)
                    .HasColumnName("id_tecnico_campo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTipoMuestra)
                    .HasColumnName("id_tipo_muestra")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdEstacionNavigation)
                    .WithMany(p => p.TblMuestra)
                    .HasForeignKey(d => d.IdEstacion)
                    .HasConstraintName("FK__tbl_muestra__tbl_estacion");

                entity.HasOne(d => d.IdMatrizNavigation)
                    .WithMany(p => p.TblMuestra)
                    .HasForeignKey(d => d.IdMatriz)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tbl_muestra_tbl_matriz");

                entity.HasOne(d => d.IdQualityControlNavigation)
                    .WithMany(p => p.TblMuestra)
                    .HasForeignKey(d => d.IdQualityControl)
                    .HasConstraintName("FK_tbl_muestra_tbl_quality_control");

                entity.HasOne(d => d.IdTecnicoCampoNavigation)
                    .WithMany(p => p.TblMuestra)
                    .HasForeignKey(d => d.IdTecnicoCampo)
                    .HasConstraintName("FK_tbl_muestra_tbl_empleado");

                entity.HasOne(d => d.IdTipoMuestraNavigation)
                    .WithMany(p => p.TblMuestra)
                    .HasForeignKey(d => d.IdTipoMuestra)
                    .HasConstraintName("FK_tbl_muestra_tbl_tipo_muestra");
            });

            modelBuilder.Entity<TblNivelAgua>(entity =>
            {
                entity.HasKey(e => new { e.IdEstacion, e.Fecha })
                    .HasName("PK_tbl_nivel_agua");

                entity.ToTable("tbl_nivel_agua");

                entity.Property(e => e.IdEstacion)
                    .HasColumnName("id_estacion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.Comentario)
                    .HasColumnName("comentario")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.CotaReferencia).HasColumnName("cota_referencia");

                entity.Property(e => e.ElevacionAgua).HasColumnName("elevacion_agua");

                entity.Property(e => e.ProfundidadAgua).HasColumnName("profundidad_agua");

                entity.HasOne(d => d.IdEstacionNavigation)
                    .WithMany(p => p.TblNivelAgua)
                    .HasForeignKey(d => d.IdEstacion)
                    .HasConstraintName("FK_tbl_nivel_agua_tbl_estacion");
            });

            modelBuilder.Entity<TblParametroAnalisis>(entity =>
            {
                entity.HasKey(e => e.IdParametro)
                    .HasName("PK_tbl_parametro_analisis");

                entity.ToTable("tbl_parametro_analisis");

                entity.HasIndex(e => e.IdCateria)
                    .HasName("FK_tbl_parametro_analisis_tbl_parametro_cateria");

                entity.Property(e => e.IdParametro)
                    .HasColumnName("id_parametro")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AnalitoFormulaPeso).HasColumnName("analito_formula_peso");

                entity.Property(e => e.Carga).HasColumnName("carga");

                entity.Property(e => e.IdCateria)
                    .HasColumnName("id_cateria")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombreParametro)
                    .IsRequired()
                    .HasColumnName("nombre_parametro")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Simbologia)
                    .IsRequired()
                    .HasColumnName("simbologia")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.IdCateriaNavigation)
                    .WithMany(p => p.TblParametroAnalisis)
                    .HasForeignKey(d => d.IdCateria)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tbl_parametro_analisis_tbl_parametro_cateria");
            });

            modelBuilder.Entity<TblParametroCateria>(entity =>
            {
                entity.HasKey(e => e.IdCateria)
                    .HasName("PK_tbl_parametro_cateria");

                entity.ToTable("tbl_parametro_cateria");

                entity.Property(e => e.IdCateria)
                    .HasColumnName("id_cateria")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cateria)
                    .HasColumnName("cateria")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OrdenCateria)
                    .HasColumnName("orden_cateria")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<TblParametroGrupo>(entity =>
            {
                entity.HasKey(e => new { e.IdParametroGrupoLista, e.IdParametro })
                    .HasName("PK_tbl_parametro_grupo");

                entity.ToTable("tbl_parametro_grupo");

                entity.HasIndex(e => e.IdParametro)
                    .HasName("FK_tbl_parametro_grupo_tbl_parametro_analisis");

                entity.Property(e => e.IdParametroGrupoLista)
                    .HasColumnName("id_parametro_grupo_lista")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdParametro)
                    .HasColumnName("id_parametro")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Orden)
                    .HasColumnName("orden")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.IdParametroNavigation)
                    .WithMany(p => p.TblParametroGrupo)
                    .HasForeignKey(d => d.IdParametro)
                    .HasConstraintName("FK_tbl_parametro_grupo_tbl_parametro_analisis");

                entity.HasOne(d => d.IdParametroGrupoListaNavigation)
                    .WithMany(p => p.TblParametroGrupo)
                    .HasForeignKey(d => d.IdParametroGrupoLista)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tbl_parametro_grupo_tbl_parametro_grupo_lista");
            });

            modelBuilder.Entity<TblParametroGrupoLista>(entity =>
            {
                entity.HasKey(e => e.IdParametroGrupoLista)
                    .HasName("PK_tbl_parametro_grupo_lista");

                entity.ToTable("tbl_parametro_grupo_lista");

                entity.Property(e => e.IdParametroGrupoLista)
                    .HasColumnName("id_parametro_grupo_lista")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Comentario)
                    .HasColumnName("comentario")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.NombreGrupo)
                    .IsRequired()
                    .HasColumnName("nombre_grupo")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<TblParametroUnidad>(entity =>
            {
                entity.HasKey(e => e.IdUnidad)
                    .HasName("PK_tbl_parametro_unidad");

                entity.ToTable("tbl_parametro_unidad");

                entity.Property(e => e.IdUnidad)
                    .HasColumnName("id_unidad")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UnidadMedida)
                    .IsRequired()
                    .HasColumnName("unidad_medida")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<TblPerfil>(entity =>
            {
                entity.HasKey(e => e.IdPerfil)
                    .HasName("PK_tbl_perfil");

                entity.ToTable("tbl_perfil");

                entity.Property(e => e.IdPerfil)
                    .HasColumnName("id_perfil")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombrePerfil)
                    .HasColumnName("nombre_perfil")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<TblPerforacion>(entity =>
            {
                entity.HasKey(e => new { e.Estacion, e.From, e.To })
                    .HasName("PK_tbl_perforacion");

                entity.ToTable("tbl_perforacion");

                entity.HasIndex(e => e.IdMetodoPerforacion)
                    .HasName("FK_tbl_perforacion_tbl_metodo_perforacion_f6e8eadaf66646e189cb9d");

                entity.Property(e => e.Estacion)
                    .HasColumnName("estacion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.From).HasColumnName("from_");

                entity.Property(e => e.To).HasColumnName("to_");

                entity.Property(e => e.Azimuth).HasColumnName("azimuth");

                entity.Property(e => e.Detalles)
                    .HasColumnName("detalles")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.DiametroPulg).HasColumnName("diametro_pulg");

                entity.Property(e => e.FechaPerforacion)
                    .HasColumnName("fecha_perforacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdMetodoPerforacion)
                    .HasColumnName("id_metodo_perforacion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Inclinacion).HasColumnName("inclinacion");

                entity.Property(e => e.Supervisor)
                    .HasColumnName("supervisor")
                    .HasColumnType("varchar(55)");

                entity.HasOne(d => d.EstacionNavigation)
                    .WithMany(p => p.TblPerforacion)
                    .HasForeignKey(d => d.Estacion)
                    .HasConstraintName("FK_tbl_perforacion_tbl_estacion");

                entity.HasOne(d => d.IdMetodoPerforacionNavigation)
                    .WithMany(p => p.TblPerforacion)
                    .HasForeignKey(d => d.IdMetodoPerforacion)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_tbl_perforacion_tbl_metodo_perforacion_f6e8eadaf66646e189cb9d");
            });

            modelBuilder.Entity<TblPlanDetalle>(entity =>
            {
                entity.HasKey(e => new { e.IdEstacion, e.IdPlan, e.IdTarea })
                    .HasName("PK_tbl_plan_detalle");

                entity.ToTable("tbl_plan_detalle");

                entity.HasIndex(e => e.IdPlan)
                    .HasName("FK_tbl_plan_detalle_tbl_plan_monitoreo");

                entity.HasIndex(e => e.IdTarea)
                    .HasName("FK_tbl_plan_detalle_tbl_tarea");

                entity.Property(e => e.IdEstacion)
                    .HasColumnName("id_estacion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdPlan)
                    .HasColumnName("id_plan")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTarea)
                    .HasColumnName("id_tarea")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Comentario)
                    .HasColumnName("comentario")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Cumplido)
                    .HasColumnName("cumplido")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FechaEstimada)
                    .HasColumnName("fecha_estimada")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaReal)
                    .HasColumnName("fecha_real")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdEstacionNavigation)
                    .WithMany(p => p.TblPlanDetalle)
                    .HasForeignKey(d => d.IdEstacion)
                    .HasConstraintName("FK_tbl_plan_detalle_tbl_estacion");

                entity.HasOne(d => d.IdPlanNavigation)
                    .WithMany(p => p.TblPlanDetalle)
                    .HasForeignKey(d => d.IdPlan)
                    .HasConstraintName("FK_tbl_plan_detalle_tbl_plan_monitoreo");

                entity.HasOne(d => d.IdTareaNavigation)
                    .WithMany(p => p.TblPlanDetalle)
                    .HasForeignKey(d => d.IdTarea)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tbl_plan_detalle_tbl_tarea");
            });

            modelBuilder.Entity<TblPlanMonitoreo>(entity =>
            {
                entity.HasKey(e => e.IdPlan)
                    .HasName("PK_tbl_plan_monitoreo");

                entity.ToTable("tbl_plan_monitoreo");

                entity.HasIndex(e => e.IdAprobador)
                    .HasName("FK_tbl_plan_monitoreo_tbl_empleado_id_aprobador");

                entity.HasIndex(e => e.IdTecnicoCampo)
                    .HasName("FK_tbl_plan_monitoreo_tbl_empleado_id_tecnico");

                entity.Property(e => e.IdPlan)
                    .HasColumnName("id_plan")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cerrado)
                    .HasColumnName("cerrado")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FechaFin)
                    .HasColumnName("fecha_fin")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("fecha_inicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdAprobador)
                    .HasColumnName("id_aprobador")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTecnicoCampo)
                    .HasColumnName("id_tecnico_campo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombrePlan)
                    .IsRequired()
                    .HasColumnName("nombre_plan")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Observaciones)
                    .HasColumnName("observaciones")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.IdAprobadorNavigation)
                    .WithMany(p => p.TblPlanMonitoreoIdAprobadorNavigation)
                    .HasForeignKey(d => d.IdAprobador);

                entity.HasOne(d => d.IdTecnicoCampoNavigation)
                    .WithMany(p => p.TblPlanMonitoreoIdTecnicoCampoNavigation)
                    .HasForeignKey(d => d.IdTecnicoCampo)
                    .HasConstraintName("FK_tbl_plan_monitoreo_tbl_empleado_id_tecnico");
            });

            modelBuilder.Entity<TblPluviometria>(entity =>
            {
                entity.HasKey(e => new { e.IdEstacion, e.Fecha })
                    .HasName("PK_tbl_pluviometria");

                entity.ToTable("tbl_pluviometria");

                entity.HasIndex(e => e.IdEstacion)
                    .HasName("FK_tbl_pluviometria_tbl_estacion");

                entity.Property(e => e.IdEstacion)
                    .HasColumnName("id_estacion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.Comentario)
                    .HasColumnName("comentario")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LluviaMm).HasColumnName("lluvia_mm");

                entity.HasOne(d => d.IdEstacionNavigation)
                    .WithMany(p => p.TblPluviometria)
                    .HasForeignKey(d => d.IdEstacion)
                    .HasConstraintName("FK_tbl_pluviometria_tbl_estacion");
            });

            modelBuilder.Entity<TblProyecto>(entity =>
            {
                entity.HasKey(e => e.IdProyecto)
                    .HasName("PK_tbl_proyecto");

                entity.ToTable("tbl_proyecto");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("FK_tbl_proyecto_tbl_cliente");

                entity.Property(e => e.IdProyecto)
                    .HasColumnName("id_proyecto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.IdCliente)
                    .HasColumnName("id_cliente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombreProyecto)
                    .HasColumnName("nombre_proyecto")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TblProyecto)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_tbl_proyecto_tbl_cliente");
            });

            modelBuilder.Entity<TblQualityControl>(entity =>
            {
                entity.HasKey(e => e.IdQualityControl)
                    .HasName("PK_tbl_quality_control");

                entity.ToTable("tbl_quality_control");

                entity.Property(e => e.IdQualityControl)
                    .HasColumnName("id_quality_control")
                    .HasColumnType("varchar(70)");

                entity.Property(e => e.DescripcionQc)
                    .HasColumnName("descripcion_qc")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.NombreQc)
                    .IsRequired()
                    .HasColumnName("nombre_qc")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<TblResultadoAnalisis>(entity =>
            {
                entity.HasKey(e => new { e.IdEstacion, e.IdMuestra, e.IdParametro, e.IdUnidad })
                    .HasName("PK_tbl_resultado_analisis");

                entity.ToTable("tbl_resultado_analisis");

                entity.HasIndex(e => e.IdParametro)
                    .HasName("FK_tbl_resultado_analisis_tbl_parametro_analisis");

                entity.Property(e => e.IdEstacion)
                    .HasColumnName("id_estacion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdMuestra)
                    .HasColumnName("id_muestra")
                    .HasColumnType("varchar(70)");

                entity.Property(e => e.IdParametro)
                    .HasColumnName("id_parametro")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdUnidad)
                    .HasColumnName("id_unidad")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Comentario)
                    .HasColumnName("comentario")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.FechaAnalisis)
                    .HasColumnName("fecha_analisis")
                    .HasColumnType("datetime");

                entity.Property(e => e.FuenteDatos)
                    .HasColumnName("fuente_datos")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LimiteDeteccion).HasColumnName("limite_deteccion");

                entity.Property(e => e.MetodoAnalisis)
                    .HasColumnName("metodo_analisis")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Qualifier)
                    .HasColumnName("qualifier")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ValorResultado).HasColumnName("valor_resultado");

                entity.HasOne(d => d.IdEstacionNavigation)
                    .WithMany(p => p.TblResultadoAnalisis)
                    .HasForeignKey(d => d.IdEstacion)
                    .HasConstraintName("FK_tbl_resultado_analisis_tbl_estacion");

                entity.HasOne(d => d.IdParametroNavigation)
                    .WithMany(p => p.TblResultadoAnalisis)
                    .HasForeignKey(d => d.IdParametro)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tbl_resultado_analisis_tbl_parametro_analisis");
            });

            modelBuilder.Entity<TblTarea>(entity =>
            {
                entity.HasKey(e => e.IdTarea)
                    .HasName("PK_tbl_tarea");

                entity.ToTable("tbl_tarea");

                entity.Property(e => e.IdTarea)
                    .HasColumnName("id_tarea")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DescripcionTarea)
                    .HasColumnName("descripcion_tarea")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.NombreTarea)
                    .IsRequired()
                    .HasColumnName("nombre_tarea")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<TblTipoEstacion>(entity =>
            {
                entity.HasKey(e => e.IdTipoEstacion)
                    .HasName("PK_tbl_tipo_estacion");

                entity.ToTable("tbl_tipo_estacion");

                entity.Property(e => e.IdTipoEstacion)
                    .HasColumnName("id_tipo_estacion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.TipoEstacion)
                    .HasColumnName("tipo_estacion")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<TblTipoMuestra>(entity =>
            {
                entity.HasKey(e => e.IdTipoMuestra)
                    .HasName("PK_tbl_tipo_muestra");

                entity.ToTable("tbl_tipo_muestra");

                entity.Property(e => e.IdTipoMuestra)
                    .HasColumnName("id_tipo_muestra")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.TipoMuestra)
                    .IsRequired()
                    .HasColumnName("tipo_muestra")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<TblUsuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK_tbl_usuario");

                entity.ToTable("tbl_usuario");

                entity.HasIndex(e => e.IdPerfil)
                    .HasName("FK_tbl_usuario_tbl_perfil");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdPerfil)
                    .HasColumnName("id_perfil")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Identificador)
                    .HasColumnName("identificador")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pssword)
                    .HasColumnName("pssword")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Usuario)
                    .HasColumnName("usuario")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.TblUsuario)
                    .HasForeignKey(d => d.IdPerfil)
                    .HasConstraintName("FK_tbl_usuario_tbl_perfil");
            });

            modelBuilder.Entity<TblZona>(entity =>
            {
                entity.HasKey(e => e.IdZona)
                    .HasName("PK_tbl_zona");

                entity.ToTable("tbl_zona");

                entity.Property(e => e.IdZona)
                    .HasColumnName("id_zona")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Departamento)
                    .IsRequired()
                    .HasColumnName("departamento")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Distrito)
                    .HasColumnName("distrito")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Pais)
                    .IsRequired()
                    .HasColumnName("pais")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Provincia)
                    .HasColumnName("provincia")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Zona)
                    .HasColumnName("zona")
                    .HasColumnType("varchar(255)");
            });
        }
    }
}