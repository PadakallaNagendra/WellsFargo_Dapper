using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellsFargo_BusinessEntities.Entities
{
    public class PgAccount
    {
        [Column("Account")]
        public int AccountId { get; set; }

        [Column("Name")]
        public string AccountName { get; set; }

        [Column("RecordCount")]
        public int RecordCount { get; set; }
    }
}
