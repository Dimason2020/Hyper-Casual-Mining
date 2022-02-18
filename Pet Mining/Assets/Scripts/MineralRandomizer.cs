using UnityEngine;

public class MineralRandomizer : MonoBehaviour
{
    [SerializeField, Range(0, 100)] 
    private float goldSpawnChance, rockSpawnChance;

    [SerializeField] private Mesh gold, rock;
    [SerializeField] private Material goldMaterial, rockMaterial;

    private MeshFilter defaultMesh;
    private MeshRenderer meshRenderer;
    private MineralClickHandler clickHandler;

    private void Start() 
    {
        meshRenderer = GetComponent<MeshRenderer>();
        defaultMesh = GetComponent<MeshFilter>();
        clickHandler = GetComponent<MineralClickHandler>();

        defaultMesh.mesh = ActivateRandomMineral();
    }

    private Mesh ActivateRandomMineral()
    {
        float spawn = UnityEngine.Random.Range(0, 101);

        if (spawn <= goldSpawnChance)
        {
            meshRenderer.material = goldMaterial;
            clickHandler.isPreciousOre = true;
            return gold;
        }
        else if (spawn > goldSpawnChance)
        {
            meshRenderer.material = rockMaterial;
            clickHandler.isPreciousOre = false;
            return rock;
        }

        return rock;
    }
}