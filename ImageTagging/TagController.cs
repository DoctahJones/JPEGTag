using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;

namespace ImageTagging
{
    /// <summary>
    /// TagController handles displaying data from the data classes to the view and updating the back end when the user does something via the view.
    /// </summary>
    public class TagController
    {
        /// <summary>
        /// The view being used for display purposes.
        /// </summary>
        private ITagView view;
        /// <summary>
        /// The previous image.
        /// </summary>
        private ImageWithTags previousImage;
        /// <summary>
        /// The current image being displayed.
        /// </summary>
        private ImageWithTags currentImage;
        /// <summary>
        /// The next image to be displayed.
        /// </summary>
        private ImageWithTags nextImage;
        /// <summary>
        /// The list of filenames of the images in the current directory we are looking in.
        /// </summary>
        private List<string> filesInFolder;
        /// <summary>
        /// The datastore for tags that have been previously used.
        /// </summary>
        private TagUsageData tagUsageData;
        /// <summary>
        /// Whether a file has been loaded yet so we have a current/next/prev image. This is used
        /// to prevent trying to save/move through images etc before we have loaded anything.
        /// </summary>
        private bool filesLoaded = false;
        /// <summary>
        /// Method used to displaye previous tags used, atm should be either mostUsed or mostRecent.
        /// </summary>
        private string sortMethod;


        /// <summary>
        /// Constructor for tag controller. Loads tag data and attmpts to continue from where the program was when it was last exited.
        /// </summary>
        /// <param name="view">The view to display to the user.</param>
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
            setPrevTagDataSortMethod(Properties.Settings.Default.tagDataSortMethod);
            updatePrevTagsPanel();
            string lastFile = Properties.Settings.Default.lastFile;
            if (lastFile != "")
            {
                openImage(lastFile);
            }
        }


        /// <summary>
        /// Opens a specific image and gets details of the other images in the folder so that they can be moved through if it's required.
        /// </summary>
        /// <param name="filePath">The path to the image to be loaded.</param>
        public void openImage(string filePath)
        {
            //save changes to current file if we have loaded something since start.
            if (filesLoaded)
                saveCurrentImageChanges();
            bool x = openImageFile(filePath, out currentImage);
            if (x)
            {
                displayImageAndTags();
                this.filesInFolder = getFilesInFolder(Path.GetDirectoryName(filePath));
                setNextImage();
                setPreviousImage();
                this.filesLoaded = true;
                this.view.setStatusText("Ready");
            }
            else
            {
                cleanToStartup();
            }
        }

        /// <summary>
        /// Opens a folder and displays the first image within the foler. Also gets details of the other files in the folder so that they can be traversed.
        /// </summary>
        /// <param name="directory">The directory to the folder to load.</param>
        public void openFolder(string directory)
        {
            //save changes to current file if we have loaded something since start.
            if (filesLoaded)
                saveCurrentImageChanges();
            this.filesInFolder = getFilesInFolder(directory);
            //make sure there are images in the folder before trying to load anything.
            if (this.filesInFolder.Count != 0)
                loadFirstDirectory();
            //if some of the files could not be loaded because they werent correct type of image then the count could gain be 0;
            if (this.filesInFolder.Count != 0)
            {
                displayImageAndTags();
                this.filesLoaded = true;
                this.view.setStatusText("Ready");
            }
            else
            {
                cleanToStartup();
                this.view.setStatusText("No Images in Folder!");
            }
        }

        /// <summary>
        /// Method to clean the UI to as if the program had no file/folder open.
        /// </summary>
        public void cleanToStartup()
        {
            this.view.displayImage(null);
            this.filesLoaded = false;
            this.view.populateExistingTags(new List<string>());
        }

        /// <summary>
        /// Adds a tag to the current image.
        /// </summary>
        /// <param name="s">The tag to add to the image.</param>
        public void addTagToImage(string s)
        {
            if (filesLoaded)
            {
                //add the tag to the image and update data store that it has been added.
                this.currentImage.addTagToList(s);
                this.tagUsageData.newTagUsed(s);
                //update the tags of the image and the list of prev tags with the new tag used.
                this.view.populateExistingTags(currentImage.getTags());
                updatePrevTagsPanel();
            }
        }



        /// <summary>
        /// Remove a tag from the current image.
        /// </summary>
        /// <param name="tagToRemove">The tag to be removed form the current image.</param>
        public void removeExistingTagFromImage(string tagToRemove)
        {
            this.currentImage.removeTagFromList(tagToRemove);
            view.populateExistingTags(currentImage.getTags());

        }

        #region MoveBetweenImagesInFolder
        

