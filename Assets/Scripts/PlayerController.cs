using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerMoveSpeed;
    public float arrowMinx, arrowMaxX;
    public float throwForce;

    [SerializeField] private Transform throwingArrow;
    [SerializeField] private Transform ballSpawnPoint;
    [SerializeField] private Rigidbody selectedBall;
    [SerializeField] private Rigidbody[] balls;
    [SerializeField] private Animator arrowAnimator;   

    //disntance between the arrow and the ball
    Vector3 ballOffset;
    bool wasBallThrown;

    // Start is called before the first frame update
    void Start()
    {
        ballOffset = ballSpawnPoint.position - throwingArrow.position;
        //StartThrow();
    }

    // Update is called once per frame
    void Update()
    {
        TryMoveArrrow();
        TryShootBall();
    }

    public void StartThrow()
    {
        arrowAnimator.SetBool("Aiming", true);
        wasBallThrown = false;

        //Anti Cheating line

        int balltoSpawnIndex = Random.Range(0, balls.Length);
        // length is the length of the balls array 
        selectedBall = Instantiate(balls[balltoSpawnIndex], ballSpawnPoint.position, Quaternion.identity);
        Debug.Log($"Balls to spawn Index = {balltoSpawnIndex}");
    }

    void TryMoveArrrow()
    { 
        //!wasBallThrown is the same as wasBallThrown == false
        if(!wasBallThrown)
        {
            //Move Arrow without bounds
            // below allows the arrow to move left and right
            //throwingArrow.position += throwingArrow.right * Input.GetAxis("Horizontal") * playerMoveSpeed * Time.deltaTime;

            //Move Arrow with bounds
            // below is a boundry for the arrow
            float movePosition = Input.GetAxis("Horizontal") * playerMoveSpeed * Time.deltaTime;
            throwingArrow.position = new Vector3(Mathf.Clamp(throwingArrow.position.x + movePosition, arrowMinx, arrowMaxX), throwingArrow.position.y, throwingArrow.position.z);

            //Move the ball with the Arrow
            selectedBall.transform.position = throwingArrow.position + ballOffset;

            //Shoot the ball...
        }
    }

    void TryShootBall()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            wasBallThrown = true;
            selectedBall.AddForce(throwingArrow.forward * throwForce, ForceMode.Impulse);
            arrowAnimator.SetBool("Aiming", false);
        }
    
    }
}
