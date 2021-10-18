using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalPopUp : MonoBehaviour
{
    public GameObject portalText;

    void Start()
    {
        StartCoroutine(PortalText());
    }

    private IEnumerator PortalText()
    {
        yield return new WaitForSeconds(6f);
        portalText.SetActive(true);
        yield return new WaitForSeconds(6f);
        portalText.SetActive(false);
    }
}
