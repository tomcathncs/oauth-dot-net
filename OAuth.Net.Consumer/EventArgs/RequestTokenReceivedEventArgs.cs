﻿// Copyright (c) 2008 Madgex
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
// OAuth.net uses the Windsor Container from the Castle Project. See "Castle 
// Project License.txt" in the Licenses folder.
// 
// Authors: Bruce Boughton, Chris Adams
// Website: http://lab.madgex.com/oauth-net/
// Email:   oauth-dot-net@madgex.com

using System;
using System.Collections.Specialized;
using OAuth.Net.Common;

namespace OAuth.Net.Consumer
{
    /// <summary>
    /// The event arguments sent when a request token is received.
    /// </summary>
    public class RequestTokenReceivedEventArgs
        : EventArgs
    {
        /// <summary>
        /// Creates event arguments with the corresponding request token and parameter collection.
        /// </summary>
        /// <param name="requestToken">Request token</param>
        /// <param name="additionalParameters">Parameter collection</param>
        public RequestTokenReceivedEventArgs(IToken requestToken, NameValueCollection additionalParameters)
        {
            this.RequestToken = requestToken;
            this.AdditionalParameters = additionalParameters;
        }

        /// <summary>
        /// The request token issued by the service provider
        /// </summary>
        public IToken RequestToken
        {
            get;
            private set;
        }

        /// <summary>
        /// Any non-OAuth parameters returned by the service provider
        /// </summary>
        public NameValueCollection AdditionalParameters
        {
            get;
            private set;
        }
    }
}
