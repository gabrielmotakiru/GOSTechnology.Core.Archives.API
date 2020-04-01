using GOSTechnology.Core.Archives.Domain.Interfaces;
using GOSTechnology.Core.Archives.Domain.Models;
using Npgsql;
using System;
using System.Threading.Tasks;
using Dapper;
using System.Collections;
using System.Collections.Generic;

namespace GOSTechnology.Core.Archives.Repository
{
    /// <summary>
    /// ArchiveRepository.
    /// </summary>
    public class ArchiveRepository : IArchiveRepository
    {
        /// <summary>
        /// _connectionString.
        /// </summary>
        private readonly String _connectionString;

        /// <summary>
        /// ArchiveRepository.
        /// </summary>
        public ArchiveRepository()
        {
            _connectionString = BaseRepository.GetConnectionString();
        }

        /// <summary>
        /// InsertArchive.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> InsertArchive(ArchiveModel model)
        {
            var result = false;         

            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(_connectionString))
            {
                var sql = @"INSERT INTO Archives (ArchiveId, ArchiveName, ContentType, UserToken) 
                            VALUES (@ArchiveId, @ArchiveName, @ContentType, @UserToken);";

                result = (await npgsqlConnection.ExecuteAsync(sql, model)) > 0;
            }

            return result;
        }

        /// <summary>
        /// FindOneArchive.
        /// </summary>
        /// <param name="archiveId"></param>
        /// <returns></returns>
        public async Task<ArchiveModel> FindOneArchive(String archiveId)
        {
            ArchiveModel result = null;

            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(_connectionString))
            {
                var sql = @"SELECT ArchiveId, ArchiveName, ContentType, UserToken FROM Archives
                            WHERE ArchiveId = @archiveId";

                result = await npgsqlConnection.QueryFirstAsync<ArchiveModel>(sql, new { archiveId });
            }

            return result;
        }

        /// <summary>
        /// ListArchives.
        /// </summary>
        /// <param name="userToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ArchiveModel>> ListArchives(String userToken)
        {
            IEnumerable<ArchiveModel> result = null;

            using (NpgsqlConnection npgsqlConnection = new NpgsqlConnection(_connectionString))
            {
                var sql = @"SELECT ArchiveId, ArchiveName, ContentType, UserToken FROM Archives
                            WHERE UserToken = @userToken";

                result = await npgsqlConnection.QueryAsync<ArchiveModel>(sql, new { userToken });
            }

            return result;
        }
    }
}
