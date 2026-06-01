using System.Xml.Linq;
using DarkUI.Controls;
using DarkUI.Forms;
using Intersect.Editor.Core;
using Intersect.Editor.Networking;
using Intersect.Enums;
using Intersect.GameObjects;
using Intersect.Models;
using Intersect.Editor.General;
using Newtonsoft.Json;

namespace Intersect.Editor.Forms.Editors;

public partial class FrmDomainExpansion : EditorForm
{
    private List<DomainExpansionDescriptor> mChanged = new();
    private DomainExpansionDescriptor mEditorItem;

    public FrmDomainExpansion()
    {
        ApplyHooks();
        InitializeComponent();
        Icon = Program.Icon;
        _btnSave = btnSave;
        _btnCancel = btnCancel;

        lstGameObjects.Init(
            UpdateToolStripItems,
            AssignEditorItem,
            toolStripItemNew_Click,
            toolStripItemCopy_Click,
            toolStripItemUndo_Click,
            toolStripItemPaste_Click,
            toolStripItemDelete_Click
        );
    }

    private void AssignEditorItem(Guid id)
    {
        mEditorItem = DomainExpansionDescriptor.Get(id);
        UpdateEditor();
    }

    protected override void GameObjectUpdatedDelegate(GameObjectType type)
    {
        if (type == GameObjectType.DomainExpansion)
        {
            InitEditor();
            if (mEditorItem != null && !DomainExpansionDescriptor.Lookup.Values.Contains(mEditorItem))
            {
                mEditorItem = null;
                UpdateEditor();
            }
        }
    }

    public void InitEditor()
    {
        var items = DomainExpansionDescriptor.Lookup
            .OrderBy(p => p.Value?.Name)
            .Select(pair => new KeyValuePair<Guid, KeyValuePair<string, string>>(
                pair.Key,
                new KeyValuePair<string, string>(
                    pair.Value?.Name ?? DatabaseObject<DomainExpansionDescriptor>.Deleted, ""
                )
            )).ToArray();

        lstGameObjects.Repopulate(items, new List<string>(), false, false, "");
    }

    private void UpdateEditor()
    {
        if (mEditorItem != null)
        {
            pnlContainer.Show();
            txtName.Text = mEditorItem.Name;
            nudRadius.Value = mEditorItem.Radius;
            nudDuration.Value = mEditorItem.Duration;
            nudCooldown.Value = mEditorItem.Cooldown;
            nudPower.Value = mEditorItem.DomainPower;
            chkTraps.Checked = mEditorItem.TrapsEntities;
            txtOverlay.Text = mEditorItem.OverlayTexture;

            cmbLockedSpell.Items.Clear();
            cmbLockedSpell.Items.Add("None");
            cmbLockedSpell.Items.AddRange(SpellDescriptor.Names);
            cmbLockedSpell.SelectedIndex = SpellDescriptor.ListIndex(mEditorItem.LockedSpellId) + 1;

            if (mChanged.IndexOf(mEditorItem) == -1)
            {
                mChanged.Add(mEditorItem);
                mEditorItem.MakeBackup();
            }
        }
        else
        {
            pnlContainer.Hide();
        }

        UpdateToolStripItems();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        foreach (var item in mChanged)
        {
            PacketSender.SendSaveObject(item);
            item.DeleteBackup();
        }
        Hide();
        Globals.CurrentEditor = -1;
        Dispose();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        foreach (var item in mChanged)
        {
            item.RestoreBackup();
            item.DeleteBackup();
        }
        Hide();
        Globals.CurrentEditor = -1;
        Dispose();
    }

    private void txtName_TextChanged(object sender, EventArgs e)
    {
        if (mEditorItem == null) return;
        mEditorItem.Name = txtName.Text;
        lstGameObjects.UpdateText(txtName.Text);
    }

    private void nudRadius_ValueChanged(object sender, EventArgs e)
        => mEditorItem.Radius = (int)nudRadius.Value;

    private void nudDuration_ValueChanged(object sender, EventArgs e)
        => mEditorItem.Duration = (int)nudDuration.Value;

    private void nudCooldown_ValueChanged(object sender, EventArgs e)
        => mEditorItem.Cooldown = (int)nudCooldown.Value;

    private void nudPower_ValueChanged(object sender, EventArgs e)
        => mEditorItem.DomainPower = (int)nudPower.Value;

    private void chkTraps_CheckedChanged(object sender, EventArgs e)
        => mEditorItem.TrapsEntities = chkTraps.Checked;

    private void txtOverlay_TextChanged(object sender, EventArgs e)
        => mEditorItem.OverlayTexture = txtOverlay.Text;

    private void cmbLockedSpell_SelectedIndexChanged(object sender, EventArgs e)
        => mEditorItem.LockedSpellId = SpellDescriptor.IdFromList(cmbLockedSpell.SelectedIndex - 1);

    private void toolStripItemNew_Click(object sender, EventArgs e)
        => PacketSender.SendCreateObject(GameObjectType.DomainExpansion);

    private void toolStripItemDelete_Click(object sender, EventArgs e)
    {
        if (mEditorItem != null && lstGameObjects.Focused)
            PacketSender.SendDeleteObject(mEditorItem);
    }

    private void toolStripItemCopy_Click(object sender, EventArgs e) { }
    private void toolStripItemPaste_Click(object sender, EventArgs e) { }
    private void toolStripItemUndo_Click(object sender, EventArgs e)
    {
        if (mChanged.Contains(mEditorItem) && mEditorItem != null)
        {
            mEditorItem.RestoreBackup();
            UpdateEditor();
        }
    }

    private void UpdateToolStripItems()
    {
        toolStripItemDelete.Enabled = mEditorItem != null && lstGameObjects.Focused;
        toolStripItemUndo.Enabled = mEditorItem != null && lstGameObjects.Focused;
    }
}