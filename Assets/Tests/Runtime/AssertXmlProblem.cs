// Copyright (c) 2021-2024 Koji Hasegawa.
// This software is released under the MIT License.

using System.Xml.Linq;
using NUnit.Framework;

namespace Tests.Runtime
{
    /// <summary>
    /// Test result not display in Test Runner window.
    /// </summary>
    /// <see href="https://unity3d.atlassian.net/servicedesk/customer/portal/2/IN-89366"/>
    [TestFixture]
    public class AssertXmlProblem
    {
        [Test]
        public void AssertXml()
        {
            var actual = XElement.Parse(
                @"<testsuite name=""CreateTestSuite_Passed"" tests=""1"" id=""0"" errors=""0"" failures=""0"" time=""5.5"" timestamp=""2023-01-02T03:04:05"">
  <testcase name=""CreateTestSuite_Passed"" classname=""DeNA.Anjin.Autopilot"" time=""5.5"" status=""Passed"" />
</testsuite>");
            var expected = XElement.Parse(
                @"<testsuite name=""CreateTestSuite_Passed"" tests=""1"" errors=""0"" failures=""0"" time=""5.5"" timestamp=""2023-01-02T03:04:05"">
  <testcase name=""CreateTestSuite_Passed"" classname=""DeNA.Anjin.Autopilot"" time=""5.5"" status=""Passed"" />
</testsuite>");

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
