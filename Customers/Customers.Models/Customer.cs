namespace Customers.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Added_On { get; set; }
        public string Added_By { get; set; }
        public string Added_By_IP { get; set; }
        public bool Is_Active { get; set; }
    }
}
