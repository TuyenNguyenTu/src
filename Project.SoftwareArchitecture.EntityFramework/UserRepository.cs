using Abp.Application.Services.Dto;
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
using System.Threading;
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
            using (var command = CreateCommand("sp_GetPeople", CommandType.StoredProcedure))
            {
                using (var dataReader = await command.ExecuteReaderAsync())
                {
                    var result = new List<string>();

                    while (dataReader.Read())
                    {
                        result.Add(dataReader["Name"].ToString());
                    }

                    return result;
                }
            }
        }
        /// <summary>
        /// DELETE PEOPLE BY ID
        /// </summary>
        /// <param name="input"> ID</param>
        /// <returns></returns>
        public async Task DeletePeople(EntityDto input)
        {
            await Context.Database.ExecuteSqlCommandAsync(
                "EXEC sp_DeletePeopleByID @id",
                default(CancellationToken),
                new SqlParameter("id", input.Id)
            );
        }

        ///// <summary>
        ///// Update
        ///// </summary>
        ///// <param name="input"></param>
        ///// <returns></returns>
        //public async Task UpdateEmail(UpdateUserDto input)
        //{
        //    await Context.Database.ExecuteSqlCommandAsync(
        //        "EXEC sp_UpdatePeopleByID  @id,@Age,@Name",
        //        default(CancellationToken),
        //        new SqlParameter("id", input.Id),
        //        new SqlParameter("Age", input.Age),
        //        new SqlParameter(""
        //    );
        //}

    }
}
