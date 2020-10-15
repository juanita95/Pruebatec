using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webmvcapi.Models
{
        public class FacturasSettings : IFacturasSettings
        {
            public string UserCollectionName { get; set; }
            public string ConnectionString { get; set; }
            public string DatabaseName { get; set; }
        }
        public interface IFacturasSettings
        {
            string UserCollectionName { get; set; }
            string ConnectionString { get; set; }
            string DatabaseName { get; set; }
        }
    }
    