using System;
using System.Collections.Generic;

namespace BackEndCurso.Models;

public partial class Produto
{
    public int Id { get; set; }

    public string? Codigo { get; set; }

    public string? Descricao { get; set; }

    public string? Un { get; set; }

    public int? IdCategoria { get; set; }

    public decimal? PrecoCusto { get; set; }

    public decimal? PrecoVenda { get; set; }

    public double? EstoqueMinimo { get; set; }

    public double? EstoqueMaximo { get; set; }

    public double? EstoqueSaldoInicial { get; set; }

    public DateOnly? EstoqueSaldoInicialData { get; set; }

    public string? Ativo { get; set; }

    public int? CadastradoUsuario { get; set; }

    public DateTime? CadastradoData { get; set; }

    public int? AlteradoUsuario { get; set; }

    public DateTime? AlteradoData { get; set; }

    public virtual ProdutosCategoria? IdCategoriaNavigation { get; set; }

    public virtual UnidadesMedida? UnNavigation { get; set; }
}
