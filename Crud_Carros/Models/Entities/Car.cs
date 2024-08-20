using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crud_Carros.Models.Entities
{
    public class Car
    {
        [Key]
        public Guid Id_Car { get; set; } 

        public string Plate_Car { get; set; }

        public string Name_Owner { get; set; }


        [Range(0,4000)]
        public int Year_Car { get; set; }

        public bool IPVA { get; set; }



        public Guid ModelOfCarId { get; set; } ///

        public ModelOfCar ModelOfCar { get; set; }
    }
}
