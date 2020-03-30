using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    TableController tableController;
    [SerializeField] private bool running;
    [SerializeField] float score = 0;
    [SerializeField] bool FixedDifficultyMode = true;   // controlls wether difficulty increases per line or score
    [SerializeField] int lineGoal = 10;                             // only applies on Difficulty: Fixed Mode
    [SerializeField] Vector2 scoreGoal = new Vector2(1000f, 2f);    // only applies on Difficulty: Score Mode
    [SerializeField] int lineCounter = 0;
    [SerializeField] float startingTimeSteep = 1f;
    [SerializeField] float currentTimeSteep;
    float timer = 0;
    [SerializeField] float difficutyFactor = 0.75f;
    [SerializeField] Vector2 pointsPerLine = new Vector2(100f, 1.25f);  // X --> points to add per line; Y --> multiplier per simultaneusly cleaned lines
    [SerializeField] Vector2 pointsPerBonus = new Vector2(1.10f, 2f);   // X --> multiplies your score per when sharing; Y --> multiplier per consecutive times
    [SerializeField] int bonusCounter = 0;

    // Set up references
    void Awake()
    {
        tableController = this.gameObject.GetComponent<TableController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentTimeSteep = startingTimeSteep;
        running = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            timer += Time.smoothDeltaTime;
            if (timer >= currentTimeSteep)
            {
                timer = 0;
                tableController.MoveDown(true);
            }
        }
    }
}
