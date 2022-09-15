using UnityEditor;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public int waveNumber;
    public bool bossWave;
    public int bossAmmount;
    public Enemy[] enemies;
    
}
[CustomEditor(typeof(Wave))]
public class WaveEditor : Editor
{
    override public void OnInspectorGUI()
    {
        Wave wave = new Wave();

        //wave.bossWave = GUILayout.Toggle(wave.bossWave, "Bosswave");

        //if (wave.bossWave)
        //    wave.bossAmmount = EditorGUILayout.IntSlider("Boss Ammount:", wave.bossAmmount, 1, 100);

        wave.bossWave = EditorGUILayout.Toggle("Boss Wave", wave.bossWave);

        using (new EditorGUI.DisabledScope(wave.bossWave == false))
        {
            wave.bossAmmount = EditorGUILayout.IntField("Jump Height", wave.bossAmmount);
        }
    }
}