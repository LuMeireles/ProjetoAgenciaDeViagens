using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaDeViagens.Models
{
    public class Passagem
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Destino { get; set; }
        [Required]
        public string Preco { get; set; }
        [Required]
        public string DataPartida { get; set; }
        [Required]
        public int AgenciaCadastur { get; set; }
        public Agencia Agencia { get; set; }
        [Required]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

    }
}
