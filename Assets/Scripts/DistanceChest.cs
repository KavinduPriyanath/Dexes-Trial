using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceChest : MonoBehaviour
{
    [SerializeField] private List<GameObject> chests;

    [SerializeField] private GameObject player;

    [SerializeField] private float chest1dis;
    [SerializeField] private float chest2dis;
    [SerializeField] private float chest3dis;

    private void Start()
    {
    }

    private void Update()
    {
        chest1dis = Vector3.Distance(player.transform.position, chests[0].transform.position);
        chest2dis = Vector3.Distance(player.transform.position, chests[1].transform.position);
        chest3dis = Vector3.Distance(player.transform.position, chests[2].transform.position);
    }
}
