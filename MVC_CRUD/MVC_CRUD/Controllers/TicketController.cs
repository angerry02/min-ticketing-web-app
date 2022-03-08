using Microsoft.AspNetCore.Mvc;
using MVC_CRUD.Models.ViewModels;
using MVC_CRUD.Repositories;
using static MVC_CRUD.Helpers.EnumsHelper;

namespace MVC_CRUD.Controllers
{
    public class TicketController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(string searchKey)
        {
            TicketListViewModel ticketListViewModel = new();
            ticketListViewModel.searchKey = searchKey;

            if (searchKey == null)
                ticketListViewModel.tickets = await TicketRepository.GetTickets();
            else
            {
                ticketListViewModel.tickets = (await TicketRepository.GetTickets())
                    .Where(x => x.ticketNo.ToString() == searchKey
                    || x.requester.ToUpper().Contains(searchKey.ToUpper())
                    || x.ticketDetails.ToUpper().Contains(searchKey.ToUpper()))
                    .ToList();
            }

            return View("TicketList", ticketListViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("TicketForm", new TicketViewModel());
        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            //Expect a invalid id, when the user modify the parameter
            try
            {
                return View("TicketForm", new TicketViewModel { ticket = await TicketRepository.GetTicket(id) });
            }
            catch
            {

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            //Expect a invalid id, when the user modify the parameter
            try
            {
                return View("TicketForm", new TicketViewModel { ticket = await TicketRepository.GetTicket(id), enumTransType = EnumTransType.DELETE });
            }
            catch
            {

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Create(TicketViewModel ticketView)
        {
            bool success;
            if (ticketView.enumTransType == EnumTransType.DELETE)
                success = await TicketRepository.DeleteTicket(ticketView.ticket.ticketNo);
            else
                success = await TicketRepository.SaveTicket(ticketView.ticket);

            //Not saved
            if (!success)
                return View("TicketForm", ticketView);

            return RedirectToAction("Index");
        }
    }
}
