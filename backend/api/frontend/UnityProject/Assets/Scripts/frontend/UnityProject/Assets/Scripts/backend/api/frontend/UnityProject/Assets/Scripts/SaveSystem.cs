using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem : MonoBehaviour
{
    private const string SAVE_PATH = "/saveData.json";

    [System.Serializable]
    public class SaveData
    {
        public int score;
        public int level;
    }

    public void SavePlayerStats(PlayerStats stats)
    {
        SaveData data = new SaveData
        {
            score = stats.score,
            level = stats.level
        };

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + SAVE_PATH, json);
        Debug.Log("Datos guardados en: " + Application.persistentDataPath + SAVE_PATH);
    }

    public SaveData LoadPlayerStats()
    {
        string path = Application.persistentDataPath + SAVE_PATH;
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            return data;
        }
        Debug.LogWarning("No se encontraron datos guardados.");
        return new SaveData();
    }
}
