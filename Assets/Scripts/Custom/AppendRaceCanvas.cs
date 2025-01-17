using BoatAttack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppendRaceCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var controller = FindObjectOfType<HumanController>();
		if (controller != null)
        {
            var tag = controller.GetComponentInChildren<CanvasFollowerTag>(true);
            if(tag != null)
            {
				Debug.Log("Tag: " + tag.name);
                tag.gameObject.SetActive(true);
				transform.SetParent(tag.transform, false);
            }
        }
    }
}
