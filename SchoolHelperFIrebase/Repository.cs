using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperFIrebase
{
    public abstract class Repository<T>
    {
        private readonly string _tableName = default;
        private readonly FirebaseClient _firebase = default;
        public Repository(string databaseConnectionString, string tableName)
        {
            _tableName = tableName;
            _firebase = new FirebaseClient(databaseConnectionString);
        }
        public virtual async Task<bool> CreateAsync(T item)
        {
            try
            {
                var json = JsonConvert.SerializeObject(item);
                var tt = await _firebase
                      .Child(_tableName)
                      .PostAsync(json);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public virtual async Task<bool> UpdateAsync(string id, T item)
        {
            try
            {
                var json = JsonConvert.SerializeObject(item);
                await _firebase.Child(_tableName).Child(id).PutAsync(json);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public virtual async Task<bool> DeleteAsync(string key)
        {
            try
            {
                await _firebase
                  .Child(_tableName)
                  .Child(key)
                  .DeleteAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public virtual async Task<IEnumerable<FirebaseObject<T>>> ReadAsync()
        {
            var response = await _firebase.Child(_tableName).OrderByKey().OnceAsync<T>();

            return response;
        }
    }
}
