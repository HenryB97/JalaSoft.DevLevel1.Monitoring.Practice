namespace TDD01
{
    public class Purchase
    {
        private List<Product> _products = new List<Product>();
        public double Discount { get; set; }

        public void Add(Product myProduct)
        {
            _products.Add(myProduct);
        }

        public void CalculateDiscount()
        {
            double totalDiscount = 0;
            int discountValue = 0;
            double additionalDiscount = 0;
            double totalAmount = 0;

            foreach(Product product in _products)
            {
                /*             
                if (product.Discount == null)
                {
                    if (_products.Count > 6)
                        discountValue = 7;
                    else
                        discountValue = 5;
                }
                else
                {
                    discountValue = product.Discount.Value;
                }
                */

                if (!isValidProduct(product))
                {
                    throw new Exception("Invalid Data");
                }

                totalAmount += product.Price;

                discountValue = product.Discount == null ? _products.Count > 6 ? 7 : 5 : product.Discount.Value;

                totalDiscount += product.Price * discountValue / 100;
            }

            if (_products.Count > 3 && totalDiscount > 0)
            {
                additionalDiscount = totalAmount * 10 / 100;
            }

            Discount = totalDiscount + additionalDiscount;
        }

        private bool isValidProduct(Product product)
        {
            return (product.Discount == null || 
                (product.Discount.Value >= 0 && product.Discount.Value <= 60)) &&
                (product.Price * 100 % 1 == 0);
        }
    }
}