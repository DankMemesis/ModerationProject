using Microsoft.VisualBasic.ApplicationServices;
using ModeratingProject.Models;
using ModeratingProject.Repository.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeratingProject.Repository
{
    internal class MySqlRepository : IUserRepository
    {
        public MySqlRepository()
        { }
        private MySqlConnection GetConnection()
        {
            var cs = ConfigurationManager.ConnectionStrings["MySqlConn"].ToString();
            var builder = new MySqlConnectionStringBuilder(cs);
            //чтоб избежать проблем с русским языком
            builder.CharacterSet = "utf8";
            return new MySqlConnection(builder.ConnectionString);
        }
        public async Task<Result<List<UserModel>>> GetUsers(TextBox _textBoxSearch)
        {
            var list = new List<UserModel>();

            try
            {
                using (var con = GetConnection())
                using (var cmd = con.CreateCommand())
                {
                    if (_textBoxSearch.Text == "")
                    {
                        cmd.CommandText = "SELECT * FROM users";
                        con.Open();
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var user = new UserModel(reader.GetInt32(0));
                                user.Username = reader.GetString(1);
                                user.Password = reader.GetString(2);
                                user.Ban = reader.GetBoolean(3);

                                list.Add(user);
                            }
                        }
                    }
                    else
                    {
                        cmd.CommandText = "SELECT * FROM users where username LIKE '%" + _textBoxSearch.Text + "%'";
                        //cmd.Parameters.Add(new MySqlParameter("@text", MySqlDbType.VarChar, 16)
                        //{ Value = _textBoxSearch.Text });
                        con.Open();
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var user = new UserModel(reader.GetInt32(0));
                                user.Username = reader.GetString(1);
                                user.Password = reader.GetString(2);
                                user.Ban = reader.GetBoolean(3);

                                list.Add(user);
                            }
                        }
                    }
                }

            }
            catch (MySqlException ex)
            {
                return new Result<List<UserModel>>(GetUserFriendlyErrorMessage(ex));
            }
            catch (Exception ex)
            {
                return new Result<List<UserModel>>(ex.Message);
            }

            return new Result<List<UserModel>>(list);
        }
        public async Task<Result<int>> AddUser(UserModel user)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(user));
            if (String.IsNullOrWhiteSpace(user.Username)
                || String.IsNullOrEmpty(user.Username))
            {
                return new Result<int>("Enter username");
            }
            if (String.IsNullOrWhiteSpace(user.Password)
                || String.IsNullOrEmpty(user.Password))
            {
                return new Result<int>("Enter password");
            }

            int result = 0;
            try
            {
                using (var con = GetConnection())
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO users (username, password, id, ban)" +
                        " VALUES(@username, @password, @id, @ban)";

                    cmd.Parameters.Add(new MySqlParameter("@username", MySqlDbType.VarChar, 16)
                    { Value = user.Username });

                    cmd.Parameters.Add(new MySqlParameter("@password", MySqlDbType.VarChar, 16)
                    { Value = user.Password });

                    cmd.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int64)
                    {
                        Value = user.Id //(object)System.DBNull.Value
                    });
                    
                    cmd.Parameters.Add(new MySqlParameter("@ban", MySqlDbType.Bit, 1)
                    {
                        Value = user.Ban //?? (object)System.DBNull.Value
                    });

                    con.Open();
                    result = await cmd.ExecuteNonQueryAsync();
                }

            }
            catch (MySqlException ex)
            {
                return new Result<int>(GetUserFriendlyErrorMessage(ex));
            }
            catch (Exception ex)
            {
                return new Result<int>(ex.Message);
            }

            return new Result<int>(result);
        }

        public async Task<Result<int>> RemoveUser(int id)
        {
            if (id <= 0)
                throw new ArgumentException(nameof(id));

            int result = 0;
            try
            {
                using (var con = GetConnection())
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM users WHERE id = @id";

                    cmd.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32)
                    { Value = id });

                    con.Open();
                    result = await cmd.ExecuteNonQueryAsync();
                }

            }
            catch (MySqlException ex)
            {
                return new Result<int>(GetUserFriendlyErrorMessage(ex));
            }
            catch (Exception ex)
            {
                return new Result<int>(ex.Message);
            }

            return new Result<int>(result);
        }
        public async Task<Result<int>> UpdateUser(UserModel user)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(user));
            if (String.IsNullOrWhiteSpace(user.Username)
                || String.IsNullOrEmpty(user.Username))
            {
                return new Result<int>("Enter username");
            }
            if (String.IsNullOrWhiteSpace(user.Password)
                || String.IsNullOrEmpty(user.Password))
            {
                return new Result<int>("Enter password");
            }

            int result = 0;
            try
            {
                using (var con = GetConnection())
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "UPDATE users" +
                        " SET username = @username, password = @password, ban = @ban" +
                        " WHERE id =@id";

                    cmd.Parameters.Add(new MySqlParameter("@username", MySqlDbType.VarChar, 200)
                    { Value = user.Username });

                    cmd.Parameters.Add(new MySqlParameter("@password", MySqlDbType.VarChar, 300)
                    { Value = user.Password });

                    cmd.Parameters.Add(new MySqlParameter("@ban", MySqlDbType.Bit, 1)
                    {
                        Value = user.Ban //?? (object)System.DBNull.Value
                    });

                    cmd.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32)
                    { Value = user.Id });

                    con.Open();
                    result = await cmd.ExecuteNonQueryAsync();
                }

            }
            catch (MySqlException ex)
            {
                return new Result<int>(GetUserFriendlyErrorMessage(ex));
            }
            catch (Exception ex)
            {
                return new Result<int>(ex.Message);
            }

            return new Result<int>(result);
        }
        /*public async Task<Result<List<UserModel>>> SearchUser(UserModel user)
        {
            var list = new List<UserModel>();
            try
            {
                using (var con = GetConnection())
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "Select * from users" +
                        " where username like '@username%'";

                    cmd.Parameters.Add(new MySqlParameter("@username", MySqlDbType.VarChar, 16)
                    { Value = user.UsernameSearch }) ;

                    con.Open();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        
                            var userM = new UserModel(reader.GetInt32(0));
                            userM.Username = reader.GetString(1);
                            userM.Password = reader.GetString(2);
                            userM.Ban = reader.GetBoolean(3);

                            list.Add(userM);
                        
                    }
                }

            }
            catch (MySqlException ex)
            {
                return new Result<List<UserModel>>(GetUserFriendlyErrorMessage(ex));
            }
            catch (Exception ex)
            {
                return new Result<List<UserModel>>(ex.Message);
            }

            return new Result<List<UserModel>>(list);
        } */
    
        private string GetUserFriendlyErrorMessage(MySqlException ex)
        {
            var message = String.Empty;
            switch (ex.Number)
            {
                case 0:
                    if (ex.InnerException.Message.Contains("Unknown"))
                    {
                        message = "Wrong server name";
                    }
                    else if (ex.InnerException.Message.Contains("Access"))
                    {
                        message = "Wrong username or password";
                    }
                    else
                    {
                        message = ex.Message;
                    }
                    break;
                case 1042:
                    message = "Server with current adress is unavailable" +
                        "\nTime expired";
                    break;
                case 1045:
                    message = "Wrong username or password, " +
                        "\ntry again";
                    break;
                default:
                    message = ex.Message;
                    break;
            }
            return message;
        }
    }
}
