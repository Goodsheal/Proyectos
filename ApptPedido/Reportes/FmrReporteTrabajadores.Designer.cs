﻿namespace ApptPedido.Reportes
{
    partial class FmrReporteTrabajadores
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsPrincipal = new ApptPedido.dsPrincipal();
            this.spmostrartrabajadorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spmostrar_trabajadorTableAdapter = new ApptPedido.dsPrincipalTableAdapters.spmostrar_trabajadorTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spmostrartrabajadorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.spmostrartrabajadorBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ApptPedido.Reportes.RptTrabajadores.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // dsPrincipal
            // 
            this.dsPrincipal.DataSetName = "dsPrincipal";
            this.dsPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spmostrartrabajadorBindingSource
            // 
            this.spmostrartrabajadorBindingSource.DataMember = "spmostrar_trabajador";
            this.spmostrartrabajadorBindingSource.DataSource = this.dsPrincipal;
            // 
            // spmostrar_trabajadorTableAdapter
            // 
            this.spmostrar_trabajadorTableAdapter.ClearBeforeFill = true;
            // 
            // FmrReporteTrabajadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FmrReporteTrabajadores";
            this.Text = "FmrReporteTrabajadores";
            this.Load += new System.EventHandler(this.FmrReporteTrabajadores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spmostrartrabajadorBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private dsPrincipal dsPrincipal;
        private System.Windows.Forms.BindingSource spmostrartrabajadorBindingSource;
        private dsPrincipalTableAdapters.spmostrar_trabajadorTableAdapter spmostrar_trabajadorTableAdapter;
    }
}