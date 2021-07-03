using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform[] commanSteps;
    [SerializeField] private Transform[] blueSteps;
    [SerializeField] private Transform[] redSteps;
    [SerializeField] private Transform[] greenSteps;
    [SerializeField] private Transform[] yellowSteps;

    public static MapController instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector3 GetBluePlayerStartingPoint()
    {
        return commanSteps[0].position;
    }
}
