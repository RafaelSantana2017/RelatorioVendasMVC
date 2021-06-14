using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RelatoriosVendasMVC.Models
{
    public class Vendedor
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "{0} obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "{0} obrigatório.")]
        [EmailAddress(ErrorMessage ="Coloque um e-mail valido!")]
        public string Email { get; set; }

        [Display(Name = "Salario")]
        [Required(ErrorMessage = "{0} obrigatório.")]
        public double SalarioBase { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "{0} obrigatório.")]
        public DateTime Aniversario { get; set; }
        
        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; }
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
