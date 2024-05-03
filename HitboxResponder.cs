using UnityEngine;

public class HitboxResponder : MonoBehaviour
{
    private Hurtbox[] activeHurtboxes; //of the opponent, get from outside file
    private Hitbox[] activeHitboxes; //of the player. get from other file

    //Debug, drawing hitboxes
    private static Texture2D _staticRectTexture;
    private static GUIStyle _staticRectStyle;

    bool showHitboxes = false;

    void Awake()
    {
        activeHitboxes = new Hitbox[0];
    }
    void OnGUI()
    {
        if (showHitboxes)
        {
            if (activeHurtboxes != null)
            {
                foreach (Hurtbox i in activeHurtboxes)
                {
                    GUIDrawRect(i.GetRect(), Color.green);
                }
            }
            if (activeHitboxes != null)
            {
                foreach (Hitbox i in activeHitboxes)
                {
                    GUIDrawRect(i.GetRect(), Color.red);
                }
            }
        }
    }
    // Note that this function is only meant to be called from OnGUI() functions.
    private static void GUIDrawRect(Rect position, Color color)
    {
        if (_staticRectTexture == null)
        {
            _staticRectTexture = new Texture2D(1, 1);
        }

        if (_staticRectStyle == null)
        {
            _staticRectStyle = new GUIStyle();
        }

        _staticRectTexture.SetPixel(0, 0, color);
        _staticRectTexture.Apply();

        _staticRectStyle.normal.background = _staticRectTexture;
        GUI.color = new Color(1.0f, 1.0f, 1.0f, 0.5f); //0.5 is half opacity 
        GUI.Box(position, GUIContent.none, _staticRectStyle);
    }
    public Hit CheckOverlap()
    {
        if (activeHurtboxes != null && activeHitboxes != null)
        {
            foreach (Hitbox i in activeHitboxes)
            {
                if (i.overlaps(activeHurtboxes))
                {
                    if (!i.GetHit().Connected())
                    {
                        i.GetHit().HitPlayer();
                        return i.GetHit(); //Returns, Max one hit per frame. (To avoid unblockable mix-ups, among other things)
                    }
                }
            }
        }
        return null;
    }
    public void SetActiveHurtboxes(Hurtbox[] _hurtboxes)
    {
        activeHurtboxes = _hurtboxes;
    }
    public void SetActiveHitboxes(Hitbox[] _hitboxes)
    {
        activeHitboxes = _hitboxes;
    }
    public void ShowHitboxes()
    {
        showHitboxes = !showHitboxes;
    }
    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);

        Gizmos.DrawCube(Vector3.zero, new Vector3(boxSize.x * 2, boxSize.y * 2, boxSize.z * 2)); // Because size is halfExtents

    }
    public Vector2 WorldToGuiPoint(Vector3 GOposition)
    {
        var guiPosition = Camera.main.WorldToScreenPoint(GOposition);
        // Y axis coordinate in screen is reversed relative to world Y coordinate
        guiPosition.y = Screen.height - guiPosition.y;

        return guiPosition;
    }
    void OnGUI()
    {
        var guiPosition = WorldToGuiPoint(gameObject.transform.position);
        var rect = new Rect(guiPosition, new Vector2(200, 70));
        GUI.Label(rect, "TEST");
    }*/
}
