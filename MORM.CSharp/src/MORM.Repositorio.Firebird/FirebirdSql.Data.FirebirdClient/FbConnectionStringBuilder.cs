﻿namespace MORM.Repositorio.Firebird.FirebirdSql.Data.FirebirdClient
{
    //-- galeg - 30/03/2018 17:12:03
    internal class FbConnectionStringBuilder
    {
        public string Database { get; internal set; }
        public string UserID { get; internal set; }
        public string Password { get; internal set; }
        public string DataSource { get; internal set; }

        public override string ToString()
        {
            return $"Database={Database};User ID={UserID};Password={Password};DataSource={DataSource};Charset=WIN1252";
        }
    }
}