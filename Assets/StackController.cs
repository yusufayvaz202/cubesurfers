using System;
using System.Collections.Generic;
using UnityEngine;

//TODO: Refactor all code.
public class StackController : MonoBehaviour
{
    public List<GameObject> stack = new();
    public Transform parent;
    public bool isRemoving = false;
    

    private void Awake()
    {
        stack.Add(parent.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            AddToStack(other.gameObject);
        }
        else if (other.CompareTag("Obstacle"))
        {
            RemoveFromStack(other);
        }
    }

    public float i = -1f;

    private void AddToStack(GameObject item)
    {
        if (item != null && !stack.Contains(item))
        {
            stack.Add(item);
            item.transform.SetParent(parent);
            item.transform.localPosition = stack.Count == 2 ? new Vector3(0, -1f, 0) : new Vector3(0, i, 0);
            transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
            i -= 1f;
        }
    }
    private float x;
    private void RemoveFromStack(Collider other)
    {
        if (stack.Count == 0) return;
        
        int index = stack.Count - 1;
        GameObject obj = stack[index];

        Vector3 pos = obj.transform.localPosition;
        obj.transform.parent = null;
        // TODO: test here all obstacle and cube count works fine x var is must be zero after this but collider is off so it doesnt trigger
        obj.transform.position = new Vector3(transform.position.x, pos.y + -i -.5f + x, transform.position.z);
        x += 1f;
        stack.RemoveAt(index);
        i += 1f;
        
        if (stack.Count > 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
        }
        
        
        other.enabled = false;
        obj.GetComponent<Collider>().enabled = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            isRemoving = false;
            x = 0f;
        }
    }
}