using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingStore.DB;

namespace ClothingStore.ClassHelper
{
    public class ProductCart
    {
        public static ObservableCollection<Product> products = new ObservableCollection<Product>();
    }
}
