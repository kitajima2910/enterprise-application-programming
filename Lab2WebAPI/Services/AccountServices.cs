using Lab2WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace Lab2WebAPI.Services
{
    public class AccountServices : IAccountServices
    {
        private string strConnect = @"Data Source=.\sqlexpress;Initial Catalog=Lab2DB;User ID=sa;Password=2105;Pooling=False";

        public async Task<bool> AddAccount(Account account)
        {
            var sql = "insert Account values(@AccountCode, @AccountName, @PinCode, @Balance)";
            using (var connect = new SqlConnection(strConnect))
            {
                await connect.OpenAsync();
                var dp = new DynamicParameters();
                dp.Add("@AccountCode", account.AccountCode);
                dp.Add("@AccountName", account.AccountName);
                dp.Add("@PinCode", account.PinCode);
                dp.Add("@Balance", account.Balance);
                return await connect.ExecuteScalarAsync<bool>(sql, dp);
            }
        }

        public async Task<bool> DeleteAccount(string accountCode)
        {
            var sql = "delete from Account where AccountCode = @accountCode";
            using (var connect = new SqlConnection(strConnect))
            {
                await connect.OpenAsync();
                var dp = new DynamicParameters();
                dp.Add("@accountCode", accountCode);
                return await connect.ExecuteScalarAsync<bool>(sql, dp);
            }
        }

        public async Task<bool> EditAccount(Account account)
        {
            var sql = "update Account set AccountName = @AccountName, PinCode = @PinCode, Balance = @Balance where AccountCode = @AccountCode";
            using (var connect = new SqlConnection(strConnect))
            {
                await connect.OpenAsync();
                var dp = new DynamicParameters();
                dp.Add("@AccountName", account.AccountName);
                dp.Add("@PinCode", account.PinCode);
                dp.Add("@Balance", account.Balance);
                dp.Add("@AccountCode", account.AccountCode);
                return await connect.ExecuteScalarAsync<bool>(sql, dp);
            }
        }

        public async Task<Account> GetAccount(string accountCode)
        {
            var sql = "select * from Account where AccountCode = @accountCode";
            using (var connect = new SqlConnection(strConnect))
            {
                await connect.OpenAsync();
                var dp = new DynamicParameters();
                dp.Add("@accountCode", accountCode);
                return await connect.QueryFirstAsync<Account>(sql, dp);
            }
        }

        public async Task<Account> GetAccount(string accountCode, string pinCode)
        {
            var sql = "select * from Account where AccountCode = @accountCode and PinCode = @pinCode";
            using (var connect = new SqlConnection(strConnect))
            {
                await connect.OpenAsync();
                var dp = new DynamicParameters();
                dp.Add("@accountCode", accountCode);
                dp.Add("@pinCode", pinCode);
                return await connect.QueryFirstAsync<Account>(sql, dp);
            }
        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            var sql = "select * from Account";
            using (var connect = new SqlConnection(strConnect))
            {
                await connect.OpenAsync();
                return await connect.QueryAsync<Account>(sql, connect);
            }
        }
    }
}
