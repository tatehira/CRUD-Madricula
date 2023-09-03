using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Matricula.Dados
{
    [Table("Cadastro")]
    public class Cadastro
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public int Idade { get; set; }
        public string Serie { get; set; }
    }
}
