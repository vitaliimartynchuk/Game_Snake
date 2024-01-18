namespace ConsoleApp_SnakeGame
{
    public class RecordFile
    {
        string fileforRecord = "binaryFile.bin"; // створюємо файл з таким підписом
        public void RecordInFile(int record) // метод запису у файл
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(fileforRecord, FileMode.Create))) // відкр чи створ файл та ПЕРЕЗАПИСУЄМО
            {
                writer.Write(record); // запис рекорду у файл
            }
        }

        public int ReedFromFile() // метод зчитування з файлу
        {
            if (File.Exists(fileforRecord))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(fileforRecord, FileMode.Open))) // відкриваємо файл
                {
                    if (reader.BaseStream.Length >= sizeof(int)) // перевіряємо чи у файлі є стільки байтів скільки треба int record
                    {
                        return reader.ReadInt32(); // зчитуємо з файлу
                    }
                }
            }
            return 0;
        }
    }
}