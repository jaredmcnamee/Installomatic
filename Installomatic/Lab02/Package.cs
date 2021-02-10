//Project : Intsall-o-Matic
//Nov 03 2019
//by Jared McNamee
//
//Package Class Definition
// ///////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    //*******************************************************************************************************
    //Package Class - The name and a list of dependencies for a package to be installed,
    //implements equals for matching names of packages, Icomparable support for sorting class in collections
    //*******************************************************************************************************
    public class Package : IComparable
    {
        public string Name { get; set; } //string that is the name of the package being installed
        private List<string> _dependencies = new List<string>(); //list of strings that are the dependencies required to install the package

        //returns the number of depencies in the package
        public int Count 
        {
            get
            {
                return _dependencies.Count;
            }
        }
        //returns a user friendly concatonated string showing the dependencies required for package install
        //separated by fancy little commas
        public string Dependencies 
        {
            get
            {
                string concat;
                if (_dependencies.Count == 0)
                    concat = "<none>";
                else
                {
                    concat = string.Join(", ", _dependencies);
                }
                return concat;
            }
        }

        /// <summary>
        /// Constructs the package from a array of strings
        /// index 0 of the string will always be the name of the package
        /// </summary>
        /// <param name="arrString">The string data that will be made into a package</param>
        public Package(string[] arrString)
        {
            Name = arrString[0];
                        
            for(int s = 1; s < arrString.Length; s++)
            {
                //preventing duplicate dependencies in the package
                if(!(_dependencies.Contains(arrString[s])))
                {
                    _dependencies.Add(arrString[s]);
                }
            }
            
        }

        /// <summary>
        /// A constructor used specifically in the library or Binary Search install algorithms
        /// </summary>
        /// <param name="inName"> the name of the package</param>
        public Package(string inName)
        {
            Name = inName;
            _dependencies = null;
        }

        /// <summary>
        /// equality is based entirely on the packages names matching
        /// </summary>
        /// <param name="obj">argument to evaluate</param>
        /// <returns>true if the name of the packages matches</returns>
        public override bool Equals(object obj)
        {
            //if not a package then not equal
            if (!(obj is Package arg)) return false;

            //leveraging equals to see if the names match
            return Name.Equals(arg.Name);
        }

        /// <summary>
        /// No hashing value, supplied to suppress warnings
        /// </summary>
        /// <returns>1 always</returns>
        public override int GetHashCode()
        {
            return 1;
        }

        /// <summary>
        /// Overriding the default compare to, to sort by the Packages Name
        /// </summary>
        /// <param name="obj">object being evaluated</param>
        /// <returns>0 if the names are equal, -1 if comparing object is less than argument, 1 if comparing object is larger than argument </returns>
        public int CompareTo(object obj)
        {
            //if not a package throwing an exception
            if (!(obj is Package arg))
                throw new ArgumentException("Not a valid Package, or null"); // thats what she said
            return Name.CompareTo(arg.Name);
        }

        /// <summary>
        /// addition IComparable compliant method for sorting by dependencies within Names
        /// </summary>
        /// <param name="arg1"> the comparing object</param>
        /// <param name="arg2"> the argument for CompareTo</param>
        /// <returns>0 if the args are equal, -1 if arg1 is less than arg2, 1 if arg1 is larger than arg2 </returns>
        public static int CompareDwName(Package arg1, Package arg2)
        {
            //if both are null returning equal
            if (arg1 == null && arg2 == null) return 0;
            //if arg1 is null returning that it is less than arg2
            if (arg1 == null) return -1;
            //if arg2 is null returning that arg1 is greater than arg2
            if (arg2 == null) return 1;

            //if when compared the names are equal
            if (arg1.Name.CompareTo(arg2.Name) == 0)
                //sorting by dependencies
                return arg1.Dependencies.CompareTo(arg2.Dependencies);
            else
                //otherwise just ordering by name
                return arg1.Name.CompareTo(arg2.Name);
        }

        /// <summary>
        /// addition IComparable compliant method for sorting by Names within dependencies
        /// </summary>
        /// <param name="arg1">the comparing object</param>
        /// <param name="arg2">the argument for CompareTo</param>
        /// <returns>0 if the args are equal, -1 if arg1 is less than arg2, 1 if arg1 is larger than arg2 </returns>
        public static int CompareNwDepdency(Package arg1, Package arg2)
        {
            //if both are null returning equal
            if (arg1 == null && arg2 == null) return 0;
            //if arg1 is null returning that it is less than arg2
            if (arg1 == null) return -1;
            //if arg2 is null returning that arg1 is greater than arg2
            if (arg2 == null) return 1;

            //if when compared the dependencies are equal
            if (arg1.Dependencies.CompareTo(arg2.Dependencies) == 0)
                //sorting by name
                return arg1.Name.CompareTo(arg2.Name);
            else
                //otherwise just ordering by dependencies 
                return arg1.Dependencies.CompareTo(arg2.Dependencies);
        }

        /// <summary>
        /// helper function for grabbing the dependencies of a package to a list of strings
        /// </summary>
        /// <returns>a list of strings representing the dependencies of a package</returns>
        public List<string> GetDepends()
        {
            List<string> rdepends = _dependencies.ToList<string>();
            return rdepends;
        }

        /// <summary>
        /// Merging two packages together while not allowing duplicates
        /// </summary>
        /// <param name="arg"> the package to be merged with</param>
        public void MergePackage(Package arg)
        {
            //if the names of the two packages do not match throwing an exception
            if(!(Name.Equals(arg.Name)))
            {
             
                throw new ArgumentException("Name of file is not Equal!");
            }
            this._dependencies.Union(arg._dependencies);
        }

        
    }
}
