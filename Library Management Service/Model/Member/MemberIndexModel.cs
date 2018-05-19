using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Management.Service.Model.Member
{
    public class MemberIndexModel
    {
        public IEnumerable<MemberDetailModel> Members { get; set; }
    }
}
