//
//  Copyright 2014  Jonathan
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
using System.Collections.Generic;

namespace Socrates.Game
{
	public class Game
	{
		public Game(IDriver driver)
		{
			List<Player> players = driver.CreatePlayers();
			MasterPlayer = driver.GetMaster(players);
			foreach(Player player in players)
			{
				if (player != MasterPlayer)
					Students.Add(new Student(player));
			}

			//initial lemmas
			Lemma[] initialLemmas = driver.GetInitialLemmas();
			IdealFormLemmas.Add(initialLemmas[0]);
			NonIdealFormLemmas.Add(initialLemmas[1]);
		}

		public List<Lemma> IdealFormLemmas
		{
			get;
			set;
		}

		public List<Lemma> NonIdealFormLemmas
		{
			get;
			set;
		}

		public List<Lemma> AwaitingLemmas
		{
			get;
			set;
		}

		public List<Student> Students
		{
			get;
			set;
		}

		public Master MasterPlayer
		{
			get;
			set;
		}

		public bool Ended
		{
			get;
			set;
		}
	}
}

