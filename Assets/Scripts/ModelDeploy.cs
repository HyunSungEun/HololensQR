using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelDeploy : MonoBehaviour
{
    [SerializeField]
    Transform originParent;
    [SerializeField]
    Transform deployPointsParent;
    [SerializeField]
    Transform[] deployPoints;
    private void Start()
    {
        originParent = transform.parent;
    }

    public Transform tempChoiced;
    [ContextMenu("aasd")]
    public void debugDeploy() { Deploy(tempChoiced); }

    public void Deploy(Transform choicedDeployPoint)
    {
        if (deployPoints == null || deployPoints.Length == 0) return;
        GameObject deployPoint = deployPoints[0].gameObject;
        deployPoint.transform.parent = null;
        gameObject.transform.parent = deployPoint.transform;
        Vector3 rotV = new Vector3(0f, choicedDeployPoint.rotation.eulerAngles.y, 180f);//yaw¸¸ Àû¿ë

        deployPoint.transform.SetPositionAndRotation(choicedDeployPoint.position, Quaternion.Euler(rotV));
        deployPoint.transform.parent = deployPointsParent;
        gameObject.transform.parent = originParent;
    }
}
