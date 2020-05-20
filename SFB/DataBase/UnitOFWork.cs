using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFB.DataBase
{
    public class UnitOfWork 
    {
        private DBConnection db = new DBConnection();

        private ActorRepository ActorRepository;
        private UserRepository UserRepository;
        private FilmRepository FilmRepository;
        private BookRepository BookRepository;
        private SerialRepository SerialRepository;
        private ChapterRepository ChapterRepository;
        private SeriesRepository SeriesRepository;
        private RequestRepository RequestRepository;

        public ActorRepository Actors
        {
            get
            {
                if (ActorRepository == null)
                    ActorRepository = new ActorRepository(db);
                return ActorRepository;
            }
        }

        public UserRepository Users
        {
            get
            {
                if (UserRepository == null)
                    UserRepository = new UserRepository(db);
                return UserRepository;
            }
        }

        public FilmRepository Films
        {
            get
            {
                if (FilmRepository == null)
                    FilmRepository = new FilmRepository(db);
                return FilmRepository;
            }
        }

        public BookRepository Books
        {
            get
            {
                if (BookRepository == null)
                    BookRepository = new BookRepository(db);
                return BookRepository;
            }
        }

        public SerialRepository Serials
        {
            get
            {
                if (SerialRepository == null)
                    SerialRepository = new SerialRepository(db);
                return SerialRepository;
            }
        }

        public ChapterRepository Chapters
        {
            get
            {
                if (ChapterRepository == null)
                    ChapterRepository = new ChapterRepository(db);
                return ChapterRepository;
            }
        }

        public SeriesRepository Series
        {
            get
            {
                if (SeriesRepository == null)
                    SeriesRepository = new SeriesRepository(db);
                return SeriesRepository;
            }
        }

        public RequestRepository Requests
        {
            get
            {
                if (RequestRepository == null)
                    RequestRepository = new RequestRepository(db);
                return RequestRepository;
            }
        }
    }
}
