using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;

namespace ImageTagging
{
    /// <summary>
    /// Class stores an image and the tags contained within the image.
    /// </summary>
    public class ImageWithTags
    {
        /// <summary>
        /// The current image.
        /// </summary>
        private Image img;
        /// <summary>
        /// The list of tags for the current image.
        /// </summary>
        private List<string> tags;
        /// <summary>
        /// The filepath of this image.
        /// </summary>
        private string filePath;
        /// <summary>
        /// Whether the file has been changed so we know when leaving the image if the changes need to be written to disk.
        /// Each time something is added this is increased by 1 and when removed the value has 1 subtracted from it.
        /// </summary>
        private int hasChanged = 0;

        /// <summary>
        /// Constructor creates the image and list of keywords from the filename used to construct it.
        /// </summary>
        /// <param name="img">The file path to the image.</param>
        public ImageWithTags(String img)
        {
            //check if property exists and if not then create this empty list if it does then read 
            //the property to create a new list.

            this.filePath = img;
            BitmapCreateOptions createOptions = BitmapCreateOptions.PreservePixelFormat | BitmapCreateOptions.IgnoreColorProfile;
            using (Stream originalFile = File.Open(img, FileMode.Open, FileAccess.Read))
            {
                BitmapDecoder original = BitmapDecoder.Create(originalFile, createOptions, BitmapCacheOption.None);
                if (!original.CodecInfo.FileExtensions.Contains("jpg"))
                {
                    throw new ArgumentException("File is not a JPEG");
                }
                /*
                 * If the image frame exists and it already has stored metadata tags
                 * then read them in. If it doesn't already have any metadata keywords then
                 * crate a blank list where they can be added.
                 */
                if (original.Frames[0] != null)
                {
                    if (original.Frames[0].Metadata != null)
                    {
                        this.tags = listFromMetadata(original.Frames[0].Metadata.Clone() as BitmapMetadata);
                    }
                    else
                    {
                        this.tags = new List<string>();
                    }
                    this.img = bitmapFromSource(original.Frames[0]);
                }
                else
                {
                    throw new ArgumentException("File missing image Frames");
                }
            }
        }

        /// <summary>
        /// Create and return a list of strings from a Metadata object that correspond to the keywords stored within.
        /// </summary>
        /// <param name="meta">The BitmapMetadata we wish to collect keywords from.</param>
        /// <returns>A List of strings containing the keywords.</returns>
        private List<string> listFromMetadata(BitmapMetadata meta)
        {
            if (meta.Keywords != null)
            {
                System.Collections.ObjectModel.ReadOnlyCollection<string> x = meta.Keywords;
                string[] y = new string[x.Count];
                x.CopyTo(y, 0);
                return new List<string>(y);
            }
            else
            {
                return new List<string>();
            }
        }

        /// <summary>
        /// Save any changes made to a new image file with the updated keywords. Adds extra padding to the image if we are adding more keywords.
        /// </summary>
        public void saveChangesToNewFile()
        {
            //if no changes have occured then no need to write a new file.
            if (this.hasChanged != 0)
            {
                //should maybe still check if this file exists.
                string outputPath = Path.Combine(Path.GetDirectoryName(this.filePath), Guid.NewGuid().ToString());
                BitmapCreateOptions createOptions = BitmapCreateOptions.PreservePixelFormat | BitmapCreateOptions.IgnoreColorProfile;
                uint paddingAmount = calcPaddingAmount();

                using (Stream originalFile = File.Open(this.filePath, FileMode.Open, FileAccess.Read))
                {
                    BitmapDecoder original = BitmapDecoder.Create(originalFile, createOptions, BitmapCacheOption.None);
                    
                    //The jpeg that will be saved with the changes.
                    JpegBitmapEncoder output = new JpegBitmapEncoder();
                    if (original.Frames[0] != null)
                    {
                        BitmapMetadata metadata = original.Frames[0].Metadata.Clone() as BitmapMetadata;
                        //If there is an increase in the number of tags then add more padding. The amount calculated previously.
                        if (paddingAmount != 0)
                        {
                            metadata.SetQuery("/app1/ifd/PaddingSchema:Padding", paddingAmount);
                            metadata.SetQuery("/app1/ifd/exif/PaddingSchema:Padding", paddingAmount);
                            metadata.SetQuery("/xmp/PaddingSchema:Padding", paddingAmount);
                        }
                        metadata.Keywords = new System.Collections.ObjectModel.ReadOnlyCollection<string>(this.tags);
                        output.Frames.Add(BitmapFrame.Create(original.Frames[0], original.Frames[0].Thumbnail, metadata, original.Frames[0].ColorContexts));
                    }

                    using (Stream outputFile = File.Open(outputPath, FileMode.Create, FileAccess.ReadWrite))
                    {
                        output.Save(outputFile);
                    }
                }
                File.Delete(this.filePath);
                File.Move(outputPath, this.filePath);
                //reset the value of changes that have occurred since last save.
                this.hasChanged = 0;
            }
        }

        /// <summary>
        /// Create Bitmap image from BitmapSource
        /// </summary>
        /// <param name="bitmapsource"></param>
        /// <returns></returns>
        private Bitmap bitmapFromSource(BitmapSource bitmapsource)
        {
            Bitmap bitmap;
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapsource));
                enc.Save(outStream);
                bitmap = new Bitmap(outStream);
            }
            return bitmap;
        }

        /// <summary>
        /// The amount of padding to add to accomodate the new tags. If the overall changes result in a decrease in the number of tags then
        /// we do not need to add padding else we add 1kb padding for each 10 tags added. May want to update this to use a better method of calculating padding
        /// as tags could be larger or shorter and requie more/less padding.
        /// </summary>
        /// <returns></returns>
        private uint calcPaddingAmount()
        {
            if (this.hasChanged > 0)
            {
                return 1024 * (uint)Math.Ceiling((double)this.hasChanged / 10);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Get the Image.
        /// </summary>
        /// <returns>The image for this imagewithtags.</returns>
        public Image getImg()
        {
            return this.img;
        }

        /// <summary>
        /// Get the list of tags associated with this image.
        /// </summary>
        /// <returns>The list of tags.</returns>
        public List<string> getTags()
        {
            return this.tags;
        }

        /// <summary>
        /// Get the filepath for this image.
        /// </summary>
        /// <returns>The filepath.</returns>
        public string getFilePath()
        {
            return this.filePath;
        }

        /// <summary>
        /// Method to remove a tag from the list of keywords for this image.
        /// </summary>
        /// <param name="s">The tag to remove from the list.</param>
        public void removeTagFromList(string s)
        {
            this.tags.Remove(s);
            this.hasChanged--;
        }

        /// <summary>
        /// Add a tag to the list of keywords.
        /// </summary>
        /// <param name="s">The tag to add.</param>
        public void addTagToList(string s)
        {
            if (!this.tags.Contains(s))
            {
                this.tags.Add(s);
                this.hasChanged++;
            }
        }

    }
}
