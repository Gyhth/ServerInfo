using System;
using System.IO;
using System.Text;

namespace ServerInfo
{
    public class Writefile
    {
        private FileStream output;

        public FileStream Output { get => output; set => output = value; }

        public void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }

        public T ReadFromBinaryFile<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }

        private void writetoFile(String text)
        {
            Byte[] info = new UTF8Encoding().GetBytes(text + Environment.NewLine);
            Output.Write(info, 0, info.Length);
        }

        public void writeToFile(String text, Boolean append = false)
        {
                this.writetoFile(text);
        }

        public void close()
        {
            Output.Close();
        }
    }
}
