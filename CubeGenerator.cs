using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    public GameObject cubePrefab;
    public int gridSize = 20;
    public int rowSize = 1;
    public float cubeSize = 100f;
    public float offsetBetweenCubes = 0f;
    public float x_center = 14000f;
    public float z_center = 2000f;
    public float height_offset = 1f;
    public Terrain terrain;
 



    void Start()
    {
        if (terrain == null)
        {
            Debug.LogError("Terrain not assigned. Please assign a Terrain in the inspector.");
            return;
        }

        GenerateCubes();
    }

    void GenerateCubes()
    {
        Vector3 terrainSize = terrain.terrainData.size;
        Vector3 terrainCenter = new Vector3(x_center, 0f, z_center);

        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                for (int k = 0; k < rowSize; k++) // 段数　rowSize
                {
                    float xOffset = i * (cubeSize + offsetBetweenCubes);
                    float yOffset = k * (cubeSize + offsetBetweenCubes);
                    float zOffset = j * (cubeSize + offsetBetweenCubes);

                    // Cube の位置を計算
                    Vector3 cubePosition = terrainCenter + new Vector3(xOffset, yOffset, zOffset);

                    // terrain 上の位置を計算
                    float normalizedX = Mathf.InverseLerp(0f, terrainSize.x, cubePosition.x);
                    float normalizedZ = Mathf.InverseLerp(0f, terrainSize.z, cubePosition.z);

                    float xTerrain = normalizedX * terrainSize.x + terrain.transform.position.x;
                    float zTerrain = normalizedZ * terrainSize.z + terrain.transform.position.z;

                    // terrain の高さをサンプリング
                    float yTerrain = terrain.SampleHeight(new Vector3(xTerrain, 0f, zTerrain));

                    // Cube の位置を調整
                    cubePosition.y = yTerrain + yOffset+height_offset;

                    // Cube を生成
                    Instantiate(cubePrefab, cubePosition, Quaternion.identity);
                }
            }
        }
    }
}