        private void loadFirstDirectory()
        {
            //whether we have encountered any problems opening any of the files, counts the number to display later.
            int problems = 0;
                //If we have more than 2 files in folder than prev, current and next image should all be unique barring any problems.
                if (filesInFolder.Count > 2)
                {
                    bool success = false;
                    //whilst we still havent successfully loaded a file and theres still more than 2 files in the list.
                    while (!success && (filesInFolder.Count > 2))
                    {
                        success = openImageFile(filesInFolder.ElementAt(filesInFolder.Count - 1), out previousImage);
                        if (!success)
                        {
                            filesInFolder.RemoveAt(filesInFolder.Count - 1);
                            problems++;
                        }
                    }
                    success = false;
                    //whilst we still havent successfully loaded a file and theres still more than 2 files in the list.
                    while (!success && (filesInFolder.Count > 2))
                    {
                        success = openImageFile(filesInFolder.ElementAt(0), out currentImage);
                        if (!success)
                        {
                            filesInFolder.RemoveAt(filesInFolder.Count - 1);
                            problems++;
                        }
                    }
                    success = false;
                    //whilst we still havent successfully loaded a file and theres still more than 2 files in the list.
                    while (!success && (filesInFolder.Count > 2))
                    {
                        success = openImageFile(filesInFolder.ElementAt(1), out nextImage);
                        if (!success)
                        {
                            filesInFolder.RemoveAt(filesInFolder.Count - 1);
                            problems++;
                        }
                    }
                }
                if (filesInFolder.Count == 2)
                {
                    ImageWithTags one;
                    ImageWithTags two;
                    bool x = openImageFile(filesInFolder.ElementAt(0), out one);
                    bool y = openImageFile(filesInFolder.ElementAt(1), out two);
                    if (x && y)
                    {
                        previousImage = two;
                        currentImage = one;
                        nextImage = two;
                    }
                    if (!y)
                    {
                        filesInFolder.RemoveAt(1);
                        problems++;
                    }
                    if (!x)
                    {
                        filesInFolder.RemoveAt(0);
                        problems++;
                    }
                    
                }
                if (filesInFolder.Count == 1)
                {
                    bool x = openImageFile(filesInFolder.ElementAt(0), out currentImage);
                    if (!x)
                    {
                        filesInFolder.RemoveAt(0);
                        problems++;
                    }
                }
                if (filesInFolder.Count == 0)
                {
                    cleanToStartup();
                    this.view.setStatusText("No Images in Folder!");
                }
                else if (problems > 0)
                {
                    this.view.setStatusText(problems + " images could not be loaded.");
                }
        }


        private bool openImageFile(string file, out ImageWithTags i)
        {
            bool good = true;
            try
            {
                i = new ImageWithTags(file);
            }
            catch (ArgumentException)
            {
                good = false;
                i = null;
            }
            catch (IOException)
            {
                good = false;
                i = null;
            }
            catch (NotSupportedException)
            {
                good = false;
                i = null;
            }
            return good;
        }

        ///// <summary>
        ///// Method to load the next image into the current image as well as handling opening the first image in the directory by setting the argument to true.
        ///// </summary>
        ///// <param name="firstInDirectory">Whether we want to load the first
        ///// image in the directory rather than using the current image to determine what is next.</param>
        //private void loadNextImage(bool firstInDirectory)
        //{
        //    if (filesInFolder != null)
        //    {
        //        if (firstInDirectory)
        //        {
        //            if (filesInFolder.Count == 2)
        //            {
        //                previousImage = new ImageWithTags(filesInFolder.ElementAt(1));
        //                currentImage = new ImageWithTags(filesInFolder.ElementAt(0));
        //                nextImage = new ImageWithTags(filesInFolder.ElementAt(1));
        //            }
        //            else if (filesInFolder.Count == 1)
        //            {
        //                previousImage = new ImageWithTags(filesInFolder.ElementAt(0));
        //                currentImage = new ImageWithTags(filesInFolder.ElementAt(0));
        //                nextImage = new ImageWithTags(filesInFolder.ElementAt(0));
        //            }
        //            else
        //            {
        //                previousImage = new ImageWithTags(filesInFolder.ElementAt(filesInFolder.Count - 1));
        //                currentImage = new ImageWithTags(filesInFolder.ElementAt(0));
        //                nextImage = new ImageWithTags(filesInFolder.ElementAt(1));
        //            }
        //        }
        //        else
        //        {
        //            this.previousImage = currentImage;
        //            this.currentImage = nextImage;
        //            setNextImage();
        //        }
        //    }
        //}

        /// <summary>
        /// Method to load the next image into the current image.
        /// </summary>
        private void loadNextImage()
        {
            if (filesInFolder != null && filesInFolder.Count > 1)
            {
                this.previousImage = currentImage;
                this.currentImage = nextImage;
                setNextImage();
            }
        }

