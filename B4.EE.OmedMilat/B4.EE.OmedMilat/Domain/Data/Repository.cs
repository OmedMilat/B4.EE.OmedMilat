using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using B4.EE.OmedMilat.Domain.Models;

namespace B4.EE.OmedMilat
{
    public class Repository
    {
        readonly SQLiteAsyncConnection database;

        public Repository(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<JarvisCommands>().Wait();
        }
        public  Task CreateTest(JarvisCommands jarvisCommands)
        {
           return database.InsertAsync(jarvisCommands);           
        }
        public Task<List<JarvisCommands>> GetAllCommads()
        {
            return database.Table<JarvisCommands>().ToListAsync();
        }
    }
}