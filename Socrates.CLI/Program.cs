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
using Socrates.Game;
using System.Diagnostics;
using System.IO;

namespace Socrates.CLI
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			int choice = NewGameChoice();
			int players = NewGamePlayers();
			if(choice == 1)
			{
				//TODO: Implement Local Game
			}
			else if (choice == 2)
			{
				//TODO: Implement Networked Game
			}


		}
		private static int NewGameChoice()
		{
			int choice = 0;
			Console.WriteLine("Would you Like to play a:");
			Console.WriteLine("1). Local Game");
			Console.WriteLine("2). Networked Game");
			try
			{
				choice = Convert.ToInt32(Console.ReadLine());
				if (choice < 1 || choice > 2) 
				{
					throw new InvalidDataException(String.Format("Error: Invalid Input, should be 1 or 2 value is {0}",choice));
				}
			}
			catch (Exception ex)
			{
				Debug.Write(ex.Data);
				NewGameChoice();
			}
			return choice;
		}
		private static int NewGamePlayers()
		{
			int numberOfPlayers = 0;
			Console.Write("How Many Players: ");
			try
			{
				numberOfPlayers = Convert.ToInt32(Console.ReadLine());
				if (numberOfPlayers < 2)
				{
					throw new InvalidDataException(String.Format("ERROR: Number of players must be 2 or greater, You inserted: {0}",numberOfPlayers));
				}
			}
			catch(InvalidDataException ex)
			{
				Debug.Write(ex.Data);
				NewGamePlayers();
			}
			catch (Exception ex)
			{
				Debug.Write(ex.ToString());
				Debug.Write("ERROR: Invalid Input, Please insert a whole number greater than or equal to 2");
				NewGamePlayers();
			}
			return numberOfPlayers;
		}
	}
}
