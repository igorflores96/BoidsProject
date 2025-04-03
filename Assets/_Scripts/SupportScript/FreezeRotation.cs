using UnityEngine;

public class FreezeRotation : MonoBehaviour
{
    public Transform parent;

    void LateUpdate()
    {
        if (parent != null)
            transform.position = new Vector3(parent.position.x, parent.position.y + 0.5f, parent.position.z);
    }
}
