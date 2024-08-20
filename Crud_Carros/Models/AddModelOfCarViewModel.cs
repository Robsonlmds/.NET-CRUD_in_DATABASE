using Crud_Carros.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Crud_Carros.Models
{
    public class AddModelOfCarViewModel
    {
        [Key]
        public Guid Car_Id { get; set; }
        public string Name_ModelOfCar { get; set; }

    /*    public string Name_Staff_FK { get; set; }*/

        public Guid StaffId { get; set; }
        public Staff Staff { get; set; }
    }
}
