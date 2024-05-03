using UnityEngine;

public class Hitbox
{
    private Hit hit;
    private Rect box;
    private int width;
    private int height;
    private Vector2 parentPosition;
    private Vector2 localPosition;
    bool flipped = false;

    public Hitbox(float _offx, float _offy, int _width, int _height, Hit _hit)
    {
        width = _width;
        height = _height;
        box = new Rect(0, 0, _width, _height);
        localPosition = new Vector2(_offx, _offy);
        SetPositionFromWorld();
        hit = _hit;
    }
    public bool overlaps(Rect _box)
    {
        return box.Overlaps(_box);
    }
    public void SetParentPosition(Vector2 _offset)
    {
        parentPosition = _offset;
        SetPositionFromWorld();
    }
    public void SetFlipped(bool _flipped)
    {
        if (flipped != _flipped)
        {
            localPosition.x = -localPosition.x;
            SetPositionFromWorld();
            flipped = _flipped;
        }
    }
    private void SetPositionFromWorld()
    {
        box.center = Camera.main.WorldToScreenPoint(new Vector2(localPosition.x + parentPosition.x, -(localPosition.y + parentPosition.y)));
        ScaleToScreen();
    }
    private void ScaleToScreen()
    {
        float scale = Screen.width / 708.0f;
        box.width = width * scale;
        box.height = height * scale;
    }
    public Rect GetRect()
    {
        return box;
    }
    public Hit GetHit()
    {
        return hit;
    }
    public bool overlaps(Hurtbox[] _hurtboxes)
    {
        bool result = false;
        foreach(Hurtbox i in _hurtboxes)
        {
            if (i.overlaps(box))
            {
                result = true;
            }
        }
        return result;
    }
}
