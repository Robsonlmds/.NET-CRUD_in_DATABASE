using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace Crud_Carros.Models.Entities
{
    public class ClientOfStaff
    {
        

     /*   public Guid Id_ClientOfStaff { get; set; }*/
        

        public Guid ClientId { get; set; }
        public Client Client { get; set; }

        public Guid StaffId { get; set; }
        public Staff Staff { get; set; }
    }
}
