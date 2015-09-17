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
    /// <summary>
    /// The main form used to display the application to the user. Implements the ITagView interface.
    /// </summary>
    public partial class MainForm : Form, ITagView
    {
        /// <summary>
        /// The controller which this form interacts with.
        /// </summary>
        private TagController controller;

        /// <summary>
        /// Constructor for MainForm.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            this.AcceptButton = btnAddTag;

        }

        /// <summary>
        /// Sets the controller to this view.
        /// </summary>
        /// <param name="controller">The controller.</param>
        public void setController(TagController controller)
        {
            this.controller = controller;
        }

        #region MainMenu
        private void mnuFileOpenImage_Click(object sender, EventArgs e)
        {

            if (!dlgOpenFile.ShowDialog().Equals(DialogResult.Cancel))
            {
                controller.openImage(dlgOpenFile.FileName);
            }

        }

        private void mnuOpenFolder_Click(object sender, EventArgs e)
        {
            if (!dlgOpenFolder.ShowDialog().Equals(DialogResult.Cancel))
            {
                string folder = dlgOpenFolder.SelectedPath;
                controller.openFolder(folder);
            }
        }

        private void mnuFileQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuEditPaste_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                this.txtTagEntry.Paste();
            }
        }

        #endregion

        /// <summary>
        /// Set the main display image.
        /// </summary>
        /// <param name="img">The image to be displayed. Can be null to display default image.</param>
        public void displayImage(Image img)
        {
            if (img != null)
                picMain.Image = img;
            else
            {
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
                this.picMain.Image = ((System.Drawing.Image)(resources.GetObject("picMain.Image"))); 
            }
        }

       

        /// <summary>
        /// Populates the LinkLabel with links each of which represents a tag on the image.
        /// </summary>
        /// <param name="tags"></param>
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

        /// <summary>
        /// Set the label above the tags to the string stating which sorting method being used at the moment.
        /// </summary>
        /// <param name="s">String which describes how the tags are being organised at this time.</param>
        public void setSortMethodLabel(string s)
        {
            this.lblTagsHeader.Text = s;
        }

        /// <summary>
        /// Used to populate the previously used tags panel.
        /// </summary>
        /// <param name="tags">The list of tags to populate the panel with.</param>
        public void populatePrevTagsPanel(List<string> tags)
        {
            //clear existing buttons
            int c = this.pnlPrevTags.getCurrentButtons().Count();
            if (c > 0)
            {
                for (int i = 0; i < c; i++)
                {
                    //remove event handler for current button and then remove button.
                    this.pnlPrevTags.getCurrentButtons()[0].Click -= new EventHandler(prevTagClick);
                    this.pnlPrevTags.RemoveButton(this.pnlPrevTags.getCurrentButtons()[0]);
                }
            }
            //add new button for each tag used.
            foreach (string curTag in tags)
            {
                Button b = new Button();
                b.Text = curTag;
                System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
                ToolTip1.SetToolTip(b, b.Text);
                b.Click += new EventHandler(prevTagClick);
                this.pnlPrevTags.addButton(b);
            }
        }

        /// <summary>
        /// Method to add a tag to an image when one of the tags in the list of previously used ones is clicked.
        /// </summary>
        /// <param name="sender">The Button that sent the event when it was clicked.</param>
        /// <param name="e"></param>
        private void prevTagClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            this.controller.addTagToImage(b.Text);

        }

        /// <summary>
        /// Prompts the user with a confirmation dialog box with custom message and title.
        /// </summary>
        /// <param name="message">The message telling the user what to confirm.</param>
        /// <param name="title">The header/title of the dialog box.</param>
        /// <returns>Whether the user wishes to contrinue or cancel.</returns>
        public bool confirmDialog(string message, string title)
        {
            var confirmResult = MessageBox.Show(message, title,  MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Sets the contents of the label in the bottom status bar.
        /// </summary>
        /// <param name="message">The message/status to be displayed.</param>
        public void setStatusText(string message)
        {
            this.statusLabel.Text = message;
        }

        /// <summary>
        /// Method to remove a tag from an image when one of the tags in its list has been clicked.
        /// </summary>
        /// <param name="sender">The LinkLabel sending the click event.</param>
        /// <param name="e">The event arguements which contain which link it was that was clicked.</param>
        private void lblExistingTags_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel temp = new LinkLabel();
            temp = (LinkLabel)sender;
            this.controller.removeExistingTagFromImage((string)temp.Links[temp.Links.IndexOf(e.Link)].LinkData);
        }

        #region ToolstripButtons
        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            mnuOpenFolder_Click(sender, e);
        }

        private void openImageToolStripButton_Click(object sender, EventArgs e)
        {
            mnuFileOpenImage_Click(sender, e);
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            this.controller.saveChangesOnClose();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            mnuEditPaste_Click(sender, e);
        }
        #endregion

        

        

        private void btnNextImage_Click(object sender, EventArgs e)
        {
            this.controller.displayNextImage();
        }

        private void btnPrevImage_Click(object sender, EventArgs e)
        {
            this.controller.displayPreviousImage();
        }

        #region ArrowkeyMovement
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

        /// <summary>
        /// Method to allow us to use key left and right to navigate through images.
        /// </summary>
        /// <param name="keyData">The data about which key has been pressed.</param>
        /// <returns>Whethere the key was processed.</returns>
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
        #endregion

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



        /// <summary>
        /// Have the controller save changes when the application closes.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                this.controller.saveChangesOnClose();
            }
            catch { throw; }
            finally
            {
                this.Dispose();
            }
        }

        private void mnuClearPreviousTags_Click(object sender, EventArgs e)
        {
            this.controller.clearTagdata();
        }

        

        /// <summary>
        /// Method to automatically set the maximum width of the linklabel displaying current tags so that
        /// when it autosizes the contents it wraps to the next line. The size is based on the container panel it sits within.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void splitLeftContent_Panel2_Resize(object sender, EventArgs e)
        {
            this.lblExistingTags.MaximumSize = new System.Drawing.Size(splitLeftContent.Panel2.Width - 50 ,0); 
        }

        private void mnuMostUsed_Click(object sender, EventArgs e)
        {
            this.mnuMostRecent.Checked = false;
            this.mnuMostUsed.Checked = true;
            this.controller.setPrevTagDataSortMethod("mostUsed");
        }

        private void mnuMostRecent_Click(object sender, EventArgs e)
        {
            this.mnuMostUsed.Checked = false;
            this.mnuMostRecent.Checked = true;
            this.controller.setPrevTagDataSortMethod("mostRecent");
        }

    }
}
