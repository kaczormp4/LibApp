using LibApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Interfaces
{
    public interface InterfaceGenreRepository
    {
        IEnumerable<Genre> GetGenres();
        Genre Get(int id);
        void Add(Genre item);
        void Remove(int id);
        void Update(Genre item);
        void Save();
    }
}
