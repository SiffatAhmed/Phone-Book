using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ApplicationLayerPhoneBook
{
    class FileHandlingPhoneBook
    {
        //Creating a list
        private List<PhoneBook> phoneBooksList = new List<PhoneBook>();

        //default constructor
        public FileHandlingPhoneBook()
        {
        }

        //properties
        internal List<PhoneBook> PhoneBooks
        {
            get => phoneBooksList;
            set => phoneBooksList = value;
        }

        //read all records
        public List<PhoneBook> ReadAllRecords()
        {
            StreamReader reader = new StreamReader("PhoneBook.txt");
            while (!reader.EndOfStream)
            {
                if (reader.ReadLine().ToString() == "\n")
                {
                    reader.ReadLine().ToString().Trim('\n');
                }
                else
                {
                    PhoneBook phoneBook = new PhoneBook();
                    phoneBook.Name = reader.ReadLine();
                    phoneBook.Number = reader.ReadLine();
                    phoneBook.Email = reader.ReadLine();
                    phoneBook.Address = reader.ReadLine();

                    phoneBooksList.Add(phoneBook);
                }
            }
            reader.Close();
            return phoneBooksList;
        }

        // Store all records to file
        public void StoreAllRecordsBackToPhoneBookFile()
        {
            StreamWriter PhoneBookFileWriter = new StreamWriter("PhoneBook.txt");
            foreach (PhoneBook data in phoneBooksList)
            {
                PhoneBookFileWriter.WriteLine();
                PhoneBookFileWriter.WriteLine(data.Name);
                PhoneBookFileWriter.WriteLine(data.Number);
                PhoneBookFileWriter.WriteLine(data.Email);
                PhoneBookFileWriter.WriteLine(data.Address);
            }
            PhoneBookFileWriter.Close();
        }

        //Add record to list
        public void AddRecord(PhoneBook phoneBook)
        {
            phoneBooksList.Add(phoneBook);
        }

        //Search Records from list
        public PhoneBook SearchRecord(string name)
        {
            bool isFound = false;
            int indexOfRecord = -1;
            PhoneBook phoneBook = new PhoneBook();
            for (int index = 0; index < phoneBooksList.Count; index++)
            {
                phoneBook = phoneBooksList[index] as PhoneBook;
                if (phoneBook.Name == name)
                {
                    isFound = true;
                    indexOfRecord = index;
                    break;
                }
            }
            if (isFound)
            {
                return phoneBook;
            }
            else
            {
                phoneBook.Name = "Not Found";
                phoneBook.Number = "Not Found";
                phoneBook.Email = "Not Found";
                phoneBook.Address = "Not Found";
                return phoneBook;
            }
        }

        //Delete Records From List
        public List<PhoneBook> DeleteRecord(string name)
        {
            bool isFound = false;
            int indexOfRecord = -1;
            for (int i = 0; i < phoneBooksList.Count; i++)
            {
                if (phoneBooksList[i].Name == name)
                {
                    isFound = true;
                    indexOfRecord = i;
                    break;
                }
            }
            if (isFound)
            {
                phoneBooksList.RemoveAt(indexOfRecord);
                return phoneBooksList;
            }
            else
            {
                return phoneBooksList;
            }
        }

        // store to file
        public void WritebackRecords()
        {
            this.StoreAllRecordsBackToPhoneBookFile();
        }
    }
}