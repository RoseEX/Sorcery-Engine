using DarkUI.Controls;

namespace Intersect.Editor.Forms.Editors;

partial class FrmDomainExpansion
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        pnlContainer = new Panel();
        grpGeneral = new DarkGroupBox();
        lblName = new Label();
        txtName = new DarkTextBox();
        lblRadius = new Label();
        nudRadius = new DarkNumericUpDown();
        lblDuration = new Label();
        nudDuration = new DarkNumericUpDown();
        lblCooldown = new Label();
        nudCooldown = new DarkNumericUpDown();
        lblPower = new Label();
        nudPower = new DarkNumericUpDown();
        chkTraps = new DarkCheckBox();
        lblOverlay = new Label();
        txtOverlay = new DarkTextBox();
        lblLockedSpell = new Label();
        cmbLockedSpell = new DarkComboBox();
        grpSpells = new DarkGroupBox();
        lstGameObjects = new Controls.GameObjectList();
        toolStrip = new DarkToolStrip();
        toolStripItemNew = new ToolStripButton();
        toolStripItemDelete = new ToolStripButton();
        toolStripItemCopy = new ToolStripButton();
        toolStripItemPaste = new ToolStripButton();
        toolStripItemUndo = new ToolStripButton();
        btnSave = new DarkButton();
        btnCancel = new DarkButton();
        pnlContainer.SuspendLayout();
        grpGeneral.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudRadius).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudDuration).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudCooldown).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudPower).BeginInit();
        grpSpells.SuspendLayout();
        toolStrip.SuspendLayout();
        SuspendLayout();
        // 
        // pnlContainer
        // 
        pnlContainer.Controls.Add(grpGeneral);
        pnlContainer.Location = new System.Drawing.Point(244, 39);
        pnlContainer.Name = "pnlContainer";
        pnlContainer.Size = new Size(600, 580);
        pnlContainer.TabIndex = 3;
        pnlContainer.Visible = false;
        // 
        // grpGeneral
        // 
        grpGeneral.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
        grpGeneral.BorderColor = System.Drawing.Color.FromArgb(90, 90, 90);
        grpGeneral.Controls.Add(lblName);
        grpGeneral.Controls.Add(txtName);
        grpGeneral.Controls.Add(lblRadius);
        grpGeneral.Controls.Add(nudRadius);
        grpGeneral.Controls.Add(lblDuration);
        grpGeneral.Controls.Add(nudDuration);
        grpGeneral.Controls.Add(lblCooldown);
        grpGeneral.Controls.Add(nudCooldown);
        grpGeneral.Controls.Add(lblPower);
        grpGeneral.Controls.Add(nudPower);
        grpGeneral.Controls.Add(chkTraps);
        grpGeneral.Controls.Add(lblOverlay);
        grpGeneral.Controls.Add(txtOverlay);
        grpGeneral.Controls.Add(lblLockedSpell);
        grpGeneral.Controls.Add(cmbLockedSpell);
        grpGeneral.ForeColor = System.Drawing.Color.Gainsboro;
        grpGeneral.Location = new System.Drawing.Point(9, 6);
        grpGeneral.Name = "grpGeneral";
        grpGeneral.Size = new Size(560, 400);
        grpGeneral.TabIndex = 0;
        grpGeneral.TabStop = false;
        grpGeneral.Text = "Domain Expansion";
        // 
        // lblName
        // 
        lblName.AutoSize = true;
        lblName.ForeColor = System.Drawing.Color.Gainsboro;
        lblName.Location = new System.Drawing.Point(7, 23);
        lblName.Name = "lblName";
        lblName.Size = new Size(42, 15);
        lblName.TabIndex = 0;
        lblName.Text = "Name:";
        // 
        // txtName
        // 
        txtName.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
        txtName.BorderStyle = BorderStyle.FixedSingle;
        txtName.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
        txtName.Location = new System.Drawing.Point(120, 20);
        txtName.Name = "txtName";
        txtName.Size = new Size(420, 23);
        txtName.TabIndex = 1;
        txtName.TextChanged += txtName_TextChanged;
        // 
        // lblRadius
        // 
        lblRadius.AutoSize = true;
        lblRadius.ForeColor = System.Drawing.Color.Gainsboro;
        lblRadius.Location = new System.Drawing.Point(7, 60);
        lblRadius.Name = "lblRadius";
        lblRadius.Size = new Size(77, 15);
        lblRadius.TabIndex = 2;
        lblRadius.Text = "Radius (tiles):";
        // 
        // nudRadius
        // 
        nudRadius.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
        nudRadius.ForeColor = System.Drawing.Color.Gainsboro;
        nudRadius.Location = new System.Drawing.Point(120, 57);
        nudRadius.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
        nudRadius.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudRadius.Name = "nudRadius";
        nudRadius.Size = new Size(200, 23);
        nudRadius.TabIndex = 3;
        nudRadius.Value = new decimal(new int[] { 5, 0, 0, 0 });
        nudRadius.ValueChanged += nudRadius_ValueChanged;
        // 
        // lblDuration
        // 
        lblDuration.AutoSize = true;
        lblDuration.ForeColor = System.Drawing.Color.Gainsboro;
        lblDuration.Location = new System.Drawing.Point(7, 100);
        lblDuration.Name = "lblDuration";
        lblDuration.Size = new Size(83, 15);
        lblDuration.TabIndex = 4;
        lblDuration.Text = "Duration (ms):";
        // 
        // nudDuration
        // 
        nudDuration.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
        nudDuration.ForeColor = System.Drawing.Color.Gainsboro;
        nudDuration.Location = new System.Drawing.Point(120, 97);
        nudDuration.Maximum = new decimal(new int[] { 300000, 0, 0, 0 });
        nudDuration.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
        nudDuration.Name = "nudDuration";
        nudDuration.Size = new Size(200, 23);
        nudDuration.TabIndex = 5;
        nudDuration.Value = new decimal(new int[] { 10000, 0, 0, 0 });
        nudDuration.ValueChanged += nudDuration_ValueChanged;
        // 
        // lblCooldown
        // 
        lblCooldown.AutoSize = true;
        lblCooldown.ForeColor = System.Drawing.Color.Gainsboro;
        lblCooldown.Location = new System.Drawing.Point(7, 140);
        lblCooldown.Name = "lblCooldown";
        lblCooldown.Size = new Size(92, 15);
        lblCooldown.TabIndex = 6;
        lblCooldown.Text = "Cooldown (ms):";
        // 
        // nudCooldown
        // 
        nudCooldown.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
        nudCooldown.ForeColor = System.Drawing.Color.Gainsboro;
        nudCooldown.Location = new System.Drawing.Point(120, 137);
        nudCooldown.Maximum = new decimal(new int[] { 600000, 0, 0, 0 });
        nudCooldown.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
        nudCooldown.Name = "nudCooldown";
        nudCooldown.Size = new Size(200, 23);
        nudCooldown.TabIndex = 7;
        nudCooldown.Value = new decimal(new int[] { 60000, 0, 0, 0 });
        nudCooldown.ValueChanged += nudCooldown_ValueChanged;
        // 
        // lblPower
        // 
        lblPower.AutoSize = true;
        lblPower.ForeColor = System.Drawing.Color.Gainsboro;
        lblPower.Location = new System.Drawing.Point(7, 180);
        lblPower.Name = "lblPower";
        lblPower.Size = new Size(88, 15);
        lblPower.TabIndex = 8;
        lblPower.Text = "Domain Power:";
        // 
        // nudPower
        // 
        nudPower.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
        nudPower.ForeColor = System.Drawing.Color.Gainsboro;
        nudPower.Location = new System.Drawing.Point(120, 177);
        nudPower.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
        nudPower.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudPower.Name = "nudPower";
        nudPower.Size = new Size(200, 23);
        nudPower.TabIndex = 9;
        nudPower.Value = new decimal(new int[] { 100, 0, 0, 0 });
        nudPower.ValueChanged += nudPower_ValueChanged;
        // 
        // chkTraps
        // 
        chkTraps.AutoSize = true;
        chkTraps.ForeColor = System.Drawing.Color.Gainsboro;
        chkTraps.Location = new System.Drawing.Point(7, 217);
        chkTraps.Name = "chkTraps";
        chkTraps.Size = new Size(133, 19);
        chkTraps.TabIndex = 10;
        chkTraps.Text = "Traps Entities Inside?";
        chkTraps.CheckedChanged += chkTraps_CheckedChanged;
        // 
        // lblOverlay
        // 
        lblOverlay.AutoSize = true;
        lblOverlay.ForeColor = System.Drawing.Color.Gainsboro;
        lblOverlay.Location = new System.Drawing.Point(7, 255);
        lblOverlay.Name = "lblOverlay";
        lblOverlay.Size = new Size(91, 15);
        lblOverlay.TabIndex = 11;
        lblOverlay.Text = "Overlay Texture:";
        // 
        // txtOverlay
        // 
        txtOverlay.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
        txtOverlay.BorderStyle = BorderStyle.FixedSingle;
        txtOverlay.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
        txtOverlay.Location = new System.Drawing.Point(120, 252);
        txtOverlay.Name = "txtOverlay";
        txtOverlay.Size = new Size(420, 23);
        txtOverlay.TabIndex = 12;
        txtOverlay.TextChanged += txtOverlay_TextChanged;
        // 
        // lblLockedSpell
        // 
        lblLockedSpell.AutoSize = true;
        lblLockedSpell.ForeColor = System.Drawing.Color.Gainsboro;
        lblLockedSpell.Location = new System.Drawing.Point(7, 295);
        lblLockedSpell.Name = "lblLockedSpell";
        lblLockedSpell.Size = new Size(76, 15);
        lblLockedSpell.TabIndex = 13;
        lblLockedSpell.Text = "Locked Spell:";
        // 
        // cmbLockedSpell
        // 
        cmbLockedSpell.BackColor = System.Drawing.Color.FromArgb(69, 73, 74);
        cmbLockedSpell.BorderColor = System.Drawing.Color.FromArgb(90, 90, 90);
        cmbLockedSpell.BorderStyle = ButtonBorderStyle.Solid;
        cmbLockedSpell.ButtonColor = System.Drawing.Color.FromArgb(43, 43, 43);
        cmbLockedSpell.DrawDropdownHoverOutline = false;
        cmbLockedSpell.DrawFocusRectangle = false;
        cmbLockedSpell.DrawMode = DrawMode.OwnerDrawFixed;
        cmbLockedSpell.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbLockedSpell.FlatStyle = FlatStyle.Flat;
        cmbLockedSpell.ForeColor = System.Drawing.Color.Gainsboro;
        cmbLockedSpell.FormattingEnabled = true;
        cmbLockedSpell.Location = new System.Drawing.Point(120, 292);
        cmbLockedSpell.Name = "cmbLockedSpell";
        cmbLockedSpell.Size = new Size(420, 24);
        cmbLockedSpell.TabIndex = 14;
        cmbLockedSpell.Text = null;
        cmbLockedSpell.TextPadding = new Padding(2);
        cmbLockedSpell.SelectedIndexChanged += cmbLockedSpell_SelectedIndexChanged;
        // 
        // grpSpells
        // 
        grpSpells.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
        grpSpells.BorderColor = System.Drawing.Color.FromArgb(90, 90, 90);
        grpSpells.Controls.Add(lstGameObjects);
        grpSpells.ForeColor = System.Drawing.Color.Gainsboro;
        grpSpells.Location = new System.Drawing.Point(4, 32);
        grpSpells.Name = "grpSpells";
        grpSpells.Size = new Size(233, 580);
        grpSpells.TabIndex = 4;
        grpSpells.TabStop = false;
        grpSpells.Text = "Domain Expansions";
        // 
        // lstGameObjects
        // 
        lstGameObjects.BackColor = System.Drawing.Color.FromArgb(60, 63, 65);
        lstGameObjects.BorderStyle = BorderStyle.None;
        lstGameObjects.ForeColor = System.Drawing.Color.Gainsboro;
        lstGameObjects.ImageIndex = 0;
        lstGameObjects.Location = new System.Drawing.Point(6, 20);
        lstGameObjects.Name = "lstGameObjects";
        lstGameObjects.SelectedImageIndex = 0;
        lstGameObjects.Size = new Size(222, 553);
        lstGameObjects.TabIndex = 0;
        // 
        // toolStrip
        // 
        toolStrip.AutoSize = false;
        toolStrip.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
        toolStrip.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
        toolStrip.Items.AddRange(new ToolStripItem[] { toolStripItemNew, toolStripItemDelete, toolStripItemCopy, toolStripItemPaste, toolStripItemUndo });
        toolStrip.Location = new System.Drawing.Point(0, 0);
        toolStrip.Name = "toolStrip";
        toolStrip.Padding = new Padding(5, 0, 1, 0);
        toolStrip.Size = new Size(920, 29);
        toolStrip.TabIndex = 0;
        // 
        // toolStripItemNew
        // 
        toolStripItemNew.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
        toolStripItemNew.Name = "toolStripItemNew";
        toolStripItemNew.Size = new Size(35, 26);
        toolStripItemNew.Text = "New";
        toolStripItemNew.Click += toolStripItemNew_Click;
        // 
        // toolStripItemDelete
        // 
        toolStripItemDelete.Enabled = false;
        toolStripItemDelete.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
        toolStripItemDelete.Name = "toolStripItemDelete";
        toolStripItemDelete.Size = new Size(44, 26);
        toolStripItemDelete.Text = "Delete";
        toolStripItemDelete.Click += toolStripItemDelete_Click;
        // 
        // toolStripItemCopy
        // 
        toolStripItemCopy.Enabled = false;
        toolStripItemCopy.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
        toolStripItemCopy.Name = "toolStripItemCopy";
        toolStripItemCopy.Size = new Size(39, 26);
        toolStripItemCopy.Text = "Copy";
        toolStripItemCopy.Click += toolStripItemCopy_Click;
        // 
        // toolStripItemPaste
        // 
        toolStripItemPaste.Enabled = false;
        toolStripItemPaste.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
        toolStripItemPaste.Name = "toolStripItemPaste";
        toolStripItemPaste.Size = new Size(39, 26);
        toolStripItemPaste.Text = "Paste";
        toolStripItemPaste.Click += toolStripItemPaste_Click;
        // 
        // toolStripItemUndo
        // 
        toolStripItemUndo.Enabled = false;
        toolStripItemUndo.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
        toolStripItemUndo.Name = "toolStripItemUndo";
        toolStripItemUndo.Size = new Size(40, 26);
        toolStripItemUndo.Text = "Undo";
        toolStripItemUndo.Click += toolStripItemUndo_Click;
        // 
        // btnSave
        // 
        btnSave.Location = new System.Drawing.Point(650, 630);
        btnSave.Name = "btnSave";
        btnSave.Padding = new Padding(5);
        btnSave.Size = new Size(120, 31);
        btnSave.TabIndex = 2;
        btnSave.Text = "Save";
        btnSave.Click += btnSave_Click;
        // 
        // btnCancel
        // 
        btnCancel.DialogResult = DialogResult.Cancel;
        btnCancel.Location = new System.Drawing.Point(780, 630);
        btnCancel.Name = "btnCancel";
        btnCancel.Padding = new Padding(5);
        btnCancel.Size = new Size(120, 31);
        btnCancel.TabIndex = 1;
        btnCancel.Text = "Cancel";
        btnCancel.Click += btnCancel_Click;
        // 
        // FrmDomainExpansion
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
        ClientSize = new Size(920, 680);
        Controls.Add(toolStrip);
        Controls.Add(btnCancel);
        Controls.Add(btnSave);
        Controls.Add(pnlContainer);
        Controls.Add(grpSpells);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "FrmDomainExpansion";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Domain Expansion Editor";
        pnlContainer.ResumeLayout(false);
        grpGeneral.ResumeLayout(false);
        grpGeneral.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudRadius).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudDuration).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudCooldown).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudPower).EndInit();
        grpSpells.ResumeLayout(false);
        toolStrip.ResumeLayout(false);
        toolStrip.PerformLayout();
        ResumeLayout(false);
    }

    private Panel pnlContainer;
    private DarkGroupBox grpGeneral;
    private Label lblName;
    private DarkTextBox txtName;
    private Label lblRadius;
    private DarkNumericUpDown nudRadius;
    private Label lblDuration;
    private DarkNumericUpDown nudDuration;
    private Label lblCooldown;
    private DarkNumericUpDown nudCooldown;
    private Label lblPower;
    private DarkNumericUpDown nudPower;
    private DarkCheckBox chkTraps;
    private Label lblOverlay;
    private DarkTextBox txtOverlay;
    private Label lblLockedSpell;
    private DarkComboBox cmbLockedSpell;
    private DarkGroupBox grpSpells;
    private Controls.GameObjectList lstGameObjects;
    private DarkToolStrip toolStrip;
    private ToolStripButton toolStripItemNew;
    private ToolStripButton toolStripItemDelete;
    private ToolStripButton toolStripItemCopy;
    private ToolStripButton toolStripItemPaste;
    private ToolStripButton toolStripItemUndo;
    private DarkButton btnSave;
    private DarkButton btnCancel;
}