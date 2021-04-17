using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListRandomizer {
	class Program {

		const string introPath = "\\intro";
		const string randomListPath = "\\randomList";

		static void Main(string[] args) {
			int count = 1;
			string projectDirectory = System.IO.Directory.GetCurrentDirectory();
			string path = @projectDirectory + randomListPath + count + ".txt";
			if (System.IO.File.Exists(@projectDirectory + introPath + ".txt")) {
				Console.WriteLine(System.IO.File.ReadAllText(@projectDirectory + introPath + ".txt"));
				Console.WriteLine();
			}
			

			while (System.IO.File.Exists(path)) {
				count++;
				path = @projectDirectory + randomListPath + count + ".txt";
			}

			count--;

			if (count == 0) {
				Console.WriteLine("No lists available!");
				Console.ReadKey();
				return;
			}


			int parse = 1;

			while (true) {
				if (count > 1) {
					Console.WriteLine("Select from lists 1 to " + count);

					string input;

					parse = -1;

					while (parse < 1 || parse > count) {
						input = Console.ReadLine();
						Int32.TryParse(input, out parse);
					}
				}

				path = @projectDirectory + randomListPath + parse + ".txt";

				if (System.IO.File.Exists(path)) {
					string[] lines = System.IO.File.ReadAllLines(path);
					bool loop = true;
					while (loop) {
						int i = new Random().Next(0, lines.Length);
						Console.WriteLine(lines[i]);
						Console.WriteLine();
						if (Console.ReadKey().Key == ConsoleKey.Escape)
							loop = false;
						Console.WriteLine();
					}
				} else {
					Console.WriteLine("File not found at:");
					Console.WriteLine(path);
					Console.ReadKey();
				}
			}
		}
	}
}
