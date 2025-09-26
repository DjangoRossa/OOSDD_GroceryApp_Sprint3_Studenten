using Grocery.Core.Helpers;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using Grocery.Core.Services;
using Grocery.Core;

namespace TestCore
{
    public class TestHelpers
    {
        [SetUp]
        public void Setup()
        {
        }

        //Happy flow
        [Test]
        public void TestPasswordHelperReturnsTrue()
        {
            string password = "user3";
            string passwordHash = "sxnIcZdYt8wC8MYWcQVQjQ==.FKd5Z/jwxPv3a63lX+uvQ0+P7EuNYZybvkmdhbnkIHA=";
            Assert.IsTrue(PasswordHelper.VerifyPassword(password, passwordHash));
        }

        [TestCase("user1", "IunRhDKa+fWo8+4/Qfj7Pg==.kDxZnUQHCZun6gLIE6d9oeULLRIuRmxmH2QKJv2IM08=")]
        [TestCase("user3", "sxnIcZdYt8wC8MYWcQVQjQ==.FKd5Z/jwxPv3a63lX+uvQ0+P7EuNYZybvkmdhbnkIHA=")]
        public void TestPasswordHelperReturnsTrue(string password, string passwordHash)
        {
            Assert.IsTrue(PasswordHelper.VerifyPassword(password, passwordHash));
        }

        //Unhappy flow
        [Test]
        public void TestPasswordHelperReturnsFalse()
        {
            string password = "user3";
            string passwordHash = "sxnIcZdYt8wC8MYWcQVQjQ==.FKd5Z/jwxPv3a63lX+uvQ0+P7EuNYZybvkmdhbnkIHA+";
            Assert.IsFalse(PasswordHelper.VerifyPassword(password, passwordHash)); 
        }

        [TestCase("user1", "IunRhDKa+fWo8+4/Qfj7Pg==.kDxZnUQHCZun6gLIE6d9oeULLRIuRmxmH2QKJv2IM08+")]
        [TestCase("user3", "sxnIcZdYt8wC8MYWcQVQjQ==.FKd5Z/jwxPv3a63lX+uvQ0+P7EuNYZybvkmdhbnkIHA+")]
        public void TestPasswordHelperReturnsFalse(string password, string passwordHash)
        {
            Assert.IsFalse(PasswordHelper.VerifyPassword(password, passwordHash));
        }

        [Test]
        public void TestAddProductReturnsTrue()
        {
            List<GroceryListItem> groceryListItems = new List<GroceryListItem>();
            GroceryListItem product = new GroceryListItem(-1, 1, 1, 1);
            groceryListItems.Add(product);
            Assert.IsTrue(groceryListItems.Contains(product));
        }

        [TestCase(-1, 2, 3, 4)]
        [TestCase(-1, 3, 4, 5)]
        public void TestAddProductReturnsTrue(int id, int groceryListId, int productId, int amount)
        {
            List<GroceryListItem> groceryListItems = new List<GroceryListItem>();
            GroceryListItem product = new GroceryListItem(id, groceryListId, productId, amount);
            groceryListItems.Add(product);
            Assert.IsTrue(groceryListItems.Contains(product));
        }

        [Test]
        public void TestRemoveProductReturnsFalse()
        {
            List<GroceryListItem> groceryListItems = new List<GroceryListItem>();
            GroceryListItem product = new GroceryListItem(-1, 1, 1, 1);
            groceryListItems.Add(product);
            groceryListItems.Remove(product);
            Assert.IsFalse(groceryListItems.Contains(product));
        }

    }
}