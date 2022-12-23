using TDD01;

namespace ProjectTests
{
    [TestClass]
    public class DiscountCalculationTests
    {
        [TestMethod]
        public void TestCalculationDiscountWhenProductHaveDiscountReturnsDiscountAmount()
        {
            Product myProduct = new Product("Book A", 10.00, 20);

            Purchase myPurchase = new Purchase();

            myPurchase.Add(myProduct);

            myPurchase.CalculateDiscount();

            Assert.AreEqual(2, myPurchase.Discount);
        }

        [TestMethod]
        public void TestCalculationDiscountWhenProductDoesNotHaveDiscountReturnsDefaultDiscount()
        {
            Product myProduct = new Product("Book A", 10.00);

            Purchase myPurchase = new Purchase();

            myPurchase.Add(myProduct);

            myPurchase.CalculateDiscount();

            // 5% = 0.5 default discount
            Assert.AreEqual(0.5, myPurchase.Discount);
        }

        [TestMethod]
        public void TestCalculationDiscountWhenPurchaseHaveSeveralProductsReturnsDiscountAmount()
        {            
            Purchase myPurchase = new Purchase();

            myPurchase.Add(new Product("Book A", 10.00, 20));
            myPurchase.Add(new Product("Book B", 10.00, 10));

            myPurchase.CalculateDiscount();

            // 2 + 1 = 3
            Assert.AreEqual(3, myPurchase.Discount);
        }

        [TestMethod]
        public void TestCalculationDiscountWhenPurchaseHaveMoreThanThreeProductsReturnsAdditionalDiscount1()
        {
            Purchase myPurchase = new Purchase();

            myPurchase.Add(new Product("Book A", 10.00, 10));
            myPurchase.Add(new Product("Book B", 10.00, 20));
            myPurchase.Add(new Product("Book C", 10.00, 30));
            myPurchase.Add(new Product("Book D", 10.00, 40));


            myPurchase.CalculateDiscount();

            // 1 + 2 + 3 + 4 + {40 * 10%}
            // 1 + 2 + 3 + 4 + {4} = 14
            Assert.AreEqual(14, myPurchase.Discount);
        }

        [TestMethod]
        public void TestCalculationDiscountWhenPurchaseHaveMoreThanSixProductsReturnsAdditionalDiscount2()
        {
            Purchase myPurchase = new Purchase();

            myPurchase.Add(new Product("Book A", 10.00, 10));
            myPurchase.Add(new Product("Book B", 10.00, 20));
            myPurchase.Add(new Product("Book C", 10.00, 30));
            myPurchase.Add(new Product("Book D", 10.00, 40));
            myPurchase.Add(new Product("Book E", 10.00, 50));
            myPurchase.Add(new Product("Book F", 10.00, 60));
            myPurchase.Add(new Product("Book G", 10.00));

            myPurchase.CalculateDiscount();

            // 1 + 2 + 3 + 4 + 5 + 6 + { 10 * 0.07 (7%)} + 7
            // 1 + 2 + 3 + 4 + 5 + 6 + 0.7 = 21.7 + 7 = 28.7
            Assert.AreEqual(28.7, myPurchase.Discount);
        }

        [TestMethod]
        public void TestCalculationDiscountWhenProductHaveInvalidDiscountRangeReturnsErrorMessage()
        {
            string message = string.Empty;

            Product myProduct = new Product("Book A", 10.00, 70);

            Purchase myPurchase = new Purchase();

            myPurchase.Add(myProduct);            

            try
            {
                myPurchase.CalculateDiscount();
            }
            catch(Exception ex)
            {
                message = ex.Message;
            }
            
            Assert.AreEqual("Invalid Data", message);
        }

        [TestMethod]
        public void TestCalculationDiscountWhenProductDoesNotHaveDiscountRangeReturnsZeroDiscount()
        {
            string message = string.Empty;

            Product myProduct = new Product("Book A", 10.00, 0);

            Purchase myPurchase = new Purchase();

            myPurchase.Add(myProduct);            

            Assert.AreEqual(0, myPurchase.Discount);
        }

        [TestMethod]
        public void TestCalculationDiscountWhenProductExceedPresicionReturnsErrorMessage()
        {
            string message = string.Empty;

            Product myProduct = new Product("Book A", 10.101, 50);

            Purchase myPurchase = new Purchase();

            myPurchase.Add(myProduct);

            try
            {
                myPurchase.CalculateDiscount();
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            Assert.AreEqual("Invalid Data", message);
        }

        [TestMethod]
        public void TestCalculationDiscountWhenPurchaseHaveProductsWithoutDiscountReturnsAdditionalDiscount()
        {
            Purchase myPurchase = new Purchase();

            myPurchase.Add(new Product("Book A", 10.00, 0));
            myPurchase.Add(new Product("Book B", 10.00, 0));
            myPurchase.Add(new Product("Book C", 10.00, 0));
            myPurchase.Add(new Product("Book D", 10.00, 0));
            myPurchase.Add(new Product("Book E", 10.00, 0));
            myPurchase.Add(new Product("Book F", 10.00, 0));
            myPurchase.Add(new Product("Book G", 10.00, 0));

            myPurchase.CalculateDiscount();

            // { 10 * 70 (10%)} = 7            
            Assert.AreEqual(0, myPurchase.Discount);
        }

        [TestMethod]
        public void TestCalculationDiscountWhenPurchaseHaveProductsWithoutDiscountReturnsAdditionalDiscount2()
        {
            Purchase myPurchase = new Purchase();

            myPurchase.Add(new Product("Book A", 10.00, 10));
            myPurchase.Add(new Product("Book B", 10.00, 0));
            myPurchase.Add(new Product("Book C", 10.00, 0));
            myPurchase.Add(new Product("Book D", 10.00, 0));
            myPurchase.Add(new Product("Book E", 10.00, 0));
            myPurchase.Add(new Product("Book F", 10.00, 0));
            myPurchase.Add(new Product("Book G", 10.00, 0));

            myPurchase.CalculateDiscount();

            // { 10 * 70 (10%)} = 7            
            Assert.AreEqual(8, myPurchase.Discount);
        }
    }
}