/*
    The MIT License (MIT)
    Copyright © 2015 Englishtown <opensource@englishtown.com>

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

using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EF.Diagnostics.Profiling.ProfilingFilters
{
    /// <summary>
    /// An <see cref="IProfilingFilter"/> implement for ignoring profiling by regex matches.
    /// </summary>
    public class RegexProfilingFilter : IProfilingFilter
    {
        private readonly Regex _regex;

        /// <summary>
        /// The regex string to be checked.
        /// </summary>
        public string RegexString { get { return _regex.ToString(); } }

        #region Constructors

        /// <summary>
        /// Initializes a <see cref="RegexProfilingFilter"/>.
        /// </summary>
        /// <param name="regex">The <see cref="Regex"/></param>
        public RegexProfilingFilter(Regex regex)
        {
            _regex = regex;
        }

        /// <summary>
        /// Initializes a <see cref="RegexProfilingFilter"/>.
        /// </summary>
        /// <param name="regexString">The regex string.</param>
        public RegexProfilingFilter(string regexString)
        {
            _regex = new Regex(regexString, RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }

        #endregion

        #region IProfilingFilter Members

        /// <summary>
        /// Returns whether or not the profiling session should NOT be started.
        /// </summary>
        /// <param name="name">The name of the profiling session to be started.</param>
        /// <param name="tags">The tags of the profiling session to be started.</param>
        /// <returns>Returns true, if the profiling session should NOT be started, otherwise, returns false.</returns>
        public bool ShouldBeExculded(string name, IEnumerable<string> tags)
        {
            if (_regex == null)
            {
                return false;
            }

            if (name == null)
            {
                return true;
            }

            return _regex.IsMatch(name);
        }

        bool IProfilingFilter.ShouldBeExculded(string name, IEnumerable<string> tags)
        {
            return ShouldBeExculded(name, tags);
        }

        #endregion
    }
}
