using Intersect.Client.Framework.Gwen.Control;
using Intersect.Client.General;
using Intersect.Framework.Core;

namespace Intersect.Client.Interface.Game.Hotbar;

public class ParryIndicator : Base
{
    private ImagePanel _ring;
    private long _windowEndsAt;
    private bool _active;
    private const int ParryWindowMs = 300;

    public ParryIndicator(Base parent) : base(parent, "ParryIndicator")
    {
        _ring = new ImagePanel(this, "ParryRing");
        _ring.SetSize(80, 80);
        IsHidden = true;
    }

    public void OnWindowOpened(int windowMs)
    {
        _windowEndsAt = Timing.Global.Milliseconds + windowMs;
        _active = true;
        IsHidden = false;
    }

    public override void Think()
    {
        base.Think();
        if (!_active) return;

        var now = Timing.Global.Milliseconds;
        var remaining = _windowEndsAt - now;

        if (remaining <= 0)
        {
            _active = false;
            IsHidden = true;
            return;
        }

        // Fade out as window closes
        var pct = (float)remaining / ParryWindowMs;
        var alpha = (byte)(255 * pct);
        _ring.RenderColor = new Color(alpha, 255, 215, 0); // gold fade
    }
}