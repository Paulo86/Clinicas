﻿namespace Kleber.Clinicas.UI.WindowsForms.Cadastro
{
    partial class FrmMedico
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnAdicionar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExcluir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDetalhes = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStripPrincipal = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.gdvPrincipal = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTelefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCelular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuToolStrip.SuspendLayout();
            this.statusStripPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // menuToolStrip
            // 
            this.menuToolStrip.BackColor = System.Drawing.Color.White;
            this.menuToolStrip.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menuToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdicionar,
            this.toolStripSeparator3,
            this.btnEditar,
            this.toolStripSeparator1,
            this.btnExcluir,
            this.toolStripSeparator2,
            this.btnDetalhes,
            this.toolStripSeparator4});
            this.menuToolStrip.Location = new System.Drawing.Point(0, 0);
            this.menuToolStrip.Name = "menuToolStrip";
            this.menuToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuToolStrip.Size = new System.Drawing.Size(791, 45);
            this.menuToolStrip.TabIndex = 18;
            this.menuToolStrip.Text = "toolStrip1";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionar.ForeColor = System.Drawing.Color.Black;
            this.btnAdicionar.Image = global::Kleber.Clinicas.UI.WindowsForms.Properties.Resources.Add;
            this.btnAdicionar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(73, 42);
            this.btnAdicionar.Text = "&Adicionar";
            this.btnAdicionar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAdicionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 45);
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.Black;
            this.btnEditar.Image = global::Kleber.Clinicas.UI.WindowsForms.Properties.Resources.Edit;
            this.btnEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(50, 42);
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 45);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.ForeColor = System.Drawing.Color.Black;
            this.btnExcluir.Image = global::Kleber.Clinicas.UI.WindowsForms.Properties.Resources.Cancelar;
            this.btnExcluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(56, 42);
            this.btnExcluir.Text = "&Excluir";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 45);
            // 
            // btnDetalhes
            // 
            this.btnDetalhes.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalhes.ForeColor = System.Drawing.Color.Black;
            this.btnDetalhes.Image = global::Kleber.Clinicas.UI.WindowsForms.Properties.Resources.Detail;
            this.btnDetalhes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDetalhes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDetalhes.Name = "btnDetalhes";
            this.btnDetalhes.Size = new System.Drawing.Size(69, 42);
            this.btnDetalhes.Text = "&Detalhes";
            this.btnDetalhes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDetalhes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDetalhes.Click += new System.EventHandler(this.btnDetalhes_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 45);
            // 
            // statusStripPrincipal
            // 
            this.statusStripPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.statusStripPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStripPrincipal.Location = new System.Drawing.Point(0, 339);
            this.statusStripPrincipal.Name = "statusStripPrincipal";
            this.statusStripPrincipal.Padding = new System.Windows.Forms.Padding(1, 0, 24, 0);
            this.statusStripPrincipal.Size = new System.Drawing.Size(791, 22);
            this.statusStripPrincipal.TabIndex = 17;
            this.statusStripPrincipal.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel1.Image = global::Kleber.Clinicas.UI.WindowsForms.Properties.Resources.estabelecimento;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(766, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "Médicos Cadastrados";
            // 
            // gdvPrincipal
            // 
            this.gdvPrincipal.AllowUserToAddRows = false;
            this.gdvPrincipal.AllowUserToDeleteRows = false;
            this.gdvPrincipal.BackgroundColor = System.Drawing.Color.White;
            this.gdvPrincipal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvPrincipal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.ColNome,
            this.ColTelefone,
            this.ColCelular});
            this.gdvPrincipal.Location = new System.Drawing.Point(0, 48);
            this.gdvPrincipal.Name = "gdvPrincipal";
            this.gdvPrincipal.ReadOnly = true;
            this.gdvPrincipal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gdvPrincipal.Size = new System.Drawing.Size(791, 288);
            this.gdvPrincipal.TabIndex = 19;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Codigo";
            this.Column1.HeaderText = "Código";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // ColNome
            // 
            this.ColNome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColNome.DataPropertyName = "Nome";
            this.ColNome.HeaderText = "Nome do Médico";
            this.ColNome.Name = "ColNome";
            this.ColNome.ReadOnly = true;
            // 
            // ColTelefone
            // 
            this.ColTelefone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColTelefone.DataPropertyName = "Telefone";
            this.ColTelefone.HeaderText = "Telefone";
            this.ColTelefone.Name = "ColTelefone";
            this.ColTelefone.ReadOnly = true;
            this.ColTelefone.Width = 86;
            // 
            // ColCelular
            // 
            this.ColCelular.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColCelular.DataPropertyName = "Celular";
            this.ColCelular.HeaderText = "Celular";
            this.ColCelular.Name = "ColCelular";
            this.ColCelular.ReadOnly = true;
            this.ColCelular.Width = 76;
            // 
            // FrmMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(791, 361);
            this.Controls.Add(this.gdvPrincipal);
            this.Controls.Add(this.menuToolStrip);
            this.Controls.Add(this.statusStripPrincipal);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMedico";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.menuToolStrip.ResumeLayout(false);
            this.menuToolStrip.PerformLayout();
            this.statusStripPrincipal.ResumeLayout(false);
            this.statusStripPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvPrincipal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip menuToolStrip;
        private System.Windows.Forms.ToolStripButton btnAdicionar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnExcluir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnDetalhes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.StatusStrip statusStripPrincipal;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.DataGridView gdvPrincipal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTelefone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCelular;
    }
}