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


            var item3 = new DateTime(2019, 8, 19, 9, 12, 0);
            var result3 = ConvertDate.ConvertRelativeDate(item3);

            Assert.AreEqual("7 dni temu", result3);
            

        }
    }
}
