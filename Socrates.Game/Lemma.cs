//
//  Copyright 2014  Luke
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Socrates.Game
{
	/// <summary>
	/// A Lemma is a string of letters from A-Z. It may not contain numbers
	/// and is case insensitive.  A lemma should be no more than 40 characters long 
	/// as going longer than that makes rules difficult to discern.
	/// </summary>
	public class Lemma
    {
		#region constants
		private const Byte maxLength = 40;
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Socrates.Game.Lemma"/> class.
		/// </summary>
        public Lemma()
        {

        }
		/// <summary>
		/// Initializes a new instance of the <see cref="Socrates.Game.Lemma"/> class.
		/// </summary>
		/// <param name="content">
		/// Do not make more than 40 characters long. While we do not check, 
		/// if you are following this guideline, it makes it difficult for players to discern rules.
		/// </param>
		public Lemma(string content)
		{
			Content = Normalize(content);

			Debug.WriteIf(Content.Length > maxLength, "Lemma Longer than 40 Characters");
			//TODO: Strip string of non A-Z characters

		}
		#endregion
		#region Methods
		public static string Normalize(string str)
		{

			string res = str.ToUpper().Trim();
			Regex r = new Regex("\\s+");
			res = r.Replace(res, " ");
			r = new Regex("[^A-Z ]");
			res = r.Replace(res, "");

			return res;
		}

		public override string ToString()
		{
			return string.Format("{0}", Content);
		}
		#endregion
		#region Properties
		/// <summary>
		/// The String representing the Lemma.
		/// </summary>
		/// <value>The String representing the Lemma.</value>
		public String Content
		{
			get;
			private set; //Contents of a Lemma should be read only
		}
		#endregion
		#region Private Variables

		#endregion
    }
}

