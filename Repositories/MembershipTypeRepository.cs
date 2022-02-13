using LibApp.Data;
using LibApp.Interfaces;
using LibApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Repositories
{
    public class MembershipTypeRepository : InterfaceMembershipTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public MembershipTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<MembershipType> GetMembershipTypes()
        {
            return _context.MembershipTypes;
        }

        public MembershipType Get(int id) => _context.MembershipTypes.Find(id);

        public void Add(MembershipType item) => _context.MembershipTypes.Add(item);

        public void Remove(int id) => _context.MembershipTypes.Remove(Get(id));

        public void Update(MembershipType item) => _context.MembershipTypes.Update(item);
        public void Save() => _context.SaveChanges();
    }
}
