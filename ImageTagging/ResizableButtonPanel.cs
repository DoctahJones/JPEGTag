using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageTagging
{
    /// <summary>
    /// Class to represent a panel which has a variable number of buttons on it which adjust to the size of the panel and number of buttons located upon it.
    /// </summary>
    public class ResizableButtonPanel : Panel
    {

        List<Button> currentButtons;
        //the number of columns of buttons in the panel.
        int columns = -1;
        //the gap between the buttons on the panel for display purposes.
        int widthOffset = -1;
        //The gap between the buttons on the panels rows.
        int heightOffset = 2;
        //the maximum number of rows of buttons that can fit within the panel.
        int maxRows = -1;

        /// <summary>
        /// Constructor for Panel.
        /// </summary>
        public ResizableButtonPanel()
        {
            currentButtons = new List<Button>();
        }


        private void calculateColumns()
        {
            if (currentButtons.Count > 0)
            {
                this.columns = (int)Math.Floor((double)this.Size.Width / getButtonWidth());
                if ((this.columns - 1) > 0)
                {
                    widthOffset = (this.Size.Width - (getButtonWidth() * this.columns)) / (this.columns - 1);
                }
                else
                {
                    widthOffset = 0;
                }
            }
        }

        private void calculateMaxRows()
        {
            if (currentButtons.Count > 0)
            {
                this.maxRows = (int)Math.Floor((double)this.Size.Height / (getButtonHeight() + heightOffset));
            }
        }


        private void setButtonsLocations()
        {
            for (int i = 0; i < this.currentButtons.Count; i++)
            {
                //calcs the row column of the current button
                int row = (int)Math.Floor((double)i / this.columns);
                int column = i % this.columns;
                //calc the actual coordinates for the current button.
                int x = (column * getButtonWidth()) + (column * this.widthOffset);
                int y = row * (getButtonHeight() + this.heightOffset);
                currentButtons[i].Location = new System.Drawing.Point(x, y);

            }
            setVisibleButtons();
        }

        
        private void setVisibleButtons()
        {
            int numVisible = this.columns * this.maxRows;
            for (int i = 0; i < currentButtons.Count; i++)
            {
                if (i < numVisible)
                {
                    currentButtons[i].Visible = true;
                }
                else
                {
                    currentButtons[i].Visible = false;
                }
            }
        }

        /// <summary>
        /// Remove a button from the panel.
        /// </summary>
        /// <param name="b">The button to remove.</param>
        public void RemoveButton(Button b)
        {
            this.currentButtons.Remove(b);
            this.Controls.Remove(b);
            b.Dispose();
            setButtonsLocations();
        }

        /// <summary>
        /// Method to add a button to the panel and readjust positions.
        /// </summary>
        /// <param name="b">The button to add.</param>
        public void addButton(Button b)
        {
            if (columns == -1)
            {
                calculateColumns();
                calculateMaxRows();
            }
            this.currentButtons.Add(b);

            this.Controls.Add(b);
            b.BringToFront();

            //Make sure all the buttons are displayed correctly + the new one.
            setButtonsLocations();
        }

        /// <summary>
        /// Get the width of the buttons.
        /// </summary>
        /// <returns>The width of the buttons.</returns>
        public int getButtonWidth()
        {
            if (currentButtons.Count > 0)
            {
                return this.currentButtons[0].Size.Width;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the height of the buttons.
        /// </summary>
        /// <returns>The height of the buttons.</returns>
        public int getButtonHeight()
        {
            if (currentButtons.Count > 0)
            {
                return this.currentButtons[0].Size.Height;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Returns a list of the current buttons.
        /// </summary>
        /// <returns>A list of the current buttons on the panel.</returns>
        public List<Button> getCurrentButtons()
        {
            return this.currentButtons;
        }


        /// <summary>
        /// Overridden method to readjust poistions of buttons whenever the panel is resized so that buttons don't get hidden or leave huge blank spaces.
        /// </summary>
        /// <param name="eventargs">The event arguements for the resize.</param>
        protected override void OnResize(EventArgs eventargs)
        {
            //Recalculate coumns and rows of buttons on panel & reposition in case they have changed due to larger/smaller panel.
            calculateColumns();
            calculateMaxRows();
            setButtonsLocations();
            //call the base class original resize method.
            base.OnResize(eventargs);
        }

    }
}
