using System;

class Program
{
    static void Main(string[] args)
    {
        
        var library = new ScriptureLibrary();
        library.AddScripture(new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."));
        library.AddScripture(new Scripture(new Reference("D&C", 19, 38), "Pray always, and I will pour out my Spirit upon you, and great shall be your blessing"));
        library.AddScripture(new Scripture(new Reference("Philippians", 4, 13), "I can do all things through Christ which strengtheneth me."));
        library.AddScripture(new Scripture(new Reference("2 Nephi", 4, 15-16), "My soul delighteth in the scriptures, and my heart pondereth them. Behold, my soul delighteth in the things of the Lord; and my heart pondereth continually upon the things which I have seen and heard"));
        library.AddScripture(new Scripture(new Reference("Moroni", 1, 2-3), "They put to death every Nephite that will not deny the Christ. And I, Moroni, will not deny the Christ."));
        
        var scripture = library.GetRandomScripture();
        scripture.Display();

        while (true)
        {
            Console.WriteLine("Press Enter to hide a word, or type 'quit' to exit:");
            string input = Console.ReadLine();
            if (input?.ToLower() == "quit")
            {
                break;
            }

            if (scripture.HideRandomWord())
            {
                scripture.Display();
            }
            else
            {
                Console.WriteLine("You memorized it! Awesome!");
                break;
            }
        }
    }
}
