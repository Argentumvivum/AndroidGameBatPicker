using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThrowControl : MonoBehaviour {

    public GameObject trajectoryPointPrefab;
    public GameObject projectilePrefab;
    public GameObject projectileSpawnPoint;
    public GameObject player;
    public int numOfTrajectoryPoints;
    public float power;

    private GameObject projectileClone;
    private List<GameObject> trajectoryPoints;
    private bool isPressed;
    private float projectileMass;
    private Vector2 input;
    private Animator animator;

    private void Start()
    {
        trajectoryPoints = new List<GameObject>();
        isPressed = false;
        projectileMass = projectilePrefab.GetComponent<Rigidbody2D>().mass;
        animator = player.GetComponent<Animator>();

        for (int i = 0; i < numOfTrajectoryPoints; i++)
        {
            GameObject dot = Instantiate(trajectoryPointPrefab) as GameObject;
            dot.GetComponent<Renderer>().enabled = false;
            trajectoryPoints.Insert(i, dot);
        }
    }

    private void Update()
    {
        for(int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began &&  !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(i).fingerId))
            {
                isPressed = true;
            }
            else if (Input.GetTouch(i).phase == TouchPhase.Moved && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(i).fingerId) && isPressed == true)
            {
                Vector3 vel = GetForceFrom(projectileSpawnPoint.transform.position, Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position));
                SetTrajectoryPoints(projectileSpawnPoint.transform.position, vel / projectileMass);
            }
            else if (Input.GetTouch(i).phase == TouchPhase.Ended && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(i).fingerId) && Input.touchCount != 2)
            {
                isPressed = false;
                input = Input.GetTouch(i).position;
                HideTrajectory();
            }
            
            animator.SetBool("isAiming", isPressed);
        }
    }

    private Vector2 GetForceFrom(Vector3 fromPos, Vector3 toPos)
    {
        return (new Vector2(toPos.x, toPos.y) - new Vector2(fromPos.x, fromPos.y)) * power;
    }

    void SetTrajectoryPoints(Vector3 pStartPosition, Vector3 pVelocity)
    {
        float velocity = Mathf.Sqrt((pVelocity.x * pVelocity.x) + (pVelocity.y * pVelocity.y));
        float angle = Mathf.Rad2Deg * (Mathf.Atan2(pVelocity.y, pVelocity.x));
        float fTime = 0;

        fTime += 0.1f;

        for (int i = 0; i < numOfTrajectoryPoints; i++)
        {
            float dx = velocity * fTime * Mathf.Cos(angle * Mathf.Deg2Rad);
            float dy = velocity * fTime * Mathf.Sin(angle * Mathf.Deg2Rad) - (Physics2D.gravity.magnitude * fTime * fTime / 2.0f);
            Vector3 pos = new Vector3(pStartPosition.x + dx, pStartPosition.y + dy, 0);
            trajectoryPoints[i].transform.position = pos;
            trajectoryPoints[i].GetComponent<Renderer>().enabled = true;
            trajectoryPoints[i].transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(pVelocity.y - (Physics2D.gravity.magnitude) * fTime, pVelocity.x) * Mathf.Rad2Deg);
            fTime += 0.1f;
        }
    }

    void HideTrajectory()
    {
        foreach (var point in trajectoryPoints)
        {
            point.GetComponent<Renderer>().enabled = false;
        }
    }

    public void SpawnProjectile()
    {
        projectileClone = Instantiate(projectilePrefab) as GameObject;
        Vector3 pos = projectileSpawnPoint.transform.position;
        pos.z = 0;
        projectileClone.transform.position = pos;
        FireProjectile(input);
    }

    private void FireProjectile(Vector2 inputPosition)
    {
        Rigidbody2D rb = projectileClone.GetComponent<Rigidbody2D>();

        rb.AddForce(GetForceFrom(projectileClone.transform.position, Camera.main.ScreenToWorldPoint(inputPosition)), ForceMode2D.Impulse);
        rb.AddTorque(5);
    }
}
