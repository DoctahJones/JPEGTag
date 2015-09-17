using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ImageTagging
{
    /// <summary>
    /// An interface to define the methods a view for the project should implement.
    /// </summary>
    public interface ITagView
    {
        /// <summary>
        /// Sets the controller to this view.
        /// </summary>
        /// <param name="controller">The controller.</param>
        void setController(TagController controller);
        /// <summary>
        /// Set the main display image.
        /// </summary>
        /// <param name="img">The image to be displayed. Can be null to display default image.</param>
        void displayImage(Image img);
        /// <summary>
        /// Populates the LinkLabel with links each of which represents a tag on the image.
        /// </summary>
        /// <param name="tags"></param>
        void populateExistingTags(List<string> tags);
        /// <summary>
        /// Used to populate the previously used tags panel.
        /// </summary>
        /// <param name="tags">The list of tags to populate the panel with.</param>
        void populatePrevTagsPanel(List<string> tags);
        /// <summary>
        /// Set the label above the tags to the string stating which sorting method being used at the moment.
        /// </summary>
        /// <param name="s">String which describes how the tags are being organised at this time.</param>
        void setSortMethodLabel(string s);
        /// <summary>
        /// Sets the contents of the label in the bottom status bar.
        /// </summary>
        /// <param name="message">The message/status to be displayed.</param>
        void setStatusText(string message);
        /// <summary>
        /// Prompts the user with a confirmation dialog box with custom message and title.
        /// </summary>
        /// <param name="message">The message telling the user what to confirm.</param>
        /// <param name="title">The header/title of the dialog box.</param>
        /// <returns>Whether the user wishes to contrinue or cancel.</returns>
        bool confirmDialog(string message, string title);

    }
}
