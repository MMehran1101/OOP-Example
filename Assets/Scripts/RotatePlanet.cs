using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    public Vector3 RotationPlanetVector;
    private void FixedUpdate() {
        gameObject.transform.Rotate(RotationPlanetVector*Time.deltaTime);
    }
}
