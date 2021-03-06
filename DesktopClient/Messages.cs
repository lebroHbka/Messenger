﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace DesktopClient
{
    class MessageFormat
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Friend { get; set; }
        public string Message { get; set; }
        public long Data { get; set; }
        public int IsReceived { get; set; }
    }

    static class Messages
    {
        static string connectionString = AppDomain.CurrentDomain.BaseDirectory + Properties.Settings.Default.commentsDbPath;

        public static void CreateUserTable(string name)
        {
            string command = $"create table if not exists {name}" +
                            $"( id integer primary key, " +
                            $"  friend string, " +
                            $"  message string, " +
                            $"  data integer, " +
                            $"  isReceived integer) ";

            using (var db = new SQLiteConnection(connectionString))
            {
                db.CreateCommand(command).ExecuteNonQuery();
            }
        }

        public static void SaveMessages(string userName, IEnumerable<MessageFormat> msgs)
        {
            using (var db = new SQLiteConnection(connectionString))
            {
                StringBuilder command = new StringBuilder();
                db.BeginTransaction();

                foreach (var m in msgs)
                {
                    command.Append($"insert into {userName} (friend, message, data, isReceived) values " +
                                                    $"('{m.Friend}','{m.Message}',{m.Data},{m.IsReceived})");
                    db.CreateCommand(command.ToString()).ExecuteNonQuery();
                    command.Clear();
                }
                db.Commit();
            }
        }



        public static IEnumerable<MessageFormat> GetMessages(string userName, string friendName)
        {
            IEnumerable<MessageFormat> msgs;
            var command = $"select * from {userName} where friend='{friendName}'";

            using (var db = new SQLiteConnection(connectionString))
            {
                msgs = db.CreateCommand(command).ExecuteQuery<MessageFormat>();
            }
            return msgs;
        }

    }
}