        /// <summary>
        /// Method to load the previous image to the current image and set the new next and previous images.
        /// </summary>
        private void loadPreviousImage()
        {
            if (filesInFolder != null && filesInFolder.Count > 1)
            {
                this.nextImage = currentImage;
                this.currentImage = previousImage;
                setPreviousImage();
            }
        }

        /// <summary>
        /// Method to switch the currently displayed image to the next one in the folder.
        /// </summary>
        public void displayNextImage()
        {
            if (this.filesLoaded)
            {
                //set the status first so if any error occurs it overwrites it.
                this.view.setStatusText("Ready");
                saveCurrentImageChanges();
                loadNextImage();
                displayImageAndTags();
            }
        }

        /// <summary>
        /// Method to switch the currently displayed image to the previous one in the folder.
        /// </summary>
        public void displayPreviousImage()
        {
            if (this.filesLoaded)
            {
                this.view.setStatusText("Ready");
                saveCurrentImageChanges();
                loadPreviousImage();
                displayImageAndTags();
            }
        }

        /// <summary>
        /// Method to set the next image to be displayed. 
        /// </summary>
        private void setNextImage()
        {
            //get index of current image.
            int pos = -1;
            pos = filesInFolder.IndexOf(this.currentImage.getFilePath());
            if (pos != -1)
            {
                if (pos != filesInFolder.Count - 1)
                {
                    bool success = false;
                    //whilst we still havent successfully loaded a file and theres still more than 2 files in the list and we havent got to the current image
                    //being the last element in the list by removing others.
                    //removed && (filesInFolder.Count > 1), shouldn't matter.
                    while (!success && pos != filesInFolder.Count - 1)
                    {
                        //try and open the next file in the list and if it fails remove it from the list.
                        success = openImageFile(filesInFolder.ElementAt(pos + 1), out nextImage);
                        if (!success)
                        {
                            filesInFolder.RemoveAt(pos + 1);
                        }
                    }
                }
                //if the current image is the last one in the list then we want to try loading the first one in the list as the next image.
                if(pos == filesInFolder.Count - 1)
                {
                    bool success = false;
                    //whilst we still havent successfully loaded a file and theres still more than 2 files in the list.
                    //removed && (filesInFolder.Count > 1), shouldn't matter.
                    while (!success)
                    {
                        success = openImageFile(filesInFolder.ElementAt(0), out nextImage);
                        if (!success)
                        {
                            filesInFolder.RemoveAt(0);
                            //because we have removed the first element the list is now shorter by 1 so decrement pos.
                            pos--;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Method to set the previous image to be displayed.
        /// </summary>
        private void setPreviousImage()
        {
            int pos = -1;
            pos = filesInFolder.IndexOf(this.currentImage.getFilePath());
            if (pos != -1)
            {
                //if the current image is not the first one in the list then we want to get the previous one in the list.
                if (pos != 0)
                {
                    bool success = false;
                    //whilst we still havent successfully loaded a file and we haven't move the current image to the first in the list by 
                    //removing previous images.
                    while (!success && pos != 0)
                    {
                        //try and open the next file in the list and if it fails remove it from the list.
                        success = openImageFile(filesInFolder.ElementAt(pos - 1), out previousImage);
                        if (!success)
                        {
                            filesInFolder.RemoveAt(pos - 1);
                            //because we removed something ealrier in the list the current image is now 1 index earlier.
                            pos--;
                        }
                    }
                }
                //if the current image is the first item in the list we want to set the previous image to the last item in the list.
                if (pos == 0)
                {
                    bool success = false;
                    //whilst we still havent successfully loaded a file.
                    while (!success)
                    {
                        //try and load the last item in the list into previousImage.
                        success = openImageFile(filesInFolder.ElementAt(filesInFolder.Count - 1), out previousImage);
                        if (!success)
                        {
                            filesInFolder.RemoveAt(filesInFolder.Count - 1);
                        }
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// Save changes that have occurred to current image, the programs settings and tag usage.
        /// </summary>
        public void saveChangesOnClose()
        {
            if (filesLoaded)
                saveCurrentImageChanges();
            saveTagDataToFile();
            //if we haven't loaded a file don't need to write it and we won't have a currentImage.
            if (this.filesLoaded)
                Properties.Settings.Default.lastFile = currentImage.getFilePath();
            Properties.Settings.Default.tagDataSortMethod = this.sortMethod;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Save the changes to the current file and display error to the view as to why.
        /// </summary>
        private void saveCurrentImageChanges()
        {
            try
            {
                this.currentImage.saveChangesToNewFile();
            }
            catch (IOException)
            {
                this.view.setStatusText("An I/O error occurred saving changes to file");
            }
            catch (NotSupportedException)
            {
                this.view.setStatusText("A not supported error occurred saving changes to file");
            }
            
        }

        

        #region PreviousTagDataOperations
        /// <summary>
        /// Writes the TagUsageData which stores data about tags used previously to a file in 
        /// the programs directory\Data\tagdata.json.
        /// </summary>
        public void saveTagDataToFile()
        {
            if (this.tagUsageData.getChangesMade())
            {
                //TODO anime and stuff check file write is successful
                try
                {
                    string file = getProgDir() + "\\Data\\";
                    Directory.CreateDirectory(file);
                    using (FileStream fs = new FileStream(file + "tagdata.json", FileMode.OpenOrCreate))
                    {
                        this.tagUsageData.writeToFileStream(fs);
                    }
                }
                catch (IOException)
                {
                    this.view.setStatusText("An I/O error occurred saving changes to previous tag data");
                }
            }
        }

        /// <summary>
        /// Method to load the TagUsageData with data about previously used tags from the file prog directory\Data\tagdata.json.
        /// If the file isn't found it should create a blank file to save to later.
        /// </summary>
        public void readTagDataFromFile()
        {
            string fileDir = getProgDir() + "\\Data\\";
            Directory.CreateDirectory(fileDir);
            using (MemoryStream stream = new MemoryStream())
            {
                if (File.Exists(fileDir + "tagdata.json"))
                {
                    using (FileStream file = new FileStream(fileDir + "tagdata.json", FileMode.Open, FileAccess.Read))
                    {
                        file.CopyTo(stream);
                        try
                        {
                            this.tagUsageData.readDataFromMemoryStream(stream);
                        }
                        catch (IOException)
                        {
                            this.view.setStatusText("Unable to Read Previous Tag Data");
                            //Rename the file that can't be read so we can overwrite with a new one later.
                            File.Move(fileDir + "tagdata.json", fileDir + "tagdata.error");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Method to clear the data about previously used tags so that the list should be empty.
        /// </summary>
        public void clearTagdata()
        {
            if (view.confirmDialog("Are you sure you would like to clear all previous tag data?", "Delete Tag Data"))
            {
                this.tagUsageData.clearLists();
                updatePrevTagsPanel();
            }
        }

        /// <summary>
        /// Sets the method used to display the previously used tag data.
        /// </summary>
        /// <param name="method">The method to use for sorting tag data, either "mostUsed" or "mostRecent".</param>
        public void setPrevTagDataSortMethod(string method)
        {
            if (method == "mostUsed")
            {
                this.sortMethod = "mostUsed";
                updatePrevTagsPanel();
            }
            else
            {
                this.sortMethod = "mostRecent";
                updatePrevTagsPanel();
            }
        }

        /// <summary>
        /// Method to update the interface with the prev tags used and the method of doing so.
        /// </summary>
        public void updatePrevTagsPanel()
        {
            if (this.sortMethod == "mostUsed")
            {
                //Create a list of DictionaryEntries so that we can sort the most used tag data by the tags which have been used the most.
                List<DictionaryEntry> x = this.tagUsageData.getMostUsed().Cast<DictionaryEntry>().OrderByDescending(entry => entry.Value).ToList();
                //Get the list of keys in the sorted order and populate the UI with this info.
                this.view.populatePrevTagsPanel(x.Select(s => s.Key).Cast<string>().ToList());
                //this.view.populatePrevTagsPanel(this.tagUsageData.getMostUsed().Keys.Cast<string>().ToList());
                this.view.setSortMethodLabel("Most Used:");
            }
            else
            {
                this.view.populatePrevTagsPanel(this.tagUsageData.getMostRecent().Cast<string>().ToList());
                this.view.setSortMethodLabel("Most Recent:");
            }
        }
        #endregion

        /// <summary>
        /// Display the image of the current image to the UI and also display the tags associated with the current image.
        /// </summary>
        private void displayImageAndTags()
        {
            view.displayImage(currentImage.getImg());
            view.populateExistingTags(currentImage.getTags());
        }

        /// <summary>
        /// Get the list of filenames of jpeg files in a directory.
        /// </summary>
        /// <param name="folderPath">The directory to search.</param>
        /// <returns></returns>
        private List<string> getFilesInFolder(string folderPath)
        {
            IEnumerable<string> files = Directory.GetFiles(folderPath, "*.*").Where(s => s.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
                || s.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase));
            return files.ToList();
        }

        /// <summary>
        /// Get the directory the program is currently running from.
        /// </summary>
        /// <returns>The directory the program is running in.</returns>
        private string getProgDir()
        {
            return System.IO.Path.GetDirectoryName(new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath);
        }

    }
}