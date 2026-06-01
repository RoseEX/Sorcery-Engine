using Intersect.Client.Framework.Gwen.Control;
using Intersect.Client.General;
using Intersect.Framework.Core;
using Intersect.GameObjects;

namespace Intersect.Client.Interface.Game.Hotbar;

public class DomainSlotWindow : Base
{
    private ImagePanel _slotBg;
    private ImagePanel _iconImage;
    private ImagePanel _cooldownOverlay;
    private Label _cooldownLabel;

    private long _cooldownEndsAt;
    private long _durationEndsAt;
    private long _cooldownTotal;
    private bool _isActive;

    public DomainSlotWindow(Base parent) : base(parent, "DomainSlotWindow")
    {
        _slotBg = new ImagePanel(this, "DomainSlotBg");
        _slotBg.SetSize(54, 54);

        _iconImage = new ImagePanel(_slotBg, "DomainSlotIcon");
        _iconImage.SetSize(48, 48);
        _iconImage.SetPosition(3, 3);

        _cooldownOverlay = new ImagePanel(_slotBg, "DomainCooldownOverlay");
        _cooldownOverlay.SetSize(48, 48);
        _cooldownOverlay.SetPosition(3, 3);
        _cooldownOverlay.RenderColor = new Color(160, 0, 0, 0);
        _cooldownOverlay.IsHidden = true;

        _cooldownLabel = new Label(_slotBg, "DomainCooldownLabel");
        _cooldownLabel.IsHidden = true;

        IsHidden = true;
    }

    public void SetDomain(DomainExpansionDescriptor domain)
    {
        if (domain == null)
        {
            IsHidden = true;
            return;
        }

        _cooldownTotal = domain.Cooldown;
        IsHidden = false;
    }

    public void SetActive(long durationMs)
    {
        _durationEndsAt = Timing.Global.Milliseconds + durationMs;
        _isActive = true;
        _cooldownOverlay.IsHidden = true;
        _cooldownLabel.IsHidden = true;
    }

    public void StartCooldown(long cooldownMs)
    {
        _cooldownEndsAt = Timing.Global.Milliseconds + cooldownMs;
        _cooldownTotal = cooldownMs;
        _isActive = false;
    }

    public override void Think()
    {
        base.Think();
        var now = Timing.Global.Milliseconds;

        if (_isActive)
        {
            if (now >= _durationEndsAt)
            {
                _isActive = false;
                _slotBg.RenderColor = Color.White;
            }
            else
            {
                // Gold pulse while active
                var pulse = (float)Math.Sin(now / 200.0) * 0.5f + 0.5f;
                var brightness = (byte)(180 + pulse * 75);
                _slotBg.RenderColor = new Color(255, brightness, brightness, 0);
            }
        }
        else if (_cooldownEndsAt > now)
        {
            var remaining = _cooldownEndsAt - now;
            var pct = (float)remaining / _cooldownTotal;
            var overlayH = (int)(48 * pct);

            _cooldownOverlay.SetSize(48, overlayH);
            _cooldownOverlay.IsHidden = false;

            _cooldownLabel.SetText(remaining > 1000
                ? ((int)(remaining / 1000)).ToString()
                : (remaining / 1000f).ToString("0.0"));
            _cooldownLabel.IsHidden = false;
        }
        else
        {
            _cooldownOverlay.IsHidden = true;
            _cooldownLabel.IsHidden = true;
            _slotBg.RenderColor = Color.White;
        }
    }
}