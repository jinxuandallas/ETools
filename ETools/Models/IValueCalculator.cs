using System.Collections.Generic;

namespace ETools.Models {
    public interface IValueCalculator {

        decimal ValueProducts(IEnumerable<Product> products);
    }
}
