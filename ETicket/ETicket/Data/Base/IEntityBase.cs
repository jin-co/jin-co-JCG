using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket.Data.Base
{
    // all the models and entities will inherit this interface
    // when using generic
    public interface IEntityBase
    {
        int Id { get; set; }
    }
}
