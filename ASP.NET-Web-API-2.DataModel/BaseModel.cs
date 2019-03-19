using System.Runtime.Serialization;

namespace ASP.NET_Web_API_2.DataModel
{
    [DataContract]
    public class BaseModel
    {
        [DataMember] public string Id { get; set; }
        [DataMember] public bool Active { get; set; }
    }
}
