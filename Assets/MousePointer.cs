using UnityEngine;

public class MousePointer : MonoBehaviour
{

    void Update()
    {
        {
            Vector3 mposition = Input.mousePosition;
            Vector3 cpoint = Camera.main.ScreenToWorldPoint(mposition);
            transform.position = new Vector3(cpoint.x, cpoint.y);
        }

        Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y - Camera.main.transform.position.z));

        if(Input.GetMouseButton(0))
        {
            Debug.Log(point.ToString());
        }
    }
}
