using LibApp.Data;
using LibApp.Interfaces;
using LibApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Repositories
{
    public class GenreRepository : InterfaceGenreRepository
    {
        private readonly ApplicationDbContext _context;
        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Genre> GetGenres()
        {
            return _context.Genre;
        }

        public Genre Get(int id) => _context.Genre.Find(id);

        public void Add(Genre item) => _context.Genre.Add(item);

        public void Remove(int id) => _context.Genre.Remove(Get(id));

        public void Update(Genre item) => _context.Genre.Update(item);
        public void Save() => _context.SaveChanges();
    }
}
