namespace TwitterAPI.Contracts
{

    public class Tweets
    {
        public Datum[] data { get; set; }
        public Includes includes { get; set; }
    }

    public class Includes
    {
        public User[] users { get; set; }
    }

    public class User
    {
        public string name { get; set; }
        public string id { get; set; }
        public DateTime created_at { get; set; }
        public string username { get; set; }
    }

    public class Datum
    {
        public string text { get; set; }
        public string id { get; set; }
        public string author_id { get; set; }
        public DateTime created_at { get; set; }
    }


}
