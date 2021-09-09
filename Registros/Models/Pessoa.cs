using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registros.Models
{
    public class Pessoa
    {

        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} Size should be between {2} and {1}")]
        [Display(Name = "Nome:")]
        public String Name { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0} Size should be between {2} and {1}")]
        [Display(Name = "CPF:")]
        public String CPF { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0} Size should be between {2} and {1}")]
        [Display(Name = "Telefone:")]
        public String Tel { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail:")]
        public String Email { get; set; }
      
        [Required(ErrorMessage = "{0} Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data de Nascimento:")]
        public DateTime Nascimento { get; set; }



        public Pessoa(string name, string tel, String cpf, String email, DateTime nascimento)
        {
            Id = Guid.NewGuid();
            Name = name;
            CPF = cpf;
            Tel = tel;
            Email = email;
            Nascimento = nascimento;
        }

        public Pessoa()
        {

        }

        public Pessoa(Guid id, string name, string tel, String cpf, String email, DateTime nascimento)
        {
            Id = id;
            Name = name;
            CPF = cpf;
            Tel = tel;
            Email = email;
            Nascimento = nascimento;
        }

        public Pessoa(string name, string tel, String cpf, String email)
        {
            Id = Guid.NewGuid();
            Name = name;
            CPF = cpf;
            Tel = tel;
            Email = email;

        }
        public List<Pessoa> Listar()
        {
            var list = new List<Pessoa>();
            return list;
        }

        public override int GetHashCode()
        {
            return CPF.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Pessoa))
                return false;
            Pessoa other = obj as Pessoa;
            return CPF.Equals(other.CPF);
        }
    }
}
