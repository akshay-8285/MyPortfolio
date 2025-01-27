using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class EditorDataServices : IDataServices
{
    private const byte encryptionKey = 0xAA; // Alternating pattern of 1s and 0s (101010... in binary)
    private const string saveFileName = "5573657244617461.dat";

    public UserData GetData()
    {
        string path = Application.persistentDataPath + "/" + saveFileName;
        if (File.Exists(path))
        {
            byte[] encryptedData = File.ReadAllBytes(path);
            byte[] decryptedBytes = Decrypt(encryptedData);
            string jsondata = Encoding.UTF8.GetString(decryptedBytes);
            return JsonUtility.FromJson<UserData>(jsondata);
        }
        else
        {
            return new UserData();
        }
    }

    public void SetData(UserData data)
    {
        byte[] encryptedData = Encrypt(Encoding.UTF8.GetBytes(JsonUtility.ToJson(data)));
        File.WriteAllBytes(Application.persistentDataPath + "/" + saveFileName, encryptedData);
    }

    #region ENCRYPT / DECRYPT LOGIC
        
    private byte[] Encrypt(byte[] data)
    {
        byte[] encryptedData = new byte[data.Length];
        for (int i = 0; i < data.Length; i++)
        {
            encryptedData[i] = (byte)(data[i] ^ encryptionKey);
        }
        return encryptedData;
    }

    private byte[] Decrypt(byte[] data)
    {
        return Encrypt(data); // XOR encryption is its own decryption (XOR-ing twice cancels out)
    }

    #endregion

}
