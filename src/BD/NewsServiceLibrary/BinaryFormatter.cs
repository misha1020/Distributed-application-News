using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ServerWCF
{
    class BinFormatter
    {
        public static byte[] ToBytes<T>(T parameters)
        {
            MemoryStream stream = new System.IO.MemoryStream();
            System.Runtime.Serialization.IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, parameters);

            byte[] bytes = stream.GetBuffer();

            return bytes;
        }

        public static T FromBytes<T>(byte[] byteArrayData)
        {
            T parameters;
            using (MemoryStream stream = new MemoryStream(byteArrayData))
            {
                BinaryFormatter bformatter = new BinaryFormatter();
                parameters = (T)bformatter.Deserialize(stream);
            }
            return parameters;
        }
    }
}
