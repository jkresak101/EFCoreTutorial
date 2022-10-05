using EFCoreTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreTutorial 
{
    public class SongRepository : Repository<Song>
    {
        private MusicContext db;

        public SongRepository(MusicContext context) : base(context)
        {
            this.db = db;
        }

        public int Count()
        {
            return db.Songs.Count();
        }

        public void Create(Song song)
        {
            db.Songs?.Add(song);
            db.SaveChanges();
        }

        public Song GetById(int id)
        {
            return db.Songs.Single(s => s.Id == id);
        }

        public void Delete(Song song)
        {
            db.Songs?.Remove(song);
            db.SaveChanges();
        }

        public void Save()
        {
            // Save will update all song instances that have been modified in the DB.
            // Theres no great way to test this, and really we would be testing Microsoft's
            // code and not ours.
            db.SaveChanges();
        }

        public IEnumerable<Song> GetAll()
        {
            return db.Songs.ToList();
        }
    }
}

