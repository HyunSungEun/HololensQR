using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployManager : QRTracking.Singleton<DeployManager>
{
    [SerializeField]
    GameObject[] ModelPrefabs;
    Dictionary<DeployModelType, GameObject> instanciatedModelDict;
    private void Start()
    {
        instanciatedModelDict = new Dictionary<DeployModelType, GameObject>();
    }
    public void Deploy(DeployModelType modelType, Transform deployPoint)
    {
        if(instanciatedModelDict.ContainsKey(modelType))
        {
            ModelDeploy model = instanciatedModelDict[modelType].GetComponent<ModelDeploy>();
            if(!model)
            {
                Debug.LogError(modelType + " ÇÁ¸®ÆÕ¿¡ ModelDeploy ÄÄÆ÷³ÍÆ® ºÎÀç ");
                return;
            }
            model.gameObject.SetActive(true);
            model.Deploy(deployPoint);
        }
        else
        {
            GameObject temp = Instantiate<GameObject>(ModelPrefabs[(int)modelType]);
            instanciatedModelDict.Add(modelType, temp);
            temp.GetComponent<ModelDeploy>().Deploy(deployPoint);
        }
    }
}
