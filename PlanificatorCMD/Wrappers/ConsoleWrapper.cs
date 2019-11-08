using System;
using System.Collections.Generic;
using System.Text;

namespace PlanificatorCMD.Wrappers
{
    public class ConsoleWrapper
    {
        public void NameError(int i)
        {
            switch (i)
            {
                case 0:
                    Console.WriteLine("Too long name");
                    break;
                case 1:
                    Console.WriteLine("Name is null or empty");
                    break;
                default:
                    Console.WriteLine("Name Error");
                    break;
            }
        }

        public void EmailError()
        {
            switch (i)
            {
                case 0:
                    Console.WriteLine("Email is null or emtpty");
                    break;
                case 1:
                    Console.WriteLine("Incorrect format(smth@example.ex needed)");
                    break;
                default:
                    Console.WriteLine("Email Error");
                    break;
            }
        }

        public void PhotoError(int i)
        {
            switch (i)
            {
                case 0:
                    Console.WriteLine("Incorrect Path");
                    break;
                case 1:
                    Console.WriteLine("Incorrect format(.jpg needed)");
                    break;
                default:
                    Console.WriteLine("Photo Error");
                    break;
            }
        }
        public void TagsError(int i)
        {
            switch (i)
            {
                case 0:
                    Console.WriteLine("Tagline is null or empty");
                    break;
                default:
                    Console.WriteLine("Tags Error");
                    break;
            }
        }

        public void LongDescriptionError(int i)
        {
            switch (i)
            {
                case 0:
                    Console.WriteLine("LongDescription is too long (800 symbols max)");
                    break;
                case 1:
                    Console.WriteLine("LongDescription is null or empty");
                    break;
                default:
                    Console.WriteLine("LongDescription Error");
                    break;
            }
        }

        public void ShortDescriptionError(int i)
        {
            switch (i)
            {
                case 0:
                    Console.WriteLine("ShortDescription is too long (200 symbols max)");
                    break;
                case 1:
                    Console.WriteLine("ShortDescription is null or empty");
                    break;
                default:
                    Console.WriteLine("ShortDescription Error");
                    break;
            }
        }

        public void TitleError(int i)
        {
            switch (i)
            {
                case 0:
                    Console.WriteLine("Title is too long (100 symbols max)");
                    break;
                case 1:
                    Console.WriteLine("Title is null or empty");
                    break;
                default:
                    Console.WriteLine("ShortDescription Error");
                    break;
            }
        }
    }
}
