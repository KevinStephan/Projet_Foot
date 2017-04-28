using CoffeeTime.Foot.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeTime.Foot.Core.Business.Services
{
    public abstract class BaseService
    {
        protected CoffeeTime_FootEntities DataModel
        {
            get { return CoreContext.DataModel; }
        }
    }
}
