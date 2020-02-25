using CalificarTaxis.Common.Models;
using CalificarTaxis.Web.Entiries.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalificarTaxis.Web.Helpers
{
 public   interface IConverterHelper
    {
        TaxiResponse ToTaxiResponse(TaxiEntity taxiEntity);

    }
}
