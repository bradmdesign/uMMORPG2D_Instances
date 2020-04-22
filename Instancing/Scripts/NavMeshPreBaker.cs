using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMeshPreBaker : MonoBehaviour
{
    [Header("Press this to create instances on all instances tagged with ''Instance''")]
    [SerializeField] bool createInstances;


    void Update()
    {
        if (createInstances)
        {
            CreateInstances();
            createInstances = false;
        }
    }

    private void CreateInstances()
    {
        GameObject[] instances = GameObject.FindGameObjectsWithTag("Instance");
        foreach (GameObject obj in instances)
        {
            InstanceZone zonecomp = obj.GetComponent<InstanceZone>();
            zonecomp.PrebakeNavMesh();
        }
    }
}
