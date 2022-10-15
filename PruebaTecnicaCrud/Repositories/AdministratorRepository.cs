
using PruebaTecnicaCrud.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace PruebaTecnicaCrud.Repositories
{
    public class AdministratorRepository : IAdministratorRepository
    {

        public async Task<object> LoginAsync(string nickname, string password)
        {
            try
            {



            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<List<AdministratorDTO>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        
    }
}
