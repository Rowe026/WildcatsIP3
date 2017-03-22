//
//  This file was auto-generated using the ChilliConnect SDK Generator.
//
//  The MIT License (MIT)
//
//  Copyright (c) 2015 Tag Games Ltd
//
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
//

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using SdkCore;

namespace ChilliConnect
{
	/// <summary>
	/// <para>A container for all information that will be sent to the server during a
 	/// Get Messages api call.</para>
	///
	/// <para>This is immutable after construction and is therefore thread safe.</para>
	/// </summary>
	public sealed class GetMessagesRequest : IImmediateServerRequest
	{
		/// <summary>
		/// The url the request will be sent to.
		/// </summary>
		public string Url { get; private set; }
		
		/// <summary>
		/// The HTTP request method that should be used.
		/// </summary>
		public HttpRequestMethod HttpRequestMethod { get; private set; }
		
		/// <summary>
		/// A valid session ConnectAccessToken obtained through one of the login endpoints.
		/// </summary>
        public string ConnectAccessToken { get; private set; }
	
		/// <summary>
		/// The Page requested. Paging is 1-indexed. If not provided, this will be defaulted
		/// to 1.
		/// </summary>
        public int? Page { get; private set; }
	
		/// <summary>
		/// Only messages received now minus Since seconds will be returned. Default: 86400
		/// (24 hours).
		/// </summary>
        public int? Since { get; private set; }
	
		/// <summary>
		/// Only unread messages will be returned. Default: true.
		/// </summary>
        public bool? UnreadOnly { get; private set; }
	
		/// <summary>
		/// Only messages with the specified Tags will be returned.
		/// </summary>
        public ReadOnlyCollection<string> Tags { get; private set; }
	
		/// <summary>
		/// Return full message bodies with the response. Default: false. If false; Text,
		/// Data, and Rewards will not be returned.
		/// </summary>
        public bool? FullMessages { get; private set; }
	
		/// <summary>
		/// Mark messages as read once returned by this call. Default: false.
		/// </summary>
        public bool? MarkAsRead { get; private set; }

		/// <summary>
		/// Initialises a new instance of the request with the given description.
		/// </summary>
		///
		/// <param name="desc">The description.</param>
		/// <param name="connectAccessToken">A valid session ConnectAccessToken obtained through one of the login endpoints.</param>
		public GetMessagesRequest(GetMessagesRequestDesc desc, string connectAccessToken)
		{
			ReleaseAssert.IsNotNull(desc, "A description object cannot be null.");
			
	
			ReleaseAssert.IsNotNull(connectAccessToken, "Connect Access Token cannot be null.");
	
            Page = desc.Page;
            Since = desc.Since;
            UnreadOnly = desc.UnreadOnly;
            if (desc.Tags != null)
			{
                Tags = Mutability.ToImmutable(desc.Tags);
			}
            FullMessages = desc.FullMessages;
            MarkAsRead = desc.MarkAsRead;
            ConnectAccessToken = connectAccessToken;
	
			Url = "https://connect.chilliconnect.com/1.0/message/player/list";
			HttpRequestMethod = HttpRequestMethod.Post;
		}

		/// <summary>
		/// Serialises all header properties. The output will be a dictionary containing 
		/// the extra header key-value pairs in addition the standard headers sent with 
		/// all server requests. Will return an empty dictionary if there are no headers.
		/// </summary>
		///
		/// <returns>The header key-value pairs.</returns>
		public IDictionary<string, string> SerialiseHeaders()
		{
			var dictionary = new Dictionary<string, string>();
			
			// Connect Access Token
			dictionary.Add("Connect-Access-Token", ConnectAccessToken.ToString());
		
			return dictionary;
		}
		
		/// <summary>
		/// Serialises all body properties. The output will be a dictionary containing the 
		/// body of the request in a form that can easily be converted to Json. Will return
		/// an empty dictionary if there is no body.
		/// </summary>
		///
		/// <returns>The body Json in dictionary form.</returns>
		public IDictionary<string, object> SerialiseBody()
		{
            var dictionary = new Dictionary<string, object>();
			
			// Page
            if (Page != null)
			{
				dictionary.Add("Page", Page);
            }
			
			// Since
            if (Since != null)
			{
				dictionary.Add("Since", Since);
            }
			
			// Unread Only
            if (UnreadOnly != null)
			{
				dictionary.Add("UnreadOnly", UnreadOnly);
            }
			
			// Tags
            if (Tags != null)
			{
                var serialisedTags = JsonSerialisation.Serialise(Tags, (string element) =>
                {
                    return element;
                });
                dictionary.Add("Tags", serialisedTags);
            }
			
			// Full Messages
            if (FullMessages != null)
			{
				dictionary.Add("FullMessages", FullMessages);
            }
			
			// Mark As Read
            if (MarkAsRead != null)
			{
				dictionary.Add("MarkAsRead", MarkAsRead);
            }
	
			return dictionary;
		}
	}
}
