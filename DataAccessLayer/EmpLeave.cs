using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccessLayer
{
	public class EmpLeave
	{
		#region Properties
		public int Id { get; set; }
		public int EmpId { get; set; }
		public int LeaveTypeId { get; set; }
		public DateTime DateFrom { get; set; }
		public DateTime DateTo { get; set; }
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
				String sql =  @"INSERT INTO `empleave`
                                (
                                    `EmpId`,
                                    `LeaveTypeId`,
                                    `DateFrom`,
                                    `DateTo`
                                )
                                VALUES
                                (
                                    @EmpId,
                                    @LeaveTypeId,
                                    @DateFrom,
                                    @DateTo
                                );";

				con.Open();

				using (MySqlCommand cmd = new MySqlCommand(sql, con))
				{
					cmd.Parameters.Add("@EmpId", MySqlDbType.Int32, 4).Value = EmpId;
					cmd.Parameters.Add("@LeaveTypeId", MySqlDbType.Int32, 4).Value = LeaveTypeId;
					cmd.Parameters.Add("@DateFrom", MySqlDbType.Date, 3).Value = DateFrom;
					cmd.Parameters.Add("@DateTo", MySqlDbType.Date, 3).Value = DateTo;
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
				String sql =  @"UPDATE  `empleave`
                                SET     `EmpId` = @EmpId,
                                        `LeaveTypeId` = @LeaveTypeId,
                                        `DateFrom` = @DateFrom,
                                        `DateTo` = @DateTo
                                WHERE   `Id` = @Id;";

				con.Open();

				using (MySqlCommand cmd = new MySqlCommand(sql, con))
				{
					cmd.Parameters.Add("@Id", MySqlDbType.Int32, 4).Value = Id;
					cmd.Parameters.Add("@EmpId", MySqlDbType.Int32, 4).Value = EmpId;
					cmd.Parameters.Add("@LeaveTypeId", MySqlDbType.Int32, 4).Value = LeaveTypeId;
					cmd.Parameters.Add("@DateFrom", MySqlDbType.Date, 3).Value = DateFrom;
					cmd.Parameters.Add("@DateTo", MySqlDbType.Date, 3).Value = DateTo;
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
				String sql =  @"DELETE  FROM `empleave`
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
		public static EmpLeave Get(int id)
		{
			String connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

			using (MySqlConnection con = new MySqlConnection(connectionString))
			{
				String sql =  @"SELECT  `Id`,
                                        `EmpId`,
                                        `LeaveTypeId`,
                                        `DateFrom`,
                                        `DateTo`
                                FROM    `empleave`
                                WHERE   `Id` = @Id;";

				EmpLeave empLeave = new EmpLeave();

				con.Open();

				using (MySqlCommand cmd = new MySqlCommand(sql, con))
				{
					cmd.Parameters.Add("@Id", MySqlDbType.Int32, 4).Value = id;

					using (MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
						if (reader.Read())
						{
							empLeave.Id = Convert.ToInt32(reader["Id"]);
							empLeave.EmpId = Convert.ToInt32(reader["EmpId"]);
							empLeave.LeaveTypeId = Convert.ToInt32(reader["LeaveTypeId"]);
							empLeave.DateFrom = Convert.ToDateTime(reader["DateFrom"]);
							empLeave.DateTo = Convert.ToDateTime(reader["DateTo"]);
						}
					}
				}

				return empLeave;
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
                                        `EmpId`,
                                        `LeaveTypeId`,
                                        `DateFrom`,
                                        `DateTo`
                                FROM    `empleave`;";

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