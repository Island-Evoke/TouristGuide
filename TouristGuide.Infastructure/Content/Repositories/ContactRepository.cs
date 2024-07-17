using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristGuide.Domain.Common.Models;
using TouristGuide.Domain.Content.IRepositories;
using Microsoft.Extensions.Configuration;
using TouristGuide.Domain.Content.Models;
namespace TouristGuide.Infastructure.Content.Repositories
{
    public class ContactRepository:IContentRepository
    {
        private readonly IConfiguration _config;

        public ContactRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<CommonResponseModel> GetContactPageDetails()
        {
            CommonResponseModel response;
            try
            {
                using (IDbConnection conn = new SqlConnection(_config.GetConnectionString("Tourist")))
                {

                    DynamicParameters outParams = new();
                    outParams.Add("@responseMsg", dbType: DbType.String, direction: ParameterDirection.Output, size: 250);
                    outParams.Add("@responseCode", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    var contactDetails = await conn.QueryAsync<ContactModel>("[CN].[spGetContactPageDetails]", outParams, commandType: CommandType.StoredProcedure);
                    response = new CommonResponseModel { responseMsg = outParams.Get<string>("@responseMsg"), responseCode = outParams.Get<Int32>("@responseCode"), returnData = contactDetails };


                  //  _logger.LogInformation(CompanyID + " " + UserName + " |" + "All Additions viewed");



                }
            }
            catch (Exception ex)
            {


                response = new CommonResponseModel { responseMsg = ex.Message.Trim(), responseCode = 0, returnData = null };


              //  _logger.LogError(CompanyID + " " + UserName + " Error occurred while getting Additions |" + ex.Message + Environment.NewLine + ex.StackTrace);

            }
            return response;


        }

    }
}
