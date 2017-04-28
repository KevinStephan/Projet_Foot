using CoffeeTime.Foot.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CoffeeTime.Foot.Core.Business
{
    public static class CoreContext
    {
        /// <summary>
        /// Key to access datamodel in context.
        /// </summary>
        private const string DATA_MODEL_KEY = "AppDataModel";

        /// <summary>
        /// Gets or Sets conneciton string from/into context.
        /// </summary>
        /// <param name="connectionString"></param>
        internal static CoffeeTime_FootEntities DataModel
        {
            get
            {
                //in case of web application, object is stored in httpContext.
                HttpContext ctx = HttpContext.Current;
                if (ctx == null)
                {
                    return CallContext.GetData(DATA_MODEL_KEY) as CoffeeTime_FootEntities;
                }
                else
                {
                    return ctx.Items[DATA_MODEL_KEY] as CoffeeTime_FootEntities;
                }
            }
            set
            {

                if (value != null)
                {
                    //TODO: configuration.
                    ((System.Data.Entity.Infrastructure.IObjectContextAdapter)value).ObjectContext.CommandTimeout = 120;
                }

                //in case of web application, object is stored in httpContext.
                HttpContext ctx = HttpContext.Current;
                if (ctx == null)
                {
                    CallContext.SetData(DATA_MODEL_KEY, value);
                }
                else
                {
                    ctx.Items[DATA_MODEL_KEY] = value;
                }
            }
        }

        /// <summary>
        /// Initialises new model.
        /// </summary>
        public static void Initialize()
        {
            //if (log.IsDebugEnabled)
            //{
            //    log.Debug("Initializing new core context.");
            //}
            if (DataModel == null)
            {
                DataModel = new CoffeeTime_FootEntities();
            }
        }

        /// <summary>
        /// Frees data model.
        /// </summary>
        public static void Free()
        {
            //if (log.IsDebugEnabled)
            //{
            //    log.Debug("Freeing context.");
            //}

            if (DataModel != null)
            {
                DataModel.Dispose();
            }
            CallContext.FreeNamedDataSlot(DATA_MODEL_KEY);
        }
    }
}
