using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Control : MonoBehaviour
{
    [SerializeField] private Animator door1;
    [SerializeField] private Animator door2;
    [SerializeField] private string doorOpen1 = "DoorOpen1";
    [SerializeField] private string doorClose1 = "DoorClose1";
    [SerializeField] private string doorOpen2 = "DoorOpen2";
    [SerializeField] private string doorClose2 = "DoorClose2";
    [SerializeField] private GameObject doorObj1;
    [SerializeField] private GameObject doorObj2;

    private void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            if (doorObj1.transform.position.y <= 0.4)
            {
                door1.Play(doorOpen1);
                door2.Play(doorOpen2);
            }
            else
            {
                door1.Play(doorClose1);
                door2.Play(doorClose2);
            }
        }
    }
}
