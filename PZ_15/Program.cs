namespace PZ_15
{


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите полный путь к каталогу:");
            string directoryPath = Console.ReadLine();

            string sourcePath = Path.Combine(directoryPath, "full");
            string destinationPath = Path.Combine(directoryPath, "empty");

            if (Directory.Exists(sourcePath) && Directory.Exists(destinationPath))
            {
                string[] files = Directory.GetFiles(sourcePath);
                for (int i = 0; i < files.Length; i++)
                {
                    string fileName = Path.GetFileName(files[i]);
                    string destinationFile = Path.Combine(destinationPath, fileName);
                    File.Move(files[i], destinationFile);
                    Console.WriteLine("Перенос файла {0} выполнен успешно", fileName);
                }
            }
            else
            {
                Console.WriteLine("Каталоги full и/или empty не существуют.");
            }

            Console.ReadLine();
        }
    }