using Crud_Carros.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Crud_Carros.Models
{
    public class AddCarViewModel
    {
        [Key]
        public Guid Id_Car { get; set; }

        public string Plate_Car { get; set; }

        public string Name_Owner { get; set; }


        [Range(0, 2999)]
        public int Year_Car { get; set; }

        public bool IPVA { get; set; } 

        public Guid ModelOfCarId { get; set; } ///

        public ModelOfCar ModelOfCar { get; set; }

    }
}
