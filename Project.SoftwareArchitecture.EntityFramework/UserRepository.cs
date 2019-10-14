using Abp.Data;
using Abp.EntityFramework;
using Project.SoftwareArchitecture.Authorization.Users;
using Project.SoftwareArchitecture.EntityFramework;
using Project.SoftwareArchitecture.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.SoftwareArchitecture
{
    public class UserRepository : SoftwareArchitectureRepositoryBase<User, long>, IUserRepository
    {
        //chỉ đọc
        private readonly IActiveTransactionProvider _transaction;
        public UserRepository(IDbContextProvider<SoftwareArchitectureDbContext> dbContextProvider, IActiveTransactionProvider transactionProvider) : base(dbContextProvider)
        {
            _transaction = transactionProvider;
        }
        // Tạo 1 command
        private DbCommand CreateCommand(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            var command = Context.Database.Connection.CreateCommand();

            command.CommandText = commandText;
            command.CommandType = commandType;
            command.Transaction = GetActiveTransaction();

            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }

            return command;
        }

        // lấy cái transaction đc active
        private DbTransaction GetActiveTransaction()
        {
            return (DbTransaction)_transaction.GetActiveTransaction(new ActiveTransactionProviderArgs
            {
                {"ContextType", typeof(SoftwareArchitectureDbContext) },
                {"MultiTenancySide", MultiTenancySide }
            });
        }

        //Đảm báo kết nối mở
        private void EnsureConnectionOpen()
        {
            var connection = Context.Database.Connection;
            
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }

        // bất đồng bộ
        public async Task<List<string>> GetUserAccount()
        {
            EnsureConnectionOpen();
            using (var command = CreateCommand("sp_GetUser", CommandType.StoredProcedure))
            {
                using (var dataReader = await command.ExecuteReaderAsync())
                {
                    var result = new List<string>();

                    while (dataReader.Read())
                    {
                        result.Add(dataReader["UserName"].ToString());
                    }

                    return result;
                }
            }
        }


    }
}
