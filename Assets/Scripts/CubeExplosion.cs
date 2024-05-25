using UnityEngine;

public class CubeExplosion : MonoBehaviour
{
    [SerializeField] private float _splitChance = 1f;
    [SerializeField] private float _explosionForce = 500f;

    void OnMouseDown()
    {
        if (Random.value < _splitChance)
        {
            int newCubesCount = Random.Range(2, 7);

            for (int i = 0; i < newCubesCount; i++)
            {
                GameObject spawnedCube = GameObject.CreatePrimitive(PrimitiveType.Cube);

                spawnedCube.transform.localScale = transform.localScale / 2;
                spawnedCube.transform.position = transform.position;

                Rigidbody rigidbody = spawnedCube.AddComponent<Rigidbody>();

                rigidbody.AddForce(Physics.gravity);
                rigidbody.AddExplosionForce(_explosionForce, transform.position, 5);

                spawnedCube.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
                spawnedCube.AddComponent<CubeExplosion>()._splitChance = _splitChance / 2;
            }
        }

        Destroy(gameObject);
    }
}
