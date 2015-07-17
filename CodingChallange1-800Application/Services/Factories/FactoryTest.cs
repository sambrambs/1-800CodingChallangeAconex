using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallange1_800Application.Services.Factories
{
    [TestFixture]
    public class FactoryTest
    {
        [Test]
        public void FactoryPropertiesAreInitializedWhenFactryIsCreated()
        {
            var factory = new Factory();
            Assert.IsNotNull(factory.CommandLineParser);
            Assert.IsNotNull(factory.FileSystem);
            Assert.IsNotNull(factory.ConsoleService);
        }
    }
}
