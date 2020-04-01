using System;
using System.Collections.Generic;
using System.Text;

namespace GOSTechnology.Core.Archives.Repository
{
    /// <summary>
    /// BaseRepository.
    /// </summary>
    public static class BaseRepository
    {
        /// <summary>
        /// GetConnectionString.
        /// </summary>
        /// <returns></returns>
        public static String GetConnectionString()
        {
            var result = String.Empty;
            var defaultEnvironment = Environment.GetEnvironmentVariable("ArchiveConnectionString");
            var userEnvironment = Environment.GetEnvironmentVariable("ArchiveConnectionString", EnvironmentVariableTarget.User);
            var processEnvironment = Environment.GetEnvironmentVariable("ArchiveConnectionString", EnvironmentVariableTarget.Process);
            var machineEnvironment = Environment.GetEnvironmentVariable("ArchiveConnectionString", EnvironmentVariableTarget.Machine);

            if (!String.IsNullOrWhiteSpace(defaultEnvironment))
            {
                result = defaultEnvironment;
            }
            else if (!String.IsNullOrWhiteSpace(userEnvironment))
            {
                result = userEnvironment;
            }
            else if (!String.IsNullOrWhiteSpace(processEnvironment))
            {
                result = processEnvironment;
            }
            else if (!String.IsNullOrWhiteSpace(machineEnvironment))
            {
                result = machineEnvironment;
            }

            return result;
        }
    }
}
