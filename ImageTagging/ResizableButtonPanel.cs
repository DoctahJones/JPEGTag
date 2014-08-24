using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageTagging
{
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
