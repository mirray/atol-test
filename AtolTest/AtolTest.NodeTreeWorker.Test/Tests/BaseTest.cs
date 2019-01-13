using System;
using System.Collections.Generic;
using System.Text;

namespace AtolTest.GraphWorkerTest.Tests
{
    public class BaseTest
    {
        protected ILogger _logger;

        public BaseTest()
        {
            _logger = new TestLogger();
        }
    }
}
