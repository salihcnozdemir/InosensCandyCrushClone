using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruit : MonoBehaviour
{
    public List<GameObject> AllObjects;
    public List<GameObject> XAxisObjects;
    public List<GameObject> ZAxisObjects;
    public Transform DownCont;
    void Start()
    {
        StartCoroutine(ExampleCoroutine());
    }
    IEnumerator ExampleCoroutine()
    {
        controlRay();

        yield return new WaitForSeconds(0.3f);
        StartCoroutine(ExampleCoroutine());
    }

    public void controlRay()
    {
        RaycastHit hit; 
        if (Physics.Raycast(transform.position, transform.right, out hit ,1f)) 
        {
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);
                control();
            }

        }
        else
        {
            float xx = this.transform.position.x + 1;
            this.transform.position = new Vector3(xx,0, this.transform.position.z);
        }
    }
    public void control()
    {
        foreach (var allObjects in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if (allObjects.name == "Banana(Clone)" || allObjects.name == "Cherry(Clone)" || allObjects.name == "Watermelon(Clone)")
            {
                AllObjects.Add(allObjects);
            }
        }

          
        for (int i = 0; i < AllObjects.Count; i++)
        {
            float x = Mathf.Abs(this.transform.position.x - AllObjects[i].transform.position.x);
            float z = Mathf.Abs(this.transform.position.z - AllObjects[i].transform.position.z);
            if (x <= 1 && this.tag == AllObjects[i].GetComponent<fruit>().tag)
            {
                if (z == 0)
                {
                    ZAxisObjects.Add(AllObjects[i]);
                    ZAxisObjects.Remove(this.gameObject);
                }
            }
            if (z <= 1 && this.tag == AllObjects[i].GetComponent<fruit>().tag)
            {
                if (x == 0)
                {
                    XAxisObjects.Add(AllObjects[i]);
                    XAxisObjects.Remove(this.gameObject);
                }
            }

        }
        if (ZAxisObjects.Count >= 2)
        {
            foreach (GameObject item in ZAxisObjects)
            {
                Destroy(item);
            }
            Destroy(this.gameObject);
        }
        else
        {
            AllObjects.Clear();
            ZAxisObjects.Clear();
        }
        if (XAxisObjects.Count >= 2)
        {
            foreach (GameObject item in XAxisObjects)
            {
                Destroy(item);
            }
            Destroy(this.gameObject);
        }
        else
        {
            AllObjects.Clear();
            XAxisObjects.Clear();
        }
    }
    void FixedUpdate()
    {
      

    }
}

