using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectFruit : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> AllObjects;
    public fruit kd;

    public GameObject firstSelectObject, secoundObject;
    public bool tiklandi;
    void Start()
    {
        git();
    }


    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 200.0f))
        {
            Debug.Log(hit.collider.tag);
            Debug.Log(hit.collider.transform.position.x);

            if (Input.GetMouseButtonDown(0))
            {
                firstSelectObject = hit.collider.gameObject;
            }
            if (Input.GetMouseButtonUp(0))
            {
                git();
                Invoke("git", 0.4f);
                secoundObject = hit.collider.gameObject;
                float xFark = Mathf.Abs(firstSelectObject.transform.position.x - secoundObject.transform.position.x);
                float zFark = Mathf.Abs(firstSelectObject.transform.position.z - secoundObject.transform.position.z);
                if (firstSelectObject != secoundObject && xFark + zFark == 1)
                {
                    var firstObjePos = firstSelectObject.transform.position;
                    firstSelectObject.transform.position = secoundObject.transform.position;
                    secoundObject.transform.position = firstObjePos;

                }
                else
                {
                    firstSelectObject = null;
                    secoundObject = null;
                }
            }
        }
    }
    void git()
    {
        foreach (var allObjects in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if (allObjects.name == "Banana(Clone)" || allObjects.name == "Cherry(Clone)" || allObjects.name == "Watermelon(Clone)")
            {
                AllObjects.Add(allObjects);
                allObjects.GetComponent<fruit>().control();
                
            }
        }
    }
}
