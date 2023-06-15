using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace HermesService.Domain.Entity
{
    public abstract class EntidadeBase
    {
        [Computed]
        public virtual int id { get; set; }

        [Computed]
        public virtual DateTime? dtInclusao { get; set; }
        public virtual DateTime? dtAlteracao { get; set; }
    }
}
