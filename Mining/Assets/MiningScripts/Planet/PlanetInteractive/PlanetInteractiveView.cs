using System;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInteractiveView : View
{
    [SerializeField] private PlanetInteractive_Big planetBigPrefab;
    [SerializeField] private PlanetInteractive_Middle planetMiddlePrefab;
    [SerializeField] private PlanetInteractive_Small planetSmallPrefab;
    [SerializeField] private List<PlanetInteractivePosition> availablePlanetPositions = new List<PlanetInteractivePosition>();

    private List<PlanetInteractivePosition> unavailablePlanetPositions = new List<PlanetInteractivePosition>();

    private List<PlanetInteractive> planetVisualizes = new List<PlanetInteractive>();

    public void VisualizePlanet(Planet planet)
    {
        var position = availablePlanetPositions[UnityEngine.Random.Range(0, availablePlanetPositions.Count)];

        availablePlanetPositions.Remove(position);
        unavailablePlanetPositions.Add(position);

        position.SetID(int.Parse(planet.GetID()));

        PlanetInteractive planetVisualize = null;

        switch (planet.PlanetType)
        {
            case PlanetType.High:
                planetVisualize = Instantiate(planetBigPrefab, position.TransformPlanet);
                planetVisualize.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
                break;
            case PlanetType.Middle:
                planetVisualize = Instantiate(planetMiddlePrefab, position.TransformPlanet);
                planetVisualize.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
                break;
            case PlanetType.Low:
                planetVisualize = Instantiate(planetSmallPrefab, position.TransformPlanet);
                planetVisualize.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
                break;
        }

        planetVisualize.OnClickToPlanet += HandleChoosePlanet;
        planetVisualize.SetData(planet.PlanetSprite);
        planetVisualize.Initialize(int.Parse(planet.GetID()));
    }

    public void Dispose()
    {
        for (int i = 0; i < planetVisualizes.Count; i++)
        {
            planetVisualizes[i].OnClickToPlanet -= HandleChoosePlanet;
            planetVisualizes[i].Dispose();
        }

        planetVisualizes.Clear();
    }

    #region Input

    public event Action<int> OnChoosePlanet;

    private void HandleChoosePlanet(int id)
    {
        OnChoosePlanet?.Invoke(id);
    }

    #endregion
}
