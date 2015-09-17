using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace ImageTagging
{
    /// <summary>
    /// Class to store data about tags being used.
    /// </summary>
    [DataContract]
    public class TagUsageData
    {
        [DataMember]
        private Hashtable mostUsed;
        [DataMember]
        private Queue mostRecent;
        /// <summary>
        /// Whether any changes have been made so we can save writing file if nothing has changed.
        /// </summary>
        private bool changesMade = false;

        /// <summary>
        /// Default Constructor initialises both data members as empty lists.
        /// </summary>
        public TagUsageData()
        {
            mostUsed = new Hashtable();
            mostRecent = new Queue();
        }

        /// <summary>
        /// Method to read a TageUsageData object from a JSON memorystream and set the data structures of this object to those from the stream.
        /// </summary>
        /// <param name="stream">The MemoryStream containing the JSON serialization of an object.</param>
        public void readDataFromMemoryStream(MemoryStream stream)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(TagUsageData));
            //set position to start of stream in case it isn't already.
            stream.Position = 0;
            TagUsageData streamData = (TagUsageData)ser.ReadObject(stream);
            this.mostUsed = streamData.getMostUsed();
            this.mostRecent = streamData.getMostRecent();
        }

        /// <summary>
        /// Method to update the tag usage data when a tag has been used so we have records of how many times and how recently it was used.
        /// </summary>
        /// <param name="tag">The Tag Added to an Image.</param>
        public void newTagUsed(string tag)
        {
            if (this.mostUsed.Contains(tag))
            {
                int s = (int)this.mostUsed[tag];
                this.mostUsed[tag] = ++s;
            }
            else
            {
                this.mostUsed.Add(tag, 1);
            }
            if (this.mostRecent.Count >= 50)
            {
                this.mostRecent.Dequeue();
            }
            this.mostRecent.Enqueue(tag);
            this.changesMade = true;
        }
        /// <summary>
        /// Method to write the data contract of this object to a MemoryStream in JSON format.
        /// </summary>
        /// <returns>MemoryStream containing the object in JSON format.</returns>
        public MemoryStream toJSON()
        {
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(TagUsageData));
            ser.WriteObject(stream, this);
            return stream;
        }

        /// <summary>
        /// Writes the JSON output of this class to the filestream passed in.
        /// </summary>
        /// <param name="fileStream">The filestream to write to.</param>
        public void writeToFileStream(FileStream fileStream)
        {
            this.toJSON().WriteTo(fileStream);
        }

        /// <summary>
        /// Clears both mostUsed and mostRecent lists to empty lists.
        /// </summary>
        public void clearLists()
        {
            this.mostRecent.Clear();
            this.mostUsed.Clear();
            this.changesMade = true;
        }

        /// <summary>
        /// Get the Hashtable of most used tags.
        /// </summary>
        /// <returns>The Hashtable.</returns>
        public Hashtable getMostUsed()
        {
            return this.mostUsed;
        }

        /// <summary>
        /// Get the most recent tags used Queue.
        /// </summary>
        /// <returns>The most recent tag Queue.</returns>
        public Queue getMostRecent()
        {
            return this.mostRecent;
        }

        /// <summary>
        /// Check if any changes have been made.
        /// </summary>
        /// <returns>Whether any changes have been made.</returns>
        public bool getChangesMade()
        {
            return this.changesMade;
        }

    }
}
