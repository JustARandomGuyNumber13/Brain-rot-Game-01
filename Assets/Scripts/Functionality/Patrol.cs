using System.Collections;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] float xSpeed;
    [SerializeField] float ySpeed;

    [SerializeField] float restDuration;
    [SerializeField] Vector2 maxRange;
    [SerializeField] Vector2 minRange;

    Vector2 destinationX;
    Vector2 destinationY;

    bool patrolX = true;
    bool patrolY = true;
    WaitForSeconds Rest;

    private void Start()
    {
        Vector3 org = transform.position;
        Rest = new WaitForSeconds(restDuration);
        destinationX = new Vector2(org.x - minRange.x, org.x + maxRange.x);
        destinationY = new Vector2(org.y - minRange.y, org.y + maxRange.y);

        if(xSpeed == 0) patrolX = false;
        if (ySpeed == 0) patrolY = false;
    }

    private void Update()
    {
        Patrolling();
    }

    void Patrolling()
    {
        if (patrolX)
        {
            if (xSpeed > 0 && transform.position.x > destinationX.y) StartCoroutine(RestCoroutine(true));
            else if (xSpeed < 0 && transform.position.x < destinationX.x) StartCoroutine(RestCoroutine(true));
            else
                transform.position += Vector3.right * xSpeed * Time.deltaTime;
        }

        if (patrolY)
        {
            if (ySpeed > 0 && transform.position.y > destinationY.y) StartCoroutine(RestCoroutine(false));
            else if (ySpeed < 0 && transform.position.y < destinationY.x) StartCoroutine(RestCoroutine(false));
            else
                transform.position += Vector3.up * ySpeed * Time.deltaTime;
        }

    }

    IEnumerator RestCoroutine(bool isX)
    {
        if (isX)
            patrolX = false;
        else
            patrolY = false;

        yield return Rest;

        if (isX)
        {
            patrolX = true;
            xSpeed = -xSpeed;
        }
        else
        {
            patrolY = true;
            ySpeed = -ySpeed;
        }
    }
}