using SQLite;

namespace MeasureBook.Data
{
    public class MeasureBookDb
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<MeasureBookDb> Instance =
            new AsyncLazy<MeasureBookDb>(async () => 
            {
                var instance = new MeasureBookDb();
                try
                {
                    CreateTableResult result = await Database.CreateTableAsync<ClientModel>();
                }
                catch (Exception ex)
                {

                    throw;
                }
                return instance;
            });


        public MeasureBookDb()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<ClientModel>> GetItemsAsync()
        {
            return Database.Table<ClientModel>().ToListAsync();
        }

        public Task<List<ClientModel>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<ClientModel>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<ClientModel> GetItemAsync(int id)
        {
            return Database.Table<ClientModel>().Where(client => client.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(ClientModel client)
        {
            if (client.Id != 0)
            {
                return Database.UpdateAsync(client);
            }
            else
            {
                return Database.InsertAsync(client);
            }
        }

        public Task<int> DeleteItemAsync(ClientModel client)
        {
            return Database.DeleteAsync(client);
        }
    }
}
