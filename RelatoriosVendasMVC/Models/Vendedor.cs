using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelatoriosVendasMVC.Models
{
    public class Vendedor
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public double SalarioBase { get; set; }
        public DateTime Aniversario { get; set; }
        public Departamento Departamento { get; set; }
        public ICollection<Vendas> Vendas { get; set; } = new List<Vendas>();


        public Vendedor()
        {

        }

        public Vendedor(int id, string nome, string email, double salarioBase, DateTime aniversario, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            SalarioBase = salarioBase;
            Aniversario = aniversario;
            Departamento = departamento;
        }

        public void AddVendas(Vendas vd)
        {
            Vendas.Add(vd);
        }

        public void RmVendas(Vendas vd)
        {

            Vendas.Remove(vd);
        }

        public double TotalVendas(DateTime inicial, DateTime final)
        {

            return Vendas.Where(vd => vd.Data >= inicial && vd.Data <= final).Sum(vd => vd.Quantidade);
        }
    }


}
