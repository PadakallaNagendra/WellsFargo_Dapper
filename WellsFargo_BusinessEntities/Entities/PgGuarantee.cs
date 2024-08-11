using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellsFargo_BusinessEntities.Entities
{
    public class PgGuarantee
    {
        [Column("Guarantee")]
        public int Guarantee { get; set; }

        [Column("Description")]
        public string Description { get; set; }
    }
}
