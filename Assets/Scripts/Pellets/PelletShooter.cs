using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletShooter : MonoBehaviour
{
    [SerializeField]
    GameObject pelletPrefab;

    public void ShootPellet(float force)
    {
        Pellet pellet = Instantiate(pelletPrefab, transform.position, transform.rotation).GetComponent<Pellet>();
        pellet.AddForce(transform.up * force);
    }
}
