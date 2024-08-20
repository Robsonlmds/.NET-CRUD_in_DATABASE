using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace Crud_Carros.Models.Entities
{
    public class Staff
    {
        [Key]
        public Guid Id_Staff { get; set; }

        public string Name_Staff { get; set; }

        public string Local_Staff { get; set; }

        public string Postalcode { get; set; }

        public bool active { get; set; }

      
        public ICollection<Client> Clients { get; set; }
        public ICollection<ClientOfStaff> ClientOfStaffs { get; set; }

    }
}
