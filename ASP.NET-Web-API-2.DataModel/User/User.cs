using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.Serialization;
using ASP.NET_Web_API_2.DataModel.Utils;

namespace ASP.NET_Web_API_2.DataModel.User
{
    [DataContract]
    public class User: BaseModel
    {
        [DataMember,Required] public string UserName { get; set; }
        [DataMember,Required] public string Password { get; set; }
        [DataMember,Required] public string Salt { get; set; }

        public User()
        {
            
        }

        public User(DataRow dataRow)
        {
            UserName = dataRow.GetValue("GOT_USER_USERNAME");
            Password = dataRow.GetValue("GOT_USER_PASSWORD");
            Salt = dataRow.GetValue("GOT_USER_SALT");
        }
    }
}
