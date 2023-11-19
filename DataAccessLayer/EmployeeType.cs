using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccessLayer
{
	public class EmployeeType
	{
		#region Properties
		public int Id { get; set; }
		public string Name { get; set; }
		#endregion

		#region Add
		/// <summary>
		/// Adds a new record.
		/// </summary>
		public void Add()
		{
			String connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

			using (MySqlConnection con = new MySqlConnection(connectionString))
			{
				String sql =  @"INSERT INTO `employeetype`
                                (
                                    `Name`
                                )
                                VALUES
                                (
                                    @Name
                                );";

				con.Open();

				using (MySqlCommand cmd = new MySqlCommand(sql, con))
				{
					cmd.Parameters.Add("@Name", MySqlDbType.VarChar, 50).Value = Name;
					cmd.ExecuteNonQuery();

					// Get value of the auto increment column.
					Id = Convert.ToInt32(cmd.LastInsertedId);
				}

				con.Close();
			}
		}
		#endregion

		#region Update
		/// <summary>
		/// Updates an existing record.
		/// </summary>
		public void Update()
		{
			String connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

			using (MySqlConnection con = new MySqlConnection(connectionString))
			{
				String sql =  @"UPDATE  `employeetype`
                                SET     `Name` = @Name
                                WHERE   `Id` = @Id;";

				con.Open();

				using (MySqlCommand cmd = new MySqlCommand(sql, con))
				{
					cmd.Parameters.Add("@Id", MySqlDbType.Int32, 4).Value = Id;
					cmd.Parameters.Add("@Name", MySqlDbType.VarChar, 50).Value = Name;
					cmd.ExecuteNonQuery();
				}

				con.Close();
			}
		}
		#endregion

		#region Delete
		/// <summary>
		/// Deletes an existing record.
		/// </summary>
		public static void Delete(int id)
		{
			String connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

			using (MySqlConnection con = new MySqlConnection(connectionString))
			{
				String sql =  @"DELETE  FROM `employeetype`
                                WHERE   `Id` = @Id;";

				con.Open();

				using (MySqlCommand cmd = new MySqlCommand(sql, con))
				{
					cmd.Parameters.Add("@Id", MySqlDbType.Int32, 4).Value = id;
					cmd.ExecuteNonQuery();
				}

				con.Close();
			}
		}
		#endregion

		#region Get
		/// <summary>
		/// Gets an existing record.
		/// </summary>
		public static EmployeeType Get(int id)
		{
			String connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

			using (MySqlConnection con = new MySqlConnection(connectionString))
			{
				String sql =  @"SELECT  `Id`,
                                        `Name`
                                FROM    `employeetype`
                                WHERE   `Id` = @Id;";

				EmployeeType employeeType = new EmployeeType();

				con.Open();

				using (MySqlCommand cmd = new MySqlCommand(sql, con))
				{
					cmd.Parameters.Add("@Id", MySqlDbType.Int32, 4).Value = id;

					using (MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
						if (reader.Read())
						{
							employeeType.Id = Convert.ToInt32(reader["Id"]);
							employeeType.Name = reader["Name"].ToString();
						}
					}
				}

				return employeeType;
			}
		}
		#endregion

		#region Get All
		/// <summary>
		/// Gets all records.
		/// </summary>
		public static DataTable GetAll()
		{
			String connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

			using (MySqlConnection con = new MySqlConnection(connectionString))
			{
				DataTable dataTable = new DataTable();

				con.Open();

				string sql =  @"SELECT  `Id`,
                                        `Name`
                                FROM    `employeetype`;";

				using (MySqlCommand cmd = new MySqlCommand(sql, con))
				{
					using (MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
						dataTable.Load(reader);
					}
				}

				return dataTable;
			}
		}
		#endregion
	}
}