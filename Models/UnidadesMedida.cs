using System;
using System.Collections.Generic;

namespace BackEndCurso.Models;

public partial class UnidadesMedida
{
    public string Sigla { get; set; } = null!;

    public string? Descricao { get; set; }

    public bool? CasasDecimais { get; set; }

    public string? Ativa { get; set; }

    public int? CadastradoUsuario { get; set; }

    public DateTime? CadastradoData { get; set; }

    public int? AlteradoUsuario { get; set; }

    public DateTime? AlteradoData { get; set; }

    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
