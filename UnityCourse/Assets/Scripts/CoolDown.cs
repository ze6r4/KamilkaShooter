using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown : MonoBehaviour
{
    public float cooldownTime { get; set; }
    public bool canDoAction { get; set; }


    public void StartTimer() 
    { 
        StartCoroutine(ICooldown()); 
    }
    private void Start()
    {
        canDoAction = true;
    }
    private IEnumerator ICooldown()
    {
        canDoAction = false;
        yield return new WaitForSeconds(cooldownTime);
        canDoAction = true;
    }
}
