using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InteractiveResponse.Model;
using NUnit.Framework;

namespace InteractiveResponse.Test
{
    [TestFixture]
    public class TextSanitizerTest
    {      
        [TestCase]
        public void SanitizeText() {
            Sanitizer san = new Sanitizer();                       
            List<string> sanitizedWords = san.SanitizeString("I want to know account balance");
            System.IO.Directory.Exists("");            
            Assert.AreEqual(2, sanitizedWords.Count);
        }

        [TestCase]
        public void SanitizeText2()
        {
            Sanitizer san = new Sanitizer();            
            List<string> sanitizedWords = san.SanitizeString("What do you mean by search in my account for deposit");

            Assert.AreEqual(3, sanitizedWords.Count);
        }

    }
}
