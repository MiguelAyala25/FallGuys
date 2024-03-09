using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Victory : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Player")
        {

            textMeshProUGUI.enabled = true;
            float time = GameManager.Instance.timer;
            textMeshProUGUI.text = "Time goku sayayin 4: " + time;

            Time.timeScale = 0f;
        }
    }
}
