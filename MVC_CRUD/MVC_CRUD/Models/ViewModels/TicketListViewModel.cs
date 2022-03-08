using MVC_CRUD.Models.DataModels;

namespace MVC_CRUD.Models.ViewModels
{
    public class TicketListViewModel
    {
        public List<TicketModel> tickets { get; set; }

        public string searchKey { get; set; }
    }
}
