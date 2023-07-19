using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomHudElements : MonoBehaviour
{
    [SerializeField] private TMP_Text gravityMeter;
    [SerializeField] private TMP_Text o2Meter;
    [SerializeField] private TMP_Text anomaliesLvl;

    private void FixedUpdate()
    {
        float gravity = Random.Range(0.1f, 0.9f);
        gravityMeter.text = gravity.ToString() + " mgal";

        int o2lvl = Random.Range(64, 76);
        o2Meter.text = o2lvl.ToString() + "%";
    }
}
