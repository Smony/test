using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace WebApplicationTest
{
    public partial class Default : System.Web.UI.Page
    {
        string connectionString = null;
        SqlConnection connection;
        string sql = null;


        /*МЕТОД ЗАПОЛНЯЕТ ВТОРУЮ "СОМОДЕЛЬНУЮ ТАБЛИЦУ"*/
        void funTable1One() 
        {
            connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\info.mdf;Integrated Security=True";
            sql = "SELECT name, surname, age, work FROM Person";

            /*создание таблицы*/
            Table table = new Table();

            table.CellPadding = 5; /*внутренний отступ в ячейке*/
            table.CellSpacing = 5; /*отступ между ячейками*/
            table.BorderWidth = 1; /*толщина границы*/
            table.BorderStyle = BorderStyle.Solid; /*сплошная линия*/
            table.BorderColor = System.Drawing.Color.FromArgb(80, 80, 80); /*цвет линии*/

            TableRow row; /*ряд <tr></tr>*/
            TableCell cell; /*ячейка <td></td>*/

            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        /*создаем ряд*/
                        row = new TableRow();

                        /*создаем и заполняем ячейки*/

                        cell = new TableCell();
                        cell.BorderWidth = 1; /*толщина границы*/
                        cell.BorderStyle = BorderStyle.Solid; /*сплошная линия*/
                        cell.BorderColor = System.Drawing.Color.FromArgb(80, 80, 80); /*цвет линии*/
                        cell.Text = reader["name"].ToString(); /*заполняем ячейку*/
                        row.Cells.Add(cell); /*добавляем ячейку в ряд*/

                        cell = new TableCell();
                        cell.BorderWidth = 1; /*толщина границы*/
                        cell.BorderStyle = BorderStyle.Solid; /*сплошная линия*/
                        cell.BorderColor = System.Drawing.Color.FromArgb(80, 80, 80); /*цвет линии*/
                        cell.Text = reader["surname"].ToString(); /*заполняем ячейку*/
                        row.Cells.Add(cell); /*добавляем ячейку в ряд*/

                        cell = new TableCell();
                        cell.BorderWidth = 1; /*толщина границы*/
                        cell.BorderStyle = BorderStyle.Solid; /*сплошная линия*/
                        cell.BorderColor = System.Drawing.Color.FromArgb(80, 80, 80); /*цвет линии*/
                        cell.Text = reader["age"].ToString(); /*заполняем ячейку*/
                        row.Cells.Add(cell); /*добавляем ячейку в ряд*/

                        cell = new TableCell();
                        cell.BorderWidth = 1; /*толщина границы*/
                        cell.BorderStyle = BorderStyle.Solid; /*сплошная линия*/
                        cell.BorderColor = System.Drawing.Color.FromArgb(80, 80, 80); /*цвет линии*/
                        cell.Text = reader["work"].ToString(); /*заполняем ячейку*/
                        row.Cells.Add(cell); /*добавляем ячейку в ряд*/

                        /*добавляем ряд в таблицу*/
                        table.Rows.Add(row);
                    }

                    /*добавляем таблицу в PlaceHolder*/
                    PlaceHolder1One.Controls.Add(table);
                }
                catch
                {
                    Label5Error.Text = "Ошибка соединения";
                    Label5Error.CssClass = "color-red";
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /*ЕЩЕ МЕТОД ЗАПОЛНЯЕТ ВТОРУЮ "СОМОДЕЛЬНУЮ ТАБЛИЦУ"*/
        void funTable1One2()
        {
            Table table = new Table();
            TableRow row; /*ряд <tr></tr>*/
            TableCell cell; /*ячейка <td></td>*/

            connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\info.mdf;Integrated Security=True";
            
            sql = "SELECT name, surname, age, work FROM Person";

            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    /*цикл создает ряды*/
                    while (reader.Read())
                    {
                        row = new TableRow();
                        /*цикл создает ячейки*/
                        for (int j = 0; j < 4; j++)
                        {
                            cell = new TableCell();
                            if (j == 0)
                            {
                                cell.Text = reader[0].ToString();
                            }
                            if (j == 1)
                            {
                                cell.Text = reader[1].ToString();
                            }
                            if (j == 2)
                            {
                                cell.Text = reader[2].ToString();
                            }
                            if (j == 3)
                            {
                                cell.Text = reader[3].ToString();
                            }
                            row.Cells.Add(cell); /*добавляем ячейку в ряд*/
                        }
                        table.Rows.Add(row); /*добавляем ряд в таблицу*/
                    }

                    /*добавляем таблицу в PlaceHolder*/
                    PlaceHolder1One.Controls.Add(table);
                }
                catch
                {
                    Label5Error.Text = "Ошибка соединения";
                    Label5Error.CssClass = "color-red";
                }
                finally
                {
                    connection.Close();
                }
            }
        }


        /*МЕТОД ДОБАВЛЯЕТ ЗАПИСИ В ТАБЛИЦУ БАЗЫ ДАННЫХ*/
        void funWriteData()
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
                    cmd.Parameters["@name"].Value = TextBox1Name.Text;

                    cmd.Parameters.Add(new SqlParameter("@surname", SqlDbType.NVarChar));
                    cmd.Parameters["@surname"].Value = TextBox2SurName.Text;

                    cmd.Parameters.Add(new SqlParameter("@age", SqlDbType.Int));
                    cmd.Parameters["@age"].Value = TextBox3Age.Text;

                    cmd.Parameters.Add(new SqlParameter("@work", SqlDbType.NVarChar));
                    cmd.Parameters["@work"].Value = TextBox4Work.Text;

                    cmd.ExecuteNonQuery();
                    Label5Error.Text = "Запись успшно добавлена!";
                    Label5Error.CssClass = "color-green";
                }
                catch
                {
                    Label5Error.Text = "Ошибка соединения";
                    Label5Error.CssClass = "color-red";
                }
                finally
                {
                    connection.Close();
                }
            }
            //отмена повторной отправки формы данных при перезагрузке
            Response.Redirect(Request.Url.ToString());
            return;
        }


        //метод заполняет левую таблицу
        void funShowTableLeft()
        {
            Table table = new Table();
            TableRow row; /*ряд <tr></tr>*/
            TableCell cell; /*ячейка <td></td>*/

           

            connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\info.mdf;Integrated Security=True";
            sql = "SELECT * FROM Options";

            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    /*цикл создает ряды*/
                    while (reader.Read())
                    {
                        row = new TableRow();
                        /*цикл создает ячейки*/
                        for (int j = 0; j < 2; j++)
                        {
                            cell = new TableCell();
                            if (j == 0)
                            {
                                cell.Text = reader[0].ToString();
                            }
                            if (j == 1)
                            {
                                cell.Text = reader[1].ToString();
                            }
                            row.Cells.Add(cell); /*добавляем ячейку в ряд*/
                        }
                        table.Rows.Add(row); /*добавляем ряд в таблицу*/
                    }

                    /*добавляем таблицу в PlaceHolder*/
                    PlaceHolder1Left.Controls.Add(table);
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

        //метод заполняет правую таблицу
        void funShowTableRight()
        {
            Table table = new Table();
            TableRow row; /*ряд <tr></tr>*/
            TableCell cell; /*ячейка <td></td>*/

            connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\info.mdf;Integrated Security=True";
            sql = "SELECT * FROM Options WHERE(id % 3) = 0";

            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    /*цикл создает ряды*/
                    while (reader.Read())
                    {
                        row = new TableRow();
                        /*цикл создает ячейки*/
                        for (int j = 0; j < 2; j++)
                        {
                            cell = new TableCell();
                            if (j == 0)
                            {
                                cell.Text = reader[0].ToString();
                            }
                            if (j == 1)
                            {
                                cell.Text = reader[1].ToString();
                            }
                            row.Cells.Add(cell); /*добавляем ячейку в ряд*/
                        }
                        table.Rows.Add(row); /*добавляем ряд в таблицу*/
                    }

                    /*добавляем таблицу в PlaceHolder*/
                    PlaceHolder2Right.Controls.Add(table);
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


        //загрузка страницы
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            //funTable1One();
            funTable1One2();
            //метод заполняет левую таблицу
            funShowTableLeft();
            //метод заполняет правую таблицу
            funShowTableRight();

        }

        //кнопка Отправить(Asp.Net)
        protected void Button2Asp_Click(object sender, EventArgs e)
        {
            //метод заполняет вторую "сомодельную таблицу"
            //funTable1One();

            //ЕЩЕ МЕТОД ЗАПОЛНЯЕТ ВТОРУЮ "СОМОДЕЛЬНУЮ ТАБЛИЦУ"
            //funTable1One2();

            funWriteData();
        }

        //кнопка Показать(Asp.Net)
        protected void Button4ShowAsp_Click(object sender, EventArgs e)
        {
            string str = TextArea1.InnerText;

            /*-выводит введенную разметку в div без html тегов-*/
            //str = Regex.Replace(str, @"<(?!br|p|\/p)[^>]*>", String.Empty);
            //show.InnerText = str;

            /*-просто выводит введенную разметку в div-*/
            //show.InnerText = str;

            /*-выполняет введенную раметку в div-*/
            //show.InnerHtml = str;

            //с разметкой
            if (RadioButton1.Checked)
            {
                show.InnerText = str;
            }
            //без разметки
            else if (RadioButton2.Checked)
            {
                str = Regex.Replace(str, @"<(?!br|p|\/p)[^>]*>", String.Empty);
                show.InnerText = str;
            }
            //выполнение
            else if (RadioButton3.Checked)
            {
                show.InnerHtml = str;
            }
        }


    }
}