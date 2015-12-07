using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//подключить пространство имен
using System.Data.SqlClient;
using System.Data;

namespace WebApplicationTest
{
    /// <summary>
    /// Summary description for a
    /// </summary>
    public class a : IHttpHandler
    {
        string connectionString = null;
        SqlConnection connection;
        string sql = null;

        /*МЕТОД ДОБАВЛЯЕТ ЗАПИСИ В ТАБЛИЦУ БАЗЫ ДАННЫХ*/
        void funWriteData(string argName, string argSurName, string argAge, string argWork)
        {
            connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\info.mdf;Integrated Security=True";
            //между значением null, которое ассоциируется с идентификатором и следующим значением, запятая не ставится
            sql = "INSERT INTO Person VALUES(" + null + " @name, @surname, @age, @work)";

            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);

                    cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar));
                    cmd.Parameters["@name"].Value = argName;

                    cmd.Parameters.Add(new SqlParameter("@surname", SqlDbType.NVarChar));
                    cmd.Parameters["@surname"].Value = argSurName;

                    cmd.Parameters.Add(new SqlParameter("@age", SqlDbType.Int));
                    cmd.Parameters["@age"].Value = argAge;

                    cmd.Parameters.Add(new SqlParameter("@work", SqlDbType.NVarChar));
                    cmd.Parameters["@work"].Value = argWork;

                    cmd.ExecuteNonQuery();
                }
                catch
                {

                }
                finally
                {
                    connection.Close();
                }



            }
        }

        public void ProcessRequest(HttpContext context)
        {
            /*тип данных, которые будут передаваться обратно*/
            context.Response.ContentType = "json/application";

            if (context.Request.HttpMethod == "POST")
            {
                //данные, которые передаются из формы
                var data = context.Request.Form;
                //метод добавляет записи в таблицу базы данных
                funWriteData(data[0], data[1], data[2], data[3]);
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}