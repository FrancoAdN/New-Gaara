using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Gaara.Models
{
    public class EnterprisesDatabaseSettings : IEnterprisesDatabaseSettings
    {
        public string EnterprisesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IEnterprisesDatabaseSettings
    {
        string EnterprisesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
