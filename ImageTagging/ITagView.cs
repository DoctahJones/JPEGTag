using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ImageTagging
{
    public interface ITagView
    {

        void setController(TagController controller);
        void displayImage(Image img);
        void populateExistingTags(List<string> tags);
        void populatePrevTagsPanel(List<string> tags);

    }
}
