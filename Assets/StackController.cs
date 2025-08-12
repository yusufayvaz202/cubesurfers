using System;
using System.Collections.Generic;
using UnityEngine;

public class StackController : MonoBehaviour
{
    private List<GameObject> stack = new();
    public Transform parent;

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
            RemoveFromStack();
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

    private void RemoveFromStack()
    {
        if (stack.Count == 0) return;

        int index = stack.Count - 1;
        GameObject obj = stack[index];

        obj.transform.parent = null;

        stack.RemoveAt(index);
        i += 1f;
    }
}