using UnityEngine;

public class MainControlScript : MonoBehaviour
{
    public static int currentWeapon = 1;
    private float angleZ = 0.5f;
    float current_rotate = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Alpha la phim so
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 2;
        }
        if (Input.GetKey(KeyCode.Q) && current_rotate < 45)
        {
            transform.Rotate(new Vector3(0, 0f, angleZ));
            current_rotate += angleZ;
        }

        if (Input.GetKey(KeyCode.E) && current_rotate > -45)
        {
            transform.Rotate(new Vector3(0, 0f, -1 * angleZ));
            current_rotate -= angleZ;
        }
    }

    private void FixedUpdate()
    {
        //Debug.Log("Current Weapon is "+currentWeapon);
        if (currentWeapon == 1)
        {
            CannonScript.isCannonActive = true;
        }
        else
        if (currentWeapon == 2) { CannonScript.isCannonActive = false; }
    }
}
