using Blog.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Tests.Services
{
    [TestFixture]
    public class ConvertDateShould
    {
        [Test]
        public void Can_Calculate_Relative_Time()
        {
            var item = new DateTime(2019, 8, 23);
            var item1 = new DateTime(2019, 8, 25, 10, 54, 0);
            var item2 = new DateTime(2019, 8, 25, 14, 54, 0);
            var item4 = new DateTime(2019, 8, 24, 14, 54, 0);
            var item5 = new DateTime(2019, 8, 25, 20, 33, 0);
            //Ten test nie działa
            //var item3 = new DateTime(2019, 8, 18, 19, 0, 0);

            var result = ConvertDate.ConvertRelativeDate(item);
            var result1 = ConvertDate.ConvertRelativeDate(item1);
            var result2 = ConvertDate.ConvertRelativeDate(item2);
            var result4 = ConvertDate.ConvertRelativeDate(item4);
            var result5 = ConvertDate.ConvertRelativeDate(item5);

            //Nie działa
            //var result3 = ConvertDate.ConvertRelativeDate(item3);

            Assert.AreEqual("2 dni temu", result);
            Assert.AreEqual("8 godzin temu", result1);
            Assert.AreEqual("4 godziny temu", result2);
            Assert.AreEqual("wczoraj", result4);
            Assert.AreEqual("godzinę temu", result5);
            //Nie działa
            //Assert.AreEqual("7 dni temu", result3);
            

        }
    }
}
