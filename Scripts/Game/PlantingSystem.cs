using UnityEngine;
using System.Collections.Generic;
using TMPro; // Para el manejo de TextMeshPro

namespace YourNamespace
{
    public class PlantingSystem : MonoBehaviour
    {
        [System.Serializable]
        public class PlantData
        {
            public GameObject previewPlantPrefab;
            public GameObject plantPrefab;
            public string plantName;
            public int cost;  // Costo de la planta en soles
        }

        public List<PlantData> availablePlants;  // Lista de plantas disponibles
        private GameObject previewPlant;
        private bool isPlanting = false;
        private Camera mainCamera;
        private PlantData selectedPlant;  // Planta seleccionada
        private int playerSuns = 50;  // Cantidad de soles del jugador, inicializa con 50 soles
        public TextMeshProUGUI sunText;  // Texto para mostrar los soles

        void Start()
        {
            mainCamera = Camera.main;
            UpdateSunText();
        }

        void Update()
        {
            HandlePlanting();
        }

        void HandlePlanting()
        {
            if (Input.GetMouseButtonDown(0) && isPlanting)
            {
                PlacePlant();
            }

            if (isPlanting && previewPlant != null)
            {
                Vector3 mousePosition = Input.mousePosition;
                mousePosition.z = 10;
                Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
                previewPlant.transform.position = worldPosition;

                // Cambiar color de la vista previa si no tienes suficientes soles
                if (playerSuns < selectedPlant.cost)
                {
                    previewPlant.GetComponent<SpriteRenderer>().color = Color.gray;
                }
                else
                {
                    previewPlant.GetComponent<SpriteRenderer>().color = Color.white;
                }
            }
        }

        public void StartPlanting(PlantData plant)
        {
            if (previewPlant == null)
            {
                selectedPlant = plant;

                // Verificar si el jugador tiene suficientes soles para plantar
                if (playerSuns >= selectedPlant.cost)
                {
                    previewPlant = Instantiate(selectedPlant.previewPlantPrefab);
                    isPlanting = true;
                }
                else
                {
                    Debug.Log("No tienes suficientes soles para plantar esta planta.");
                }
            }
        }

        void PlacePlant()
        {
            if (previewPlant != null && playerSuns >= selectedPlant.cost)
            {
                // Colocar la planta
                Instantiate(selectedPlant.plantPrefab, previewPlant.transform.position, Quaternion.identity);

                // Restar los soles
                playerSuns -= selectedPlant.cost;

                // Actualizar el texto de soles
                UpdateSunText();

                // Eliminar la vista previa
                Destroy(previewPlant);
                isPlanting = false;
            }
            else
            {
                Debug.Log("No tienes suficientes soles para plantar.");
            }
        }

        public void StopPlanting()
        {
            if (previewPlant != null)
            {
                Destroy(previewPlant);
            }
            isPlanting = false;
        }

        // Método para actualizar el texto de los soles
        private void UpdateSunText()
        {
            if (sunText != null)
            {
                sunText.text = "" + playerSuns.ToString();
            }
        }

        // Método para aumentar los soles (esto puede ser llamado cuando el jugador gane soles)
        public void AddSuns(int amount)
        {
            playerSuns += amount;
            // Asegurarse de que no se pase del máximo (9999 soles)
            if (playerSuns > 9999)
                playerSuns = 9999;

            UpdateSunText();
        }
    }
}