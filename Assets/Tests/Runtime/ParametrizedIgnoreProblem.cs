// Copyright (c) 2021-2024 Koji Hasegawa.
// This software is released under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Tests.Runtime
{
    /// <summary>
    /// NotImplementedException occurs when combining ParametrizedIgnoreAttribute with async test.
    /// Fixed in test-framework v1.4.6
    /// </summary>
    /// <see href="https://issuetracker.unity3d.com/product/unity/issues/guid/DSTR-1068"/>
    [TestFixture]
    [Explicit("Fixed issue")]
    public class ParametrizedIgnoreProblem
    {
        private static IEnumerable<int> TestCases()
        {
            yield return 0;
            yield return 1;
            yield return 2;
        }

        [TestCaseSource(nameof(TestCases))]
        [ParametrizedIgnore(0)]
        public async Task TestAsync(int value)
        {
            await Task.Yield();
            Assert.That(value, Is.GreaterThan(0));
        }
    }
}
