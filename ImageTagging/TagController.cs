using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ImageTagging
{
    public class TagController
    {
        private ITagView view;
        private ImageWithTags previousImage;
        private ImageWithTags currentImage;
        private ImageWithTags nextImage;
        private List<string> filesInFolder;
        private TagUsageData tagUsageData;
        /// <summary>
        /// Whether a file has been loaded yet so we have a current/next/prev image. This is used
        /// to prevent trying to save/move through images etc before we have loaded anything.
        /// </summary>
        private bool filesLoaded = false;



        public TagController(ITagView view)
        {
            this.view = view;
            this.view.setController(this);
            this.filesInFolder = new List<string>();
            this.tagUsageData = new TagUsageData();
            this.initialise();
        }

        private void initialise()
        {
            readTagDataFromFile();
            //TODO read? which tagusagedata member we are using, most recent or most used and load that into the buttons on view.
        }



        public void openImage(string filePath)
        {
            if (filesLoaded)
                this.currentImage.saveChangesToNewFile();
            currentImage = new ImageWithTags(filePath);
            displayImageAndTags();
            this.filesInFolder = getFilesInFolder(Path.GetDirectoryName(filePath));
            setNextImage();
            setPreviousImage();
            this.filesLoaded = true;
        }


        public void openFolder(string directory)
        {
            if (filesLoaded)
                this.currentImage.saveChangesToNewFile();
            this.filesInFolder = getFilesInFolder(directory);
            loadNextImage(true);
            displayImageAndTags();
            this.filesLoaded = true;
        }

        public void removeExistingTagFromImage(string tagToRemove)
        {
            this.currentImage.removeTagFromList(tagToRemove);
            view.populateExistingTags(currentImage.getTags());

        }

        public void addTagToImage(string s)
        {
            this.currentImage.addTagToList(s);
            view.populateExistingTags(currentImage.getTags());
            this.tagUsageData.newTagUsed(s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstInDirectory">Whether we want to load the first
        /// image in the directory rather than using the current image to determine what is next.</param>
        private void loadNextImage(bool firstInDirectory)
        {
            if (filesInFolder != null && filesInFolder.Count > 1)
            {
                if (firstInDirectory)
                {
                    if (filesInFolder.Count > 2)
                    {
                        previousImage = new ImageWithTags(filesInFolder.ElementAt(filesInFolder.Count - 1));
                        currentImage = new ImageWithTags(filesInFolder.ElementAt(0));
                        nextImage = new ImageWithTags(filesInFolder.ElementAt(1));
                    }
                    else
                    {
                        previousImage = new ImageWithTags(filesInFolder.ElementAt(1));
                        currentImage = new ImageWithTags(filesInFolder.ElementAt(0));
                        nextImage = new ImageWithTags(filesInFolder.ElementAt(1));
                    }
                }
                else
                {
                    this.previousImage = currentImage;
                    this.currentImage = nextImage;
                    setNextImage();
                }
            }
        }

        private void loadPreviousImage()
        {
            if (filesInFolder != null && filesInFolder.Count > 1)
            {
                this.nextImage = currentImage;
                this.currentImage = previousImage;
                setPreviousImage();
            }
        }

        public void displayNextImage()
        {
            //if (!this.currentImage.saveChangesToNewFile())
            //{
            //    //todo display error to user about how changes could not be saved.
            //}
            this.currentImage.saveChangesToNewFile();
            loadNextImage(false);
            displayImageAndTags();
            //TODO: need to save changes to old file.
        }

        public void displayPreviousImage()
        {
            //if (!this.currentImage.saveChangesToNewFile())
            //{
            //    //todo display error to user about how changes could not be saved.
            //    //call a method like displayStatusError("message") which puts that message
            //    //into the status bar so th euser can see.
            //}
            this.currentImage.saveChangesToNewFile();
            loadPreviousImage();
            displayImageAndTags();
        }

        private void setNextImage()
        {
            int pos = -1;
            pos = filesInFolder.IndexOf(this.currentImage.getFilePath());
            if (pos != -1)
            {
                if (pos != filesInFolder.Count - 1)
                {
                    this.nextImage = new ImageWithTags(filesInFolder.ElementAt(++pos));
                }
                else
                {
                    this.nextImage = new ImageWithTags(filesInFolder.ElementAt(0));
                }
            }
        }

        private void setPreviousImage()
        {
            int pos = -1;
            pos = filesInFolder.IndexOf(this.currentImage.getFilePath());
            if (pos != -1)
            {
                if (pos != 0)
                {
                    this.previousImage = new ImageWithTags(filesInFolder.ElementAt(--pos));
                }
                else
                {
                    this.previousImage = new ImageWithTags(filesInFolder.ElementAt(filesInFolder.Count - 1));
                }
            }
        }

        public void saveChangesOnClose()
        {
            this.currentImage.saveChangesToNewFile();
            this.saveTagDataToFile();
        }


        public void saveTagDataToFile()
        {
            if (this.tagUsageData.getChangesMade())
            {
                //TODO anime and stuff check file write is successful and tagdata exists need to read fromf ile or create at program launch.
                string file = getProgDir() + "\\Data\\";
                Directory.CreateDirectory(file);
                FileStream fs = new FileStream(file + "tagdata.json", FileMode.OpenOrCreate);
                this.tagUsageData.writeToFileStream(fs);
            }
        }

        public void readTagDataFromFile()
        {
            //todo sort this mess out, if we get an error we want to inform user and create a blank tagdata, if no file founf we want blank data
            string fileDir = getProgDir() + "\\Data\\";
            Directory.CreateDirectory(fileDir);
            MemoryStream stream1 = new MemoryStream();
            if (File.Exists(fileDir + "tagdata.json"))
            {
                using (FileStream file = new FileStream(fileDir + "tagdata.json", FileMode.Open, FileAccess.Read))
                {
                    file.CopyTo(stream1);
                    this.tagUsageData.readDataFromMemoryStream(stream1);
                }
            }
        }


        private void displayImageAndTags()
        {
            view.displayImage(currentImage.getImg());
            view.populateExistingTags(currentImage.getTags());
        }

        private List<string> getFilesInFolder(string folderPath)
        {
            IEnumerable<string> files = Directory.GetFiles(folderPath, "*.*").Where(s => s.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
                || s.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase));
            return files.ToList();
        }

        private string getProgDir()
        {
            return System.IO.Path.GetDirectoryName(new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath);
        }

    }
}
