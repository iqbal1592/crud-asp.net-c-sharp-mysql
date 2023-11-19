using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccessLayer
{
	public class EmpDeduction
	{
		#region Properties
		public int Id { get; set; }
		public int EmpId { get; set; }
		public int DeductionType { get; set; }
		public DateTime DeductionDate { get; set; }
		public float Amount { get; set; }
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
				String sql =  @"INSERT INTO `empdeduction`
                                (
                                    `EmpId`,
                                    `DeductionType`,
                                    `DeductionDate`,
                                    `Amount`
                                )
                                VALUES
                                (
                                    @EmpId,
                                    @DeductionType,
                                    @DeductionDate,
                                    @Amount
                                );";

				con.Open();

				using (MySqlCommand cmd = new MySqlCommand(sql, con))
				{
					cmd.Parameters.Add("@EmpId", MySqlDbType.Int32, 4).Value = EmpId;
					cmd.Parameters.Add("@DeductionType", MySqlDbType.Int32, 4).Value = DeductionType;
					cmd.Parameters.Add("@DeductionDate", MySqlDbType.Date, 3).Value = DeductionDate;
					cmd.Parameters.Add("@Amount", MySqlDbType.Float, 4).Value = Amount;
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
				String sql =  @"UPDATE  `empdeduction`
                                SET     `EmpId` = @EmpId,
                                        `DeductionType` = @DeductionType,
                                        `DeductionDate` = @DeductionDate,
                                        `Amount` = @Amount
                                WHERE   `Id` = @Id;";

				con.Open();

				using (MySqlCommand cmd = new MySqlCommand(sql, con))
				{
					cmd.Parameters.Add("@Id", MySqlDbType.Int32, 4).Value = Id;
					cmd.Parameters.Add("@EmpId", MySqlDbType.Int32, 4).Value = EmpId;
					cmd.Parameters.Add("@DeductionType", MySqlDbType.Int32, 4).Value = DeductionType;
					cmd.Parameters.Add("@DeductionDate", MySqlDbType.Date, 3).Value = DeductionDate;
					cmd.Parameters.Add("@Amount", MySqlDbType.Float, 4).Value = Amount;
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
				String sql =  @"DELETE  FROM `empdeduction`
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
		public static EmpDeduction Get(int id)
		{
			String connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

			using (MySqlConnection con = new MySqlConnection(connectionString))
			{
				String sql =  @"SELECT  `Id`,
                                        `EmpId`,
                                        `DeductionType`,
                                        `DeductionDate`,
                                        `Amount`
                                FROM    `empdeduction`
                                WHERE   `Id` = @Id;";

				EmpDeduction empDeduction = new EmpDeduction();

				con.Open();

				using (MySqlCommand cmd = new MySqlCommand(sql, con))
				{
					cmd.Parameters.Add("@Id", MySqlDbType.Int32, 4).Value = id;

					using (MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
						if (reader.Read())
						{
							empDeduction.Id = Convert.ToInt32(reader["Id"]);
							empDeduction.EmpId = Convert.ToInt32(reader["EmpId"]);
							empDeduction.DeductionType = Convert.ToInt32(reader["DeductionType"]);
							empDeduction.DeductionDate = Convert.ToDateTime(reader["DeductionDate"]);
							empDeduction.Amount = Convert.ToSingle(reader["Amount"]);
						}
					}
				}

				return empDeduction;
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
                                        `DeductionType`,
                                        `DeductionDate`,
                                        `Amount`
                                FROM    `empdeduction`;";

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