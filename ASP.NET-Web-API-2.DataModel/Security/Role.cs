using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace ASP.NET_Web_API_2.DataModel.Security
{
    public class Role: IRole<string>
    {
        [DataMember(EmitDefaultValue = false),Required] 
        public string Id { get; set; }

        [DataMember(EmitDefaultValue = false),Required] 
        public string Name { get; set; }
    }
}
