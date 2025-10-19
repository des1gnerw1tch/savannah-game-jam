using UnityEngine;

[ExecuteAlways]
public class TerrainSettings : MonoBehaviour
{
    [SerializeField] private float amplitude;
    [SerializeField] private float scale;

    private void Start()
    {
        Shader.SetGlobalFloat("_TerrainAmplitude", amplitude);
        Shader.SetGlobalFloat("_TerrainScale", scale);
    }

    private void OnValidate()
    {
        Shader.SetGlobalFloat("_TerrainAmplitude", amplitude);
        Shader.SetGlobalFloat("_TerrainScale", scale);
    }
}
