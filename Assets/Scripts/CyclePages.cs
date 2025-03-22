using System.Collections.Generic;
using UnityEngine;

public class CyclePages : MonoBehaviour
{
    Transform parent;
    public List<GameObject> children;
    public int index;
    private void Start()
    {

        parent = gameObject.transform;
        index = 0;
        GetObjects();
        UpdateList();
    }
    void GetObjects()
    {
        foreach (Transform child in parent)
        {
            children.Add(child.gameObject);
        }

    }
    void UpdateList()
    {
        foreach (GameObject obj in children)
        {
            if (children.IndexOf(obj) == index)
            {
                obj.SetActive(true);
                //Debug.Log(children.IndexOf(obj));
            }
            else
            {
                obj.SetActive(false);
            }
        }
    }
    public void CycleUp()
    {
        if(index + 1 > children.Count - 1)
        {
            index = 0;
        }
        else
        {
            index++;
        }
        UpdateList();
    }

    public void CycleDown()
    {
        if (index - 1 < 0)
        {
            index = children.Count - 1;
        }
        else
        {
            index--;
        }
        UpdateList();
    }
}
