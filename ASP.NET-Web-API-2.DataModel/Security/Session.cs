namespace ASP.NET_Web_API_2.DataModel.Security
{
    public class Session: BaseModel
    {
        public string SessionId { get; set; }
        public User.User User { get; set; }
    }
}
