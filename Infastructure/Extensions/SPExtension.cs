using Common.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace Infastructure.Extensions
{
    public static class SPExtension
    {
        /// <summary>
        /// Custom Linq method for loading Stored procedures and sql Command that returns resultsets.
        /// The allowed CommandType are CommandType.StoreProcedure and CommandType.Text.
        /// Eg. CommandText - SELECT * FROM tablename or SELECT column1,column2 FROM tablename
        /// </summary>
        /// <param name="context">DbContext</param>
        /// <param name="commandText">Command Text or Stored procedure</param>
        /// <param name="commandType">StoredProcedure or CommandText[Default - StoredProcedure]</param>
        /// <returns></returns>
        public static DbCommand LoadCommand(this DbContext context, string commandText, CommandType commandType = CommandType.StoredProcedure)
        {
            var cmd = context.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;
            return cmd;
        }
        /// Load stored procedure paramaters with dictionary of parameters.
        /// This method passes a list of paramaters for a stored procedure.
        /// If your CommandType from LoadCommand method is CommandType.Text do not call this method.
        /// For CommandType.CommandText use string.format("SELECT * FROM tablename where column1 = '{0}'", parameter)
        /// </summary>
        /// <param name="command"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DbCommand WithSqlParam(this DbCommand command, Dictionary<string, object> parameters)
        {
            if (command.CommandText.IsNullOrEmptyOrWhiteSpace())
                throw new Exception("Call LoadCommand before using this method");
            if (!parameters.Any())
                throw new Exception("Paramaters must not be empty");

            parameters.ToList()
                   .ForEach(param => command.Parameters.Add(command.SetParams(param.Key, param.Value)));

            return command;
        }
        private static DbParameter SetParams(this DbCommand command, string paramName, object paramValue)
        {
            var param = command.CreateParameter();
            param.ParameterName = paramName;
            param.Value = paramValue;
            return param;
        }
        /// <summary>
        /// Executes the CommandType.StoredProcedure or CommandType.Text to load data to model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <param name="excludedProperties"></param>
        /// <returns></returns>
        private static IList<T> MapToList<T>(this DbDataReader reader, List<string> excludedProperties = null)
        {
            var objList = new List<T>();
            var props = excludedProperties != null
                ? typeof(T).GetProperties().Where(_ => !excludedProperties.Any(p => p.ToLower().Equals(_.Name.ToLower()))) : typeof(T).GetProperties();
            var colMapping = reader.GetColumnSchema()
                                   .Where(_ => props.Any(y => y.Name.ToLower() == _.ColumnName.ToLower()))
                                   .ToDictionary(key => key.ColumnName.ToLower());
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    T obj = Activator.CreateInstance<T>();
                    foreach(var prop in props)
                    {
                        var val = reader.GetValue(colMapping[prop.Name.ToLower()].ColumnOrdinal.Value);
                        prop.SetValue(obj, val == DBNull.Value ? null : val);
                    }
                    objList.Add(obj);
                }
            }
            return objList;
        }
        public static IList<T> ExecuteStoredProc<T>(this DbCommand command, List<string> excludedProperties = null)
        {
            using (command)
            {
                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();
                try
                {
                    using var reader = command.ExecuteReader();
                    return reader.MapToList<T>(excludedProperties);
                }
                finally
                {
                    command.Connection.Close();
                }
            }
        }
        
    }
}
