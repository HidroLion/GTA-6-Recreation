using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimRandomizer : MonoBehaviour
{
    [SerializeField] Vector2 delayRange;
    bool defaultMode;

    Animator animator;
    int animSelect;
    float randomTimer;

    float timer;

    public bool DefaultMode { get => defaultMode; set => defaultMode = value; }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        randomTimer = Random.Range(delayRange.x, delayRange.y);
        DefaultMode = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (DefaultMode)
        {
            timer += Time.deltaTime;

            if (timer >= randomTimer)
            {
                animSelect = Random.Range(1, 3);
                animator.SetTrigger(animSelect.ToString());

                randomTimer = Random.Range(delayRange.x, delayRange.y);
                timer = 0;
            }
        }
    }
}
