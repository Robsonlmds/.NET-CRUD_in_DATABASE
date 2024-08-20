using Crud_Carros.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Crud_Carros.Models
{
    public class AddClientViewModel
    {
        [Key]
        public Guid Id_Client { get; set; }

        [MinLength(1), MaxLength(50)]
        public string Name_Client { get; set; }
        public int ddd { get; set; }

        public long contact { get; set; }

        [MinLength(1), MaxLength(15)]
        public string CPF { get; set; }

        public string State { get; set; }

        public ICollection<Staff> Staffs { get; set; }
        public ICollection<ClientOfStaff> ClientOfStaffs { get; set; }
    }
}



