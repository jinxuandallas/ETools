﻿namespace ETools.Models {

    public interface IDiscountHelper {
        decimal ApplyDiscount(decimal totalParam);
    }

    public class DefaultDiscountHelper : IDiscountHelper {
        //public decimal DiscountSize { get; set; }
        public decimal discountSize;

        
        public DefaultDiscountHelper(decimal discountParam) {
            discountSize = discountParam;
        }
        

        public decimal ApplyDiscount(decimal totalParam) {
            return (totalParam - (discountSize / 100m * totalParam));
        }
    }
}
