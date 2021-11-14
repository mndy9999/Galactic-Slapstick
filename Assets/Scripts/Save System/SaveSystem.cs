using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static string FilePath
    {
        get
        {
            return Path.Combine(Application.persistentDataPath, "Crtl_Del.fun");
        }
    }
    public static void SaveScore(int seconds1, int seconds2, int seconds3)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(FilePath, FileMode.Create);

        SaveData data = new SaveData(seconds1, seconds2, seconds3);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static SaveData LoadScore()
    {
        if (File.Exists(FilePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(FilePath, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("save file not found in " + FilePath);
            return new SaveData(0, 0, 0);
        }
    }

}
