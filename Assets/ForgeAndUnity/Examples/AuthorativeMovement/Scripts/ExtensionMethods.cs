using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// Extension-methods for Forge Networking Remastered.
/// </summary>
public static class ExtensionMethods {
    //Functions
    public static byte[] ObjectToByteArray (this object obj) {
        if (obj == null) {
            return null;
        }

        BinaryFormatter bf = new BinaryFormatter();
        MemoryStream ms = new MemoryStream();
        bf.Serialize(ms, obj);

        return ms.ToArray();
    }

    public static T ByteArrayToObject<T> (this byte[] arrBytes) {
        MemoryStream ms = new MemoryStream();
        BinaryFormatter bf = new BinaryFormatter();
        ms.Write(arrBytes, 0, arrBytes.Length);
        ms.Seek(0, SeekOrigin.Begin);
        T obj = (T)bf.Deserialize(ms);

        return obj;
    }
}
