/*
    The MIT License (MIT)
    Copyright © 2014 Englishtown <opensource@englishtown.com>

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.
*/

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EF.Diagnostics.Profiling.Tests
{
    [TestClass]
    public class SimpleProfilerProviderTest
    {
        [TestMethod]
        public void TestProfilerProvider()
        {
            var mockProfilingStorage = new Mock<IProfilingStorage>();
            var target = new ProfilerProvider() as IProfilerProvider;
            Assert.IsNotNull(target.Start("test", mockProfilingStorage.Object, null));

            //handle exception should not throw exception
            target.HandleException(new Exception(), this);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestProfilerProvider_Start_InvalidName()
        {
            var target = new ProfilerProvider() as IProfilerProvider;
            target.Start(null, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestProfilerProvider_Start_InvalidStorage()
        {
            var target = new ProfilerProvider() as IProfilerProvider;
            target.Start("test", null, null);
        }
    }
}
