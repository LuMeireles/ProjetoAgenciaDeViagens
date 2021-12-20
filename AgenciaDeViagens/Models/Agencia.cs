using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaDeViagens.Models
{
    public class Agencia
    {
        [Key]
        [Required]
        public int Cadastur { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        public string GuiaTuristico { get; set; }

    }
}
