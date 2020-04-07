using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicInterfaces
{
    interface IStorable //uses interface keyword - two methods. save and load. Boolean property too. There is no implementation code. No keywords like public or private. Like defining methods in class. designed to expose functionality to other classes so contents implicitly public. No code in interface definition. 
    {
        void Save();
        void Load();
        Boolean NeedsSave { get; set; }
    }
    
    interface IEncryptable
    {
        void Encrypt();
        void Decrypt();
    }

    class Document : IStorable, IEncryptable 
    {
        private string name; //member variable
        private Boolean mNeedsSave = false;

        public Document(string s) {
            name = s;
            Console.WriteLine("Created a document with name '{0}'", s);
        }
        
        public void Save() {
            Console.WriteLine("Saving the document");
        }

        public void Load() {
            Console.WriteLine("Loading the document");
        }
        
        public void Encrypt() {
            Console.WriteLine("Encrypting the document");
        }

        public void Decrypt() {
            Console.WriteLine("Decrypting the document");
        }
        
        public Boolean NeedsSave {
            get { return mNeedsSave;  }
            set { mNeedsSave = value; }
        }
    }

    class Program
    {
        static void Main(string[] args) {
            Document d = new Document("Test Document");
            
            //calling two interfaces
            d.Load();
            d.Encrypt();
            d.Save();
            d.Decrypt();
            d.NeedsSave = false;
            
            
            //Casting useful to set out distinct cases of behaviour and implementing methods based on it. 
            // Use the 'is' operator - test if document is istorable
            // if (d is IStorable) {
            //     d.Save();
            // }
            //
            // // Use the 'as' operator
            // IStorable intStor = d as IStorable;
            // if (intStor != null) {
            //     d.Load();
            // }
            
            // d.Load();
            // d.Save();
            // d.NeedsSave = false;


            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
            
        }
    }
}