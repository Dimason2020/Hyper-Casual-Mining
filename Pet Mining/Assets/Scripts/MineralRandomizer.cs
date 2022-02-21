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

    [SerializeField] private GameObject particles;

    private void Start() 
    {
        meshRenderer = GetComponent<MeshRenderer>();
        defaultMesh = GetComponent<MeshFilter>();
        clickHandler = GetComponent<MineralClickHandler>();

        defaultMesh.mesh = ActivateRandomMineral();
    }

    private Mesh ActivateRandomMineral()
    {
        float spawn = Random.Range(0, 101);

        if (spawn <= goldSpawnChance)
        {
            meshRenderer.material = goldMaterial;
            clickHandler.isPreciousOre = true;
            particles.SetActive(true);
            return gold;
        }
        else if (spawn > goldSpawnChance)
        {
            meshRenderer.material = rockMaterial;
            clickHandler.isPreciousOre = false;
            particles.SetActive(false);
            return rock;
        }

        return rock;
    }
}
