// Lam Nguyen
// Assignment 2: Part 1
using System;

namespace Assignment2_Array {

    class IntegerSet {
        /* Array of bools */
        private bool[] _inputSet;

        /* Contructor receive an array of integer values */
        public IntegerSet(int[] numberSet) {
            _inputSet = new bool[101];
            for (int i = 0; i < numberSet.Length; i++) {
                if (numberSet[i] >= 0 && numberSet[i] < 101) {
                    InsertElement(numberSet[i]);
                }
            }
        }

        /* Parameterless constructor initializes the array to the “empty set” */
        public IntegerSet() {
            _inputSet = new bool[101];
        }

        /* Creates a third set that is the set-theoretic union of two existing sets
         (i.e., an element of the third set’s array is set to true if that element is true in either or both of the existing sets—
         otherwise, the element of the third set is set to false). */
        public IntegerSet Union(IntegerSet set2) {

            IntegerSet set3 = new IntegerSet();
            for (int i = 0; i < _inputSet.Length; i++) {
                Boolean flag = this._inputSet[i];
                if (flag == true || set2._inputSet[i] == true) {
                    set3._inputSet[i] = true;
                }

            }
            return set3;
        }

        /* Creates a third set which is the set-theoretic intersection of two existing sets */
        public IntegerSet Intersection(IntegerSet set2) {
            IntegerSet set3 = new IntegerSet();
            for (int i = 0; i < _inputSet.Length; i++) {
                bool flag = this._inputSet[i];
                if (flag == true && set2._inputSet[i] == true) {
                    set3._inputSet[i] = true;
                }

            }
            return set3;
        }

        /* Inserts a new integer k into a set (by setting a[k] to true) */
        public void InsertElement(int number) {
            if (number >= 0 && number < 101) {
                this._inputSet[number] = true;
            }
        }

        /* Deletes integer m (by setting a[m] to false) */
        public void DeleteElement(int number) {
            if (number >= 0 && number < 101) {
                this._inputSet[number] = false;
            }
        }

        /* Returns a string containing a set as a list of numbers separated by spaces.
         Include only those elements that are present in the set. Use --- to represent an empty set. */

        public String ToString() {
            string str = "";
            bool hasElement = false;
            for (int i = 1; i < _inputSet.Length; i++) {
                if (_inputSet[i] == true) {
                    str += i + " ";
                    hasElement = true;
                }
            }
            if (hasElement == false) {
                str = "";
                str = "---";
            }
            return str;
        }

        /* Determines whether two sets are equal */
        public bool IsEqualTo(IntegerSet set) {
            for (int i = 0; i < 101; i++) {
                if (this._inputSet[i] != set._inputSet[i]) {
                    return false;
                }
            }
            return true;
        }
    }
    /* Main program */
    class Program {
        static void Main(string[] args) {
            // initialize two sets
            Console.WriteLine("Input Set A");
            IntegerSet set1 = InputSet();
            Console.WriteLine("\nInput Set B");
            IntegerSet set2 = InputSet();

            IntegerSet union = set1.Union(set2);
            IntegerSet intersection = set1.Intersection(set2);

            // prepare output
            Console.WriteLine("\nSet A contains elements:");
            Console.WriteLine(set1.ToString());
            Console.WriteLine("\nSet B contains elements:");
            Console.WriteLine(set2.ToString());
            Console.WriteLine(
            "\nUnion of Set A and Set B contains elements:");
            Console.WriteLine(union.ToString());
            Console.WriteLine(
            "\nIntersection of Set A and Set B contains elements:");
            Console.WriteLine(intersection.ToString());

            // test whether two sets are equal
            if (set1.IsEqualTo(set2))
                Console.WriteLine("\nSet A is equal to set B");
            else
                Console.WriteLine("\nSet A is not equal to set B");

            // test insert and delete
            Console.WriteLine("\nInserting 77 into set A...");
            set1.InsertElement(77);
            Console.WriteLine("\nSet A now contains elements:");
            Console.WriteLine(set1.ToString());

            Console.WriteLine("\nDeleting 77 from set A...");
            set1.DeleteElement(77);
            Console.WriteLine("\nSet A now contains elements:");
            Console.WriteLine(set1.ToString());

            // test constructor
            int[] intArray = { 25, 67, 2, 9, 99, 105, 45, -5, 100, 1 };
            IntegerSet set3 = new IntegerSet(intArray);

            Console.WriteLine("\nNew Set contains elements:");
            Console.WriteLine(set3.ToString());
        }

        /* Method to generate a random boolean array and return a IntegerSet object */
        public static IntegerSet InputSet() {
            int[] inputSet = new int[101];
            int input = 0;

            for (int i = 0; i < inputSet.Length; i++) {
                Console.WriteLine("Please enter a number from 0 to 100 or enter any negative number to exit: ");
                input = Convert.ToInt32(Console.ReadLine());
                if (input < 0) {
                    break;
                }
                if (input > -1 && input < 101) {
                    inputSet[i] = input;
                }
            }
            IntegerSet randomSet = new IntegerSet(inputSet);
            return randomSet;
        }
    }
}
