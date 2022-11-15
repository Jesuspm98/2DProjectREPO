using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public Transform[] shootPointPositions;
    public GameObject proyectilePrefab;

    public float timeBetweenShoots = 1;
    private float timeSinceLastShoot = 0;

    private void Update()
    {
        timeSinceLastShoot += Time.deltaTime;

        if (timeSinceLastShoot > timeBetweenShoots)
        {
            int rand = Random.Range(0, shootPointPositions.Length);

            timeSinceLastShoot = 0;
            Instantiate(proyectilePrefab, shootPointPositions[rand].position, shootPointPositions[rand].rotation);
        }
    }
}