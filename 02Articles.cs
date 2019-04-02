using System;
using System.Globalization;
using System.Text;
using System.Numerics;
using System.Threading;
using System.Linq;

namespace _02Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            int numberOfCommands = int.Parse(Console.ReadLine());
            Article article = new Article();
            article.Title = input[0];
            article.Content = input[1];
            article.Author = input[2];
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split(": ");
                
                if (command[0]=="Edit")
                {
                    article.Edit(command[1]);
                }
                else if (command[0]=="ChangeAuthor")
                {
                    article.ChangeAuthors(command[1]);
                }
                else if (command[0]=="Rename")
                {
                    article.Rename(command[1]);
                }
                
            }

            Console.WriteLine(article.ToString());
        }
    }
    class Article
    {
        public Article()
        {

        }
        public Article(string input)
        {
            string[] tokens = input.Split(", ");
            Title = tokens[0];
            Content = tokens[1];
            Author = tokens[2];
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
         
        public void Edit(string newContent)
        {
            Content = newContent;

        }
        public void ChangeAuthors (string newAuthor)
        {
            Author = newAuthor;
        }
        public void Rename(string newTitle)
        {
            Title = newTitle;
        }
        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
        
    }
}
