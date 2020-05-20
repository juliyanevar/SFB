using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFB.Models;

namespace SFB.DataBase
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }

    public class ActorRepository : IRepository<Actor>
    {
        private DBConnection db;

        public ActorRepository(DBConnection db)
        {
            this.db = db;
        }
        public void Create(Actor actor)
        {
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "CreateActor";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = actor.Name
                };
                command.Parameters.Add(nameParam);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "DeleteActor";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                command.Parameters.Add(nameParam);
                command.ExecuteNonQuery();
            }
        }

        public Actor Get(int id)
        {
            Actor actor = new Actor();
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "GetActor";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                command.Parameters.Add(nameParam);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object Id = reader["ID_ACTOR"];
                        object name = reader["NAME"];

                        actor = new Actor(int.Parse(Id.ToString()), name.ToString());
                    }
                }
                reader.Close();
            }
            return actor;
        }

        public IEnumerable<Actor> GetAll()
        {
            List<Actor> actor = new List<Actor>();
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "GetAllActors";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object Id = reader["ID_ACTOR"];
                        object name = reader["NAME"];

                        actor.Add(new Actor(int.Parse(Id.ToString()), name.ToString()));
                    }
                }
                reader.Close();
            }
            return actor;
        }

        public void Update(Actor actor)
        {
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "UpdateActor";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = actor.Id
                };
                command.Parameters.Add(idParam);
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = actor.Name
                };
                command.Parameters.Add(nameParam);
                command.ExecuteNonQuery();
            }
        }


        public List<Actor> GetActorFilm(int id_film)
        {
            List<Actor> actor = new List<Actor>();
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "GetActorFilm";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id_film
                };
                command.Parameters.Add(nameParam);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object Id = reader["ID_ACTOR"];
                        object name = reader["NAME"];

                        actor.Add(new Actor(int.Parse(Id.ToString()), name.ToString()));
                    }
                }
                reader.Close();
            }
            return actor;
        }

        public void CreateFilmActor(string nameFilm, string nameActor)
        {
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "FilmActor";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idFilmParam = new SqlParameter
                {
                    ParameterName = "@nameFilm",
                    Value = nameFilm
                };
                command.Parameters.Add(idFilmParam);
                SqlParameter idActorParam = new SqlParameter
                {
                    ParameterName = "@nameActor",
                    Value = nameActor
                };
                command.Parameters.Add(idActorParam);
                command.ExecuteNonQuery();
            }
        }

        public void CreateSerialActor(string nameSerial, string nameActor)
        {
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "SerialActor";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idFilmParam = new SqlParameter
                {
                    ParameterName = "@nameSerial",
                    Value = nameSerial
                };
                command.Parameters.Add(idFilmParam);
                SqlParameter idActorParam = new SqlParameter
                {
                    ParameterName = "@nameActor",
                    Value = nameActor
                };
                command.Parameters.Add(idActorParam);
                command.ExecuteNonQuery();
            }
        }

        public List<Actor> GetActorSerial(int id_serial)
        {
            List<Actor> actor = new List<Actor>();
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "GetActorSerial";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id_serial
                };
                command.Parameters.Add(nameParam);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object Id = reader["ID_ACTOR"];
                        object name = reader["NAME"];

                        actor.Add(new Actor(int.Parse(Id.ToString()), name.ToString()));
                    }
                }
                reader.Close();
            }
            return actor;
        }
    }

    public class UserRepository : IRepository<User>
    {
        private DBConnection db;

        public UserRepository(DBConnection db)
        {
            this.db = db;
        }
        public void Create(User User)
        {
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "CreateUser";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter loginParam = new SqlParameter
                {
                    ParameterName = "@login",
                    Value = User.Login
                };
                command.Parameters.Add(loginParam);
                SqlParameter passwordParam = new SqlParameter
                {
                    ParameterName = "@password",
                    Value = User.Password
                };
                command.Parameters.Add(passwordParam);
                SqlParameter mailParam = new SqlParameter
                {
                    ParameterName = "@mail",
                    Value = User.Mail
                };
                command.Parameters.Add(mailParam);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "DeleteUser";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                command.Parameters.Add(idParam);
                command.ExecuteNonQuery();
            }
        }

        public User Get(int id)
        {
            User User = new User();
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "GetUser";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                command.Parameters.Add(idParam);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object Id = reader["ID_USER"];
                        object Login = reader["LOGIN"];
                        object Password = reader["PASSWORD"];
                        object Mail = reader["MAIL"];

                        User = new User(int.Parse(Id.ToString()), Login.ToString(), Password.ToString(), Mail.ToString());
                    }
                }
                reader.Close();
            }
            return User;
        }

        public IEnumerable<User> GetAll()
        {
            List<User> User = new List<User>();
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "GetAllUsers";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object Id = reader["ID_USER"];
                        object Login = reader["LOGIN"];
                        object Password = reader["PASSWORD"];
                        object Mail = reader["MAIL"];

                        User.Add(new User(int.Parse(Id.ToString()), Login.ToString(), Password.ToString(), Mail.ToString()));
                    }
                }
                reader.Close();
            }
            return User;
        }

        public void Update(User User)
        {
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "UpdateUser";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = User.Id
                };
                command.Parameters.Add(idParam);
                SqlParameter loginParam = new SqlParameter
                {
                    ParameterName = "@login",
                    Value = User.Login
                };
                command.Parameters.Add(loginParam);
                SqlParameter passwordParam = new SqlParameter
                {
                    ParameterName = "@password",
                    Value = User.Password
                };
                command.Parameters.Add(passwordParam);
                SqlParameter mailParam = new SqlParameter
                {
                    ParameterName = "@mail",
                    Value = User.Mail
                };
                command.Parameters.Add(mailParam);
                command.ExecuteNonQuery();
            }
        }

        public User FindTheSameLogin(string login)
        {
            User User = new User();
            string sqlExpression;

            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "FindTheSameLogin";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter loginParam = new SqlParameter
                {
                    ParameterName = "@login",
                    Value = login
                };
                command.Parameters.Add(loginParam);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object Id = reader["ID_USER"];
                        object Login = reader["LOGIN"];
                        object Password = reader["PASSWORD"];
                        object Mail = reader["MAIL"];

                        User = new User(int.Parse(Id.ToString()), Login.ToString(), Password.ToString(), Mail.ToString());
                    }
                }
                reader.Close();
            }
            return User;
        }


        public User FindTheSameMail(string mail)
        {
            User User = new User();
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "FindTheSameMail";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter mailParam = new SqlParameter
                {
                    ParameterName = "@mail",
                    Value = mail
                };
                command.Parameters.Add(mailParam);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object Id = reader["ID_USER"];
                        object Login = reader["LOGIN"];
                        object Password = reader["PASSWORD"];
                        object Mail = reader["MAIL"];

                        User = new User(int.Parse(Id.ToString()), Login.ToString(), Password.ToString(), Mail.ToString());
                    }
                }
                reader.Close();
            }
            return User;
        }

        public User FindUser(string login, string password)
        {
            User User = new User();
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "FindUser";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter loginParam = new SqlParameter
                {
                    ParameterName = "@login",
                    Value = login
                };
                command.Parameters.Add(loginParam);
                SqlParameter passwordParam = new SqlParameter
                {
                    ParameterName = "@password",
                    Value = password
                };
                command.Parameters.Add(passwordParam);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object Id = reader["ID_USER"];
                        object Login = reader["LOGIN"];
                        object Password = reader["PASSWORD"];
                        object Mail = reader["MAIL"];

                        User = new User(int.Parse(Id.ToString()), Login.ToString(), Password.ToString(), Mail.ToString());
                    }
                }
                reader.Close();
            }
            return User;
        }

        public int GetIdUser(string login, string mail)
        {
            int id = 0; ;
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "GetIdUser";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter loginParam = new SqlParameter
                {
                    ParameterName = "@login",
                    Value = login
                };
                command.Parameters.Add(loginParam);
                SqlParameter mailParam = new SqlParameter
                {
                    ParameterName = "@mail",
                    Value = mail
                };
                command.Parameters.Add(mailParam);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object Id = reader["ID_USER"];

                        id = (int)Id;
                    }
                }
                reader.Close();
            }
            return id;
        }
    }

    public class FilmRepository : IRepository<Film>
    {
        private DBConnection db;

        public FilmRepository(DBConnection db)
        {
            this.db = db;
        }
        public void Create(Film Film)
        {
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "CreateFilm";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = Film.Name
                };
                command.Parameters.Add(nameParam);
                SqlParameter yearParam = new SqlParameter
                {
                    ParameterName = "@year",
                    Value = Film.Year
                };
                command.Parameters.Add(yearParam);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "DeleteFilm";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                command.Parameters.Add(idParam);
                command.ExecuteNonQuery();
            }
        }

        public Film Get(int id)
        {
            Film Film = new Film();
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "GetFilm";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                command.Parameters.Add(idParam);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object Id = reader["ID_FILM"];
                        object Name = reader["NAME"];
                        object Year = reader["YEAR"];

                        Film = new Film(int.Parse(Id.ToString()), Name.ToString(), int.Parse(Year.ToString()));
                    }
                }
                reader.Close();
            }
            return Film;
        }

        public IEnumerable<Film> GetAll()
        {
            List<Film> Film = new List<Film>();
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "GetAllFilms";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object Id = reader["ID_FILM"];
                        object Name = reader["NAME"];
                        object Year = reader["YEAR"];

                        Film.Add(new Film(int.Parse(Id.ToString()), Name.ToString(), int.Parse(Year.ToString())));
                    }
                }
                reader.Close();
            }
            return Film;
        }

        public void Update(Film Film)
        {
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "UpdateFilm";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = Film.Id
                };
                command.Parameters.Add(idParam);
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = Film.Name
                };
                command.Parameters.Add(nameParam);
                SqlParameter yearParam = new SqlParameter
                {
                    ParameterName = "@year",
                    Value = Film.Year
                };
                command.Parameters.Add(yearParam);
                command.ExecuteNonQuery();
            }
        }

        public List<Film> GetNotWatchingFilms(int id_user)
        {
            List<Film> film = new List<Film>();
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "GetNotWatchingFilms";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id_user",
                    Value = id_user
                };
                command.Parameters.Add(idParam);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object Id = reader["ID_FILM"];
                        object Name = reader["NAME"];
                        object Year = reader["YEAR"];

                        film.Add(new Film(int.Parse(Id.ToString()), Name.ToString(), int.Parse(Year.ToString())));
                    }
                }
                reader.Close();
            }
            return film;
        }

        public List<Film> GetLaterFilms(int id_user)
        {
            List<Film> film = new List<Film>();
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "GetLaterFilms";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id_user",
                    Value = id_user
                };
                command.Parameters.Add(idParam);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object Id = reader["ID_FILM"];
                        object Name = reader["NAME"];
                        object Year = reader["YEAR"];

                        film.Add(new Film(int.Parse(Id.ToString()), Name.ToString(), int.Parse(Year.ToString())));
                    }
                }
                reader.Close();
            }
            return film;
        }

        public string GetStatusFilm(int id_user, int id_film)
        {
            string status = "";
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "GetStatusFilm";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id_user",
                    Value = id_user
                };
                command.Parameters.Add(idParam);
                SqlParameter idFilmParam = new SqlParameter
                {
                    ParameterName = "@id_film",
                    Value = id_film
                };
                command.Parameters.Add(idFilmParam);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object Status = reader["STATUS"];

                        status = Status.ToString();
                    }
                }
                reader.Close();
            }
            return status;
        }

        public void UpdateStatusFilm(int id_user, int id_film, string status)
        {
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "UpdateStatusFilm";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id_user",
                    Value = id_user
                };
                command.Parameters.Add(idParam);
                SqlParameter idFilmParam = new SqlParameter
                {
                    ParameterName = "@id_film",
                    Value = id_film
                };
                command.Parameters.Add(idFilmParam);
                SqlParameter statusParam = new SqlParameter
                {
                    ParameterName = "@status",
                    Value = status
                };
                command.Parameters.Add(statusParam);
                command.ExecuteNonQuery();
            }
        }

        public List<Film> GetWatchingFilms(int id_user)
        {
            List<Film> film = new List<Film>();
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "GetWatchingFilms";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id_user",
                    Value = id_user
                };
                command.Parameters.Add(idParam);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object Id = reader["ID_FILM"];
                        object Name = reader["NAME"];
                        object Year = reader["YEAR"];

                        film.Add(new Film(int.Parse(Id.ToString()), Name.ToString(), int.Parse(Year.ToString())));
                    }
                }
                reader.Close();
            }
            return film;
        }

        public List<Film> FindFilmByYear(int year)
        {
            List<Film> film = new List<Film>();
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "FindFilmByYear";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter yearParam = new SqlParameter
                {
                    ParameterName = "@year",
                    Value = year
                };
                command.Parameters.Add(yearParam);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object Id = reader["ID_FILM"];
                        object Name = reader["NAME"];
                        object Year = reader["YEAR"];

                        film.Add(new Film(int.Parse(Id.ToString()), Name.ToString(), int.Parse(Year.ToString())));
                    }
                }
                reader.Close();
            }
            return film;
        }

        public List<Film> FindFilmByYear1(int year1, int year2)
        {
            List<Film> film = new List<Film>();
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "FindFilmByYear1";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter year1Param = new SqlParameter
                {
                    ParameterName = "@year1",
                    Value = year1
                };
                command.Parameters.Add(year1Param);
                SqlParameter year2Param = new SqlParameter
                {
                    ParameterName = "@year2",
                    Value = year2
                };
                command.Parameters.Add(year2Param);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object Id = reader["ID_FILM"];
                        object Name = reader["NAME"];
                        object Year = reader["YEAR"];

                        film.Add(new Film(int.Parse(Id.ToString()), Name.ToString(), int.Parse(Year.ToString())));
                    }
                }
                reader.Close();
            }
            return film;
        }
    }

    public class BookRepository : IRepository<Book>
    {
        private DBConnection db;

        public BookRepository(DBConnection db)
        {
            this.db = db;
        }
        public void Create(Book Book)
        {
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "CreateBook";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = Book.Name
                };
                command.Parameters.Add(nameParam);
                SqlParameter authorParam = new SqlParameter
                {
                    ParameterName = "@author",
                    Value = Book.Author
                };
                command.Parameters.Add(authorParam);
                SqlParameter countParam = new SqlParameter
                {
                    ParameterName = "@count",
                    Value = Book.CountOfChapter
                };
                command.Parameters.Add(countParam);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "DeleteBook";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                command.Parameters.Add(idParam);
                command.ExecuteNonQuery();
            }
        }

        public Book Get(int id)
        {
            Book Book = new Book();
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "GetBook";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                command.Parameters.Add(idParam);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object Id = reader["ID_BOOK"];
                        object Name = reader["NAME"];
                        object Author = reader["AUTHOR"];
                        object Count = reader["COUNT_CHAPTER"];

                        Book = new Book(int.Parse(Id.ToString()), Name.ToString(), Author.ToString(), int.Parse(Count.ToString()));
                    }
                }
                reader.Close();
            }
            return Book;
        }

        public IEnumerable<Book> GetAll()
        {
            List<Book> Book = new List<Book>();
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "GetAllBooks";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object Id = reader["ID_BOOK"];
                        object Name = reader["NAME"];
                        object Author = reader["AUTHOR"];
                        object Count = reader["COUNT_CHAPTER"];

                        Book.Add(new Book(int.Parse(Id.ToString()), Name.ToString(), Author.ToString(), int.Parse(Count.ToString())));
                    }
                }
                reader.Close();
            }
            return Book;
        }

        public void Update(Book Book)
        {
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "UpdateBook";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = Book.Id
                };
                command.Parameters.Add(idParam);
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = Book.Name
                };
                command.Parameters.Add(nameParam);
                SqlParameter authorParam = new SqlParameter
                {
                    ParameterName = "@author",
                    Value = Book.Author
                };
                command.Parameters.Add(authorParam);
                SqlParameter countParam = new SqlParameter
                {
                    ParameterName = "@count",
                    Value = Book.CountOfChapter
                };
                command.Parameters.Add(countParam);
                command.ExecuteNonQuery();
            }
        }

        public string GetStatusBook(int id_user, int id_book)
        {
            string status = "";
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "GetStatusBook";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id_user",
                    Value = id_user
                };
                command.Parameters.Add(idParam);
                SqlParameter idBookParam = new SqlParameter
                {
                    ParameterName = "@id_book",
                    Value = id_book
                };
                command.Parameters.Add(idBookParam);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object Status = reader["STATUS"];

                        status = Status.ToString();
                    }
                }
                reader.Close();
            }
            return status;
        }

        public void UpdateStatusBook(int id_user, int id_book, string status)
        {
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "UpdateStatusBook";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id_user",
                    Value = id_user
                };
                command.Parameters.Add(idParam);
                SqlParameter idBookParam = new SqlParameter
                {
                    ParameterName = "@id_book",
                    Value = id_book
                };
                command.Parameters.Add(idBookParam);
                SqlParameter statusParam = new SqlParameter
                {
                    ParameterName = "@status",
                    Value = status
                };
                command.Parameters.Add(statusParam);
                command.ExecuteNonQuery();
            }
        }

        public List<Book> GetReadingBooks(int id_user)
        {
            List<Book> Book = new List<Book>();
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "GetReadingBooks";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id_user",
                    Value = id_user
                };
                command.Parameters.Add(idParam);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object Id = reader["ID_BOOK"];
                        object Name = reader["NAME"];
                        object Author = reader["AUTHOR"];
                        object Count = reader["COUNT_CHAPTER"];

                        Book.Add(new Book(int.Parse(Id.ToString()), Name.ToString(), Author.ToString(), int.Parse(Count.ToString())));
                    }
                }
                reader.Close();
            }
            return Book;
        }

        public List<Book> GetLaterBooks(int id_user)
        {
            List<Book> Book = new List<Book>();
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "GetLaterBooks";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id_user",
                    Value = id_user
                };
                command.Parameters.Add(idParam);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object Id = reader["ID_BOOK"];
                        object Name = reader["NAME"];
                        object Author = reader["AUTHOR"];
                        object Count = reader["COUNT_CHAPTER"];

                        Book.Add(new Book(int.Parse(Id.ToString()), Name.ToString(), Author.ToString(), int.Parse(Count.ToString())));
                    }
                }
                reader.Close();
            }
            return Book;
        }
    }

    public class SerialRepository : IRepository<Serial>
    {
        private DBConnection db;

        public SerialRepository(DBConnection db)
        {
            this.db = db;
        }
        public void Create(Serial Serial)
        {
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "CreateSerial";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = Serial.Name
                };
                command.Parameters.Add(nameParam);
                SqlParameter countParam = new SqlParameter
                {
                    ParameterName = "@count",
                    Value = Serial.CountOfSeason
                };
                command.Parameters.Add(countParam);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "DeleteSerial";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                command.Parameters.Add(idParam);
                command.ExecuteNonQuery();
            }
        }

        public Serial Get(int id)
        {
            Serial Serial = new Serial();
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "GetSerial";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                command.Parameters.Add(idParam);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object Id = reader["ID_SERIAL"];
                        object Name = reader["NAME"];
                        object Count = reader["COUNT_SEASON"];

                        Serial = new Serial(int.Parse(Id.ToString()), Name.ToString(), int.Parse(Count.ToString()));
                    }
                }
                reader.Close();
            }
            return Serial;
        }

        public IEnumerable<Serial> GetAll()
        {
            List<Serial> Serial = new List<Serial>();
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "GetAllSerials";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object Id = reader["ID_SERIAL"];
                        object Name = reader["NAME"];
                        object Count = reader["COUNT_SEASON"];

                        Serial.Add(new Serial(int.Parse(Id.ToString()), Name.ToString(), int.Parse(Count.ToString())));
                    }
                }
                reader.Close();
            }
            return Serial;
        }

        public void Update(Serial Serial)
        {
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "UpdateSerial";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = Serial.Id
                };
                command.Parameters.Add(idParam);
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = Serial.Name
                };
                command.Parameters.Add(nameParam);
                SqlParameter countParam = new SqlParameter
                {
                    ParameterName = "@count",
                    Value = Serial.CountOfSeason
                };
                command.Parameters.Add(countParam);
                command.ExecuteNonQuery();
            }
        }

        public string GetStatusSerial(int id_user, int id_Serial)
        {
            string status = "";
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "GetStatusSerial";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id_user",
                    Value = id_user
                };
                command.Parameters.Add(idParam);
                SqlParameter idSerialParam = new SqlParameter
                {
                    ParameterName = "@id_serial",
                    Value = id_Serial
                };
                command.Parameters.Add(idSerialParam);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object Status = reader["STATUS"];

                        status = Status.ToString();
                    }
                }
                reader.Close();
            }
            return status;
        }

        public void UpdateStatusSerial(int id_user, int id_Serial, string status)
        {
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "UpdateStatusSerial";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id_user",
                    Value = id_user
                };
                command.Parameters.Add(idParam);
                SqlParameter idSerialParam = new SqlParameter
                {
                    ParameterName = "@id_Serial",
                    Value = id_Serial
                };
                command.Parameters.Add(idSerialParam);
                SqlParameter statusParam = new SqlParameter
                {
                    ParameterName = "@status",
                    Value = status
                };
                command.Parameters.Add(statusParam);
                command.ExecuteNonQuery();
            }
        }

        public List<Serial> GetLaterSerials(int id_user)
        {
            List<Serial> Serial = new List<Serial>();
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "GetLaterSerials";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id_user",
                    Value = id_user
                };
                command.Parameters.Add(idParam);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object Id = reader["ID_SERIAL"];
                        object Name = reader["NAME"];
                        object Count = reader["COUNT_SEASON"];

                        Serial.Add(new Serial(int.Parse(Id.ToString()), Name.ToString(), int.Parse(Count.ToString())));
                    }
                }
                reader.Close();
            }
            return Serial;
        }


        public List<Serial> GetWatchingSerials(int id_user)
        {
            List<Serial> Serial = new List<Serial>();
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "GetWatchingSerials";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id_user",
                    Value = id_user
                };
                command.Parameters.Add(idParam);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object Id = reader["ID_SERIAL"];
                        object Name = reader["NAME"];
                        object Count = reader["COUNT_SEASON"];

                        Serial.Add(new Serial(int.Parse(Id.ToString()), Name.ToString(), int.Parse(Count.ToString())));
                    }
                }
                reader.Close();
            }
            return Serial;
        }
    }

    public class ChapterRepository : IRepository<Chapter>
    {
        private DBConnection db;

        public ChapterRepository(DBConnection db)
        {
            this.db = db;
        }
        public void Create(Chapter Chapter)
        {
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "CreateChapter";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idBookParam = new SqlParameter
                {
                    ParameterName = "@id_book",
                    Value = Chapter.Id_book
                };
                command.Parameters.Add(idBookParam);
                SqlParameter numberParam = new SqlParameter
                {
                    ParameterName = "@number",
                    Value = Chapter.Number
                };
                command.Parameters.Add(numberParam);
                SqlParameter statusParam = new SqlParameter
                {
                    ParameterName = "@status",
                    Value = Chapter.Status
                };
                command.Parameters.Add(statusParam);
                SqlParameter idUserParam = new SqlParameter
                {
                    ParameterName = "@id_user",
                    Value = Chapter.Id_user
                };
                command.Parameters.Add(idUserParam);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "DeleteChapter";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                command.Parameters.Add(idParam);
                command.ExecuteNonQuery();
            }
        }

        public Chapter Get(int id)
        {
            Chapter Chapter = new Chapter();
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "GetChapter";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                command.Parameters.Add(idParam);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object Id = reader["ID_CHAPTER"];
                        object Id_book = reader["ID_BOOK"];
                        object Number = reader["NUMBER_CHAPTER"];
                        object Status = reader["STATUS"];
                        object Id_user = reader["ID_USER"];

                        Chapter = new Chapter(int.Parse(Id.ToString()), int.Parse(Id_book.ToString()), int.Parse(Number.ToString()), (bool)Status, int.Parse(Id_user.ToString()));
                    }
                }
                reader.Close();
            }
            return Chapter;
        }

        public IEnumerable<Chapter> GetAll()
        {
            List<Chapter> Chapter = new List<Chapter>();
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "GetAllChapter";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object Id = reader["ID_CHAPTER"];
                        object Id_book = reader["ID_BOOK"];
                        object Number = reader["NUMBER_CHAPTER"];
                        object Status = reader["STATUS"];
                        object Id_user = reader["ID_USER"];

                        Chapter.Add(new Chapter(int.Parse(Id.ToString()), int.Parse(Id_book.ToString()), int.Parse(Number.ToString()), (bool)Status, int.Parse(Id_user.ToString())));
                    }
                }
                reader.Close();
            }
            return Chapter;
        }

        public void Update(Chapter Chapter)
        {
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "UpdateChapter";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = Chapter.Id
                };
                command.Parameters.Add(idParam);
                SqlParameter idBookParam = new SqlParameter
                {
                    ParameterName = "@id_book",
                    Value = Chapter.Id_book
                };
                command.Parameters.Add(idBookParam);
                SqlParameter numberParam = new SqlParameter
                {
                    ParameterName = "@number",
                    Value = Chapter.Number
                };
                command.Parameters.Add(numberParam);
                SqlParameter statusParam = new SqlParameter
                {
                    ParameterName = "@status",
                    Value = Chapter.Status
                };
                command.Parameters.Add(statusParam);
                SqlParameter idUserParam = new SqlParameter
                {
                    ParameterName = "@id_user",
                    Value = Chapter.Id_user
                };
                command.Parameters.Add(idUserParam);
                command.ExecuteNonQuery();
            }
        }

        public List<Chapter> GetChaptersBook(int id_book, int id_user)
        {
            List<Chapter> Chapter = new List<Chapter>();
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "GetChaptersBook";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idBookParam = new SqlParameter
                {
                    ParameterName = "@id_book",
                    Value = id_book
                };
                command.Parameters.Add(idBookParam);
                SqlParameter idUserParam = new SqlParameter
                {
                    ParameterName = "@id_user",
                    Value = id_user
                };
                command.Parameters.Add(idUserParam);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object Id = reader["ID_CHAPTER"];
                        object Id_book = reader["ID_BOOK"];
                        object Number = reader["NUMBER_CHAPTER"];
                        object Status = reader["STATUS"];
                        object Id_user = reader["ID_USER"];

                        Chapter.Add(new Chapter(int.Parse(Id.ToString()), int.Parse(Id_book.ToString()), int.Parse(Number.ToString()), (bool)Status, int.Parse(Id_user.ToString())));
                    }
                }
                reader.Close();
            }
            return Chapter;
        }
    }

    public class SeriesRepository
    {
        private DBConnection db;

        public SeriesRepository(DBConnection db)
        {
            this.db = db;
        }
        public List<Series> GetSeriesSerial(int id_serial, int id_user)
        {
            List<Series> Series = new List<Series>();
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "GetSeriesSerial";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idSerialParam = new SqlParameter
                {
                    ParameterName = "@id_serial",
                    Value = id_serial
                };
                command.Parameters.Add(idSerialParam);
                SqlParameter idUserParam = new SqlParameter
                {
                    ParameterName = "@id_user",
                    Value = id_user
                };
                command.Parameters.Add(idUserParam);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object Id = reader["ID_SERIES"];
                        object Id_serial = reader["ID_SERIAL"];
                        object Number_season = reader["NUMBER_SEASON"];
                        object Number_series = reader["NUMBER_SERIES"];
                        object Status = reader["STATUS"];
                        object Id_user = reader["ID_USER"];

                        Series.Add(new Series(int.Parse(Id.ToString()), int.Parse(Id_serial.ToString()), int.Parse(Number_season.ToString()), int.Parse(Number_series.ToString()), (bool)Status, int.Parse(Id_user.ToString())));
                    }
                }
                reader.Close();
            }
            return Series;
        }

        public void Update(Series Series)
        {
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "UpdateSeries";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = Series.Id
                };
                command.Parameters.Add(idParam);
                SqlParameter idBookParam = new SqlParameter
                {
                    ParameterName = "@id_serial",
                    Value = Series.Id_serial
                };
                command.Parameters.Add(idBookParam);
                SqlParameter numberSeasonParam = new SqlParameter
                {
                    ParameterName = "@number_season",
                    Value = Series.NumberSeason
                };
                command.Parameters.Add(numberSeasonParam);
                SqlParameter numberSeriesParam = new SqlParameter
                {
                    ParameterName = "@number_series",
                    Value = Series.NumberSeries
                };
                command.Parameters.Add(numberSeriesParam);
                SqlParameter statusParam = new SqlParameter
                {
                    ParameterName = "@status",
                    Value = Series.Status
                };
                command.Parameters.Add(statusParam);
                SqlParameter idUserParam = new SqlParameter
                {
                    ParameterName = "@id_user",
                    Value = Series.Id_user
                };
                command.Parameters.Add(idUserParam);
                command.ExecuteNonQuery();
            }
        }
    }

    public class RequestRepository
    {
        private DBConnection db;

        public RequestRepository(DBConnection db)
        {
            this.db = db;
        }
        public void Create(Request request)
        {
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "CreateRequest";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter loginParam = new SqlParameter
                {
                    ParameterName = "@login",
                    Value = request.Login
                };
                command.Parameters.Add(loginParam);
                SqlParameter mailParam = new SqlParameter
                {
                    ParameterName = "@mail",
                    Value = request.Mail
                };
                command.Parameters.Add(mailParam);
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Request> GetAll()
        {
            List<Request> Request = new List<Request>();
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "GetAllRequests";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object Id = reader["ID"];
                        object login = reader["LOGIN"];
                        object mail = reader["MAIL"];
                        object status = reader["STATUS"];

                        Request.Add(new Request(int.Parse(Id.ToString()), login.ToString(), mail.ToString(),(bool)status));
                    }
                }
                reader.Close();
            }
            return Request;
        }

        public void Update(Request Request)
        {
            string sqlExpression;
            if (db.connection.State != System.Data.ConnectionState.Open)
            {
                db.connection.Open();
            }
            if (db.connection.State == System.Data.ConnectionState.Open)
            {
                SqlCommand command;
                sqlExpression = "UpdateRequest";
                command = new SqlCommand(sqlExpression, db.connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = Request.Id
                };
                command.Parameters.Add(idParam);
                SqlParameter loginParam = new SqlParameter
                {
                    ParameterName = "@login",
                    Value = Request.Login
                };
                command.Parameters.Add(loginParam);
                SqlParameter mailParam = new SqlParameter
                {
                    ParameterName = "@mail",
                    Value = Request.Mail
                };
                command.Parameters.Add(mailParam);
                SqlParameter statusParam = new SqlParameter
                {
                    ParameterName = "@status",
                    Value = Request.Status
                };
                command.Parameters.Add(statusParam);
                command.ExecuteNonQuery();
            }
        }
    }

}
