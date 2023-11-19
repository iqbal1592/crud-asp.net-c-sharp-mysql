using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccessLayer
{
	public class EmpBonus
	{
		#region Properties
		public int Id { get; set; }
		public int EmpId { get; set; }
		public int BonusType { get; set; }
		public DateTime DateApproved { get; set; }
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
				String sql =  @"INSERT INTO `empbonus`
                                (
                                    `EmpId`,
                                    `BonusType`,
                                    `DateApproved`,
                                    `Amount`
                                )
                                VALUES
                                (
                                    @EmpId,
                                    @BonusType,
                                    @DateApproved,
                                    @Amount
                                );";

				con.Open();

				using (MySqlCommand cmd = new MySqlCommand(sql, con))
				{
					cmd.Parameters.Add("@EmpId", MySqlDbType.Int32, 4).Value = EmpId;
					cmd.Parameters.Add("@BonusType", MySqlDbType.Int32, 4).Value = BonusType;
					cmd.Parameters.Add("@DateApproved", MySqlDbType.Date, 3).Value = DateApproved;
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
				String sql =  @"UPDATE  `empbonus`
                                SET     `EmpId` = @EmpId,
                                        `BonusType` = @BonusType,
                                        `DateApproved` = @DateApproved,
                                        `Amount` = @Amount
                                WHERE   `Id` = @Id;";

				con.Open();

				using (MySqlCommand cmd = new MySqlCommand(sql, con))
				{
					cmd.Parameters.Add("@Id", MySqlDbType.Int32, 4).Value = Id;
					cmd.Parameters.Add("@EmpId", MySqlDbType.Int32, 4).Value = EmpId;
					cmd.Parameters.Add("@BonusType", MySqlDbType.Int32, 4).Value = BonusType;
					cmd.Parameters.Add("@DateApproved", MySqlDbType.Date, 3).Value = DateApproved;
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
				String sql =  @"DELETE  FROM `empbonus`
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
		public static EmpBonus Get(int id)
		{
			String connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

			using (MySqlConnection con = new MySqlConnection(connectionString))
			{
				String sql =  @"SELECT  `Id`,
                                        `EmpId`,
                                        `BonusType`,
                                        `DateApproved`,
                                        `Amount`
                                FROM    `empbonus`
                                WHERE   `Id` = @Id;";

				EmpBonus empBonus = new EmpBonus();

				con.Open();

				using (MySqlCommand cmd = new MySqlCommand(sql, con))
				{
					cmd.Parameters.Add("@Id", MySqlDbType.Int32, 4).Value = id;

					using (MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
						if (reader.Read())
						{
							empBonus.Id = Convert.ToInt32(reader["Id"]);
							empBonus.EmpId = Convert.ToInt32(reader["EmpId"]);
							empBonus.BonusType = Convert.ToInt32(reader["BonusType"]);
							empBonus.DateApproved = Convert.ToDateTime(reader["DateApproved"]);
							empBonus.Amount = Convert.ToSingle(reader["Amount"]);
						}
					}
				}

				return empBonus;
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
                                        `BonusType`,
                                        `DateApproved`,
                                        `Amount`
                                FROM    `empbonus`;";

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