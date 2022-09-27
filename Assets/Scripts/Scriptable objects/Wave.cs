using UnityEditor;
using UnityEngine;

[System.Serializable]
public class Wave
{
    [Header("Wave Info")]
    public int waveNumber;
    public int waveReward;
    [Header("Boss Stuff")]
    public bool bossWave;
    public int bossAmmount;
    [Header("Enemies in This Wave")]
    public Enemy[] enemies;
   

}
[CustomEditor(typeof(Wave))]
public class WaveEditor : Editor
{
    override public void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Wave wave = new Wave();            

        wave.bossWave = EditorGUILayout.Toggle("Boss Wave", wave.bossWave);

        using (new EditorGUI.DisabledScope(wave.bossWave == false))
        {
            wave.bossAmmount = EditorGUILayout.IntField("Boss Ammount", wave.bossAmmount);
        }
    }
}