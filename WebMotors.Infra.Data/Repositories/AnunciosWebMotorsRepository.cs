using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Domain.Entities;
using WebMotors.Domain.Interfaces.Repositories;

namespace WebMotors.Infra.Data.Repositories
{
    public class AnunciosWebMotorsRepository : RespositoryBase<AnunciosWebMotors>,  IAnunciosWebMotorsRepository
    {
    }
}
