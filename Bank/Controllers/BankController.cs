using BankDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bank.Controllers
{
    public class BankController : ApiController
    {
        public IEnumerable<Client> Get()
        {
            using (BankClientDBEntities1 entities = new BankClientDBEntities1())
            {
                return entities.Clients.ToList();
            }
        }

        public Client Get(int id)
        {
            using (BankClientDBEntities1 entities = new BankClientDBEntities1())
            {
                return entities.Clients.FirstOrDefault(x=>x.Id == id);
            }
        }
    }
}
