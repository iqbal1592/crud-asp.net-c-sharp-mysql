using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccessLayer
{
	public class Employee
	{
		#region Properties
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string EmailAddress { get; set; }
		public bool IsActive { get; set; }
		public int EmpTypeId { get; set; }
		public int? DesignationId { get; set; }
		public int? Country { get; set; }
		public string Address { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string Gender { get; set; }
		public string PassportNo { get; set; }
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
				String sql =  @"INSERT INTO `employee`
                                (
                                    `FirstName`,
                                    `MiddleName`,
                                    `LastName`,
                                    `EmailAddress`,
                                    `IsActive`,
                                    `EmpTypeId`,
                                    `DesignationId`,
                                    `Country`,
                                    `Address`,
                                    `DateOfBirth`,
                                    `Gender`,
                                    `PassportNo`
                                )
                                VALUES
                                (
                                    @FirstName,
                                    @MiddleName,
                                    @LastName,
                                    @EmailAddress,
                                    @IsActive,
                                    @EmpTypeId,
                                    @DesignationId,
                                    @Country,
                                    @Address,
                                    @DateOfBirth,
                                    @Gender,
                                    @PassportNo
                                );";

				con.Open();

				using (MySqlCommand cmd = new MySqlCommand(sql, con))
				{
					cmd.Parameters.Add("@FirstName", MySqlDbType.VarChar, 50).Value = FirstName;
					cmd.Parameters.Add("@MiddleName", MySqlDbType.VarChar, 50).Value = MiddleName == null ? (Object)DBNull.Value : MiddleName;
					cmd.Parameters.Add("@LastName", MySqlDbType.VarChar, 50).Value = LastName;
					cmd.Parameters.Add("@EmailAddress", MySqlDbType.VarChar, 100).Value = EmailAddress == null ? (Object)DBNull.Value : EmailAddress;
					cmd.Parameters.Add("@IsActive", MySqlDbType.Byte, 1).Value = IsActive;
					cmd.Parameters.Add("@EmpTypeId", MySqlDbType.Int32, 4).Value = EmpTypeId;
					cmd.Parameters.Add("@DesignationId", MySqlDbType.Int32, 4).Value = DesignationId == null ? (Object)DBNull.Value : DesignationId;
					cmd.Parameters.Add("@Country", MySqlDbType.Int32, 4).Value = Country == null ? (Object)DBNull.Value : Country;
					cmd.Parameters.Add("@Address", MySqlDbType.VarChar, 200).Value = Address == null ? (Object)DBNull.Value : Address;
					cmd.Parameters.Add("@DateOfBirth", MySqlDbType.Date, 3).Value = DateOfBirth == null ? (Object)DBNull.Value : DateOfBirth;
					cmd.Parameters.Add("@Gender", MySqlDbType.VarChar, 10).Value = Gender == null ? (Object)DBNull.Value : Gender;
					cmd.Parameters.Add("@PassportNo", MySqlDbType.VarChar, 50).Value = PassportNo == null ? (Object)DBNull.Value : PassportNo;
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
				String sql =  @"UPDATE  `employee`
                                SET     `FirstName` = @FirstName,
                                        `MiddleName` = @MiddleName,
                                        `LastName` = @LastName,
                                        `EmailAddress` = @EmailAddress,
                                        `IsActive` = @IsActive,
                                        `EmpTypeId` = @EmpTypeId,
                                        `DesignationId` = @DesignationId,
                                        `Country` = @Country,
                                        `Address` = @Address,
                                        `DateOfBirth` = @DateOfBirth,
                                        `Gender` = @Gender,
                                        `PassportNo` = @PassportNo
                                WHERE   `Id` = @Id;";

				con.Open();

				using (MySqlCommand cmd = new MySqlCommand(sql, con))
				{
					cmd.Parameters.Add("@Id", MySqlDbType.Int32, 4).Value = Id;
					cmd.Parameters.Add("@FirstName", MySqlDbType.VarChar, 50).Value = FirstName;
					cmd.Parameters.Add("@MiddleName", MySqlDbType.VarChar, 50).Value = MiddleName == null ? (Object)DBNull.Value : MiddleName;
					cmd.Parameters.Add("@LastName", MySqlDbType.VarChar, 50).Value = LastName;
					cmd.Parameters.Add("@EmailAddress", MySqlDbType.VarChar, 100).Value = EmailAddress == null ? (Object)DBNull.Value : EmailAddress;
					cmd.Parameters.Add("@IsActive", MySqlDbType.Byte, 1).Value = IsActive;
					cmd.Parameters.Add("@EmpTypeId", MySqlDbType.Int32, 4).Value = EmpTypeId;
					cmd.Parameters.Add("@DesignationId", MySqlDbType.Int32, 4).Value = DesignationId == null ? (Object)DBNull.Value : DesignationId;
					cmd.Parameters.Add("@Country", MySqlDbType.Int32, 4).Value = Country == null ? (Object)DBNull.Value : Country;
					cmd.Parameters.Add("@Address", MySqlDbType.VarChar, 200).Value = Address == null ? (Object)DBNull.Value : Address;
					cmd.Parameters.Add("@DateOfBirth", MySqlDbType.Date, 3).Value = DateOfBirth == null ? (Object)DBNull.Value : DateOfBirth;
					cmd.Parameters.Add("@Gender", MySqlDbType.VarChar, 10).Value = Gender == null ? (Object)DBNull.Value : Gender;
					cmd.Parameters.Add("@PassportNo", MySqlDbType.VarChar, 50).Value = PassportNo == null ? (Object)DBNull.Value : PassportNo;
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
				String sql =  @"DELETE  FROM `employee`
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
		public static Employee Get(int id)
		{
			String connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

			using (MySqlConnection con = new MySqlConnection(connectionString))
			{
				String sql =  @"SELECT  `Id`,
                                        `FirstName`,
                                        `MiddleName`,
                                        `LastName`,
                                        `EmailAddress`,
                                        `IsActive`,
                                        `EmpTypeId`,
                                        `DesignationId`,
                                        `Country`,
                                        `Address`,
                                        `DateOfBirth`,
                                        `Gender`,
                                        `PassportNo`
                                FROM    `employee`
                                WHERE   `Id` = @Id;";

				Employee employee = new Employee();

				con.Open();

				using (MySqlCommand cmd = new MySqlCommand(sql, con))
				{
					cmd.Parameters.Add("@Id", MySqlDbType.Int32, 4).Value = id;

					using (MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
						if (reader.Read())
						{
							employee.Id = Convert.ToInt32(reader["Id"]);
							employee.FirstName = reader["FirstName"].ToString();
							employee.MiddleName = reader["MiddleName"] == DBNull.Value ? null : reader["MiddleName"].ToString();
							employee.LastName = reader["LastName"].ToString();
							employee.EmailAddress = reader["EmailAddress"] == DBNull.Value ? null : reader["EmailAddress"].ToString();
							employee.IsActive = Convert.ToBoolean(reader["IsActive"]);
							employee.EmpTypeId = Convert.ToInt32(reader["EmpTypeId"]);
							employee.DesignationId = reader["DesignationId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["DesignationId"]);
							employee.Country = reader["Country"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["Country"]);
							employee.Address = reader["Address"] == DBNull.Value ? null : reader["Address"].ToString();
							employee.DateOfBirth = reader["DateOfBirth"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["DateOfBirth"]);
							employee.Gender = reader["Gender"] == DBNull.Value ? null : reader["Gender"].ToString();
							employee.PassportNo = reader["PassportNo"] == DBNull.Value ? null : reader["PassportNo"].ToString();
						}
					}
				}

				return employee;
			}
		}
		#endregion

		#region Get All
		/// <summary>
		/// Gets all records.
		/// </summary>
		public static DataTable GetAll(int pageNo, int pageSize, out int totalRecordsCount, String sortColumn, String sortOrder, string firstName, string lastName)
		{
			String connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

			using (MySqlConnection con = new MySqlConnection(connectionString))
			{
				DataTable dataTable = new DataTable();

				con.Open();

				String sql =  @"SELECT  COUNT(*)
                                FROM    `employee`
                                WHERE   (@FirstName IS NULL OR `FirstName` LIKE @FirstName)
                                AND     (@LastName IS NULL OR `LastName` LIKE @LastName);";

				using (MySqlCommand cmd = new MySqlCommand(sql, con))
				{
					cmd.Parameters.Add("@FirstName", MySqlDbType.VarChar, 50).Value = firstName == null ? (Object)DBNull.Value : "%" + firstName + "%";
					cmd.Parameters.Add("@LastName", MySqlDbType.VarChar, 50).Value = lastName == null ? (Object)DBNull.Value : "%" + lastName + "%";

					totalRecordsCount = Convert.ToInt32(cmd.ExecuteScalar());
				}

				int pagesCount = (int)Math.Ceiling((double)totalRecordsCount / pageSize);
				pageNo = pageNo > pagesCount ? pagesCount : pageNo;
				int start = pageSize * pageNo - pageSize;
				start = start < 0 ? 0 : start;

				// Validate sort column and order.
				string defaultSortColumn = "`Id`";
				string[] sortColumns = { "ID", "FIRSTNAME", "LASTNAME", "EMAILADDRESS", "ISACTIVE", "GENDER" };
				sortColumn = sortColumns.Contains(sortColumn.ToUpper()) ? "`" + sortColumn + "`" : defaultSortColumn;
				sortOrder = sortOrder.ToUpper() == "DESC" ? "DESC" : "ASC";

				sql = @"SELECT  `Id`,
                                `FirstName`,
                                `LastName`,
                                `EmailAddress`,
                                `IsActive`,
                                `Gender`
                        FROM    `employee`
                        WHERE   (@FirstName IS NULL OR `FirstName` LIKE @FirstName)
                        AND     (@LastName IS NULL OR `LastName` LIKE @LastName)
                        ORDER BY {0} {1}
                        LIMIT   @Start, @PageSize;";

				sql = string.Format(sql, sortColumn, sortOrder);

				using (MySqlCommand cmd = new MySqlCommand(sql, con))
				{
					cmd.Parameters.Add("@FirstName", MySqlDbType.VarChar, 50).Value = firstName == null ? (Object)DBNull.Value : "%" + firstName + "%";
					cmd.Parameters.Add("@LastName", MySqlDbType.VarChar, 50).Value = lastName == null ? (Object)DBNull.Value : "%" + lastName + "%";
					cmd.Parameters.Add("@SortColumn", MySqlDbType.VarChar, 12).Value = sortColumn;
					cmd.Parameters.Add("@SortOrder", MySqlDbType.VarChar, 4).Value = sortOrder;
					cmd.Parameters.Add("@Start", MySqlDbType.Int32, 4).Value = start;
					cmd.Parameters.Add("@PageSize", MySqlDbType.Int32, 4).Value = pageSize;

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