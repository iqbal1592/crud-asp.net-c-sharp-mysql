using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccessLayer
{
	public class EmpLoan
	{
		#region Properties
		public int Id { get; set; }
		public int EmpId { get; set; }
		public DateTime LoanDate { get; set; }
		public int LoanTypeId { get; set; }
		public float? Amount { get; set; }
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
				String sql =  @"INSERT INTO `emploan`
                                (
                                    `EmpId`,
                                    `LoanDate`,
                                    `LoanTypeId`,
                                    `Amount`
                                )
                                VALUES
                                (
                                    @EmpId,
                                    @LoanDate,
                                    @LoanTypeId,
                                    @Amount
                                );";

				con.Open();

				using (MySqlCommand cmd = new MySqlCommand(sql, con))
				{
					cmd.Parameters.Add("@EmpId", MySqlDbType.Int32, 4).Value = EmpId;
					cmd.Parameters.Add("@LoanDate", MySqlDbType.Date, 3).Value = LoanDate;
					cmd.Parameters.Add("@LoanTypeId", MySqlDbType.Int32, 4).Value = LoanTypeId;
					cmd.Parameters.Add("@Amount", MySqlDbType.Float, 4).Value = Amount == null ? (Object)DBNull.Value : Amount;
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
				String sql =  @"UPDATE  `emploan`
                                SET     `EmpId` = @EmpId,
                                        `LoanDate` = @LoanDate,
                                        `LoanTypeId` = @LoanTypeId,
                                        `Amount` = @Amount
                                WHERE   `Id` = @Id;";

				con.Open();

				using (MySqlCommand cmd = new MySqlCommand(sql, con))
				{
					cmd.Parameters.Add("@Id", MySqlDbType.Int32, 4).Value = Id;
					cmd.Parameters.Add("@EmpId", MySqlDbType.Int32, 4).Value = EmpId;
					cmd.Parameters.Add("@LoanDate", MySqlDbType.Date, 3).Value = LoanDate;
					cmd.Parameters.Add("@LoanTypeId", MySqlDbType.Int32, 4).Value = LoanTypeId;
					cmd.Parameters.Add("@Amount", MySqlDbType.Float, 4).Value = Amount == null ? (Object)DBNull.Value : Amount;
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
				String sql =  @"DELETE  FROM `emploan`
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
		public static EmpLoan Get(int id)
		{
			String connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

			using (MySqlConnection con = new MySqlConnection(connectionString))
			{
				String sql =  @"SELECT  `Id`,
                                        `EmpId`,
                                        `LoanDate`,
                                        `LoanTypeId`,
                                        `Amount`
                                FROM    `emploan`
                                WHERE   `Id` = @Id;";

				EmpLoan empLoan = new EmpLoan();

				con.Open();

				using (MySqlCommand cmd = new MySqlCommand(sql, con))
				{
					cmd.Parameters.Add("@Id", MySqlDbType.Int32, 4).Value = id;

					using (MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
						if (reader.Read())
						{
							empLoan.Id = Convert.ToInt32(reader["Id"]);
							empLoan.EmpId = Convert.ToInt32(reader["EmpId"]);
							empLoan.LoanDate = Convert.ToDateTime(reader["LoanDate"]);
							empLoan.LoanTypeId = Convert.ToInt32(reader["LoanTypeId"]);
							empLoan.Amount = reader["Amount"] == DBNull.Value ? (float?)null : Convert.ToSingle(reader["Amount"]);
						}
					}
				}

				return empLoan;
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
                                        `LoanDate`,
                                        `LoanTypeId`,
                                        `Amount`
                                FROM    `emploan`;";

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