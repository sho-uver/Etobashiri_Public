using UnityEngine;
public class LineDraw : MonoBehaviour
{
    [SerializeField] private LineRenderer _rend;
    [SerializeField] private Camera _cam;
    private int posCount = 0;
    private float interval = 0.1f;
    private void Update()
    {
        Vector2 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0))
            SetPosition(mousePos);
        else if (Input.GetMouseButtonUp(0))
            posCount = 0;
    }
    private void SetPosition(Vector2 pos)
    {
        if (!PosCheck(pos)) return;
        posCount++;
        _rend.positionCount = posCount;
        _rend.SetPosition(posCount - 1, pos);
    }
    private bool PosCheck(Vector2 pos)
    {
        if (posCount == 0) return true;
        float distance = Vector2.Distance(_rend.GetPosition(posCount - 1), pos);
        if (distance > interval)
            return true;
        else
            return false;
    }
}