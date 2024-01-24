namespace Products.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime Added_On { get; set; }
        public string Added_By { get; set; }
        public string Added_By_IP { get; set; }
        public bool Is_Active { get; set; }
    }
}
