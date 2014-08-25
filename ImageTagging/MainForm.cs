using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageTagging
{
    public partial class MainForm : Form, ITagView
    {
        /// <summary>
        /// The controller which this form interacts with.
        /// </summary>
        private TagController controller;

        public MainForm()
        {
            InitializeComponent();
            this.AcceptButton = btnAddTag;

        }


        private void mnuFileQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuFileOpenImage_Click(object sender, EventArgs e)
        {

            if (!dlgOpenFile.ShowDialog().Equals(DialogResult.Cancel))
            {
                controller.openImage(dlgOpenFile.FileName);
            }

        }

        public void displayImage(Image img)
        {
            picMain.Image = img;
        }

        public void setController(TagController controller)
        {
            this.controller = controller;
        }

        private void btnAnime_Click(object sender, EventArgs e)
        {
            Button x = new Button();
            x.Size = new Size(70, 25);
            x.Text = "Anime";
            x.UseVisualStyleBackColor = true;
            this.pnlPrevTags.addButton(x);

            this.controller.saveTagDataToFile();
            //TagUsageData z = new TagUsageData();
            //z.newTagUsed("rt");
            //z.toJSON();
        }

        public void populateExistingTags(List<string> tags)
        {

            StringBuilder s = new StringBuilder();
            lblExistingTags.Links.Clear();
            int count = 0;
            foreach (string curr in tags)
            {
                lblExistingTags.Links.Add(new LinkLabel.Link(count, curr.Length, curr));
                s.Append(curr);
                count += curr.Length;
                //if the current tag is the last one
                if (tags.IndexOf(curr) != tags.Count - 1)
                {
                    s.Append(", ");
                    count += 2;
                }
            }
            lblExistingTags.Text = s.ToString();
        }


        private void openImageToolStripButton_Click(object sender, EventArgs e)
        {
            mnuFileOpenImage_Click(sender, e);
        }



        private void lblExistingTags_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel temp = new LinkLabel();
            temp = (LinkLabel)sender;
            this.controller.removeExistingTagFromImage((string)temp.Links[temp.Links.IndexOf(e.Link)].LinkData);
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            openFolderToolStripMenuItem_Click(sender, e);
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!dlgOpenFolder.ShowDialog().Equals(DialogResult.Cancel))
            {
                string folder = dlgOpenFolder.SelectedPath;
                controller.openFolder(folder);
            }
        }

        private void btnNextImage_Click(object sender, EventArgs e)
        {
            this.controller.displayNextImage();
        }

        private void btnPrevImage_Click(object sender, EventArgs e)
        {
            this.controller.displayPreviousImage();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            //check if the text box has uh the cursor in it and if not then move left and right in images.
            if (!txtTagEntry.Focused)
            {
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        this.controller.displayPreviousImage();
                        e.Handled = true;
                        break;
                    case Keys.Right:
                        this.controller.displayNextImage();
                        e.Handled = true;
                        break;
                }
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData.Equals(Keys.Left) || keyData.Equals(Keys.Right))
                return false;
            else
                // Pass it on to the base class for processing
                return base.ProcessDialogKey(keyData);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            setFeatureToAllControls(this.Controls);
        }

        private void setFeatureToAllControls(Control.ControlCollection cc)
        {
            if (cc != null)
            {
                foreach (Control control in cc)
                {
                    control.PreviewKeyDown += new PreviewKeyDownEventHandler(control_PreviewKeyDown);
                    setFeatureToAllControls(control.Controls);
                }
            }
        }

        void control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = true;
            }
        }

        private void btnAddTag_Click(object sender, EventArgs e)
        {
            //if a tag has been entered.
            if (txtTagEntry.Text.Trim() != "")
            {
                this.controller.addTagToImage(txtTagEntry.Text.Trim().ToLower());
                this.txtTagEntry.Text = "";
                this.txtTagEntry.Focus();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                this.controller.saveChangesOnClose();
            }
            finally
            {
                base.OnFormClosing(e);
            }
        }
    }
}
