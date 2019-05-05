using SimpleVideoClubHire;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GradedUnitWPF
{
    /// <summary>
    /// Datafile class creating a datafile storing stock and member details
    /// </summary>
	[Serializable]
    class Datafile
    {
		private BinaryFormatter formatter;
		private const string DATA_FILENAME = "database.dat";
		private const string FILE_NAME = "dummyprinter.txt";

		private Library thelib; 
        /// <summary>
        /// Default constructor creating an instance of the library and formatter.
        /// </summary>
		public Datafile()
		{
			thelib = Library.Instance;
			this.formatter = new BinaryFormatter();
		}
        /// <summary>
        /// save method storing stock and member data in a datafile
        /// </summary>
		public void save()
		{
			// Gain code access to the file that we are going
			// to write to
			try
			{
				// Create a FileStream that will write data to file.
				FileStream writerFileStream = new FileStream(DATA_FILENAME, FileMode.Create, FileAccess.Write);
				// Save to file
				this.formatter.Serialize(writerFileStream, thelib.stock);
                this.formatter.Serialize(writerFileStream, thelib.members);
                //Close the writerFileStream when we are done.
                writerFileStream.Close();
			}
			catch (Exception e)
			{
				throw new Exception("Unable to save our members' information\n" + e);
			} // end try-catch
		}
        /// <summary>
        /// Load method loading the previously saved stock and member information.
        /// </summary>
		public void load()
		{
			// Check if we had previously Save information of our friends
			// previously
			if (File.Exists(DATA_FILENAME))
			{
				try
				{
					// Create a FileStream will gain read access to the 
					// data file.
					FileStream readerFileStream = new FileStream(DATA_FILENAME, FileMode.Open, FileAccess.Read);
					// Reconstruct information of our friends from file.
					thelib.stock = (List<Stock>)
						this.formatter.Deserialize(readerFileStream);
                    thelib.members = (List<Member>)
                    this.formatter.Deserialize(readerFileStream);
                    // Close the readerFileStream when we are done
                    readerFileStream.Close();
				}
				catch (Exception)
				{
					throw new Exception();
				} // end try-catch
			} // end if
		}
	}//end of class
}
