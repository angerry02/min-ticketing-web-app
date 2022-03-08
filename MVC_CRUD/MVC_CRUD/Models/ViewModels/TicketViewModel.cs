using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_CRUD.Models.DataModels;
using static MVC_CRUD.Helpers.EnumsHelper;

namespace MVC_CRUD.Models.ViewModels
{
    public class TicketViewModel
    {
        public TicketViewModel()
        {
            ticket = new();
        }

        public TicketModel ticket { get; set; }

        public IEnumerable<SelectListItem> Statuses
        {
            get
            {
                List<SelectListItem> selectListItems = new();
                selectListItems.Add(new SelectListItem { Text = "OPEN", Value = "OPEN" });
                selectListItems.Add(new SelectListItem { Text = "RESOLVED", Value = "RESOLVED" });
                selectListItems.Add(new SelectListItem { Text = "CLOSED", Value = "CLOSED" });
                selectListItems.Add(new SelectListItem { Text = "UNASSIGNED", Value = "UNASSIGNED" });

                var tip = new SelectListItem
                {
                    Value = null,
                    Text = "-- STATUS --"
                };

                selectListItems.Insert(0, tip);

                return selectListItems;
            }
        }

        public EnumTransType enumTransType { get; set; } = EnumTransType.NEW;

        public string headerTitle 
        { 
            get
            {
                return enumTransType == EnumTransType.DELETE ? "Delete Ticket Confirmation" : $"Ticket Data Form (Mode: {(ticket.ticketNo > 0 ? "View/Edit" : "Delete")})";
            }
        }
    }
}