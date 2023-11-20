using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }

        public Cliente() 
        {
            this.Id = 0;
            this.Nome = string.Empty;
            this.DataNascimento = null;
        }
    }
}