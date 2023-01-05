using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireController : MonoBehaviour
{
    [Header("Fire Variables")] public Transform firePoint;
    public GameObject regularFire;
    public float fireWait;
    private float fireWaitSeconds;

    void Start()
    {
        fireWaitSeconds = fireWait;
    }

    // Update is called once per frame
    void Update()
    {
        fireWaitSeconds -= Time.deltaTime;
        if (fireWaitSeconds <= 0)
        {
            StartCoroutine(Fire(8f));
            //fire three lasers
            fireWaitSeconds = fireWait;
        }
    }

    private IEnumerator Fire(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        LaserController.Spawn().Init(transform.position, Quaternion.identity);
        LaserController.Spawn().Init(transform.position, Quaternion.Euler(0, 0, 10));
        LaserController.Spawn().Init(transform.position, Quaternion.Euler(0, 0, -10));
    }
}