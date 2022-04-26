using UnityEngine;
public class ProjectileMovement : MonoBehaviour
{

    public float speedLimit = 4;
    public float launchAngleLimit = -160;


    void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, Random.Range(-120, launchAngleLimit));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speedLimit);
    }
}
