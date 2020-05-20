using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFB.Models
{
    public class Book
    {
		public Book() { }

		public Book(int id, string name, string author,  int count)
		{
			Id = id;
			Name = name;
			Author = author;
			CountOfChapter = count;
		}

		public Book(string name, string author, int count)
		{
			Name = name;
			Author = author;
			CountOfChapter = count;
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public string Author { get; set; }
		public int CountOfChapter { get; set; }
	}
}
