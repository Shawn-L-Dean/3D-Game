using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge_Control : MonoBehaviour
{
    [SerializeField] private Animator bridge;
    [SerializeField] private string bridgeExtend = "BridgeExtend";
    [SerializeField] private string bridgeRetract = "BridgeRetract";
    [SerializeField] private GameObject bridgeObj;

    private void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            if (bridgeObj.transform.position.x >= 70)
            {
                bridge.Play(bridgeExtend);
            }
            else
            {
                bridge.Play(bridgeRetract);
            }
        }
    }
}
