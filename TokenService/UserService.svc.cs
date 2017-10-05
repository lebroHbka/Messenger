using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

using System.Configuration;
using System.Threading;
using System.Data;
using System.Linq;
using System.ServiceModel.Web;
using System.Net;
using System.Text;
using Serilog;
using Serilog.Core;
using SQLite;
using System.Collections.Generic;

namespace MessagesService
{
    public class UserService : IUserService
    {

        #region Vars
        static string secretKey;
        static Logger logger;
        static string connectionString;

        #endregion

        #region Constructors
        static UserService()
        {
            secretKey = Properties.Settings.Default.SecretKey;
            logger = new LoggerConfiguration().WriteTo.RollingFile(@"C:\inetpub\wwwroot\RestService\App_Data\log-{Date}.txt").CreateLogger();
            connectionString = AppDomain.CurrentDomain.BaseDirectory + Properties.Settings.Default.BDPath;
        }
        #endregion


        public Token LogIn()
        {
            var usr = Authorization(WebOperationContext.Current);

            if(usr != null)
                return ProvideToken(usr);
            WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Unauthorized;
            return null;
        }

        public Token SignUp(User user)
        {
            if (FindUser(user.Login) != null)
            {
                return null;
            }
            else
            {
                AddNewUser(user.Login, user.Password);
                return ProvideToken(user);
            }
        }

        public bool AddFriend(string friendName)
        {
            var usr = Authorization(WebOperationContext.Current);
            if(usr == null)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Unauthorized;
                return false;
            }
            var frd = FindUser(friendName);

            if((frd == null) || (FindFriends(usr.Login).Contains(frd.Login)))
                return false;

            AddNewFriend(usr.Login, frd.Login);
            return true;
        }

        public List<string> GetFriends()
        {
            var usr = Authorization(WebOperationContext.Current);
            if (usr == null)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Unauthorized;
                return null;
            }
            return FindFriends(usr.Login);
        }



        private User Authorization(WebOperationContext context)
        {
            var authHeader = context.IncomingRequest.Headers[HttpRequestHeader.Authorization];

            if (authHeader != null)
            {
                var encodedLogPass = authHeader.Split(' ');
                var logPass = DecodeBase64(encodedLogPass.Last()).Split(':');
                if (logPass.Length == 2)
                {
                    string name = logPass[0], pass = logPass[1];
                    var user = FindUser(name, pass);
                    return user;
                }
            }
            return null;
        }

        private void AddNewUser(string name, string pass)
        {
            using (var db = new SQLiteConnection(connectionString))
            {
                db.Insert(new User() { Login = name, Password = pass});
                db.Commit();
            }
        }

        private void AddNewFriend(string friend1, string friend2)
        {
            using (var db = new SQLiteConnection(connectionString))
            {
                db.Insert(new Friends() { Friend1_login = friend1, Friend2_login = friend2});
                db.Commit();
            }
        }

        private User FindUser(string name)
        {
            User us;
            using (var db = new SQLiteConnection(connectionString))
            {
                us = db.Find<User>(u => u.Login == name);
            }
            return us;
        }

        private User FindUser(string name, string pass)
        {
            User us;
            using (var db = new SQLiteConnection(connectionString))
            {
                us = db.Find<User>(u => (u.Login == name) && (u.Password == pass));
            }
            return us;
        }

        private List<string> FindFriends(string name)
        {
            List<Friends> friends;
            var friendsNames = new List<string>();

            using (var db = new SQLiteConnection(connectionString))
            {
                friends = db.Table<Friends>().Where(u => (u.Friend1_login == name) || (u.Friend2_login == name)).ToList();
            }

            foreach (var f in friends)
            {
                if (f.Friend1_login != name)
                    friendsNames.Add(f.Friend1_login);
                else
                    friendsNames.Add(f.Friend2_login);
            }
            return friendsNames;
        }




        private string DecodeBase64(string str)
        {
            var bt = Convert.FromBase64String(str);
            return Encoding.UTF8.GetString(bt);
        }

        private Token ProvideToken(User user)
        {
            var symetricKey = Convert.FromBase64String(secretKey);
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, user.Login)
                    }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symetricKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var secToken = tokenHandler.CreateToken(tokenDescription);
            return new Token() { Key = tokenHandler.WriteToken(secToken) };
        }
    }
}
