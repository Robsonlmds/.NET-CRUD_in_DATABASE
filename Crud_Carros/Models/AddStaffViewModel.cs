using System.ComponentModel.DataAnnotations;

namespace Crud_Carros.Models
{
    public class AddStaffViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name_Staff { get; set; }

        public string Local_Staff { get; set; }

        public string Postalcode { get; set; }

        public bool active { get; set; }

    }
}
