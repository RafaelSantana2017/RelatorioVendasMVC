using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelatoriosVendasMVC.Models
{
    public class Vendas
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Quantidade { get; set; }
        public Vendedor Vendedor { get; set; }


        public Vendas() 
        {
        
        }

        public Vendas(int id, DateTime data, double quantidade, Vendedor vendedor)
        {
            Id = id;
            Data = data;
            Quantidade = quantidade;
            Vendedor = vendedor;
        }
    }
}
