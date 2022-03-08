using System.ComponentModel.DataAnnotations;

namespace MVC_CRUD.Models.DataModels
{
    public class TicketModel
    {
        public int ticketNo { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        [Display(Name = "Ticket Date")]
        public DateTime? dateCreated { get; set; }

        [Required]
        [Display(Name = "Requester Name")]
        public string requester { get; set; }

        [Required]
        [Display(Name = "Ticket Details")]
        public string ticketDetails { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string ticketStatus { get; set; }
    }
}
