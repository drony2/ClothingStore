using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.ClassHelper
{
    public class ProductCart
    {
        public static ObservableCollection<DB.Product> products = new ObservableCollection<DB.Product>();
    }
}
