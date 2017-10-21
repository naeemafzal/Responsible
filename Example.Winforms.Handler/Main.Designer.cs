namespace Example.Winforms.Handler
{
    partial class Main
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
            this.btnAddException = new System.Windows.Forms.Button();
            this.btnAddError = new System.Windows.Forms.Button();
            this.btnAddOk = new System.Windows.Forms.Button();
            this.btnGet = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddException
            // 
            this.btnAddException.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddException.Location = new System.Drawing.Point(34, 26);
            this.btnAddException.Name = "btnAddException";
            this.btnAddException.Size = new System.Drawing.Size(345, 50);
            this.btnAddException.TabIndex = 0;
            this.btnAddException.Text = "Add Person Exception";
            this.btnAddException.UseVisualStyleBackColor = true;
            this.btnAddException.Click += new System.EventHandler(this.btnAddException_Click);
            // 
            // btnAddError
            // 
            this.btnAddError.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddError.Location = new System.Drawing.Point(34, 82);
            this.btnAddError.Name = "btnAddError";
            this.btnAddError.Size = new System.Drawing.Size(345, 50);
            this.btnAddError.TabIndex = 1;
            this.btnAddError.Text = "Add Person Error";
            this.btnAddError.UseVisualStyleBackColor = true;
            this.btnAddError.Click += new System.EventHandler(this.btnAddError_Click);
            // 
            // btnAddOk
            // 
            this.btnAddOk.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOk.Location = new System.Drawing.Point(34, 138);
            this.btnAddOk.Name = "btnAddOk";
            this.btnAddOk.Size = new System.Drawing.Size(345, 50);
            this.btnAddOk.TabIndex = 2;
            this.btnAddOk.Text = "Add Person OK";
            this.btnAddOk.UseVisualStyleBackColor = true;
            this.btnAddOk.Click += new System.EventHandler(this.btnAddOk_Click);
            // 
            // btnGet
            // 
            this.btnGet.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGet.Location = new System.Drawing.Point(34, 194);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(345, 50);
            this.btnGet.TabIndex = 3;
            this.btnGet.Text = "Get Person";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(34, 250);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(345, 50);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Update Person (Not Implemented)";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 320);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.btnAddOk);
            this.Controls.Add(this.btnAddError);
            this.Controls.Add(this.btnAddException);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddException;
        private System.Windows.Forms.Button btnAddError;
        private System.Windows.Forms.Button btnAddOk;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button btnUpdate;
    }
}

