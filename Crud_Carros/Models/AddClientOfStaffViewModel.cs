using Crud_Carros.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Crud_Carros.Models
{
    public class AddClientOfStaffViewModel
    {
        public Guid ClientId { get; set; }
        public List<Guid> SelectedStaffIds { get; set; } //
    }
}

