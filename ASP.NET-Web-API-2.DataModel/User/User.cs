using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.Serialization;
using System.Security.Principal;
using ASP.NET_Web_API_2.DataModel.Utils;
using Microsoft.AspNet.Identity;

namespace ASP.NET_Web_API_2.DataModel.User
{
    [DataContract]
    public class User: BaseModel, IIdentity, IUser<string>
    {
        [DataMember(EmitDefaultValue = false),Required] 
        public string UserName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Email { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string NormalizeUserName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string PasswordHash { get; set; }

        [DataMember(EmitDefaultValue = false),Required] 
        public string Password { get; set; }

        [DataMember(EmitDefaultValue = false),Required] 
        public string Salt { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string AuthenticationType { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public bool IsAuthenticated { get; set; }

        public User()
        {
            
        }

        public User(string userName)
        {
            UserName = userName;
        }

        public User(DataRow dataRow)
        {
            UserName = dataRow.GetValue("GOT_USER_USERNAME");
            Password = dataRow.GetValue("GOT_USER_PASSWORD");
            Salt = dataRow.GetValue("GOT_USER_SALT");
        }
    }
}
