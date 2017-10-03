using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MessagesService
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/user/login",
                ResponseFormat = WebMessageFormat.Json, 
                BodyStyle = WebMessageBodyStyle.Bare)]
        Token LogIn();

        [OperationContract]
        [WebInvoke(Method = "POST",
                   UriTemplate = "/user/signup",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Bare)]
        Token SignUp(User info);

        [OperationContract]
        [WebGet(UriTemplate = "/user/addfriend={name}",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare)]
        bool AddFriend(string name);

        [OperationContract]
        [WebGet(UriTemplate = "/user/friendslist", 
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare)]
        List<string> GetFriends();
    }

    [DataContract]
    public class Token
    {
        [DataMember]
        public string Key { get; set; }
    }

    [DataContract]
    [Table("Users")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
    }

    [Table("Friends")]
    public class Friends
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Friend1_login { get; set; }
        public string Friend2_login { get; set; }
    }

}
