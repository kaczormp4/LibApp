using LibApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Interfaces
{
    public interface InterfaceMembershipTypeRepository
    {
        IEnumerable<MembershipType> GetMembershipTypes();
        MembershipType Get(int id);
        void Add(MembershipType item);
        void Remove(int id);
        void Update(MembershipType item);
        void Save();
    }
}
