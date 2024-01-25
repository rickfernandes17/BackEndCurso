using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BackEndCurso.Models;

public partial class EstoqueTreinamentoContext : DbContext
{
    public EstoqueTreinamentoContext()
    {
    }

    public EstoqueTreinamentoContext(DbContextOptions<EstoqueTreinamentoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<ProdutosCategoria> ProdutosCategorias { get; set; }

    public virtual DbSet<UnidadesMedida> UnidadesMedidas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("produtos")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.HasIndex(e => e.Un, "fk_sigla_un_idx");

            entity.HasIndex(e => e.IdCategoria, "id_categoria_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AlteradoData)
                .HasColumnType("datetime")
                .HasColumnName("alterado_data");
            entity.Property(e => e.AlteradoUsuario)
                .HasDefaultValueSql("'0'")
                .HasColumnName("alterado_usuario");
            entity.Property(e => e.Ativo)
                .HasMaxLength(1)
                .HasDefaultValueSql("'S'")
                .IsFixedLength()
                .HasColumnName("ativo");
            entity.Property(e => e.CadastradoData)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("cadastrado_data");
            entity.Property(e => e.CadastradoUsuario)
                .HasDefaultValueSql("'0'")
                .HasColumnName("cadastrado_usuario");
            entity.Property(e => e.Codigo)
                .HasMaxLength(12)
                .HasDefaultValueSql("''")
                .HasColumnName("codigo");
            entity.Property(e => e.Descricao)
                .HasMaxLength(70)
                .HasDefaultValueSql("''")
                .HasColumnName("descricao");
            entity.Property(e => e.EstoqueMaximo)
                .HasDefaultValueSql("'0'")
                .HasColumnName("estoque_maximo");
            entity.Property(e => e.EstoqueMinimo)
                .HasDefaultValueSql("'0'")
                .HasColumnName("estoque_minimo");
            entity.Property(e => e.EstoqueSaldoInicial)
                .HasDefaultValueSql("'0'")
                .HasColumnName("estoque_saldo_inicial");
            entity.Property(e => e.EstoqueSaldoInicialData).HasColumnName("estoque_saldo_inicial_data");
            entity.Property(e => e.IdCategoria)
                .HasDefaultValueSql("'0'")
                .HasColumnName("id_categoria");
            entity.Property(e => e.PrecoCusto)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("preco_custo");
            entity.Property(e => e.PrecoVenda)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("preco_venda");
            entity.Property(e => e.Un)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("un");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("fk_id_categoria");

            entity.HasOne(d => d.UnNavigation).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.Un)
                .HasConstraintName("fk_sigla_un");
        });

        modelBuilder.Entity<ProdutosCategoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("produtos_categorias")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AlteradoData)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("alterado_data");
            entity.Property(e => e.AlteradoUsuario)
                .HasDefaultValueSql("'0'")
                .HasColumnName("alterado_usuario");
            entity.Property(e => e.Ativa)
                .HasMaxLength(1)
                .HasDefaultValueSql("'S'")
                .IsFixedLength()
                .HasColumnName("ativa");
            entity.Property(e => e.CadastradoData)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("cadastrado_data");
            entity.Property(e => e.CadastradoUsuario)
                .HasDefaultValueSql("'0'")
                .HasColumnName("cadastrado_usuario");
            entity.Property(e => e.Descricao)
                .HasMaxLength(50)
                .HasColumnName("descricao");
        });

        modelBuilder.Entity<UnidadesMedida>(entity =>
        {
            entity.HasKey(e => e.Sigla).HasName("PRIMARY");

            entity
                .ToTable("unidades_medidas")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Sigla)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("sigla");
            entity.Property(e => e.AlteradoData)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("alterado_data");
            entity.Property(e => e.AlteradoUsuario)
                .HasDefaultValueSql("'0'")
                .HasColumnName("alterado_usuario");
            entity.Property(e => e.Ativa)
                .HasMaxLength(1)
                .HasDefaultValueSql("'S'")
                .IsFixedLength()
                .HasColumnName("ativa");
            entity.Property(e => e.CadastradoData)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("cadastrado_data");
            entity.Property(e => e.CadastradoUsuario)
                .HasDefaultValueSql("'0'")
                .HasColumnName("cadastrado_usuario");
            entity.Property(e => e.CasasDecimais)
                .HasDefaultValueSql("'0'")
                .HasColumnName("casas_decimais");
            entity.Property(e => e.Descricao)
                .HasMaxLength(50)
                .HasColumnName("descricao");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("usuarios")
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ativo)
                .HasMaxLength(1)
                .HasDefaultValueSql("'S'")
                .IsFixedLength()
                .HasColumnName("ativo");
            entity.Property(e => e.DataCadastro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("data_cadastro");
            entity.Property(e => e.Email)
                .HasMaxLength(120)
                .HasDefaultValueSql("''")
                .HasColumnName("email");
            entity.Property(e => e.NomeLogin)
                .HasMaxLength(20)
                .HasColumnName("nome_login");
            entity.Property(e => e.NomeReal)
                .HasMaxLength(80)
                .HasDefaultValueSql("''")
                .HasColumnName("nome_real");
            entity.Property(e => e.Senha)
                .HasMaxLength(128)
                .HasDefaultValueSql("''")
                .HasColumnName("senha");
            entity.Property(e => e.Tema)
                .HasDefaultValueSql("'3'")
                .HasColumnName("tema");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
