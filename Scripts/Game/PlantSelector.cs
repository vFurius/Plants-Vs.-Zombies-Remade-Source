using UnityEngine;
using UnityEngine.UI;
using YourNamespace;  // Asegúrate de importar el espacio de nombres correcto

namespace YourNamespace  // Asegúrate de que esté en el mismo namespace
{
    public class PlantSelector : MonoBehaviour
    {
        public PlantingSystem plantingSystem;

        public void OnPlantSelected(int plantIndex)
        {
            PlantingSystem.PlantData selectedPlant = plantingSystem.availablePlants[plantIndex];  // Cambia 'Plant' a 'PlantData'
            plantingSystem.StartPlanting(selectedPlant);
        }
    }
}