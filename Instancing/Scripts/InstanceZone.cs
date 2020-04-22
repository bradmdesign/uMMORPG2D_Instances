using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceZone : MonoBehaviour
{
    [SerializeField] private GameObject zone;

    [SerializeField] private List<GameObject> activeInstances;

    [SerializeField] private Vector3 instanceLocation;

    [SerializeField] private int distanceBetweenZones;
    
    [SerializeField] private GameObject newZone;

    [SerializeField] private bool go;
    
    [SerializeField] private bool removeLast;

    [SerializeField] private bool removeAtIndex;

    [SerializeField] private int removalIndex;

    [SerializeField] private bool prebakeNavMesh;

    [SerializeField] public int instancesToCreate = 25;

    private void Update()
    {
        if (go)
        {
            InstantiateZone();
            go = false;
        }

        if (removeLast)
        {
            RemoveLast();
            removeLast = false;
        }

        if (removeAtIndex)
        {
            RemoveInstance(removalIndex);
            removeAtIndex = false;
        }

        if (prebakeNavMesh)
        {
            PrebakeNavMesh();
            prebakeNavMesh = false;
        }
    }

    public void PrebakeNavMesh()
    {
        for (int i = 0; i < instancesToCreate; i++)
        {
            InstantiateZone();
        }
    }

    private void InstantiateZone()
    {
        if (activeInstances.Count == 0) //if list empty, start it at base point + 100
            newZone = Instantiate(zone, new Vector3(instanceLocation.x + distanceBetweenZones, instanceLocation.y, instanceLocation.z), transform.rotation);

        else
            newZone = Instantiate(zone,
                new Vector3(activeInstances[activeInstances.Count - 1].transform.position.x + distanceBetweenZones, instanceLocation.y, instanceLocation.z),
                transform.rotation, gameObject.transform);

        activeInstances.Add(newZone);
        newZone.GetComponent<ZoneIndex>().zoneIndex = activeInstances.Count - 1;
    }

    private void RemoveLast()
    {
        if (activeInstances.Count != 0) //Later: Check for player before removal.
        {
            int thisCount = activeInstances.Count -1 ;
            GameObject currentInstance = activeInstances[thisCount];
            Destroy(currentInstance);
            activeInstances.RemoveAt(thisCount);
        }
    }

    private void RemoveInstance(int location)
    {
        if (activeInstances.Count != 0) //Later: Check for player before removal.
        {
            
            GameObject currentInstance = activeInstances[location];
            UpdateIndexes(currentInstance.GetComponent<ZoneIndex>().zoneIndex); //Update indexes on all higher.
            Destroy(currentInstance);
            activeInstances.RemoveAt(location);
        }
    }

    private void UpdateIndexes(int thisIndex)
    {

        for (int i = thisIndex; i<activeInstances.Count; i++)
        {
            activeInstances[i].GetComponent<ZoneIndex>().zoneIndex -= 1;
        }
    }
}
