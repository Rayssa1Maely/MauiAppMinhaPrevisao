using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiAppMinhaPrevisao.Models;
using SQLite;

namespace MauiAppMinhaPrevisao.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Usuario>().Wait();
        }

        public Task<int> Insert(Usuario usuario)
        {
            return _conn.InsertAsync(usuario);
        }

        public Task<List<Usuario>> Search(string email, string senha)
        {
            string sql = "SELECT * FROM Usuario WHERE Email = ? AND Senha = ?";

            return _conn.QueryAsync<Usuario>(sql, email, senha);
        }
    }
}
