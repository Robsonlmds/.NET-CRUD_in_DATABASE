using System.ComponentModel.DataAnnotations;

namespace Crud_Carros.Models.Entities
{
    public class ModelOfCar
    {
        [Key]
        public Guid Id_ModelOfCar { get; set; }
        public string Name_ModelOfCar { get; set; }

        public Guid StaffId { get; set; }
        public Staff Staff { get; set; } /*= null*//*;*/

    }
}
