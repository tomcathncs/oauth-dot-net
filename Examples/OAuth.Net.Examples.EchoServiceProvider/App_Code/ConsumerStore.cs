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
using Castle.Core;
using OAuth.Net.Common;
using OAuth.Net.Components;

namespace OAuth.Net.Examples.EchoServiceProvider
{
    [Singleton]
    public sealed class ConsumerStore : InMemoryConsumerStore, IConsumerStore
    {
        internal static readonly IConsumer FixedConsumer = new OAuthConsumer("key", "secret", "Fixed consumer", ConsumerStatus.Valid);

        public ConsumerStore()
        {
            this.ConsumerDictionary.Add(
                ConsumerStore.FixedConsumer.Key, 
                ConsumerStore.FixedConsumer);
        }

        public override bool Add(IConsumer consumer)
        {
            throw new NotSupportedException("Consumers cannot be added to this store--it is fixed.");
        }

        public override bool Contains(string consumerKey)
        {
            return ConsumerStore.FixedConsumer.Key.Equals(consumerKey);
        }

        public override bool Update(IConsumer consumer)
        {
            throw new NotSupportedException("Consumers cannot be updated in this store--it is fixed.");
        }

        public override bool Remove(IConsumer consumer)
        {
            throw new NotSupportedException("Consumers cannot be removed from this store--it is fixed.");
        }
    }
}
