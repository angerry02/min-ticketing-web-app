using Dapper;
using MVC_CRUD.Helpers;
using MVC_CRUD.Models.DataModels;

namespace MVC_CRUD.Repositories
{
    public static class TicketRepository
    {
        public static async Task<bool> SaveTicket(TicketModel ticket)
        {
            try
            {
                using DBHelper dbHelper = new();
                DynamicParameters param = new();
                param.Add("@ticketNo", ticket.ticketNo);
                param.Add("@dateCreated", ticket.dateCreated);
                param.Add("@requester", ticket.requester);
                param.Add("@ticketDetails", ticket.ticketDetails);
                param.Add("@ticketStatus", ticket.ticketStatus);

                return await dbHelper.Execute("SaveTicket", param);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ERROR: {ex.Message}");

                return false;
            }
        }

        public static async Task<List<TicketModel>> GetTickets()
        {
            using DBHelper dbHelper = new();
            var data = await dbHelper.LoadData<TicketModel>("GetTickets", null);
            return data.ToList();
        }

        public static async Task<TicketModel> GetTicket(int ticketNo)
        {
            using DBHelper dbHelper = new();
            DynamicParameters param = new();
            param.Add("@ticketNo", ticketNo);
            var data = await dbHelper.LoadData<TicketModel>("GetTicket", param);
            return data.ToList().First();
        }

        public static async Task<bool> DeleteTicket(int ticketNo)
        {
            try
            {
                using DBHelper dbHelper = new();
                DynamicParameters param = new();
                param.Add("@ticketNo", ticketNo);

                return await dbHelper.Execute("DeleteTicket", param);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ERROR: {ex.Message}");

                return false;
            }
        }
    }
}