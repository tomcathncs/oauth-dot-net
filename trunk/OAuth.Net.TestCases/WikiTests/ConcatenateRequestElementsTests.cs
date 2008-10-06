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

#if DEBUG
using System;
using System.Collections.Specialized;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using OAuth.Net.Common;

namespace OAuth.Net.TestCases.WikiTests
{
    [TestFixture]
    public class ConcatenateRequestElementsTests
    {
        [Test]
        public void TestGetHttpExampleDotComNoSlashWithNEqualsV()
        {
            OAuthParameters parameters = new OAuthParameters();
            parameters.AdditionalParameters.Add("n", "v");

            Assert.That(
                SignatureBase.Create("GET", new Uri("http://example.com"), parameters),
                Is.EqualTo("GET&http%3A%2F%2Fexample.com%2F&n%3Dv"));
        }

        [Test]
        public void TestGetHttpExampleDotComWithSlashWithNEqualsV()
        {
            OAuthParameters parameters = new OAuthParameters();
            parameters.AdditionalParameters.Add("n", "v");

            Assert.That(
                SignatureBase.Create("GET", new Uri("http://example.com/"), parameters),
                Is.EqualTo("GET&http%3A%2F%2Fexample.com%2F&n%3Dv"));
        }

        [Test]
        public void TestPostHttpsPhotosDotExampleDotNetSlashRequestUnderscoreTokenWithOAuthParameters()
        {
            OAuthParameters parameters = new OAuthParameters()
            {
                Version = Constants.Version1_0,
                ConsumerKey = "dpf43f3p2l4k3l03",
                Timestamp = "1191242090",
                Nonce = "hsu94j3884jdopsl",
                SignatureMethod = "PLAINTEXT",
                Signature = "ignored"
            };

            Assert.That(
                SignatureBase.Create("POST", new Uri("https://photos.example.net/request_token"), parameters),
                Is.EqualTo("POST&https%3A%2F%2Fphotos.example.net%2Frequest_token&oauth_consumer_key%3Ddpf43f3p2l4k3l03%26oauth_nonce%3Dhsu94j3884jdopsl%26oauth_signature_method%3DPLAINTEXT%26oauth_timestamp%3D1191242090%26oauth_version%3D1.0"));
        }

        [Test]
        public void TestGetHttpPhotosDotExampleDotNetSlashPhotosWithOAuthParametersAndFileEqualsVacationDotJpgAndSizeEqualsOriginal()
        {
            OAuthParameters parameters = new OAuthParameters()
            {
                Version = Constants.Version1_0,
                ConsumerKey = "dpf43f3p2l4k3l03",
                Token = "nnch734d00sl2jdk",
                Timestamp = "1191242096",
                Nonce = "kllo9940pd9333jh",
                SignatureMethod = "HMAC-SHA1",
                Signature = "ignored"
            };
            parameters.AdditionalParameters.Add("file", "vacation.jpg");
            parameters.AdditionalParameters.Add("size", "original");

            Assert.That(
                SignatureBase.Create("GET", new Uri("http://photos.example.net/photos"), parameters),
                Is.EqualTo("GET&http%3A%2F%2Fphotos.example.net%2Fphotos&file%3Dvacation.jpg%26oauth_consumer_key%3Ddpf43f3p2l4k3l03%26oauth_nonce%3Dkllo9940pd9333jh%26oauth_signature_method%3DHMAC-SHA1%26oauth_timestamp%3D1191242096%26oauth_token%3Dnnch734d00sl2jdk%26oauth_version%3D1.0%26size%3Doriginal"));
        }
    }
}
#endif