using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class RandomTextureGenerator : MonoBehaviour
{
    [SerializeField]
    private InfoWallMaterial[] _infoWallMaterials;

    private List<GameObject> _allWalls = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        _allWalls = GetChildWithTag();
        
        foreach (InfoWallMaterial infoWallMaterial in _infoWallMaterials)
        {
            AddTexture(infoWallMaterial);
        }
    }

    private List<GameObject> GetChildWithTag()
    {
        List<GameObject> list = new List<GameObject>();

        foreach (Transform t in this.transform)
        {
            if(t.tag == "Wall")
            {
                list.Add(t.gameObject);
            }
            else
            {
                foreach (Transform t2 in t)
                {
                    if (t2.tag == "Wall")
                    {
                        list.Add(t2.gameObject);
                    }
                }
            }
            
        }

        return list;
    }

    private void AddTexture(InfoWallMaterial m)
    {
        for (int i = 0; i < m.NombreTexture; i++)
        {
            int toSkip = Random.Range(0, _allWalls.Count);

            _allWalls[toSkip].GetComponent<MeshRenderer>().material = m.Material;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public struct InfoWallMaterial
{
    [SerializeField]
    public int NombreTexture;
    [SerializeField]
    public Material Material;

    InfoWallMaterial(int nombreTexture, Material mat)
    {
        NombreTexture = nombreTexture;
        Material = mat;
    }
}