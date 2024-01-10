﻿using Dapper;
using Microsoft.Extensions.Configuration;
using SUSS.DOM.Entities;
using System.Data;

namespace SUSS.DAL.Repositories
{
    // public class GenericRepository : BaseRepository, IGenericRepository
    public class GenericRepository<T> : BaseRepository, IGenericRepository<T> where T : BaseEntity
    {
        public GenericRepository(IConfiguration configuration) : base(configuration)
        { }
        public int Delete<T>(string sp, T parms, CommandType commandType = CommandType.StoredProcedure)
        {
            int result;
            using IDbConnection db = CreateConnection();
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    result = db.Execute(sp, parms, commandType: commandType, transaction: tran);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result;
        }
        public int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            throw new NotImplementedException();
        }
        public T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text)
        {
            using IDbConnection db = CreateConnection();
            return db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
        }
        public List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = CreateConnection();
            return db.Query<T>(sp, parms, commandType: commandType).ToList();
        }
        public T Insert<T>(string sp, T parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            using IDbConnection db = CreateConnection();
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result;
        }
        public T Update<T>(string sp, T parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            using IDbConnection db = CreateConnection();
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result;
        }
        public void Dispose()
        {

        }
    }

}
