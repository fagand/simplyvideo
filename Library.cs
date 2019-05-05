using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace SimpleVideoClubHire
{
    [Serializable]
    /// <summary>
    /// Library class that does most functions of the program
    /// Creates and instance of the library so that the information is the same each time the program is run
    /// Uses DateTime library https://msdn.microsoft.com/en-us/library/system.datetime(v=vs.110).aspx 
    /// Last edited 19th May 2018 by David Fagan
    /// </summary>
    public class Library
    {
        /// <summary>
        /// Singleton object
        /// </summary>
        private static Library library;
        /// <summary>
        /// Instance property returns the singleton instance
        /// </summary>
        public static Library Instance
        {
            get
            {
                if (library == null)
                    library = new Library();
                return library;
            }
        }
        /// <summary>
        /// Instance variable storing stock in a list
        /// </summary>
        public List<Stock> stock = new List<Stock>();
        /// <summary>
        /// Instance variable storing members in a list
        /// </summary>
        public List<Member> members;
        /// <summary>
        /// Default constructor creating a new list of members
        /// </summary>
        private BinaryFormatter formatter;
        private const string DATA_FILENAME = "database.dat";
        private const string FILE_NAME = "dummyprinter.txt";
        private string[] searchBarSelect = new string[] { "Member LastName", /*"Films", "Games",*/ "All Stock", "Member ID", "Member ForeName"};
        /// <summary>
        /// Default constructor creating a list of members and the formatter.
        /// </summary>
        public Library()
        {
            members = new List<Member>();
            this.formatter = new BinaryFormatter();
        }
        /// <summary>
        /// Method that adds members to the list
        /// Sets ID to one more than the count of the list
        /// </summary>
        /// <param name="_firstname">Member firstname</param>
        /// <param name="_lastname">Member lastname</param>
        /// <param name="_phoneNo">Member phone no</param>
        /// <param name="_street">Member street</param>
        /// <param name="_town">Memeber town</param>
        /// <param name="_postcode">Member postcode</param>
        public void addMember(string _firstname, string _lastname, string _phoneNo, string _street, string _town, string _postcode)
        {
            int memberID = members.Count + 1;
            members.Add(new Member(_firstname, _lastname, _phoneNo, _street, _town, _postcode, memberID));
        }
        /// <summary>
        /// Method that gets members from the list and prints them
        /// </summary>
        /// <returns>Members in the list</returns>
        public string getMembers()
        {
            sortMembersByID();
            string strout = "";
            foreach (Member m in members)
            {
                strout = strout + m.ToString() + "\n";
            }
            return strout;
        }
        /// <summary>
        /// Public property storing the list of members
        /// </summary>
        public List<Member> MembersProp
        {
            get { return members; }
			set { value = members; }
        }
        /// <summary>
        /// Public property storing the list of stock
        /// </summary>
        public List<Stock> StockProp
        {
            get { return stock; }
			set { value = stock; }
        }
        /// <summary>
        /// Method for adding a new film to the stock list
        /// </summary>
        /// <param name="StockID">Stock ID</param>
        /// <param name="title">Film Title</param>
        /// <param name="category">Film Category</param>
        /// <param name="dvdQ">Film DVD Quantity</param>
        /// <param name="vhsQ">Film VHS Quantity</param>
        /// <param name="certif">Film Certificate (e.g. PG)</param>
        /// <param name="costBracket">Film Cost Bracket</param>
        /// <param name="distributor">Film Distributor (e.g. Warner Brothers)</param>
        /// <param name="DOR">Film Date of Release</param>
        /// <param name="description">Film Description</param>
        public void addFilm(string title, string category, int dvdQ, int vhsQ,  string certif, int costBracket, 
            string distributor, string DOR, string description)
        {
            int StockID = stock.Count + 1;
            stock.Add(new Film(StockID, title, category, dvdQ, vhsQ, certif, costBracket, distributor, DOR, description));
        }
        /// <summary>
        /// Method for adding a game to the stock list
        /// </summary>
        /// <param name="stockID">Stock ID</param>
        /// <param name="title">Game Title</param>
        /// <param name="gameQ">Game Stock Quantity</param>
        /// <param name="platform">Game Platform</param>
        /// <param name="certif">Game Certificate</param>
        /// <param name="costBracket">Game Cost Bracket</param>
        /// <param name="distributor">Game Distributor</param>
        /// <param name="DOR">Game Date of Release</param>
        /// <param name="description">Game Description</param>
        public void addGame(string title, int gameQ, string platform, string certif, int costBracket,
            string distributor, string DOR, string description)
        {
            int stockID = stock.Count + 1;
            int gameID = 0;
            stock.Add(new Game(stockID, title,platform, gameQ, certif, costBracket, distributor, DOR, description));
            gameID = stock.Count + 1;
        }
        /// <summary>
        /// Method that returns films from the list
        /// </summary>
        /// <returns>Films in the list</returns>
        public string getFilms()
        {
            string strout = "";
            foreach (Stock s in stock)
            {
                if (s.GetType() == typeof(Film))
                {
                    strout = strout + s.ToString() + "\r\n";
                }
            }
            return strout;
        }
        /// <summary>
        /// List storing films only from the stock list
        /// </summary>
        /// <returns>Films in stock</returns>
        public List<Film> getListFilms()
        {
            List<Film> films = new List<Film>();
            foreach (Stock s in stock)
            {
                if (s.GetType() == typeof(Film))
                {
                    films.Add((Film)s);
                }
            }
            return films;
        }
        /// <summary>
        /// Property storing films from the stock list
        /// </summary>
        public List<Film> GetFilmsProp
        {
            get { return getListFilms(); }
            set { value = getListFilms(); }
        }
        /// <summary>
        /// Method that returns games from the list
        /// </summary>
        /// <returns>Games in the list</returns>
        public string getGames()
        {
            string strout = "";
            foreach (Stock s in stock)
            {
                if (s.GetType() == typeof(Game))
                {
                    strout = strout + s.ToString() + "\r\n";
                }
            }
            return strout;
        }
        /// <summary>
        /// Method that returns all stock in the list
        /// </summary>
        /// <returns>Stock in the list</returns>
        public string getStock()
        {
            string strout = "";
            foreach (Stock s in stock)
            {
                strout = strout + s.ToString() + "\r\n";
            }
            return strout;
        }
        /// <summary>
        /// Method that sorts members by their last name
        /// </summary>
        /// <returns>Members sorted by their first name</returns>
        public string sortMembersByName() // uses the method in Person to compare the values
        {
            Comparison<Member> compareLastName = new Comparison<Member>(Member.CompareCustomerLastName);
            members.Sort(compareLastName);
            string strout = "";
            foreach (Member m in members)
            {
                strout = strout + m.LastName + ", " + m.FirstName + "\n";
            }
            return strout;
        }
        /// <summary>
        /// Method that sorts members by their first name and returns in string format.
        /// </summary>
        /// <returns>Members sorted by their first name</returns>
        public string sortMembersByNameFirst() // uses the method in Person to compare the values
        {
            Comparison<Member> compareFirstName = new Comparison<Member>(Member.CompareCustomerFirstName);
            members.Sort(compareFirstName);
            string strout = "";
            foreach (Member m in members)
            {
                strout = strout + m.FirstName + " " + m.LastName + "\n";
            }
            return strout;
        }
        /// <summary>
        /// Members that sorts members by their customer ID
        /// </summary>
        /// <returns>Members sorted by their customer ID</returns>
        public string sortMembersByID()
        {
            Comparison<Member> compareID = new Comparison<Member>(Member.CompareCustomerID);
            members.Sort(compareID);
            string strout = "";
            foreach (Member m in members)
            {
                strout = strout + m.ToString() + "\n";
            }
            return strout;
        }
        /// <summary>
        /// Method sorting stock by their title using a delegate
        /// </summary>
        /// <returns>Stock sorted by their title in string format</returns>
        public string sortStock() // uses the method in Person to compare the values
        {
            Comparison<Stock> comparetitle = new Comparison<Stock>(Stock.CompareStock);
            stock.Sort(comparetitle);
            string strout = "";
            foreach (Stock s in stock)
            {
                strout = strout + s.ToString() + "\n";
            }
            return strout;
        }
        /// <summary>
        /// Method sorting stock by their ID
        /// </summary>
        /// <returns>Stock sorted by ID</returns>
        public string sortStockByID()
        {
            Comparison<Stock> compareID = new Comparison<Stock>(Stock.CompareStockID);
            stock.Sort(compareID);
            string strout = "";
            foreach (Stock s in stock)
            {
                strout = strout + s.ToString() + "\n";
            }
            return strout;
        }
        /// <summary>
        /// A class used by the bellow method for sorting members by their last name
        /// </summary>
        public class CustomerNameSort : IComparer<Member>
        {
            public int Compare(Member c1, Member c2)
            {
                return c1.LastName.CompareTo(c2.LastName);
            }
        }
        /// <summary>
        /// Another method by returning members by their last name using the above class as a delegate
        /// </summary>
        /// <returns>Members sorted by their last name</returns>
        public string sortMembersByName2() // uses the above class CustomerNameSort
        {
            Console.WriteLine("\nSort Based on Name");
            CustomerNameSort esort = new CustomerNameSort();
            members.Sort(esort);
            string strout = "";
            foreach (Member cus in members)
            {
                strout = strout + cus.ToString() + "\n";
            }
            return strout;
        }
        /// <summary>
        /// Searches the members list for a member with id of value 'v'
        /// </summary>
        /// <param name="v">Member ID</param>
        /// <returns>Member matching ID of value 'v'</returns>
        public string SearchMembersByID(int v)
        {
            try
            {
                string strout = "";
                Member memberSearch = members.Find(delegate (Member _member)
                {
                    if (_member.memberIDProp == v)
                    {
                        return true;
                        //strout = (memberSearch.ToString());
                    }
                    return false;
                }); strout = (memberSearch.ToString());
                return strout;
            }
            catch (Exception e)
            {
                throw new Exception (" not found" + e);
            }
        }
        /// <summary>
        /// Method searching stock by their ID using a delegate
        /// </summary>
        /// <param name="v">Member ID to search for</param>
        /// <returns>Search results in string format</returns>
		public string SearchStockByID(int v)
		{
			try
			{
				string strout = "";
				Stock stockSearch = stock.Find(delegate (Stock _stock)
				{
					if (_stock.StockIDProp == v)
					{
						return true;
						//strout = (memberSearch.ToString());
					}
					return false;
				}); strout = (stockSearch.StockCost.ToString());
				return strout;
			}
			catch (Exception e)
			{
				throw new Exception(" not found" + e);
			}
		}
        /// <summary>
        /// Method searching stock by their title
        /// </summary>
        /// <param name="v">Title to search for</param>
        /// <returns>Search results of title search</returns>
		public string SearchStockReturnTitle(int v)
		{
			try
			{
				string strout = "";
				Stock stockSearch = stock.Find(delegate (Stock _stock)
				{
					if (_stock.StockIDProp == v)
					{
						return true;
						//strout = (memberSearch.ToString());
					}
					return false;
				}); strout = (stockSearch.Title.ToString());
				return strout;
			}
			catch (Exception e)
			{
				throw new Exception(" not found" + e);
			}
		}
		/// <summary>
		/// Method for getting the certificate of a certain stock item
		/// Used in the edit stock window to edit stock item certificate 
		/// </summary>
		/// <param name="v">stock ID</param>
		/// <returns>Film certificate for selected film "v"</returns>
		public string SearchStockReturnCertificate(int v)
		{
			try
			{
				string strout = "";
				Stock stockSearch = stock.Find(delegate (Stock _stock)
				{
					if (_stock.StockIDProp == v)
					{
						return true;
						//strout = (memberSearch.ToString());
					}
					return false;
				}); strout = (stockSearch.CertificateProp.ToString());
				return strout;
			}
			catch (Exception e)
			{
				throw new Exception("Film with ID " + v + " not found" + e);
			}
		}
		/// <summary>
		/// Method for searching stock to return description 
		/// for searched value
		/// Throws an exception if the member can't be found
		/// </summary>
		/// <param name="v">Stock ID value</param>
		/// <returns>Film description for selected film "v"</returns>
		public string SearchStockReturnDescription(int v)
		{
			try
			{
				string strout = "";
				Stock stockSearch = stock.Find(delegate (Stock _stock)
				{
					if (_stock.StockIDProp == v)
					{
						return true;
						//strout = (memberSearch.ToString());
					}
					return false;
				}); strout = (stockSearch.DescriptionProp.ToString());
				return strout;
			}
			catch (Exception e)
			{
				throw new Exception(" not found" + e);
			}
		}
        /// <summary>
		/// Method for searching stock to return DVD Quantity 
		/// for searched value
		/// Throws an exception if the member can't be found
		/// </summary>
		/// <param name="v">Stock ID value</param>
		/// <returns>Film description for selected film "v"</returns>
		public string SearchStockReturnDVDQuantity(int v)
        {
            try
            {
                string strout = "";
                Stock stockSearch = stock.Find(delegate (Stock _stock)
                {
                    if (_stock.StockIDProp == v)
                    {
                        return true;
                        //strout = (memberSearch.ToString());
                    }
                    return false;
                }); strout = (stockSearch.DVDprop.ToString());
                return strout;
            }
            catch (Exception e)
            {
                throw new Exception(" not found" + e);
            }
        }
        /// <summary>
        /// Method for searching stock to return VHS Quantity 
        /// for searched value
        /// Throws an exception if the member can't be found
        /// </summary>
        /// <param name="v">Stock ID value</param>
        /// <returns>Film description for selected film "v"</returns>
        public string SearchStockReturnVHSQuantity(int v)
        {
            try
            {
                string strout = "";
                Stock stockSearch = stock.Find(delegate (Stock _stock)
                {
                    if (_stock.StockIDProp == v)
                    {
                        return true;
                        //strout = (memberSearch.ToString());
                    }
                    return false;
                }); strout = (stockSearch.VHSprop.ToString());
                return strout;
            }
            catch (Exception e)
            {
                throw new Exception(" not found" + e);
            }
        }
        /// <summary>
        /// Method for searching stock to return Game Quantity 
        /// for searched value
        /// Throws an exception if the member can't be found
        /// </summary>
        /// <param name="v">Stock ID value</param>
        /// <returns>Film description for selected film "v"</returns>
        public string SearchStockReturnGameQuantity(int v)
        {
            try
            {
                string strout = "";
                Stock stockSearch = stock.Find(delegate (Stock _stock)
                {
                    if (_stock.StockIDProp == v)
                    {
                        return true;
                        //strout = (memberSearch.ToString());
                    }
                    return false;
                }); strout = (stockSearch.GameQuantProp.ToString());
                return strout;
            }
            catch (Exception e)
            {
                throw new Exception(" not found" + e);
            }
        }
        /// <summary>
        /// Searches the members list for a member matching the value 'v'
        /// Throws an exception if the member can't be found.
        /// </summary>
        /// <param name="v">Member Name</param>
        /// <returns>Member with matching name as 'v'</returns>
        public string searchMembersByFirstName(string v)
        {
            // converting the input to lowercase
            v = v.ToLower();
            try
            {
                string strout = "Search result(s) are: \n";
                List<Member> results = members.FindAll(delegate (Member m) { return m.FirstName.ToLower() == v; });
                foreach (Member m in results)
                {
                    strout = strout + m.ToString() + "\n";
                }
                if (results.Count != 0)
                {
                    return strout;
                }
                else
                { throw new Exception(); }
            }
            catch (Exception)
            {
                string strout = "";
                Member memberSearchName = members.Find(delegate (Member _member) { if (_member.FirstName.ToLower().Contains(v)) { return true; } return false; });
                strout = v + " could not be found, possible match could be: " + (memberSearchName.ToString());
                return strout;
            }
            
            // Old code that only returned single result.
            //v = v.ToLower();
            //try
            //{ 
            //string strout = "";
            //    Member memberSearchName = members.Find(delegate (Member _member) { if (_member.FirstName.ToLower() == v) { return true; } return false; });
            //strout = (memberSearchName.ToString());
            //return strout;
            //}
            //catch (Exception)
            //{
            //    throw new Exception ("Not found");
            //}
        }
		/// <summary>
		/// Method that searches members by ID and returns the
		/// the last name of the member
		/// Throws exception if member can't be found and tries to find a member close to what was searched for.
		/// </summary>
		/// <param name="v">Member ID</param>
		/// <returns>Last name of member</returns>
        public string searchMembersByLastName(string v)
        {
			// converting the input to lowercase
            v = v.ToLower();
            try
            {
                string strout = "Search results are: \n";
                List<Member> results = members.FindAll(delegate (Member m) { return m.LastName.ToLower() == v; });
                foreach (Member m in results)
                {
                    strout = strout + m.ToString() + "\n";
                }
                if (results.Count != 0)
                {
                    return strout;
                }
                else
                { throw new Exception(); }
            }
            catch (Exception)
            {
                string strout = "";
                Member memberSearchName = members.Find(delegate (Member _member) { if (_member.LastName.ToLower().Contains(v)) { return true; } return false; });
                strout = v + " could not be found, possible match could be: " + (memberSearchName.ToString());
                return strout;
            }
        }
        /// <summary>
        /// This search method worked but only if there was one instance of the search value. 
        /// The above method works better and returns multiple occurences of the search value if there are multiple.
        /// </summary>
        /// <param name="v">Last Name To Search</param>
        /// <returns></returns>
        public string searchMembersByLastNameOld(string v)
        {
			// converting the input to lowercase
            v = v.ToLower();
            try
            {
                string strout = "";
                Member memberSearchName = members.Find(delegate (Member _member) { if (_member.LastName.ToLower() == v) { return true; } return false; });
                strout = (memberSearchName.ToString());
                return strout;
            }
            catch (Exception)
            {
                string strout = "";
                Member memberSearchName = members.Find(delegate (Member _member) { if (_member.LastName.ToLower().Contains(v)) { return true; } return false; });
                strout = v + " could not be found, possible match could be: " + (memberSearchName.ToString());
                return strout;
            }
        }
		/// <summary>
		/// Method for searching stock by title and displaying the result in string format
		/// </summary>
		/// <param name="v">Stock title</param>
		/// <returns>Relevant stock item for entered title</returns>
        public string searchStock(string v)
        {
            v = v.ToLower();
            try
            {
                string strout = "";
                Stock stockSearch = stock.Find(delegate (Stock _stock) { if (_stock.Title.ToLower() == v) { return true; } return false; });
                strout = (stockSearch.ToString());
                return strout;
            }
            catch (Exception)
            {
                string strout = "";
                Stock stockSearch = stock.Find(delegate (Stock _stock) { if (_stock.Title.ToLower().Contains(v)) { return true; } return false; });
                strout = v + " could not be found, possible stock could be: \n" + (stockSearch.ToString());
                return strout;
            }
        }
		/// <summary>
		/// Method for populating the library with stock and members.
		/// </summary>
        public void populate()
        {
            library.addMember("David", "Fagan", "0123456789", "12 The Street", "Townish", "ML11BC");
            library.addMember("John", "Fagan", "0777848767", "13 The Street", "Townish", "ML11BC");
            library.addMember("Bart", "Simpson", "0777777122", "742 Evergreen Terrace", "Springfield", "SI00MP");
            library.addMember("Bruce", "Wayne", "0123456789", "Wayne Manor", "Gotham", "GO00TH");
            library.addMember("Peter", "Griffin", "0123456789", "Spooner Street", "Quahog", "FA99ML");
            library.addMember("Jeremey", "Clarkson", "0123456789", "Top Gear", "London", "ML11BC");
            library.addMember("Tony", "Soprano", "0123456789", "Stag Trail Road", "North Caldwell", "N3WJ3R");
            library.addFilm("Batman", "Action", 10, 2, "12", 5, "Warner Bros", "1990", "A film about a man who is a bat");
            library.addFilm("Spiderman", "Action", 20, 1, "PG", 15, "Marvel", "2000", "A film about a man who acts like a spider");
            library.addFilm("Antman", "Kids", 100, 0, "PG", 10, "Marvel", "2010", "A film about a man who acts like an ant");
            library.addGame("FIFA", 2, "PS4", "PG", 40, "EA Games", "2017", "Football game");
        }
		/// <summary>
		/// Initial datafile save method
		/// Since been moved into it's own class but left for testing purposes.
		/// </summary>
        public void createDataFile()
        {
            // Gain code access to the file that we are going
            // to write to
            try
            {
                // Create a FileStream that will write data to file.
                FileStream writerFileStream = new FileStream(DATA_FILENAME, FileMode.Create, FileAccess.Write);
                // Save stock to file
                // havent tested adding members yet
                this.formatter.Serialize(writerFileStream, this.stock);
                this.formatter.Serialize(writerFileStream, this.members);
                //Close the writerFileStream when we are done.
               writerFileStream.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Unable to save our friends' information" + e);
            } // end try-catch
        }
		/// <summary>
		/// Initial datafile load method
		/// Since been moved to it's own datafile class
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
                    this.stock = (List<Stock>)
                        this.formatter.Deserialize(readerFileStream);
                    this.members = (List<Member>)
                        this.formatter.Deserialize(readerFileStream);
                    // Close the readerFileStream when we are done
                    readerFileStream.Close();
                }
                catch (Exception)
                {
                    throw new Exception("Exception text");
                } // end try-catch
            } // end if
        }
		/// <summary>
		/// Method for printing stock and members to a txt file
		/// </summary>
		public void printStock()
        {
            if (File.Exists(FILE_NAME))
            {
                using (StreamWriter sw = File.AppendText(FILE_NAME))
                {
                    // Add some text to the file.
                    sw.WriteLine("");
                    sw.Write("This is the Stock");
                    sw.WriteLine("header for the file.");
                    sw.WriteLine("-------------------");
                    // Arbitrary objects can also be written to the file.
                    sw.Write("This file was amended on : ");
                    sw.WriteLine(DateTime.Now);
                    sw.WriteLine("All stock is:");
                    sw.WriteLine(getStock());
                    sw.WriteLine("Game stock is: \n");
                    sw.WriteLine(getGames());
                    sw.WriteLine("Film stock is: \n");
                    sw.WriteLine(getFilms());
                    sw.WriteLine("Members are: " + getMembers());
                    sw.Close();
                }
            }
            else
            {
                // Create an instance of StreamWriter to write text to a file.
                // The using statement also closes the StreamWriter.
                using (StreamWriter sw = new StreamWriter("dummyprinter.txt"))
                {
                    // Add some text to the file.
                    sw.Write("This is the Stock");
                    sw.WriteLine("header for the file.");
                    sw.WriteLine("-------------------");
                    // Arbitrary objects can also be written to the file.
                    sw.Write("The date is: ");
                    sw.WriteLine(DateTime.Now);
                    sw.WriteLine("All stock is: ");
                    sw.WriteLine(getStock());
                    sw.WriteLine("Game stock is: \n");
                    sw.WriteLine(getGames());
                    sw.WriteLine("Film stock is: \n");
                    sw.WriteLine(getFilms());
                }
            }
        }
		/// <summary>
		/// Property storing array with items displayed in the search bar combo box. 
		/// </summary>
		public string[] SearchBarSelect
        {
            get { return searchBarSelect; }
        }
		/// <summary>
		/// Method that works along side removing a member.
		/// When the member is removed this method alters the member ID(s) in accordance
		/// </summary>
		/// <param name="removing"></param>
		/// <param name="tobechanged"></param>
		/// <param name="count"></param>
		/// <returns></returns>
		public int unitTestChangeID(int removing, int tobechanged, int count)
		{
			int i;
			int result = 0;
			if (removing > 0 && removing <= count)
			{
				for (i = removing; i <= count; i++)
				{
					result = i;
					stock.Find(s => s.StockIDProp >= i).StockIDProp = result;
				};
			}
			else if (tobechanged > count)
			{
				throw new Exception("Not enough values left to remove");
			}
			else
			{
				for (i = removing; i < count; i++)
				{
					result = i + 1;
					stock.Find(s => s.StockIDProp >= i + 1).StockIDProp = result;
				}
			}
			return result;
		}
		/// <summary>
		/// Method for removing member with ID 'v'
		/// Once removes it uses the above method to change the member ID's
		/// </summary>
		/// <param name="v">Member ID</param>
		public void unitTestRemove2(int v)
		{
			int found;
			int count;
			found = stock.Find(s => s.StockIDProp == v + 1).StockIDProp;
			stock.RemoveAt(v);
			count = stock.Count;
			unitTestChangeID(v, found, count);
		}
		/// <summary>
		/// Method for returning a bool if a member surname is found
		/// Method not used but kept for future reference.
		/// </summary>
		/// <param name="m">Member List</param>
		/// <param name="v">Member Last Name</param>
		/// <returns></returns>
        private static bool FindLastName(Member m, string v)
        {
            if (m.LastName == v)
            {
                return true;
            }
            else { return false; }
        }

        //private GradedUnitWPF.LoginWindow login = new GradedUnitWPF.LoginWindow();
        //public string getStaff()
        //{
        //    return login.StaffName;
        //}

		/// <summary>
		/// Method for displaying more information on the stock displayed.
		/// </summary>
		/// <returns>Detailed info on the stock held</returns>
        public string moreInfo()
        {
            bool b = true;
            string strout = "";
            foreach (Stock k in stock)
            {
                k.detailedInfo(b);
                strout = strout  + k.ToString() + "\n";
            }
            return strout;
        }
		/// <summary>
		/// Method for removing the detailed information and displaying
		/// the stock info in simplier terms
		/// </summary>
		/// <returns></returns>
        public string noMoreInfo()
        {
            bool b = false;
            string strout = "";
            foreach (Stock n in stock)
            {
                n.detailedInfo(b);
                strout = strout + n.ToString() + "\n";
            }
            return strout;
        }
        /// <summary>
        /// Method for storing only the stock that is rented out
        /// Making it easier to display in the rental window
        /// </summary>
        /// <returns>A list of stock on rent</returns>
        public List<Stock> collectionOfStockRentedOut()
        {
            List<Stock> stockOnRent = new List<Stock>();
            foreach (Stock s in stock)
            {
                if (s.StockMemberProp != null)
                {
                    stockOnRent.Add(s);
                }
            }
            return stockOnRent;
        }
	}// end of class
}
