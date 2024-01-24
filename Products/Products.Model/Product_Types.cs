using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Model
{
    public class Product_Types
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime Added_On { get; set; }
        public string Added_By { get; set; }
        public string Added_By_IP { get; set; }
    }
}
