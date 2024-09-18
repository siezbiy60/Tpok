using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // UI bileþenlerini kullanmak için gerekli


public class FPSController : MonoBehaviour
{
    public CharacterController controller;
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float stamina = 100f;
    public float maxStamina = 100f;
    public float staminaDecreaseRate = 15f;
    public float staminaIncreaseRate = 10f;
    public float minStaminaToRun = 5f;  // Minimum stamina seviyesi
    public float runCooldown = 3f;       // Koþma bekleme süresi

    public Slider staminaBar;  // Dayanýklýlýk barý

    private float currentSpeed;
    private bool isRunning = false;
    private bool isCooldown = false; // Koþma bekleme süresi kontrolü
    private float cooldownTimer = 0f; // Bekleme süresi zamanlayýcý

    void Start()
    {
        currentSpeed = walkSpeed;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = stamina;
    }

    void Update()
    {
        MovePlayer();
        HandleStamina();

        // Koþma bekleme süresini kontrol et
        if (isCooldown)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0f)
            {
                isCooldown = false;  // Bekleme süresi sona erdi
            }
        }
    }

    void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * currentSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift) && stamina > minStaminaToRun && !isCooldown)
        {
            isRunning = true;
            currentSpeed = runSpeed;
        }
        else
        {
            isRunning = false;
            currentSpeed = walkSpeed;
        }
    }

    void HandleStamina()
    {
        if (isRunning)
        {
            stamina -= staminaDecreaseRate * Time.deltaTime;
            if (stamina < 0) stamina = 0;
        }
        else
        {
            stamina += staminaIncreaseRate * Time.deltaTime;
            if (stamina > maxStamina) stamina = maxStamina;
        }

        // Eðer dayanýklýlýk minimum seviyeye düþerse, koþmayý engelle ve bekleme süresini baþlat
        if (stamina <= minStaminaToRun && !isCooldown)
        {
            isCooldown = true;
            cooldownTimer = runCooldown; // Bekleme süresini baþlat
        }

        staminaBar.value = stamina;  // Dayanýklýlýk barýný güncelle
    }
}