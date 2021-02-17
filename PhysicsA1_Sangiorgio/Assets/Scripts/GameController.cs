using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class GameController : MonoBehaviour
{
	public Rigidbody targetRb;
	public Rigidbody ball;
	public Transform target;
	public float speedOfTarget = 0.01f;
	public float gravity = -9.8f;
	Vector3 movement;
	public LineRenderer lineVisual;
	public int lineSegment;
	void Start()
	{
		ball.useGravity = false;
		lineVisual.positionCount = lineSegment;
	}

	void Update()
	{
		
		if (Input.GetKeyDown(KeyCode.R))
		{
			RestartGame(); //restarts scene using the scenemanager 
		}
	}
    private void FixedUpdate()
    {
		movement.x = Input.GetAxisRaw("Horizontal"); // input horizontal movement for target
		movement.y = Input.GetAxisRaw("Vertical"); // input vertical movement for target
		Move();
	}
    public void Launch()
	{
		Physics.gravity = Vector3.up * gravity;
		ball.useGravity = true;
		ball.velocity = CalculateProjectile();
	}
	public void RestartGame()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
	public Vector3 CalculateProjectile()
	{
		float height = target.position.y; // setting the height of the parabola to the height of the target so no height errors occur
		float displacementY = target.position.y - ball.position.y; // getting the Y displacement between the ball and the target
		Vector3 displacementXZ = new Vector3(target.position.x - ball.position.x, 0, target.position.z - ball.position.z); // calculating the displacement 
		float time = Mathf.Sqrt(-2 * height / gravity) + Mathf.Sqrt(2 * (displacementY - height) / gravity); // time of the full, time up, time down motion
		Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * height); //calculating the initial vertical velocity 
		Vector3 velocityXZ = displacementXZ / time; //calculating the displacement
		showLine(velocityXZ + velocityY);
		return velocityXZ + velocityY; // returning a raw value, almost like adding a force
	}

	void showLine(Vector3 v0)
    {
        for(int i = 0; i < lineSegment; i++)
        {
			Vector3 pos = CalcPosInTime(v0, i/(float)lineSegment);
			lineVisual.SetPosition(i, pos);
        }
    }

    private void Move()
    {
		targetRb.MovePosition(targetRb.position + movement * speedOfTarget * Time.fixedDeltaTime);
	}
	Vector3 CalcPosInTime(Vector3 v0, float time) // my trajectory pos-time func
    {
		Vector3 Vxz = v0;
		Vxz.y = 0.0f;
		
		Vector3 result = ball.position + v0 * time; //the balls' position in time
		float m_FinalPos = (-0.5f * Mathf.Abs(gravity) * (time * time)) + (v0.y * time) + ball.position.y; // the final position of the 

		result.y = m_FinalPos;
		return result;
    }
}