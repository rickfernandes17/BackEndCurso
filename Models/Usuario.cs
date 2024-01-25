using System;
using System.Collections.Generic;

namespace BackEndCurso.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string? NomeLogin { get; set; }

    public string? NomeReal { get; set; }

    public string? Email { get; set; }

    public string? Senha { get; set; }

    public int? Tema { get; set; }

    public DateTime? DataCadastro { get; set; }

    public string? Ativo { get; set; }
}
