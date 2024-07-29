using Dapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristGuide.Domain.Common.Models;
using TouristGuide.Domain.Content.Models;
using Microsoft.Extensions.Configuration;
using TouristGuide.Domain.Content.IRepositories;

namespace TouristGuide.Infastructure.Content.Repositories
{
    public class GalleryRepository : IGalleryRepository
    {
        private readonly IConfiguration _config;

        public GalleryRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<CommonResponseModel> UploadGallery(string Title, List<IFormFile> files, string Description)
        {
            CommonResponseModel response;
            try
            {
                using (IDbConnection conn = new SqlConnection(_config.GetConnectionString("Tourist")))
                {

                    DynamicParameters outParams = new();
                    outParams.Add("@Title",Title, dbType: DbType.String, direction: ParameterDirection.Input);
                    outParams.Add("@Description",Description, dbType: DbType.String, direction: ParameterDirection.Input, size: 250);
                    outParams.Add("@responseMsg", dbType: DbType.String, direction: ParameterDirection.Output, size: 250);
                    outParams.Add("@responseCode", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    var contactDetails = await conn.QueryAsync<GalleryModel>("[CN].[spUploadGallery]", outParams, commandType: CommandType.StoredProcedure);
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
        public async Task<GalleryModel> GetGalleryFilesByFolderName(string Title)
        {
            {
                GalleryModel response = new GalleryModel();
                try
                {
                    using (IDbConnection conn = new SqlConnection(_config.GetConnectionString("Tourist")))
                    {

                        DynamicParameters outParams = new();
                        outParams.Add("@Title", Title, dbType: DbType.String, direction: ParameterDirection.Input);
                        outParams.Add("@responseMsg", dbType: DbType.String, direction: ParameterDirection.Output, size: 250);
                        outParams.Add("@responseCode", dbType: DbType.Int32, direction: ParameterDirection.Output);
                        var data = await conn.QueryAsync<GalleryModel>("[CN].[spGetGalleryFilesByFolderName]", outParams, commandType: CommandType.StoredProcedure);
                        response=data.FirstOrDefault();
                       


                        //  _logger.LogInformation(CompanyID + " " + UserName + " |" + "All Additions viewed");



                    }
                }
                catch (Exception ex)
                {


                    response = null;


                    //  _logger.LogError(CompanyID + " " + UserName + " Error occurred while getting Additions |" + ex.Message + Environment.NewLine + ex.StackTrace);

                }
                return response;

            }
        }

    }
}
